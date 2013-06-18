#!/usr/bin/python

# Compo4All
# Jeff Mitchell 2013
# skeezix@skeleton.org
# http://c4a.openpandora.org/

# Licenced under GPL v3 as defined: http://www.gnu.org/licenses/gpl-3.0.html

import logging
import tempfile
import shutil
import subprocess
import os
import sys
import pprint

try:
    import state
except:
    # if running standalone, can live without this..
    pass

# monkey patch py2.7's check_output() into py2.6's missing one :)
if "check_output" not in dir( subprocess ): # duck punch it in!
    def f(*popenargs, **kwargs):
        if 'stdout' in kwargs:
            raise ValueError('stdout argument not allowed, it will be overridden.')
        process = subprocess.Popen(stdout=subprocess.PIPE, *popenargs, **kwargs)
        output, unused_err = process.communicate()
        retcode = process.poll()
        if retcode:
            cmd = kwargs.get("args")
            if cmd is None:
                cmd = popenargs[0]
            raise CalledProcessError(retcode, cmd)
        return output
    subprocess.check_output = f

class HiToText:

    # overridepath: if specified, look for .hi file there; if unspecified, look for req [ _bindata ]
    # tdirfullpath: if specified, use this as temp full path; if unspecified, will use config file tempdir set of directives
    # relrunner: if specified will use that to invoke mono/HiToText; if unspecified, will use config
    def __init__ ( self, req, overridepath=None, tdirfullpath=None, relrunner=None ):
        self.req = req

        if tdirfullpath:
            self.tdir = tdirfullpath
        else:
            self.tdir = tempfile.mkdtemp ( dir=state.config.get ( 'HiToText', 'tempdirbase' ), suffix=state.config.get ( 'HiToText', 'tempdirsuffix' ) )

        self.overridepath = overridepath

        self.relrunner = relrunner

        logging.debug ( "HiToText: Instanciating for %s to %s" % ( self.req [ 'gamename' ], self.tdir ) )

    def done ( self, req ):
        shutil.rmtree ( self.tdir, ignore_errors = True )
        logging.debug ( "HiToText: Removing tempdir for %s at %s" % ( self.req [ 'gamename' ], self.tdir ) )

    def analyze ( self ):
        logging.debug ( "HiToText: Creating %s score file at %s" % ( self.req [ 'gamename' ], self.tdir ) )

        if self.overridepath:
            shutil.copy ( self.overridepath, self.tdir )
        else:
            f = open ( self.tdir + '/' + self.req [ 'gamename' ] + '.hi', 'w' )
            f.write ( self.req [ '_bindata' ] )
            f.close()

        testfile = './runtime/plugins/hitotext/' + self.req [ 'gamename' ] + '.test'
        b = None
        if os.path.exists ( testfile ):
            f = open ( testfile, 'r' )
            b = f.read()
            f.close()
        else:
            if self.relrunner:
                command = "cd " + self.tdir + "; " + self.relrunner + ' -r ' + self.req [ 'gamename' ]
            else:
                command = "cd " + self.tdir + "; " + state.config.get ( 'HiToText', 'relrunnerbase' ) + ' -r ' + self.req [ 'gamename' ]
            logging.debug ( "HiToText %s: Query is %s" % ( self.req [ 'gamename' ], command ) )
            b = subprocess.check_output ( command, stderr=subprocess.STDOUT, shell=True )

        # ladybug works out...
        # 1|15970|       A1Z
        # 2|10000| UNIVERSAL
        # 3|10000| UNIVERSAL

        self.rows = list()

        eat = 1
        needpipe = True

        for line in b.split ( '\n' ):

            if eat > 0:
                logging.debug ( "HiToText %s: Ignored line (eaten) %s" % ( self.req [ 'gamename' ], line ) )
                if line == 'SCORE':
                    needpipe = False
                    logging.debug ( "HiToText %s: Not ignoring lines without |" % ( self.req [ 'gamename' ] ) )
                eat -= 1
                continue

            if needpipe and '|' not in line:
                logging.debug ( "HiToText %s: Ignored line (no |) %s" % ( self.req [ 'gamename' ], line ) )
                continue

            linestrip = line.replace ( ' ', '' )
            linestrip = linestrip.replace ( '\r', '' )

            wordlist = linestrip.split ( '|' ) # line: ['1', '15970', 'A1Z']
            #print wordlist, len ( wordlist )

            if len ( wordlist ) > 1:
                ent = dict()
                ent [ 'score' ] = wordlist [ 1 ]
                ent [ 'shortname' ] = wordlist [ 2 ]
                logging.debug ( "HiToText %s: Row back is %s / %s" % ( self.req [ 'gamename' ], wordlist [ 1 ], wordlist [ 2 ] ) )
                self.rows.append ( ent )
            elif len ( wordlist ) == 1 and not needpipe and len ( wordlist [ 0 ] ) > 3:
                ent = dict()
                ent [ 'score' ] = wordlist [ 0 ]
                ent [ 'shortname' ] = ''
                logging.debug ( "HiToText %s: Row back is %s / n/a" % ( self.req [ 'gamename' ], wordlist [ 0 ] ) )
                self.rows.append ( ent )
            else:
                logging.debug ( "HiToText %s: Ignored line (too short) %s" % ( self.req [ 'gamename' ], line ) )
                continue

        self.rowcount = len ( self.rows )
        logging.debug ( "HiToText %s: Rowcount back is %d" % ( self.req [ 'gamename' ], self.rowcount ) )

        return self.rowcount

if __name__ == '__main__':

    if len ( sys.argv ) < 2:
        print "%s: shortname" % ( sys.argv [ 0 ] )
        print "'shortname' is the MAME driver name (example: 'dkong')"
        print
        print "Paths are relative to current-working-directory"
        print
        print "Included with this executable:"
        print "HiToText-jeff.exe       <- included: customized HiToText hi score analysis tool (source available on request)"
        print "HiToText.xml            <- decoded score descriptors"
        print "./tmp                   <- will be created and removed dynamicly"
        print
        print "You need to supply"
        print "./shortname.hi          <- the .hi file from MAME 0.106"
        print
        sys.exit ( 0 )

    # fake up a minimal request from server
    req = dict()
    req [ 'gamename' ] = sys.argv [ 1 ]

    # make a temp dir; we'll kill it later
    tempdir = "./tmp"
    shutil.rmtree ( tempdir, ignore_errors = True )
    os.mkdir ( tempdir )

    # do it!
    hitotext = HiToText ( req, "./%s.hi" % sys.argv [ 1 ], tempdir, "mono ../HiToText-jeff.exe" )
    hitotext.analyze()
    hitotext.done ( req )

    # good?
    print 'HiToText appears to have returned %d rows' % ( hitotext.rowcount )
    print
    print 'Rows returned look like:'
    pp = pprint.PrettyPrinter ( indent=4 )
    pp.pprint ( hitotext.rows )

    print
    print '_score_ is critical'
    print '_rowcount_ is critical',
    if hitotext.rowcount > 0:
        print ' <- possibly ok?'
    else:
        print ' <- BAD'
    print '_shortname_ is currently optional'
    print

    sys.exit ( 0 )
