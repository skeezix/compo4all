
import array

import decode_bcd

def parse_hi_bin ( req, bindata ):

    a = array.array ( 'B' )
    a.fromstring ( bindata )

    # 2 bytes
    # score 1440 is ...   40   14

    hi = ( decode_bcd.bcd_byte_to_int ( a [ 1 ] ) *   100 ) + \
         ( decode_bcd.bcd_byte_to_int ( a [ 0 ] ) *     1 ) 

    return hi

def build_hi_bin ( req, hiscore ):

    a = array.array ( 'B' )
    a.append ( 0 )  # lowest 2 digits
    a.append ( 0 )  # highest 2 digits

    # print score to text
    s = "%d" % hiscore
    s = s.zfill ( 4 ) # left pad with zeroes so we have 6 digits guaranteed

    a [ 0 ] = decode_bcd.int2_to_bcd_byte ( s [ 2:4 ] ) # 2,3 == char3,4
    a [ 1 ] = decode_bcd.int2_to_bcd_byte ( s [ 0:2 ] ) # 0,1 == char1,2

    return a.tostring()
