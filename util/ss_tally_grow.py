#!/usr/bin/python

import sys
import json

filename = sys.argv [ 1 ]
size = int ( sys.argv [ 2 ] )

print "Grow %s to %s (new filename %s)" % ( filename, size, filename + ".new" )

# read
#
try:
    f = open ( filename, "r" )
    tallyfile = f.read()
    f.close()

    tally = json.loads ( tallyfile )
except:
    print "Exception READING, blew up"
    print "Unexpected error:", sys.exc_info()[0]
    sys.exit ( -1 )

# grow
#

print "Current scoreboard is %s long" % ( len ( tally [ 'scoreboard' ] ) )
newbiecount = size - len ( tally [ 'scoreboard' ] )
print "Adding %s entries (copying last entry in scoreboard)" % ( newbiecount )
template = tally [ 'scoreboard' ][ len ( tally [ 'scoreboard' ] ) - 1 ]

for i in range ( newbiecount ):
    tally [ 'scoreboard' ].append ( template )

# write
#
try:
    tallyfile = json.dumps ( tally )

    f = open ( filename + ".new", "w" )
    f.write ( tallyfile )
    f.close()
except:
    print "Exception WRITING, blew up"
    print "Unexpected error:", sys.exc_info()[0]
    sys.exit ( -1 )
