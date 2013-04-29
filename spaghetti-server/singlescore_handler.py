
# update_hi - receive binary and i) parse it, ii) update json tally as needed, iii) store .hi file for later
# get_hi -- fetch a bin for the emu
# get_json_tally - dump highscore table as json (for fancy frontend to display, say)
# get_html_tally - dump highscore in vaguely readable html table (for web browser quickies)
# get_last_modify_epoch - get epoch-time of last tally modify

import logging
import json
import array
import os
import pprint
import time

import profile
from paths import _basepath
import modulemap
import activity_log

SCOREBOARD_MAX=500

logging.info ( "LOADING: singlescore_handler" )

# "score" should not be supplied, unless its multiscore sending its shit here
def update_hi ( req, score_int=None ):

    #pp = pprint.PrettyPrinter ( indent=4 )

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
    if score_int:
        hi = score_int
    else:
        hi = parse_hi_bin ( req, req [ '_bindata' ] )

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
            # log the activity
            activity_log.log_entry ( req, d, i )
            # insert
            sb.insert ( i, d )
            # drop off last guy
            sb.pop()
            # if we updated the first entry, the very highest score, spit out a new .hi file
            # (mspacman only has a single high score, so we only update it for the highest score.. not a whole table)
            if i == 0 and score_int == None:
                f = open ( writepath + req [ 'gamename' ] + ".hi", "w" )
                f.write ( build_hi_bin ( req, sb [ 0 ][ 'score' ] ) )
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

    req [ '_bindata' ] = build_hi_bin ( req, 0 )
    req [ '_binlen' ] = len ( req [ '_bindata' ] )

    logging.info ( "%s - pulled generated zero-score hi file (len %s)" % ( req [ 'gamename' ], req [ '_binlen' ] ) )

    '''
    writepath = _basepath ( req )

    try:
        f = open ( writepath + req [ 'gamename' ] + ".hi", "r" )
        bindata = f.read()
        f.close()

        req [ '_bindata' ] = bindata
        req [ '_binlen' ] = len ( bindata )

        logging.info ( "%s - pulled existant hi file (len %s)" % ( req [ 'gamename' ], req [ '_binlen' ] ) )

    except:
        req [ '_bindata' ] = build_hi_bin ( req, 270 )
        req [ '_binlen' ] = len ( req [ '_bindata' ] )

        logging.info ( "%s - pulled generated zero-score hi file (len %s)" % ( req [ 'gamename' ], req [ '_binlen' ] ) )
    '''

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

    if '_backdate' in req:
        if req [ '_backdate' ].isdigit():
            timeframe = 'Specific Month: ' + req [ '_backdate' ]
        else:
            timeframe = 'All Time'
    else:
        timeframe = 'Current Month'

    html = ''
    html += "<h2>" + req [ 'gamename' ] + "</h2>\n"
    html += "<h3>" + timeframe + "</h3>\n"
    html += "<table>\n"

    html += '<tr>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>Rank</b></td>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>Initial</b></td>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>Name</b></td>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>Score</b></td>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>When</b></td>\n'
    html += '</tr>\n'

    i = 1
    pridcache = dict()
    lastprident = None
    lastrun = 0 # for an RLE-like run count

    for ent in tally [ 'scoreboard' ]:

        prident = None
        if ent [ 'prid' ]:
            try:
                prident = pridcache [ ent [ 'prid' ] ]
            except:
                prident = profile.fetch_pridfile_as_dict ( ent [ 'prid' ] )
                pridcache [ ent [ 'prid' ] ] = prident
        if prident == None:
            prident = profile.NULL_PROFILE

        tlocal = time.localtime ( ent [ 'time' ] )
        tdisplay = time.strftime ( '%d-%b-%Y', tlocal )

        showrow = 1 # 0 no, 1 yes, 2 ellipses

        if lastprident == prident:
            showrow = 0
            lastrun += 1
        else:

            # if not first row, and the RLE is significant .. show an ellipses
            if lastprident != None and lastrun > 0:
                showrow = 2
            else:
                showrow = 1

            # last and current are not the same, so RLE is back to zero
            lastrun = 0

        if showrow == 0:
            pass # suppress

        else:

            if showrow == 2:
                # so our last row is not same as this row, and last guy was not also the first
                # row.. so show "..."
                html += '<tr>\n'
                html += '  <td style="padding:0 15px 0 15px;">' + "" + "</td>\n"
                html += '  <td style="padding:0 15px 0 15px;">' + "" + "</td>\n"
                html += '  <td style="padding:0 15px 0 15px;">' + "..." + "</td>\n"
                html += '  <td style="padding:0 15px 0 15px;"></td>\n'
                html += '  <td style="padding:0 15px 0 15px;"></td>\n'
                html += '</tr>\n'

            # showrow == 1, or showrow == 2 .. show this line
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

        lastprident = prident
        i += 1

    html += "</table>\n"

    html += "<p>%d unique profiles in the leaderboard</p>\n" % ( len ( pridcache ) )

    req [ '_bindata' ] = html
    req [ '_binlen' ] = len ( req [ '_bindata' ] )

    return

def get_last_modify_epoch ( req ):
    try:
        filename = _basepath ( req ) + req [ 'gamename' ] + ".json"
        return int ( os.path.getmtime ( filename ) )
    except:
        return 0

# ---------------

def _read_tally ( req ):

    writepath = _basepath ( req )

    try:
        f = open ( writepath + req [ 'gamename' ] + ".json", "r" )
        tallyfile = f.read()
        f.close()

        tally = json.loads ( tallyfile )

    except:
        logging.warning ( "%s - assuming new score file (all zeroes)" % ( req [ 'gamename' ] ) )
        tally = dict()
        tally [ 'hi' ] = 0
        tally [ 'prid' ] = '_default_'

        scoreboard = list()
        for i in range ( SCOREBOARD_MAX ):
            scoreboard.append ( { 'prid': '_default_', 'score': 0, 'time': 0 } )
        tally [ 'scoreboard' ] = scoreboard

    return tally

def parse_hi_bin ( req, bindata ):
    return modulemap.gamemap [ req [ 'gamename' ] ][ 'module' ].parse_hi_bin ( req, bindata )

def build_hi_bin ( req, hiscore ):
    return modulemap.gamemap [ req [ 'gamename' ] ][ 'module' ].build_hi_bin ( req, hiscore )

def done ( req ):
    pass
