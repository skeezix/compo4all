
'''
Keeps 5 scores

Rank
Score
Area
Initials

1st     30000   5       ALB
2nd     20000   4       LIR
3rd     10000   3       GLR
2nd     8000    2       MAB
5th     4000    1       MPI

Scores are BCD
Area is BCD
   ssss ssAA iiii ii
   0030 0005 0a15 0b            1st
   00 2000 0415 12 1b           2nd
   0010 0003 1015 1b           3rd
   00 0800 0216 0a 0b          4th
   0004 0001 1619 12           5th

00000000: 0030 0005 0a15 0b00 2000 0415 121b 0010  .0...... .......
00000010: 0003 1015 1b00 0800 0216 0a0b 0004 0001  ................
00000020: 1619 1200 3000                           ....0.

'''

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
