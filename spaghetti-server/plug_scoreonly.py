
import logging
import profile
import json
import os
import sys
import modulemap
from paths import _basepath

import state
import singlescore_handler

# why aren't I using classes in any of this code? and a nice abstracted pure-interface def'n class? ... oh, right, sleepdep.

logging.info ( "LOADING: scoreonly plugin" )

conf = None

def init():
    # pull in all the conf files..
    global conf

    try:
        confpath = state.config.get ( 'PlugScoreOnly', 'confpathbase' )
    except:
        logging.error ( "plugin %s exception %s" % ( __name__, sys.exc_info() ) )
        return None

    logging.debug ( "plugin %s conf path %s" % ( __name__, confpath ) )

    dirlist = os.listdir ( confpath )

    for dirent in dirlist:

        if dirent [ 0 ] == '.':
            logging.debug ( "plugin %s conf entry %s - skip" % ( __name__, dirent ) )
            continue

        if dirent.endswith ( "~" ):
            logging.debug ( "plugin %s conf entry %s - skip" % ( __name__, dirent ) )
            continue

        if dirent.endswith ( "bak" ):
            logging.debug ( "plugin %s conf entry %s - skip" % ( __name__, dirent ) )
            continue

        if os.path.isdir ( confpath + dirent ):
            logging.debug ( "plugin %s conf entry %s - skip" % ( __name__, dirent ) )
            continue

        logging.debug ( "plugin %s conf entry %s" % ( __name__, dirent ) )

        conf = _loadconf ( confpath + dirent )
        if conf == None:
            continue

        logging.debug ( "plugin %s conf entry %s is for game %s" % ( __name__, dirent, conf [ 'longname' ] ) )

        if not conf [ 'active' ]:
            logging.debug ( "plugin %s conf entry %s is for game %s - inactive" % ( __name__, dirent, conf [ 'longname' ] ) )
            continue

        _register_game ( conf )

    pass

def submit_data ( req, argdict ):
    global conf

    argdict [ 'score' ] = int( argdict [ 'score' ] )

    if True:
        logging.debug ( "First update_hi - for actual current month" )
        singlescore_handler.update_hi ( req, score_int = argdict [ 'score' ] )

    if conf [ 'alltime' ]:
        logging.debug ( "Second update_hi - for ALLT.IM" )
        req [ '_backdate' ] = 'ALLTIM'
        singlescore_handler.update_hi ( req, score_int = argdict [ 'score' ] )

    return

def _loadconf ( fullpath ):

    try:
        f = open ( fullpath, "r" )
        file = f.read()
        f.close()

        conf = json.loads ( file )

        return conf

    except:
        logging.error ( "Could not open/parse plugin conf - %s - %s" % ( fullpath, sys.exc_info() ) )
        return None

def _register_game ( conf ):
    status = 'available'
    if 'status' in conf:
        status = conf [ 'status' ]
    modulemap.register ( conf [ 'shortname' ], conf [ 'longname' ], sys.modules[__name__], None, status, conf [ 'field' ], conf [ 'genre' ], conf )

# ------------------------------------------------------------------------------------

def get_last_modify_epoch ( req ):
    return singlescore_handler.get_last_modify_epoch ( req )

def get_json_tally ( req ):
    return singlescore_handler.get_json_tally ( req )

def get_html_tally ( req ):
    return singlescore_handler.get_html_tally ( req )

def _read_tally ( req ):
    return singlescore_handler._read_tally ( req )

def done ( req ):
    return singlescore_handler.done ( req )
