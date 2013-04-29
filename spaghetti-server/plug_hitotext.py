
import logging
import tempfile
import shutil
import subprocess

import state
import paths

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

    def __init__ ( self, req, overridepath=None ):
        self.req = req

        self.tdir = tempfile.mkdtemp ( dir=state.config.get ( 'HiToText', 'tempdirbase' ), suffix=state.config.get ( 'HiToText', 'tempdirsuffix' ) )
        self.overridepath = overridepath

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

        command = "cd " + self.tdir + "; " + state.config.get ( 'HiToText', 'relrunnerbase' ) + ' ' + self.req [ 'gamename' ]
        logging.debug ( "HiToText %s: Query is %s" % ( self.req [ 'gamename' ], command ) )
        b = subprocess.check_output ( command, stderr=subprocess.STDOUT, shell=True )

        # ladybuyg works out...
        # 1|15970|       A1Z
        # 2|10000| UNIVERSAL
        # 3|10000| UNIVERSAL

        self.rowcount = len ( b.split ( '\n' ) )
        self.rows = list()

        for line in b.split ( '\n' ):

            linestrip = line.replace ( ' ', '' )
            linestrip = linestrip.replace ( '\r', '' )

            wordlist = linestrip.split ( '|' ) # line: ['1', '15970', 'A1Z']
            #print wordlist, len ( wordlist )

            if len ( wordlist ) > 1:
                ent = dict()
                ent [ 'score' ] = wordlist [ 1 ]
                ent [ 'shortname' ] = wordlist [ 2 ]
                self.rows.append ( ent )

        return self.rowcount
