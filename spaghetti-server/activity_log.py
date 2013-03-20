
import logging
import json
import time

import profile
from paths import _basepath, actlogfullpath
import modulemap
import state

# log entry 'into table'; ie: receive scores that actually went into a games table at some rank number
# we're not concerning ourselves with scores that didn't even make top-500 say (or should we log
# any activity, even failed attempts, so we know what people are trying? If so, could just submit
# rank #9999 or something..)
def log_entry ( req, scoreent, rank ):

    # base game path
    writepath = actlogfullpath ( req )

    # req [ 'gamename' ]
    # req [ 'prid' ]
    # scoreent [ 'score' ]
    # scoreent [ 'time' ] # as int, not float, epoch

    d = dict()
    d [ 'gamename' ] = req [ 'gamename' ]
    d [ 'prid' ] = req [ 'prid' ]
    d [ 'score' ] = scoreent [ 'score' ]
    d [ 'time' ] = scoreent [ 'time' ]
    d [ 'rank' ] = rank

    log = _readlog ( req )

    log.insert ( 0, d ) # insert to head
    log.pop() # drop last entry, so we maintain size

    _writelog ( req, log )

    return None

def get_log_html ( req ):

    tally = _readlog ( req )

    html = ''
    html += "<h2>Recent Activity</h2>\n"
    html += "<table>\n"

    html += '<tr>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>Initial</b></td>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>Name</b></td>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>Game</b></td>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>Score</b></td>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>Board Rank</b></td>\n'
    html += '  <td style="padding:0 15px 0 15px;"><b>When</b></td>\n'
    html += '</tr>\n'

    i = 1
    pridcache = dict()

    for ent in tally:

        if ent [ 'gamename' ] == '':
            break # end of table

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
                html += '  <td style="padding:0 15px 0 15px;"></td>\n'
                html += '</tr>\n'

            # showrow == 1, or showrow == 2 .. show this line
            html += '<tr>\n'

            html += '  <td style="padding:0 15px 0 15px;">' + prident [ 'shortname' ] + "</td>\n"
            html += '  <td style="padding:0 15px 0 15px;">' + prident [ 'longname' ] + "</td>\n"
            html += '  <td style="padding:0 15px 0 15px;">' + modulemap.gamemap [ ent [ 'gamename' ] ][ 'longname' ] + "</td>\n"
            if ent [ 'score' ] > 0:
                html += '  <td style="padding:0 15px 0 15px;">' + str ( ent [ 'score' ] ) + "</td>\n"
            else:
                html += '  <td style="padding:0 15px 0 15px;">-</td>\n'
            html += '  <td style="padding:0 15px 0 15px;">' + str(ent [ 'rank' ] + 1) + "</td>\n"
            if ent [ 'time' ] > 0:
                html += '  <td style="padding:0 15px 0 15px;">' + tdisplay + "</td>\n"
            else:
                html += '  <td style="padding:0 15px 0 15px;"></td>\n'
            html += '</tr>\n'

        i += 1

        if i > 50:
            break

    html += "</table>\n"

    html += "<p>%d unique profiles in the log</p>\n" % ( len ( pridcache ) )

    req [ '_bindata' ] = html
    req [ '_binlen' ] = len ( req [ '_bindata' ] )

    return

def get_log_json ( req ):

    tally = _readlog ( req )

    retlist = list()

    i = 1
    pridcache = dict()

    for ent in tally:

        newent = dict()

        if ent [ 'gamename' ] == '':
            break # end of table

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

        if showrow == 0:
            pass # suppress

        else:

            # showrow == 1, or showrow == 2 .. show this line

            newent [ 'shortname' ] = prident [ 'shortname' ]
            newent [ 'longname' ] = prident [ 'longname' ]
            newent [ 'gamename' ] = modulemap.gamemap [ ent [ 'gamename' ] ][ 'longname' ]

            if ent [ 'score' ] > 0:
                newent [ 'score' ] = ent [ 'score' ]
            else:
                newent [ 'score' ] = 0

            newent [ 'rank' ] = ent [ 'rank' ] + 1

            if ent [ 'time' ] > 0:
                newent [ 'time' ] = tdisplay
            else:
                newent [ 'time' ] = ''

        retlist.append ( newent )

        i += 1

        if i > 50:
            break

    bindata = json.dumps ( retlist )

    return bindata

def _readlog ( req ):

    writepath = actlogfullpath ( req )

    try:
        f = open ( writepath, "r" )
        logfile = f.read()
        f.close()

        log = json.loads ( logfile )

    except:
        logging.warning ( "assuming new actlog file" )

        log = list()
        for i in range ( logsize() ):
            log.append ( { 'gamename': '', 'prid': '_default_', 'score': 0, 'time': 0, 'rank': 0 } )

    return log

def _writelog ( req, log ):
    writepath = actlogfullpath ( req )

    logj = json.dumps ( log )

    f = open ( writepath, "w" )
    f.write ( logj )
    f.close()

    return None

def logsize():

    if state.config.has_section ( 'ActivityLog' ):
        return state.config.getint ( 'ActivityLog', 'size' )

    return 500
