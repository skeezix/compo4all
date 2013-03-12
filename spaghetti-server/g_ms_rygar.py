
import logging

import decode_bcd
import decode_common
import hexdump

def get_table_slots ( req ):
    return 50 # !!

# 0 ... max-1
# return dict of: score, shortname
def get_table_slot_dict ( req, blockdata, n ):
    # 0 offset to first
    # +9 to get to next
    # blocks of 9b for each score table entry
    #   1b .. 41 (A) .. not sure
    #   4b score BCD
    #   3b initials in .. BCD? guessing.
    #   1b stage (byte?)

    a = decode_common.get_array ( blockdata, 0 + ( 9 * n ), 9 )

    hi = ( decode_bcd.bcd_byte_to_int ( a [ 1 ] ) * 1000000 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 2 ] ) *   10000 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 3 ] ) *     100 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 4 ] ) *       1 )

    stage = decode_bcd.bcd_byte_to_int ( a [ 8 ] ) # assuminc BCD, same thing if the level count is not really high..

    initials = decode_common.decode_ascii ( a [ 5 ] ) + \
               decode_common.decode_ascii ( a [ 6 ] ) + \
               decode_common.decode_ascii ( a [ 7 ] )

    d = dict()
    d [ 'score' ] = hi
    d [ 'shortname' ] = initials

    return d
