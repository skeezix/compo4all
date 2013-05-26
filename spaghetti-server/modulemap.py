
# map a game to either single score or tabular handlers for overall logic
#

import logging
import sys

import singlescore_handler
import multiscore_handler
import hitotext_handler
import util_dictmerge

gamemap = dict()

# status in 'active', 'available', 'unavailable'
def register ( gamename, longname, handler, module, status, field, genre = None, generaldict = None ):

    if gamename in gamemap:
        logging.error ( "FAIL REGISTER: %s is %s - already a game with this name" % ( gamename, status ) )
        sys.exit ( -1 )
        return None

    g = dict()

    g [ 'gamename' ] = gamename
    g [ 'handler' ] = handler
    g [ 'module' ] = module
    g [ 'longname' ] = longname
    g [ 'status' ] = status
    g [ 'field' ] = field
    g [ 'genre' ] = genre
    g [ '_last_tally_update_e' ] = handler.get_last_modify_epoch ( g )

    gamemap [ gamename ] = g

    if generaldict:
        g [ '_general' ] = generaldict

    logging.info ( "REGISTER: %s is %s" % ( gamename, status ) )

# really should make an interface, a class for each, and mixins for the handler+module ..
