
import logging

import decode_bcd
import decode_common
import hexdump

def get_table_slots ( req ):
    return 5

# 0 ... max-1
# return dict of: score, shortname
def get_table_slot_dict ( req, blockdata, n ):
    # 4b is top score
    # blocks of 8b for each score table entry
    #   4b BCD score
    #   1b stage (BCD or byte, not sure offhand)
    #   3b name in ASCII (!)

    a = decode_common.get_array ( blockdata, 4 + ( 8 * n ), 8 )

    hi = ( decode_bcd.bcd_byte_to_int ( a [ 0 ] ) * 1000000 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 1 ] ) *   10000 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 2 ] ) *     100 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 3 ] ) *       1 )

    stage = decode_bcd.bcd_byte_to_int ( a [ 4 ] ) # assuminc BCD, same thing if the level count is not really high..

    initials = decode_common.decode_ascii ( a [ 5 ] ) + \
               decode_common.decode_ascii ( a [ 6 ] ) + \
               decode_common.decode_ascii ( a [ 7 ] )

    d = dict()
    d [ 'score' ] = hi
    d [ 'shortname' ] = initials

    return d
