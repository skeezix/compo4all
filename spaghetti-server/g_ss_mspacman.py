
import array

def _decode ( byte ):
    # @ -> blank
    # otherwise, literal byte value is number; ^A (is byte value 1) is number one; ^@ (0) is zero
    if byte == 64: # '@'
        # print "#", int ( byte ), "->0"
        return 0
    else:
        # print "#", int ( byte ), "->", byte
        return byte

def parse_hi_bin ( req, bindata ):

    a = array.array ( 'B' )
    a.fromstring ( bindata )

    hi = _decode ( a [ 4 ] ) +              \
        ( _decode ( a [ 5 ] ) * 10 ) +      \
        ( _decode ( a [ 6 ] ) * 100 ) +     \
        ( _decode ( a [ 7 ] ) * 1000 ) +    \
        ( _decode ( a [ 8 ] ) * 10000 ) +   \
        ( _decode ( a [ 9 ] ) * 100000 )

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
