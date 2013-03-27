
# king of dragons

import logging

import decode_bcd
import decode_common
import hexdump

def get_table_slots ( req ):
    return 5

# 0 ... max-1
# return dict of: score, shortname
def get_table_slot_dict ( req, blockdata, n ):
    # 0 offset to first
    # +8 to get to next
    # blocks of 9b for each score table entry
    #   4b score -> 01 00 00 00 == 1million - BCD
    #   3b initials in .. byte, A == 00, B == 01, L == 0b
    #   1b - character used (0-4, 5 choices)

    a = decode_common.get_array ( blockdata, 0 + ( 8 * n ), 8 )

    hi = ( decode_bcd.bcd_byte_to_int ( a [ 0 ] ) * 1000000 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 1 ] ) *   10000 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 2 ] ) *     100 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 3 ] ) *       1 )

    character = a [ 7 ]

    initials = decode_char ( a [ 4 ] ) + \
               decode_char ( a [ 5 ] ) + \
               decode_char ( a [ 6 ] )

    d = dict()
    d [ 'score' ] = hi
    d [ 'shortname' ] = initials

    return d

# -------------------------------------

def decode_char ( c ):
    # 0x00 == A
    # 0x01 == B
    return chr ( ord ( 'A' ) + c )
