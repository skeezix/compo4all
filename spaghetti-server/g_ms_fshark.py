
import logging

import decode_bcd
import decode_common
import hexdump

def get_table_slots ( req ):
    return 20

# 0 ... max-1
# return dict of: score, shortname
def get_table_slot_dict ( req, blockdata, n ):
    # first 4b are 'high score' for top of screen
    # then 4b per score (1 through 20)
    # then 6b per rank for initials (6 char initials)

    a = decode_common.get_array ( blockdata, 4 + ( 4 * n ), 4 )

    hi = ( decode_bcd.bcd_byte_to_int ( a [ 1 ] ) * 100000 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 2 ] ) *   1000 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 3 ] ) *     10 )

    a = decode_common.get_array ( blockdata, 84 + ( 12 * n ), 12 )

    initials = decode_char ( a [  1 ] ) + \
               decode_char ( a [  3 ] ) + \
               decode_char ( a [  5 ] ) + \
               decode_char ( a [  7 ] ) + \
               decode_char ( a [  9 ] ) + \
               decode_char ( a [ 11 ] )

    d = dict()
    d [ 'score' ] = hi
    d [ 'shortname' ] = initials

    return d

# -------------------------------------

def decode_char ( c ):
    # 0x0a == A   0x0b == B .. etc
    # 0x23 == Z   (0x023 -> decimal 35, works out .. 10+26 == 36)
    # note: 26 = '.'
    if c == 0x26:
        return '.'
    return chr ( ord ( 'A' ) + c - 10 )
