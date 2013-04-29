
import logging

import modulemap
import paths
import singlescore_handler

logging.info ( "LOADING: multiscore_handler" )

def update_hi ( req ):

    # how many slots in the table?
    n = modulemap.gamemap [ req [ 'gamename' ] ][ 'module' ].get_table_slots ( req )

    # keep a copy of bindata since get_hi is destructive right now .. why oh why?!
    bindata = req [ '_bindata' ]

    # get the template table bits..
    template = get_hi ( req )
    thi = list()
    for i in range ( n ):
        d = modulemap.gamemap [ req [ 'gamename' ] ][ 'module' ].get_table_slot_dict ( req, template, i )
        thi.append ( d )

        logging.debug ( "%s template slot %d is %s: %s" % ( req [ 'gamename' ], i, d [ 'shortname' ], d [ 'score' ] ) )

    req [ '_bindata' ] = bindata

    # with luck, we can parse out a single entries block and send that to single-handler; do this once per entry
    # in the hi table, that looks like a new entry

    # for each entry in table
    #   does it look like a new entry? is it already in the template?
    #     if new, send it to singleserver

    for i in range ( n ):
        d = modulemap.gamemap [ req [ 'gamename' ] ][ 'module' ].get_table_slot_dict ( req, bindata, i )

        found = False
        for t in range ( n ):
            if d [ 'score' ] == thi [ t ][ 'score' ] and d [ 'shortname' ] == thi [ t ][ 'shortname' ]:
                found = True

        if found == False:
            logging.debug ( "%s - incoming slot %d is %s: %s -> looks new" % ( req [ 'gamename' ], i, d [ 'shortname' ], d [ 'score' ] ) )
            singlescore_handler.update_hi ( req, int ( d [ 'score' ] ) )
        else:
            logging.debug ( "%s - incoming slot %d is %s: %s -> looks like looper" % ( req [ 'gamename' ], i, d [ 'shortname' ], d [ 'score' ] ) )

def get_hi ( req ):
    # send the template hi file; thats what the game wanted to use, so lets feed it the defaults..

    bp = paths.templatepath ( req )

    f = open ( bp, "rb" )
    bindata = f.read()
    f.close()

    req [ '_bindata' ] = bindata
    req [ '_binlen' ] = len ( bindata )

    logging.info ( "%s - pulled template hi file (len %s)" % ( req [ 'gamename' ], req [ '_binlen' ] ) )

    try:
        d = modulemap.gamemap [ req [ 'gamename' ] ][ 'module' ].optional_prepare_template ( req )
    except:
        pass

    return bindata

def get_json_tally ( req ):
    return singlescore_handler.get_json_tally ( req )

def get_html_tally ( req ):
    return singlescore_handler.get_html_tally ( req )

def get_last_modify_epoch ( req ):
    return singlescore_handler.get_last_modify_epoch ( req )

def _read_tally ( req ):
    return singlescore_handler._read_tally ( req )

def done ( req ):
    return singlescore_handler.done ( req )
