
import logging

import decode_bcd
import decode_common
import hexdump

# 30000 32 I.F
# 30000 28 MTJ
# 30000 24 NSO
# 30000 20 KIM
# 30000 16 YSH

def get_table_slots ( req ):
    return 5

# 0 ... max-1
# return dict of: score, shortname
def get_table_slot_dict ( req, blockdata, n ):
    # blocks of
    #   3b BCD score: 0030 00 -> 30,000
    #           0130 02 -> 230010 in game, so its b3 b2 b1  02 30 01 times 10 = 230010
    #   1b stage - 1
    #   3b initials ASCII

    a = decode_common.get_array ( blockdata, 0 + ( 7 * n ), 7 )

    hi = ( decode_bcd.bcd_byte_to_int ( a [ 2 ] ) * 100000 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 1 ] ) *   1000 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 0 ] ) *     10 )

    initials = decode_common.decode_ascii ( a [ 4 ] ) + \
               decode_common.decode_ascii ( a [ 5 ] ) + \
               decode_common.decode_ascii ( a [ 6 ] )

    d = dict()
    d [ 'score' ] = hi
    d [ 'shortname' ] = initials

    return d
