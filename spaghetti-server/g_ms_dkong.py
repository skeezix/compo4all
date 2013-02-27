
import array

import decode_bcd
import hexdump

def get_table_slots ( req ):
    return 5

# 0 ... max-1
# return dict of: score, shortname
def get_table_slot_dict ( req, blockdata, n ):

    offset = 0 + ( 7 * n )
    length = 7

    a = array.array ( 'B' )
    a.fromstring ( blockdata [ offset : offset + 7 ] )

    hi = ( decode_bcd.bcd_byte_to_int ( a [ 1 ] ) * 1000 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 0 ] ) *   100 )

    level = a [ 3 ]

    # charset I bet is..
    # 0-9 -> 0-9
    # 10 0xA -> A
    # 11 0xB -> B ...
    initials = decode_char ( a [ 4 ] ) + \
               decode_char ( a [ 5 ] ) + \
               decode_char ( a [ 6 ] )

    d = dict()
    d [ 'score' ] = hi
    d [ 'level' ] = level
    d [ 'shortname' ] = initials

    return d

def decode_char ( c ):
    if c < 10:
        return chr ( ord ( '0' ) + c )
    return chr ( ord ( 'A' ) + c - 10 )
