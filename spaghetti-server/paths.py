
import datetime   # datetime.now()

def _basepath ( req ):
    now = datetime.datetime.now()
    writepath = "runtime/hidb/" + req [ 'gamename' ] + "/" + str(now.year) + "." + str('%02d'%now.month) + "/"
    return writepath
