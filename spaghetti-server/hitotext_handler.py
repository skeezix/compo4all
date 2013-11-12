
import logging
import os
import json

import modulemap
import paths
import multiscore_handler
import singlescore_handler
import plug_hitotext

logging.info ( "LOADING: multiscore_handler" )

def update_hi ( req ):

    # first, work out the template hi file
    # lets try to memoize it, avoid the multi-second runtime mono job incurs us
    thi = plug_hitotext.HiToText ( req, overridepath=paths.templatepath ( req ) )
    memofile = "./runtime/plugins/hitotext/memoize/" + req [ 'gamename' ] + '.memo'

    if os.path.exists ( memofile ):
        logging.debug ( 'HiToText %s - use memoize templates' % ( req [ 'gamename' ] ) )

        f = open ( memofile, 'r' )
        memo = f.read()
        f.close()

        thi.rows = json.loads ( memo )
    else:
        logging.debug ( 'HiToText %s - generate memoize templates' % ( req [ 'gamename' ] ) )

        req [ '_hitotext' ] = thi
        thi.analyze()

        f = open ( memofile, 'w' )
        f.write ( json.dumps ( thi.rows ) )
        f.close()

    # second, work out the scores in the submitted
    hi = plug_hitotext.HiToText ( req )
    req [ '_hitotext' ] = hi
    hi.analyze()

    # how many slots in the table?
    n = len ( hi.rows )

    # for each entry in table
    #   does it look like a new entry? is it already in the template?
    #     if new, send it to singleserver

    for i in range ( n ):

        found = False
        for t in range ( n ):
            if hi.rows [ i ][ 'score' ] == thi.rows [ t ][ 'score' ] and hi.rows [ i ][ 'shortname' ] == thi.rows [ t ][ 'shortname' ]:
                found = True

        if found == False:
            logging.debug ( "%s - incoming slot %d is %s: %s -> looks new" % ( req [ 'gamename' ], i, hi.rows [ i ] [ 'shortname' ], hi.rows [ i ][ 'score' ] ) )
            singlescore_handler.update_hi ( req, int ( hi.rows [ i ][ 'score' ] ) )
        else:
            logging.debug ( "%s - incoming slot %d is %s: %s -> looks like looper" % ( req [ 'gamename' ], i, hi.rows [ i ][ 'shortname' ], hi.rows [ i ][ 'score' ] ) )

    thi.done ( req )
    hi.done ( req )

    return

def get_hi ( req ):
    return multiscore_handler.get_hi ( req )

def get_json_tally ( req, raw=False ):
    return multiscore_handler.get_json_tally ( req, raw=raw )

def get_html_tally ( req ):
    return multiscore_handler.get_html_tally ( req )

def get_last_modify_epoch ( req ):
    return multiscore_handler.get_last_modify_epoch ( req )

def _read_tally ( req ):
    return multiscore_handler._read_tally ( req )

def done ( req ):
    return multiscore_handler.done ( req )
