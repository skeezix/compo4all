#!/usr/bin/python

import SocketServer
import logging
import urlparse
import os         # makedirs
import json
import string
import datetime

import dates
import profile
import httpparse

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

state.config = config

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

# set up module handlers
#

import modulemap
import activity_log

# open up webserver
#
logging.info ( "c4a is starting up" )

import os
import posixpath
import urllib
import BaseHTTPServer
from SimpleHTTPServer import SimpleHTTPRequestHandler

class RequestHandler(SimpleHTTPRequestHandler):
    
    def is_valid_game ( self, req ):

        if req [ 'gamename' ] not in modulemap.gamemap:
            return False

        return True

    def do_GET( self ):
        #logging.debug ( "do_GET vars: %s" % ( vars ( self ) ) )
        logging.debug ( "GET against path '%s'" % ( self.path ) )

        # parse out ?key=value sillyness
        if '?' in self.path:
            try:
                self.path, crap = self.path.split ( '&', 2 )
            except:
                pass
            self.path, query = self.path.split ( '?', 2 )
            self._query = dict()
            key, value = query.split ( '=', 2 )
            self._query [ key ] = value

        # do we have a JSONP request?
        jsonp_pre = ''
        jsonp_post = ''
        try:
            if 'jsonp' in self._query:
                jsonp_pre = self._query [ 'jsonp' ] + '('
                jsonp_post = ');'
        except:
            pass

        req = dict()

        try:
            paths = self.path.split ( "/", 6 )

            try:
                basepage, basepage_ver = paths [ 1 ].split ( '_', 2 )
                req [ 'ver' ] = basepage_ver
            except:
                logging.debug ( "Missing _ver: vars: %s" % ( vars ( self ) ) )
                basepage = paths [ 1 ]
            req [ 'basepage' ] = basepage
            req [ 'gamename' ] = paths [ 2 ]

        except:

            try:
                basepage, basepage_ver = paths [ 1 ].split ( '_', 2 )
                req [ 'ver' ] = basepage_ver
            except:
                logging.debug ( "Missing _ver: vars: %s" % ( vars ( self ) ) )
                basepage = paths [ 1 ]
            req [ 'basepage' ] = basepage

        logging.debug ( "request looks like GET %s" % ( req ) )

        if not self.is_valid_request ( req ):
            self.send_response ( 406 ) # not acceptible

        if req [ 'basepage' ] == 'banner':
            d = dict()

            f = open ( "runtime/banner/banner.txt", 'r' )
            text = f.read()
            f.close()

            d [ 'banner' ] = text

            bindata = json.dumps ( d )

            self.send_response ( 200 ) # okay; the following is the right header sequence
            self.send_header ( 'Content-type', 'application/json; charset=utf-8' )
            self.send_header ( 'Content-length', len ( bindata ) )
            self.end_headers()

            self.wfile.write ( bindata )

        elif req [ 'basepage' ] == 'ohai':

            d = dict()
            d [ 'status' ] = 'OK'
            bindata = json.dumps ( d )

            self.send_response ( 200 ) # okay; the following is the right header sequence
            self.send_header ( 'Content-type', 'application/json; charset=utf-8' )
            self.send_header ( 'Content-length', len ( bindata ) )
            self.end_headers()

            self.wfile.write ( bindata )

        elif req [ 'basepage' ] == 'links':

            now = datetime.datetime.now()
            lastmonth =  dates.subtract_one_month ( now )

            html = ''
            html += '<table>\n'
            html += '  <tr>\n'
            html += '    <td style="padding:0 15px 0 15px;"><b>Game</b></td>\n'
            html += '    <td style="padding:0 15px 0 15px;"><b>Last Month</b></td>\n'
            html += '    <td style="padding:0 15px 0 15px;"><b>Current Month So Far</b></td>\n'
            html += '    <td style="padding:0 15px 0 15px;"><b>All Time</b></td>\n'
            html += '  </tr>\n'

            for k,mm in modulemap.gamemap.iteritems():
                if mm [ 'status' ] in ( 'available', 'active' ):

                    html += '  <tr>\n'
                    html += '    <td style="padding:0 15px 0 15px;">%s</td>\n' % ( mm [ 'longname' ] )
                    html += '    <td style="padding:0 15px 0 15px;"><a href="%s">here</a></td>\n' % ( config.get ( 'WhereAmI', 'displayhost' ) + 'scoreboard_1/' + mm [ 'gamename' ] + '/' + str(lastmonth.year) + str('%02d'%lastmonth.month) + '/' )
                    html += '    <td style="padding:0 15px 0 15px;"><a href="%s">here</a></td>\n' % ( config.get ( 'WhereAmI', 'displayhost' ) + 'scoreboard_1/' + mm [ 'gamename' ] + '/' )
                    html += '    <td style="padding:0 15px 0 15px;"><a href="%s">here</a></td>\n' % ( config.get ( 'WhereAmI', 'displayhost' ) + 'scoreboard_1/' + mm [ 'gamename' ] + '/ALL' )
                    html += '  </tr>\n'

            self.send_response ( 200 ) # okay; the following is the right header sequence
            self.send_header ( 'Content-type', 'text/html; charset=utf-8' )
            self.send_header ( 'Content-length', len ( html ) )
            self.end_headers()

            self.wfile.write ( html )

        elif req [ 'basepage' ] == 'curgamelist':
            gl = list()

            for k,mm in modulemap.gamemap.iteritems():

                if mm [ 'status' ] in ( 'available', 'active' ):
                    req = dict()
                    req [ 'gamename' ] = mm [ 'gamename' ]
                    req [ 'longname' ] = mm [ 'longname' ]
                    req [ 'status' ] = mm [ 'status' ]
                    req [ '_last_tally_update_e' ] = mm [ '_last_tally_update_e' ]

                    t = mm [ 'handler' ]._read_tally ( req )
                    try:
                        req [ '_top_score' ] = t [ 'hi' ]
                        pridfile = profile.fetch_pridfile_as_dict ( t [ 'prid' ] )
                        req [ '_top_shortname' ] = pridfile [ 'shortname' ]
                        req [ '_top_longname' ] = pridfile [ 'longname' ]
                    except:
                        req [ '_top_score' ] = 0
                        req [ '_top_shortname' ] = ''
                        req [ '_top_longname' ] = ''

                    gl.append ( req )

            d = dict()
            d [ 'gamelist' ] = gl

            bindata = jsonp_pre + json.dumps ( d ) + jsonp_post

            self.send_response ( 200 ) # okay; the following is the right header sequence
            self.send_header ( 'Access-Control-Allow-Origin', '*' ) # milkshake: http://enable-cors.org/
            self.send_header ( 'Content-type', 'application/json; charset=utf-8' )
            self.send_header ( 'Content-length', len ( bindata ) )
            self.end_headers()

            self.wfile.write ( bindata )

        elif req [ 'basepage' ] == 'json':

            if len ( paths ) >= 4 and paths [ 3 ]:
                if paths [ 3 ].isdigit():
                    req [ '_backdate' ] = paths [ 3 ]
                    logging.info ( "Request is backdated; now looks like %s" % ( req ) )
                else:
                    req [ '_backdate' ] = 'ALLTIM'
                    logging.info ( "Request is for all-time; now looks like %s" % ( req ) )

            if not self.is_valid_game ( req ):
                self.send_response ( 406 ) # not acceptible
                return

            if req [ 'gamename' ] in modulemap.gamemap:
                self.send_response ( 200 ) # okay; the following is the right header sequence
                self.send_header ( 'Access-Control-Allow-Origin', '*' ) # milkshake: http://enable-cors.org/
                self.send_header ( 'Content-type', 'application/json; charset=utf-8' )
                self.end_headers()

                modulemap.gamemap [ req [ 'gamename' ] ][ 'handler' ].get_json_tally ( req )
                self.wfile.write ( jsonp_pre + req [ '_bindata' ] + jsonp_post )

            else:
                self.send_response ( 406 ) # not acceptible
                logging.error ( "No module found for game %s" % ( gamename ) )

        elif req [ 'basepage' ] == 'scoreboard':

            if len ( paths ) >= 4 and paths [ 3 ]:
                if paths [ 3 ].isdigit():
                    req [ '_backdate' ] = paths [ 3 ]
                    logging.info ( "Request is backdated; now looks like %s" % ( req ) )
                else:
                    req [ '_backdate' ] = 'ALLTIM'
                    logging.info ( "Request is for all-time; now looks like %s" % ( req ) )

            if not self.is_valid_game ( req ):
                self.send_response ( 406 ) # not acceptible
                return

            if req [ 'gamename' ] in modulemap.gamemap:
                modulemap.gamemap [ req [ 'gamename' ] ][ 'handler' ].get_html_tally ( req )

                self.send_response ( 200 )
                self.send_header ( 'Content-type', 'text/html' )
                self.send_header ( 'Content-length', len ( req [ '_bindata' ] ) )
                self.end_headers()

                self.wfile.write ( req [ '_bindata' ] )
                #self.send_response ( 200 ) # okay
            else:
                self.send_response ( 406 ) # not acceptible
                logging.error ( "No module found for game %s" % ( gamename ) )

        elif req [ 'basepage' ] == 'activity':

            activity_log.get_log_html ( req )

            self.send_response ( 200 )
            self.send_header ( 'Content-type', 'text/html' )
            self.send_header ( 'Content-length', len ( req [ '_bindata' ] ) )
            self.end_headers()

            self.wfile.write ( req [ '_bindata' ] )

        elif req [ 'basepage' ] == 'hi':

            if not self.is_valid_game ( req ):
                self.send_response ( 406 ) # not acceptible
                return

            if req [ 'gamename' ] in modulemap.gamemap:
                modulemap.gamemap [ req [ 'gamename' ] ][ 'handler' ].get_hi ( req )

                self.send_response ( 200 )
                self.send_header ( 'Content-length', req [ '_binlen' ] )
                self.end_headers()

                self.wfile.write ( req [ '_bindata' ] )
            else:
                self.send_response ( 406 ) # not acceptible
                logging.error ( "No module found for game %s" % ( gamename ) )

        else:
            self.send_response ( 406 ) # not acceptible
            return

    def do_PUT ( self ):
        #logging.debug ( "do_PUT vars: %s" % ( vars ( self ) ) )
        logging.debug ( "PUT against path '%s'" % ( self.path ) )

        length = -1

        if 'Content-Length' in self.headers:
            try:
                length = int ( self.headers['Content-Length'] ) & 0xFFFF # why do I need to mask this?
                logging.debug ( "Content-Length header implies length is %s" % ( length ) )
            except:
                logging.debug ( "Couldn't determine Content-Length from header" )

        req = dict()
        try:
            paths = self.path.split ( "/", 6 )

            # nil = paths [ 0 ]
            # basepage and ver == paths [ 1 ]
            req [ 'gamename' ] = paths [ 2 ]
            req [ 'platform' ] = paths [ 3 ]
            req [ 'emuname' ] = paths [ 4 ]
            req [ 'prid' ] = paths [ 5 ]
            # etc == paths [ 6 ]

            try:
                basepage, basepage_ver = paths [ 1 ].split ( '_', 2 )
                req [ 'ver' ] = basepage_ver
            except:
                basepage = paths [ 1 ]
                logging.debug ( "Missing _ver: vars: %s" % ( vars ( self ) ) )
            req [ 'basepage' ] = basepage

        except:

            try:
                basepage, basepage_ver = paths [ 1 ].split ( '_', 2 )
                req [ 'ver' ] = basepage_ver
            except:
                basepage = paths [ 1 ]
                logging.debug ( "Missing _ver: vars: %s" % ( vars ( self ) ) )

            req [ 'basepage' ] = basepage

        logging.debug ( "request looks like PUT %s" % ( req ) )

        if not self.is_valid_request ( req ):
            self.send_response ( 406 ) # not acceptible

        if req [ 'basepage' ] == 'setprofile':
            req [ '_bindata' ] = self.rfile.read ( length )
            req [ '_binlen' ] = length

            prid = json.loads ( req [ '_bindata' ] )

            if not self.is_valid_request ( prid ):
                self.send_response ( 406 ) # not acceptible

            f = open ( "runtime/profiles/" + prid [ 'prid' ] + ".json", 'w' )
            f.write ( req [ '_bindata' ] )
            f.close()

            self.send_response ( 200 ) # okay

        elif req [ 'basepage' ] == 'delprofile':

            req [ '_bindata' ] = self.rfile.read ( length )
            req [ '_binlen' ] = length

            prid = json.loads ( req [ '_bindata' ] )

            if not self.is_valid_request ( prid ):
                self.send_response ( 406 ) # not acceptible

            os.unlink ( "runtime/profiles/" + prid [ 'prid' ] + ".json" )

            self.send_response ( 200 ) # okay

        elif req [ 'basepage' ] == 'tally':

            if not self.is_valid_game ( req ):
                self.send_response ( 406 ) # not acceptible
                return

            if length > 0:
                req [ '_bindata' ] = self.rfile.read ( length )
                req [ '_binlen' ] = length
            else:
                req [ '_bindata' ] = self.rfile.read() # will likely hang waiting for timeout..
                req [ '_binlen' ] = len ( req [ '_bindata' ] )

            if req [ 'gamename' ] in modulemap.gamemap:
                logging.debug ( "First update_hi - for actual current month" )
                modulemap.gamemap [ req [ 'gamename' ] ][ 'handler' ].update_hi ( req )

                logging.debug ( "Second update_hi - for ALLT.IM" )
                req [ '_backdate' ] = 'ALLTIM'
                modulemap.gamemap [ req [ 'gamename' ] ][ 'handler' ].update_hi ( req )

            else:
                logging.error ( "No module found for game %s" % ( gamename ) )

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

    def is_valid_request ( self, req ):

        if 'prid' in req:
            if not all(c in string.ascii_letters+'-'+string.digits for c in req [ 'prid' ]):
                logging.warning ( "illegal prid from request %s" % ( req ) )
                return False

        if 'shortname' in req:
            if not all(c in string.ascii_letters+string.digits for c in req [ 'shortname' ]):
                logging.warning ( "illegal shortname from request %s" % ( req ) )
                return False

        if 'longname' in req:
            if not all(c in string.ascii_letters+string.digits for c in req [ 'longname' ]):
                logging.warning ( "illegal longname from request %s" % ( req ) )
                return False

        if 'email' in req:
            if not all(c in string.ascii_letters+string.digits+string.punctuation for c in req [ 'email' ]):
                logging.warning ( "illegal email from request %s" % ( req ) )
                return False

        if 'password' in req:
            if not all(c in string.ascii_letters+string.digits for c in req [ 'password' ]):
                logging.warning ( "illegal password from request %s" % ( req ) )
                return False

        if 'emuname' in req:
            if not all(c in string.ascii_letters for c in req [ 'emuname' ]):
                logging.warning ( "illegal emuname from request %s" % ( req ) )
                return False

        if 'platform' in req:
            if not all(c in string.ascii_letters for c in req [ 'platform' ]):
                logging.warning ( "illegal platform from request %s" % ( req ) )
                return False

        if 'gamename' in req:
            if not all(c in string.ascii_letters for c in req [ 'gamename' ]):
                logging.warning ( "illegal gamename from request %s" % ( req ) )
                return False

        if 'basepage' in req:
            if not all(c in string.ascii_letters for c in req [ 'basepage' ]):
                logging.warning ( "illegal basepage from request %s" % ( req ) )
                return False

        if 'ver' in req:
            if not all(c in string.digits for c in req [ 'ver' ]):
                logging.warning ( "illegal ver from request %s" % ( req ) )
                return False

        return True

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

class ThreadingHTTPServer ( SocketServer.ThreadingMixIn, BaseHTTPServer.HTTPServer ):
    # use some mixins to make a threading server.. lets see how this works
    pass

server_address = ('', state.server_port)
RequestHandler.protocol_version = "HTTP/1.0"
httpd = ThreadingHTTPServer ( server_address, RequestHandler )
sa = httpd.socket.getsockname()
logging.info ( "Serving HTTP on " + str(sa[0]) + " port " + str(sa[1]) + "..." )
httpd.serve_forever()

# finish!
#
logging.info ( "c4a is quiting; exeunt with alarums" )
