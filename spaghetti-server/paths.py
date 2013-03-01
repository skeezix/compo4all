
import logging
import datetime   # datetime.now()

def _basepath ( req ):
    if '_backdate' in req:
        writepath = "runtime/hidb/" + req [ 'gamename' ] + "/" + req [ '_backdate' ][0:4] + '.' + req [ '_backdate' ][4:6] + "/"
    else:
        now = datetime.datetime.now()
        writepath = "runtime/hidb/" + req [ 'gamename' ] + "/" + str(now.year) + "." + str('%02d'%now.month) + "/"
    #logging.debug ( "_basepath() returns %s" % ( writepath ) )
    return writepath

def templatepath ( req ):
    path = "runtime/templates/" + req [ 'gamename' ] + ".hi"
    return path
