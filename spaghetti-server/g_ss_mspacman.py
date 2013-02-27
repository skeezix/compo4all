
import array

import decode_common

def parse_hi_bin ( req, bindata ):

    a = array.array ( 'B' )
    a.fromstring ( bindata )

    hi = decode_common.decode64 ( a [ 4 ] ) +              \
        ( decode_common.decode64 ( a [ 5 ] ) * 10 ) +      \
        ( decode_common.decode64 ( a [ 6 ] ) * 100 ) +     \
        ( decode_common.decode64 ( a [ 7 ] ) * 1000 ) +    \
        ( decode_common.decode64 ( a [ 8 ] ) * 10000 ) +   \
        ( decode_common.decode64 ( a [ 9 ] ) * 100000 )

    # print "received score", hi
    return hi

def build_hi_bin ( req, hiscore ):

    a = array.array ( 'B' )
    a.append ( 112 ) # p
    a.append ( 2 )
    a.append ( 0 )
    a.append ( 0 )
    a.append ( 0 )
    a.append ( 7 )
    a.append ( 2 )
    a.append ( 64 ) # @
    a.append ( 64 ) # @
    a.append ( 64 ) # @
    a.append ( 72 ) # H

    for i in range ( 6 ):
        a [ 4 + i ] = 64 # blank by default

    source = "%d" % hiscore
    pos = 0
    for c in reversed ( source ):
        a [ 4 + pos ] = int(c)
        pos += 1

    return a.tostring()
