
# cloned essentially from g_ms_dkong.py

import logging
import array

import decode_bcd
import decode_common
import hexdump

from g_ms_dkong import decode_char


def get_table_slots ( req ):
    return 5

# 0 ... max-1
# return dict of: score, shortname
def get_table_slot_dict ( req, blockdata, n ):

    a = decode_common.get_array ( blockdata, 2 + ( 34 * n ), 34 )

    hi = ( a [ 0 ] * 100000 ) + \
         ( a [ 1 ] *  10000 ) + \
         ( a [ 2 ] *   1000 ) + \
         ( a [ 3 ] *    100 ) + \
         ( a [ 4 ] *     10 ) + \
         ( a [ 5 ] *      1 )

    initials = decode_char ( a [ 12 ] ) + \
               decode_char ( a [ 13 ] ) + \
               decode_char ( a [ 14 ] )

    d = dict()
    d [ 'score' ] = hi
    d [ 'shortname' ] = initials

    return d
