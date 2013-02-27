
# map a game to either single score or tabular handlers for overall logic
#

import logging

import singlescore_handler
import multiscore_handler

import g_ss_mspacman
import g_ss_galaxian
import g_ss_invaders
import g_ms_rthunder
import g_ms_dkong
import g_ms_fshark # sky shark

gamemap = dict()

# status in 'active', 'available', 'unavailable'
def register ( gamename, longname, handler, module, status ):

    g = dict()

    g [ 'gamename' ] = gamename
    g [ 'handler' ] = handler
    g [ 'module' ] = module
    g [ 'longname' ] = longname
    g [ 'status' ] = status
    g [ '_last_tally_update_e' ] = handler.get_last_modify_epoch ( g )

    gamemap [ gamename ] = g

    logging.info ( "REGISTER: %s is %s" % ( gamename, status ) )

# really should make an interface, a class for each, and mixins for the handler+module ..

register ( 'mspacman', 'Ms. Pacman',      singlescore_handler, g_ss_mspacman, 'active' )
register ( 'galaxian', 'Galaxian',        singlescore_handler, g_ss_galaxian, 'active' )
register ( 'invaders', 'Space Invaders',  singlescore_handler, g_ss_invaders, 'active' )
register ( 'rthunder', 'Rolling Thunder', multiscore_handler,  g_ms_rthunder, 'unavailable' ) # coded, emu is not writing hi out :/
register ( 'dkong',    'Donkey Kong',     multiscore_handler,  g_ms_dkong,    'active' )
register ( 'fshark',   'Flying Shark',    multiscore_handler,  g_ms_fshark,   'active' )
