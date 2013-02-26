import sys

# hexdump() -> returns a (multiline) string buffer that is a hexdump of the provided buffer
#   chars -> the input buffer to dump
#   sep -> spacing characters to use; default is ' ' (space)
#   width -> number of hex columns to show; default is 16
#    16 is like:  69 6d 70 6f 72 74 20 73 79 73 0a 0a 64 65 66 20 import.sys..def.
#   linesep -> default to newline
def hexdump( chars, sep = ' ', width = 16, linesep = '\n' ):
    accum = str()

    while chars:
        line = chars[:width]
        chars = chars[width:]
        line = line.ljust( width, '\000' )

        b = "%s%s%s" % ( sep.join( "%02x" % ord(c) for c in line ),
                         sep, quotechars ( line ) )

        accum += b
        accum += linesep

    return accum

# -----------------------------------------------------------

def quotechars( chars ):
    return ''.join( ['.', c][c.isalnum()] for c in chars )

def file_section( name, start, end ):
    contents = open( name, "rb" ).read()
    return contents[start:end]

if __name__ == '__main__':
    hexdump( file_section( sys.argv[1], int( sys.argv[2] ), int( sys.argv[3] )),
             ' ', int( sys.argv[4] ))
