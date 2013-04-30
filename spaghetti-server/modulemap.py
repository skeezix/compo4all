
# map a game to either single score or tabular handlers for overall logic
#

import logging
import sys

import singlescore_handler
import multiscore_handler
import hitotext_handler

import g_ss_mspacman
import g_ss_galaxian
import g_ss_invaders
import g_ms_rthunder
import g_ms_dkong
import g_ms_dkongjr
import g_ms_fshark # sky shark
import g_ms_mrdo
import g_ms_pulstar
import g_ms_bublbobl
import g_ms_rygar
import g_ms_kod
import g_ms_hi_stub

gamemap = dict()

# status in 'active', 'available', 'unavailable'
def register ( gamename, longname, handler, module, status, field, genre = None ):

    if gamename in gamemap:
        logging.error ( "FAIL REGISTER: %s is %s - already a game with this name" % ( gamename, status ) )
        sys.exit ( -1 )
        return None

    g = dict()

    g [ 'gamename' ] = gamename
    g [ 'handler' ] = handler
    g [ 'module' ] = module
    g [ 'longname' ] = longname
    g [ 'status' ] = status
    g [ 'field' ] = field
    g [ 'genre' ] = genre
    g [ '_last_tally_update_e' ] = handler.get_last_modify_epoch ( g )

    gamemap [ gamename ] = g

    logging.info ( "REGISTER: %s is %s" % ( gamename, status ) )

# really should make an interface, a class for each, and mixins for the handler+module ..

register ( 'bublbobl', 'Bubble Bobble',   multiscore_handler,  g_ms_bublbobl,   'active', 'arcade', 'platform' )
register ( 'dkong',    'Donkey Kong',     multiscore_handler,  g_ms_dkong,      'active', 'arcade', 'platform' )
register ( 'dkongjr',  'Donkey Kong Jr.', multiscore_handler,  g_ms_dkongjr,    'active', 'arcade', 'platform' )
register ( 'fshark',   'Flying Shark',    multiscore_handler,  g_ms_fshark,     'active', 'arcade', 'shmup' )
register ( 'galaxian', 'Galaxian',        singlescore_handler, g_ss_galaxian,   'active', 'arcade', 'shmup' )
register ( 'invaders', 'Space Invaders',  singlescore_handler, g_ss_invaders,   'active', 'arcade', 'shmup' )
register ( 'kod',      'King of Dragons', multiscore_handler,  g_ms_kod,        'active', 'arcade', 'beatemup' )
register ( 'mrdo',     'Mr. Do!',         multiscore_handler,  g_ms_mrdo,       'active', 'arcade', 'maze' )
register ( 'mspacman', 'Ms. Pacman',      singlescore_handler, g_ss_mspacman,   'active', 'arcade', 'maze' )
register ( 'pulstar',  'Pulstar',         multiscore_handler,  g_ms_pulstar,    'active', 'arcade', 'shmup' )
register ( 'rthunder', 'Rolling Thunder', multiscore_handler,  g_ms_rthunder,   'unavailable', 'arcade', 'platform' ) # coded, emu sucks
register ( 'rygar',    'Rygar',           multiscore_handler,  g_ms_rygar,      'active', 'arcade', 'runngun' )
# HiToText based ones
register ( 'ladybug',  'Ladybug',         hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'maze' )
register ( 'raiden',   'Raiden',          hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'shmup' )
#register ( 'blktiger', 'Black Tiger',     hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'runngun' )
#register ( 'btime',    'Burger Time',     hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'platform' )
