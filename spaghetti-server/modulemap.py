
# map a game to either single score or tabular handlers for overall logic
#

import singlescore_handler
import multiscore_handler

mapper = dict()
mapper [ 'mspacman' ] = singlescore_handler
mapper [ 'galaxian' ] = singlescore_handler
mapper [ 'dkong' ] = multiscore_handler

# in turn, those handlers may need to map some specific functions to a module .. mspacman's overall strategy is singlescore,
# but galaxian and mspacman have different encodings for the score. Same logic, different details.
#

import g_ss_mspacman
import g_ss_galaxian

drivermap = dict()
drivermap [ 'mspacman' ] = g_ss_mspacman
drivermap [ 'galaxian' ] = g_ss_galaxian
