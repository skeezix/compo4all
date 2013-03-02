
import logging

import decode_bcd
import decode_common
import hexdump

def get_table_slots ( req ):
    return 10

# 0 ... max-1
# return dict of: score, shortname
def get_table_slot_dict ( req, blockdata, n ):
    # blocks of 10b, for 10 scores == 100b total
    # bcd numbers; 3b for the score in bcd (6 digits), then name, and then timing info and crud

    a = decode_common.get_array ( blockdata, 0 + ( 10 * n ), 6 )

    hi = ( decode_bcd.bcd_byte_to_int ( a [ 0 ] ) * 10000 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 1 ] ) *   100 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 2 ] ) *     1 )

    initials = decode_char ( a [ 3 ] ) + \
               decode_char ( a [ 4 ] ) + \
               decode_char ( a [ 5 ] )

    d = dict()
    d [ 'score' ] = hi
    d [ 'shortname' ] = initials

    return d

# -------------------------------------

def decode_char ( c ):
    # note: 29 = ' '
    # note: 28 = '.'
    # 0x0a == A
    # 0x23 == Z no lowercase allowed
    if c == 0x29:
        return ' '
    elif c == 0x28:
        return '.'
    return chr ( ord ( 'A' ) + c - 10 )
