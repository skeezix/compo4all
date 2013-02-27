
import logging
import array

import decode_bcd
import decode_common
import hexdump
import singlescore_handler
import profile

def get_table_slots ( req ):
    return 5

# 0 ... max-1
# return dict of: score, shortname
def get_table_slot_dict ( req, blockdata, n ):

    a = decode_common.get_array ( blockdata, 7 + ( 34 * n ), 11 )

    hi = ( a [ 0 ] * 100000 ) + \
         ( a [ 1 ] *  10000 ) + \
         ( a [ 2 ] *   1000 ) + \
         ( a [ 3 ] *    100 ) + \
         ( a [ 4 ] *     10 ) + \
         ( a [ 5 ] *      1 )

    initials = decode_char ( a [ 8 ] ) + \
               decode_char ( a [ 9 ] ) + \
               decode_char ( a [ 10 ] )

    d = dict()
    d [ 'score' ] = hi
    d [ 'shortname' ] = initials

    return d

def optional_prepare_template ( req ):

    return # forget it for now

    logging.info ( "dkong does attempt to modify template prior to sending to client..." )

    # fetch tally
    tally = singlescore_handler._read_tally ( req )

    if tally [ 'scoreboard' ][ 0 ][ 'prid' ] != '_default_':
        # theres a real score here
        pridfile = profile.fetch_pridfile_as_dict ( tally [ 'scoreboard' ][ 0 ][ 'prid' ] )

        if not pridfile:
            return

        if not pridfile [ 'shortname' ].isdigit():
            return

        # imprint top initials
        req [ '_bindata' ][ 7 +  8 ] = encode_char ( pridfile [ 'shortname' ][ 0 ] )
        req [ '_bindata' ][ 7 +  9 ] = encode_char ( pridfile [ 'shortname' ][ 1 ] )
        req [ '_bindata' ][ 7 + 10 ] = encode_char ( pridfile [ 'shortname' ][ 2 ] )

# -------------------------------------

def decode_char ( c ):
    if c < 10: # not verified
        return chr ( ord ( '0' ) + c ) # not verified
    if c == 16:
        return ' '
    return chr ( ord ( 'A' ) + c - 17 )

def encode_char ( c ):
    # only works for A-Z for now
    return ord ( c ) - ord ( 'A' ) + 17
