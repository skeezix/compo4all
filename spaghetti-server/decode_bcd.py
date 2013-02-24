
# test: bcd_byte_to_int ( int('10011000',2) ) -> 98
def bcd_byte_to_int ( bcd ):
    # int decimal = (bcd & 0xF) + (((int)bcd & 0xF0) >> 4)*10;
    first = bcd & int('0x0F',16)
    second = ( bcd & int('0xF0',16) ) >> 4
    value = first + (second*10)
    #print 'bcd', bcd, 'break', first, second
    return value

def bcd_2byte_to_int ( lo_bcd, hi_bcd ):
    return bcd_byte_to_int ( lo_bcd ) | ( bcd_byte_to_int ( hi_bcd ) << 8 )

# take a 2char string and return a bcd-byte; so feed it "01" and not just "1"
def int2_to_bcd_byte ( source ):
    return int(source [ 1 ]) | ( int(source [ 0 ]) << 4 )
