#!/usr/bin/python

import SocketServer
import logging
import urlparse
import os         # makedirs
import datetime   # datetime.now()

# command line args
#

from optparse import OptionParser
cmdparser = OptionParser()
cmdparser.add_option ( "-d", "--debug", dest="forcedebug",
                       help="Use debug level of logging, regardless of config file setting", action="store_true", default=None )

(cmdoptions, cmdargs) = cmdparser.parse_args()

# set up hardcoded path, then use it to pull in defaults and add more paths
#

import sys
sys.path.append ( './bandit-lib' )

import defaults   # default settings
import state

import ConfigParser
config = ConfigParser.SafeConfigParser()
config.read ( defaults.server_config_fullpath )
print "Config path:", defaults.server_config_fullpath

if config.has_section ( 'PyPath' ):
    for p in config.items ( 'PyPath' ):
        sys.path.append ( p [ 0 ] )
        print "Python module path - adding '", p [ 0 ], "'"
else:
    print "WARN: Config is missing [PyPath] section"

# set up logging
#
loglevel = getattr ( logging, config.get ( 'Logging', 'level' ).upper() )

if cmdoptions.forcedebug == True:
    loglevel = logging.DEBUG

logging.basicConfig ( filename = config.get ( 'Logging', 'fullpath' ), level=loglevel,
                      format='%(asctime)s\t%(levelname)s\t%(message)s', datefmt='%m/%d/%Y %I:%M:%S %p' )

#
# actually start doing something thats application specific..
#

# figure out where we're running
#
if config.has_section ( 'WhereAmI' ):
    state.server_host = config.get ( 'WhereAmI', 'hostname' )
    state.server_port = config.getint ( 'WhereAmI', 'port' )
else:
    logging.error ( "Config is missing [WhereAmI] section!" )
    sys.exit ( -1 )

# set up routing table
#

if not config.has_section ( 'Routing' ):
    logging.error ( "config is missing Routing section; giving up." )
    sys.exit ( -1 )

state.routing_default = config.get ( 'Routing', 'DEFAULT' )

routes = []
for pair in config.items ( 'Routing' ):
    routes.append ( pair )

# open up webserver
#
logging.info ( "c4a is starting up" )

import os
import posixpath
import urllib
import BaseHTTPServer
from SimpleHTTPServer import SimpleHTTPRequestHandler

class RequestHandler(SimpleHTTPRequestHandler):
    
    def do_PUT ( self ):
        #logging.debug ( "vars: %s" % ( vars ( self ) ) )

        length = int ( self.headers['Content-Length'] )

        paths = self.path.split ( "/", 6 )
        req = dict()
        # nil = paths [ 0 ]
        # basepage and ver == paths [ 1 ]
        req [ 'gamename' ] = paths [ 2 ]
        req [ 'platform' ] = paths [ 3 ]
        req [ 'emuname' ] = paths [ 4 ]
        req [ 'prid' ] = paths [ 5 ]
        # etc == paths [ 6 ]

        basepage, basepage_ver = paths [ 1 ].split ( '_', 2 )
        req [ 'basepage' ] = basepage
        req [ 'ver' ] = basepage_ver

        logging.debug ( "request looks like %s" % ( req ) )

        if basepage == 'setprofile':

            logging.warning ( "VALIDATE INPUTS HERE" )

            self.send_response ( 406 ) # not acceptible
            return

        elif basepage == 'tally':

            logging.warning ( "VALIDATE INPUTS HERE" )

            if req [ 'gamename' ] not in ( 'mspacman', 'sf2', 'dkong' ):
                self.send_response ( 406 ) # not acceptible
                return

            raw_data = self.rfile.read ( length )

            now = datetime.datetime.now()

            writepath = "runtime/hidb/" + req [ 'gamename' ] + "/" + str(now.year) + "." + str('%02d'%now.month) + "/"
            try:
                os.makedirs ( writepath )
            except:
                pass

            f = open ( writepath + "raw.hi", "w" )
            f.write ( raw_data )
            f.close()

            self.send_response ( 200 ) # okay

        else:
            self.send_response ( 406 ) # not acceptible
            return

        """
        post_data = urlparse.parse_qs ( self.rfile.read(length).decode('utf-8') )
        for key, value in post_data.iteritems():
            logging.debug ( "%s=%s" % (key, value) )
        """

        #logging.debug ( "received %s" % ( raw_data ) )

    def translate_path ( self, path ):
        """translate path given routes"""

        original_path = path

        # set default root to cwd
        root = os.getcwd()
        
        # look up routes and set root directory accordingly
        found = False
        for pattern, rootdir in routes:
            if path.startswith(pattern):
                # found match!
                path = path[len(pattern):]  # consume path up to pattern len
                root = rootdir
                found = True
                break
        if found == False:
            logging.warning ( "Routing request %s to default %s" % ( original_path, state.routing_default ) )
            return state.routing_default

        # normalize path and prepend root directory
        path = path.split('?',1)[0]
        path = path.split('#',1)[0]
        path = posixpath.normpath(urllib.unquote(path))
        words = path.split('/')
        words = filter(None, words)
        
        path = root
        for word in words:
            drive, word = os.path.splitdrive(word)
            head, word = os.path.split(word)
            if word in (os.curdir, os.pardir):
                continue
            path = os.path.join(path, word)

        logging.info ( 'Mapped GET path %s to path %s' % ( original_path, path ) )

        return path

server_address = ('', state.server_port)
RequestHandler.protocol_version = "HTTP/1.0"
httpd = BaseHTTPServer.HTTPServer ( server_address, RequestHandler )
sa = httpd.socket.getsockname()
logging.info ( "Serving HTTP on " + str(sa[0]) + " port " + str(sa[1]) + "..." )
httpd.serve_forever()

# finish!
#
logging.info ( "c4a is quiting; exeunt with alarums" )
