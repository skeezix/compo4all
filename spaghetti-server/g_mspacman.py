
# update_hi - receive binary and i) parse it, ii) update json tally as needed, iii) store .hi file for later
# get_hi -- fetch a bin for the emu
# get_json_tally - dump highscore table as json (for fancy frontend to display, say)
# get_html_tally - dump highscore in vaguely readable html table (for web browser quickies)

import logging
import datetime   # datetime.now()
import json
import array
import os

logging.info ( "g_mspacman is loading" )

def update_hi ( req ):

    # base game path
    writepath = _basepath ( req )

    try:
        logging.debug ( "Attempt to create dirs %s" % ( writepath ) )
        os.makedirs ( writepath )
    except:
        pass

    # pull up existing tally file
    #
    tally = _read_tally ( req )

    # parse new hi buffer
    #
    hi = parse_hi_bin ( req [ '_bindata' ] )

    # is any of this new buffer better than existing tally?
    # if so, update tally file and record it
    # if not, we're done

    # new tally update? great ..
    # .. store hi-file
    # .. store new tally file

    # -------
    if hi <= tally [ 'hi' ]:
        # new submission is not higher -> no dice
        # (implication; first submitter is still winner in a tie)
        logging.info ( "%s - submitter score of %d is not sufficient for update against existing %d" % ( req [ 'gamename' ], hi, tally [ 'hi' ] ) )
        return

    logging.info ( "%s - submitter score of %d is sufficient for win against existing %d" % ( req [ 'gamename' ], hi, tally [ 'hi' ] ) )

    # .. great! emit new tally file
    tally [ 'hi' ] = hi
    tally [ 'prid' ] = req [ 'prid' ]

    tallyfile = json.dumps ( tally )

    f = open ( writepath + req [ 'gamename' ] + ".json", "w" )
    f.write ( tallyfile )
    f.close()

    # .. great! ms pacman only has 1 high score, so just save the hi-file :)
    f = open ( writepath + req [ 'gamename' ] + ".hi", "w" )
    f.write ( req [ '_bindata' ] )
    f.close()

    #logging.debug ( "received len %d" % ( req [ '_binlen' ] ) )

    return

def get_hi ( req ):

    writepath = _basepath ( req )

    try:
        f = open ( writepath + req [ 'gamename' ] + ".hi", "r" )
        bindata = f.read()
        f.close()

        req [ '_bindata' ] = bindata
        req [ '_binlen' ] = len ( bindata )

        logging.info ( "%s - pulled existant hi file" % ( req [ 'gamename' ] ) )

    except:
        req [ '_bindata' ] = build_hi_bin ( 270 )
        req [ '_binlen' ] = len ( req [ '_bindata' ] )

        logging.info ( "%s - pulled generated zero-score hi file" % ( req [ 'gamename' ] ) )

    return

def get_json_tally ( req ):
    tally = _read_tally ( req )
    req [ '_bindata' ] = json.dumps ( tally )
    req [ '_binlen' ] = len ( req [ '_bindata' ] )
    return

def get_html_tally ( req ):
    tally = _read_tally ( req )
    req [ '_bindata' ] = "<h1>" + req [ 'gamename' ] + "</h1>"
    req [ '_binlen' ] = len ( req [ '_bindata' ] )
    return

# ---------------

def _basepath ( req ):
    now = datetime.datetime.now()
    writepath = "runtime/hidb/" + req [ 'gamename' ] + "/" + str(now.year) + "." + str('%02d'%now.month) + "/"
    return writepath

def _read_tally ( req ):

    writepath = _basepath ( req )

    try:
        f = open ( writepath + req [ 'gamename' ] + ".json", "r" )
        tallyfile = f.read()
        f.close()

        tally = json.loads ( tallyfile )

    except:
        logging.warning ( "%s - assuming new score (0) file" % ( req [ 'gamename' ] ) )
        tally = dict()
        tally [ 'hi' ] = 0
        tally [ 'prid' ] = '_default_'

    return tally

def _decode ( byte ):
    # @ -> blank
    # otherwise, literal byte value is number; ^A (is byte value 1) is number one; ^@ (0) is zero
    if byte == 64: # '@'
        # print "#", int ( byte ), "->0"
        return 0
    else:
        # print "#", int ( byte ), "->", byte
        return byte

def parse_hi_bin ( bindata ):

    a = array.array ( 'B' )
    a.fromstring ( bindata )

    hi = _decode ( a [ 4 ] ) +              \
        ( _decode ( a [ 5 ] ) * 10 ) +      \
        ( _decode ( a [ 6 ] ) * 100 ) +     \
        ( _decode ( a [ 7 ] ) * 1000 ) +    \
        ( _decode ( a [ 8 ] ) * 10000 ) +   \
        ( _decode ( a [ 9 ] ) * 100000 )

    # print "received score", hi
    return hi

def build_hi_bin ( hiscore ):

    a = array.array ( 'B' )
    a.append ( 112 ) # p
    a.append ( 2 )
    a.append ( 0 )
    a.append ( 0 )
    a.append ( 0 )
    a.append ( 7 )
    a.append ( 2 )
    a.append ( 64 ) # @
    a.append ( 64 ) # @
    a.append ( 64 ) # @
    a.append ( 72 ) # H

    for i in range ( 6 ):
        a [ 4 + i ] = 64 # blank by default

    source = "%d" % hiscore
    pos = 0
    for c in reversed ( source ):
        a [ 4 + pos ] = int(c)
        pos += 1

    return a.tostring()
