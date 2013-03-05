
import array

def get_array ( blockdata, offset, length ):
    a = array.array ( 'B' )
    a.fromstring ( blockdata [ offset : offset + length ] )
    return a

# origin of this code.. g_ss_mspacman
#
def decode64 ( byte ):
    # @ -> blank
    # otherwise, literal byte value is number; ^A (is byte value 1) is number one; ^@ (0) is zero
    if byte == 64: # '@'
        # print "#", int ( byte ), "->0"
        return 0
    else:
        # print "#", int ( byte ), "->", byte
        return byte

# origin of this code.. g_ms_rthunder
#
def decode_numchar ( c ):
    if c < 10:
        return chr ( ord ( '0' ) + c )
    return chr ( ord ( 'A' ) + c - 10 )

def decode_ascii ( c ):
    return chr ( c )
