
# update_hi - receive binary and i) parse it, ii) update json tally as needed, iii) store .hi file for later
# get_hi -- fetch a bin for the emu
# get_json_tally - dump highscore table as json (for fancy frontend to display, say)
# get_html_tally - dump highscore in vaguely readable html table (for web browser quickies)
# get_last_modify_epoch - get epoch-time of last tally modify

import logging
import datetime   # datetime.now()
import json
import array
import os
import pprint
import time

import profile

SCOREBOARD_MAX=25

logging.info ( "g_mspacman is loading" )

def _basepath ( req ):
    now = datetime.datetime.now()
    writepath = "runtime/hidb/" + req [ 'gamename' ] + "/" + str(now.year) + "." + str('%02d'%now.month) + "/"
    return writepath

# -----------------

def update_hi ( req ):

    pp = pprint.PrettyPrinter ( indent=4 )

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
    sb = tally [ 'scoreboard' ]

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

    # does this score factor into the high score table, or too low to count?
    if hi < sb [ SCOREBOARD_MAX - 1 ][ 'score' ]:
        logging.info ( "hidb - %s - submitter score of %d is NOT sufficient to enter scoreboard (lowest %d, highest %d)" % ( req [ 'gamename' ], hi, sb [ SCOREBOARD_MAX - 1 ][ 'score' ], sb [ 0 ][ 'score' ] ) )
        return

    # is score same as existing top .. if so, its just resubmitting the score they pulled down, likely, so.. discard
    if hi == sb [ 0 ][ 'score' ]:
        logging.info ( "hidb - %s - submitter score of %d is same as highest score .. probably just looping. (lowest %d, highest %d)" % ( req [ 'gamename' ], hi, sb [ SCOREBOARD_MAX - 1 ][ 'score' ], sb [ 0 ][ 'score' ] ) )
        return

    # okay, so the guys score is at least better than one of them.. start at top, pushing the way down
    logging.info ( "hidb - %s - submitter score of %d IS sufficient to enter scoreboard (lowest %d, highest %d)" % ( req [ 'gamename' ], hi, sb [ SCOREBOARD_MAX - 1 ][ 'score' ], sb [ 0 ][ 'score' ] ) )

    for i in range ( SCOREBOARD_MAX ):
        if hi > sb [ i ][ 'score' ]:
            # insert new score entry
            d = dict()
            d [ 'prid' ] = req [ 'prid' ]
            d [ 'score' ] = hi
            d [ 'time' ] = int ( time.time() )
            sb.insert ( 0, d )
            # drop off last guy
            sb.pop()
            # if we updated the first entry, the very highest score, spit out a new .hi file
            # (mspacman only has a single high score, so we only update it for the highest score.. not a whole table)
            if i == 0:
                f = open ( writepath + req [ 'gamename' ] + ".hi", "w" )
                f.write ( build_hi_bin ( sb [ 0 ][ 'score' ] ) )
                f.close()
            break

    # write out the updated tally file
    tally [ 'hi' ] = sb [ 0 ][ 'score' ]
    tally [ 'prid' ] = sb [ 0 ][ 'prid' ]

    tallyfile = json.dumps ( tally )

    f = open ( writepath + req [ 'gamename' ] + ".json", "w" )
    f.write ( tallyfile )
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

    for ent in tally [ 'scoreboard' ]:
        prident = profile.fetch_pridfile_as_dict ( ent [ 'prid' ] )
        if prident == None:
            prident = profile.NULL_PROFILE

        ent [ 'shortname' ] = prident [ 'shortname' ]
        ent [ 'longname' ] = prident [ 'longname' ]
        del ent [ 'prid' ]

    req [ '_bindata' ] = json.dumps ( tally )
    req [ '_binlen' ] = len ( req [ '_bindata' ] )
    return

def get_html_tally ( req ):
    tally = _read_tally ( req )

    html = ''
    html += "<h2>" + req [ 'gamename' ] + "</h2>\n"
    html += "<table>\n"

    html += '<tr>\n'
    html += '  <td style="padding:0 15px 0 15px;"></td>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>Initial</b></td>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>Name</b></td>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>Score</b></td>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>When</b></td>\n'
    html += '</tr>\n'

    i = 1
    for ent in tally [ 'scoreboard' ]:
        prident = profile.fetch_pridfile_as_dict ( ent [ 'prid' ] )
        if prident == None:
            prident = profile.NULL_PROFILE

        tlocal = time.localtime ( ent [ 'time' ] )
        tdisplay = time.strftime ( '%d-%b-%Y', tlocal )

        html += '<tr>\n'
        html += '  <td style="padding:0 15px 0 15px;">' + str ( i ) + "</td>\n"
        html += '  <td style="padding:0 15px 0 15px;">' + prident [ 'shortname' ] + "</td>\n"
        html += '  <td style="padding:0 15px 0 15px;">' + prident [ 'longname' ] + "</td>\n"
        if ent [ 'score' ] > 0:
            html += '  <td style="padding:0 15px 0 15px;">' + str ( ent [ 'score' ] ) + "</td>\n"
        else:
            html += '  <td style="padding:0 15px 0 15px;">-</td>\n'
        if ent [ 'time' ] > 0:
            html += '  <td style="padding:0 15px 0 15px;">' + tdisplay + "</td>\n"
        else:
            html += '  <td style="padding:0 15px 0 15px;"></td>\n'
        html += '</tr>\n'

        i += 1

    html += "</table>\n"

    req [ '_bindata' ] = html
    req [ '_binlen' ] = len ( req [ '_bindata' ] )

    return

def get_last_modify_epoch ( req ):
    filename = _basepath ( req ) + req [ 'gamename' ] + ".json"
    return int ( os.path.getmtime ( filename ) )

# ---------------

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

        scoreboard = list()
        for i in range ( SCOREBOARD_MAX ):
            scoreboard.append ( { 'prid': '_default_', 'score': 0, 'time': 0 } )
        tally [ 'scoreboard' ] = scoreboard

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
