#!/usr/bin/python

import sys
import json
import pprint

inp = '{"hi": 32500, "scoreboard": [{"shortname": "EVD", "score": 32500, "longname": "EvilDragon", "time": 1361558768}, {"shortname": "MRL", "score": 26310, "longname": "MrLoon", "time": 1361546333}, {"shortname": "BUD", "score": 23640, "longname": "Budweiser", "time": 1361548136}, {"shortname": "EVD", "score": 21740, "longname": "EvilDragon", "time": 1361552329}, {"shortname": "SKZ", "score": 17170, "longname": "SkeezixPandora", "time": 1361547110}, {"shortname": "BUD", "score": 12830, "longname": "Budweiser", "time": 1361505304}, {"shortname": "ANG", "score": 12830, "longname": "ang", "time": 1361531755}, {"shortname": "COB", "score": 9710, "longname": "Cobalt", "time": 1361559884}, {"shortname": "MRL", "score": 6320, "longname": "MrLoon", "time": 1361545940}, {"shortname": "MCO", "score": 5920, "longname": "mcobit", "time": 1361522882}, {"shortname": "SKZ", "score": 4440, "longname": "SkeezixPandora", "time": 1361546810}, {"shortname": "SKZ", "score": 1140, "longname": "SkeezixPandora", "time": 1361502323}, {"shortname": "SKZ", "score": 470, "longname": "SkeezixPandora", "time": 1361546213}, {"shortname": "SKZ", "score": 380, "longname": "SkeezixPandora", "time": 1361505181}, {"shortname": "SKZ", "score": 270, "longname": "SkeezixPandora", "time": 1361425033}, {"shortname": "SKZ", "score": 270, "longname": "SkeezixPandora", "time": 1361424995}, {"shortname": "SKZ", "score": 270, "longname": "SkeezixPandora", "time": 1361422524}, {"shortname": "SKZ", "score": 270, "longname": "SkeezixPandora", "time": 1361421005}, {"shortname": "SKZ", "score": 270, "longname": "SkeezixPandora", "time": 1361420929}, {"shortname": "", "score": 0, "longname": "", "time": 0}, {"shortname": "", "score": 0, "longname": "", "time": 0}, {"shortname": "", "score": 0, "longname": "", "time": 0}, {"shortname": "", "score": 0, "longname": "", "time": 0}, {"shortname": "", "score": 0, "longname": "", "time": 0}, {"shortname": "", "score": 0, "longname": "", "time": 0}], "prid": "b992c4cd-a3ba-4e4b-baa0-5ffb27c0adfd"}'
#inp = '{"gamelist": [{"_last_tally_update_e": 1361552329, "gamename": "mspacman", "longname": "Ms. Pacman"}]}'
#inp = sys.argv [ 1 ]
j = json.loads ( inp )
pp = pprint.PrettyPrinter ( indent = 4 )

pp.pprint ( j )

