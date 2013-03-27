#!/usr/bin/python

import sys
import os

os.chdir ( "/home/skeezix/compo4all" )
sys.path.append ( os.getcwd() )

import modulemap
import singlescore_handler

if len ( sys.argv ) <= 1:
    print "./foo prid gamename scorenum"
    print "run from spagserver.py location"
    sys.exit ( 0 )

req = dict()
req [ 'prid' ] = sys.argv [ 1 ]
req [ 'gamename' ] = sys.argv [ 2 ]
hi = int( sys.argv [ 3 ] )

print "Attempting insert of score %s" % ( hi )

singlescore_handler.update_hi ( req, score_int=hi )
