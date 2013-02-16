#!/usr/bin/python

import struct
import sys
import array
import os

import hexdump

def fetch_file_as_list ( filename ):
    file = []

    f = open ( filename, "rb" )
    try:

        byte = f.read(1)

        while byte != "":
            byte = f.read(1)
            file.append ( byte )

    finally:
        f.close()

    return file

def fetch_file_as_array ( filename ):
    a = array.array ( 'B' )

    f = open ( filename, "rb" )
    try:
        a.fromfile ( f, os.path.getsize ( filename ) )
    finally:
        f.close()

    return a

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

# ---[ do it ]--------------------------------

data = fetch_file_as_array ( "bombjack.hi" )

if len ( data ) == 0:
    print "Couldn't read file"
    sys.exit ( -1 )

print "File length:", len ( data )
#print data
#print data.tostring()
print hexdump.hexdump ( data.tostring() ),

print struct.calcsize ( '<H' )
#string = '\x00\x00'
#string = '\x30\x30'
string = chr ( data [ 164 ] ) + chr ( data [ 165 ] )
string = chr ( data [ 0 ] ) + chr ( data [ 1 ] )
print struct.unpack ( "<H", string )
print hexdump.hexdump ( string )
print bcd_byte_to_int ( int('10011000',2) )

table_round = [0]*10
for x in range ( 56, 56+10 ):
    table_round [ x - 56 ] = data [ x ]
    #print x, data [ x ], hex(data[x])
print "round achieved", table_round

table_initials = ['']*10
table_initials [ 0 ] = chr( data [ 68 ] ) + chr( data [ 70 ] ) + chr( data [ 72 ] )
print table_initials
