
import logging
import json
import sys

NULL_PROFILE = dict()
NULL_PROFILE [ 'shortname' ] = ''
NULL_PROFILE [ 'longname' ] = ''
NULL_PROFILE [ 'email' ] = ''
NULL_PROFILE [ 'password' ] = ''

def fetch_pridfile_as_dict ( prid ):
    print "++", prid

    try:
        f = open ( "runtime/profiles/" + prid + ".json", 'r' )
    except:
        logging.error ( "Couldn't locate pridfile for %s" % ( prid ) )
        print "Unexpected error:", sys.exc_info()
        return None

    try:
        j = f.read()
        pridfile = json.loads ( j )
        f.close()
        return pridfile
    except:
        logging.error ( "Error loading pridfile for %s" % ( prid ) )
        print "Unexpected error:", sys.exc_info()
        pass

    f.close()

    return None
