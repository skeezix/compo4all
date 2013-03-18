#!/usr/bin/python

import os

print "cwd:", os.getcwd()
os.chdir ( "/home/skeezix/compo4all" )

import sys

sys.path.append ( os.getcwd() )

import datetime

import activity_log

"""
if len ( sys.argv ) <= 1:
    print "./foo"
    print "run from spagserver.py location"
    sys.exit ( 0 )
"""

req = dict()
al = activity_log._readlog ( req )

report = dict()
reportbyday = dict()

for aent in al:
    # ent [ time ] -- epoch time

    if aent [ 'time' ] == 0:
        break

    d = datetime.date.fromtimestamp ( aent [ 'time' ] )

    try:
        report [ str(d.year) + '/' + str(d.month) + 'ym' ] += 1
    except:
        report [ str(d.year) + '/' + str(d.month) + 'ym' ] = 1

    try:
        reportbyday [ str(d.year) + '/' + str(d.month) + '/' + str(d.day) + 'ymd' ] += 1
    except:
        reportbyday [ str(d.year) + '/' + str(d.month) + '/' + str(d.day) + 'ymd' ] = 1

print "by-month"
for k,v in report.iteritems():
    print k, v

print "by-day"
for k,v in reportbyday.iteritems():
    print k, v
