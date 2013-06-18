
import logging
import profile
import json
import os
import sys
import modulemap
from paths import _basepath
import copy

from modulemap import register
import state
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

# why aren't I using classes in any of this code? and a nice abstracted pure-interface def'n class? ... oh, right, sleepdep.

logging.info ( "LOADING: arcade plugin" )

def init():

    general = {
        "execinfo": {
                "pandora": {
                           "type": "arcade",
                           "pnd_unique_id": "c4a-skeezix-0001",
                           "last_known_filename_hint": "compo4all-mame.pnd",
                           "command_line_add": "**GAMENAME**",
                           "last_known_appdata_hint": "c4a-mame",
                           "file_dependancies_hint": "rom/**GAMENAME**.zip"
                }
         }
    }

    register ( 'bublbobl', 'Bubble Bobble',   multiscore_handler,  g_ms_bublbobl,   'available', 'arcade', 'platform', cx ( general, 'bublbobl' ) )
    register ( 'dkong',    'Donkey Kong',     multiscore_handler,  g_ms_dkong,      'available', 'arcade', 'platform', cx ( general, 'dkong' ) )
    register ( 'dkongjr',  'Donkey Kong Jr.', multiscore_handler,  g_ms_dkongjr,    'available', 'arcade', 'platform', cx ( general, 'dkongjr' ) )
    register ( 'fshark',   'Flying Shark',    multiscore_handler,  g_ms_fshark,     'available', 'arcade', 'shmup', cx ( general, 'fshark' ) )
    register ( 'galaxian', 'Galaxian',        singlescore_handler, g_ss_galaxian,   'available', 'arcade', 'shmup', cx ( general, 'galaxian' ) )
    register ( 'invaders', 'Space Invaders',  singlescore_handler, g_ss_invaders,   'available', 'arcade', 'shmup', cx ( general, 'invaders' ) )
    register ( 'kod',      'King of Dragons', multiscore_handler,  g_ms_kod,        'available', 'arcade', 'beatemup', cx ( general, 'kod' ) )
    register ( 'mrdo',     'Mr. Do!',         multiscore_handler,  g_ms_mrdo,       'available', 'arcade', 'maze', cx ( general, 'mrdo' ) )
    register ( 'mspacman', 'Ms. Pacman',      singlescore_handler, g_ss_mspacman,   'available', 'arcade', 'maze', cx ( general, 'mspacman' ) )
    register ( 'pulstar',  'Pulstar',         multiscore_handler,  g_ms_pulstar,    'available', 'arcade', 'shmup', cx ( general, 'pulstar' ) )
    register ( 'rthunder', 'Rolling Thunder', multiscore_handler,  g_ms_rthunder,   'unavailable', 'arcade', 'platform', cx ( general, 'rthunder' ) ) # coded, emu sucks
    register ( 'rygar',    'Rygar',           multiscore_handler,  g_ms_rygar,      'available', 'arcade', 'runngun', cx ( general, 'rygar' ) )
    # HiToText based ones
    register ( 'ladybug',  'Ladybug',         hitotext_handler,    g_ms_hi_stub,    'available', 'arcade', 'maze', cx ( general, 'ladybug' ) )
    register ( 'raiden',   'Raiden',          hitotext_handler,    g_ms_hi_stub,    'available', 'arcade', 'shmup', cx ( general, 'raiden' ) )
    register ( 'blktiger', 'Black Tiger',     hitotext_handler,    g_ms_hi_stub,    'available', 'arcade', 'runngun', cx ( general, 'blktiger' ) )
    register ( 'btime',    'Burger Time',     hitotext_handler,    g_ms_hi_stub,    'available', 'arcade', 'platform', cx ( general, 'btime' ) )
    register ( 'sf2',      'Street Fighter 2',  hitotext_handler,  g_ms_hi_stub,    'available', 'arcade', 'fighting', cx ( general, 'sf2' ) )
    register ( 'gng',      "Ghosts'n Goblins",  hitotext_handler,  g_ms_hi_stub,    'available', 'arcade', 'runngun', cx ( general, 'gng' ) )
    register ( 'frogger',  "Frogger",         hitotext_handler,    g_ms_hi_stub,    'available', 'arcade', 'maze', cx ( general, 'frogger' ) )
    # HiToTex 2013 May additions
    #register ( 'aliensyn', "Alien Syndrome",  hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'runngun', cx ( general, 'aliensyn' ) )
    register ( 'asteroid', "Asteroids",       hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'shmup', cx ( general, 'asteroid' ) )
    #register ( 'berzerk',  "Berzerk",         hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'maze', cx ( general, 'berzerk' ) )
    #register ( 'bosco',    "Bosconian",       hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'shmup', cx ( general, 'bosco' ) )
    #register ( 'citycon',  "City Connection", hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'platform', cx ( general, 'citycon' ) )
    register ( 'galaga',   "Galaga",          hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'shmup', cx ( general, 'galaga' ) )
    register ( 'goldnaxe', "Golden Axe",      hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'beatemup', cx ( general, 'goldnaxe' ) )
    #register ( 'inthunt',  "Into the Hunt",   hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'shmup', cx ( general, 'inthunt' ) )
    #register ( 'nrallyx',  "New Rally X",     hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'racing', cx ( general, 'nrallyx' ) )
    #register ( 'quartet',  "Quartet",         hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'runngun', cx ( general, 'quartet' ) )
    register ( 'scramble', "Scramble",        hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'shmup', cx ( general, 'scramble' ) )
    register ( 'tigeroad', "Tiger Road",      hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'beatemup', cx ( general, 'tigeroad' ) )
    register ( 'wboy',     "Wonderboy",       hitotext_handler,    g_ms_hi_stub,    'active', 'arcade', 'runngun', cx ( general, 'wboy' ) )

def cx ( d, gamename ): # customize and return dupe

    new = copy.deepcopy ( d )

    for k, v in new [ 'execinfo' ][ 'pandora' ].iteritems():
        if "**GAMENAME**" in v:
            new [ 'execinfo' ][ 'pandora' ][ k ] = v.replace ( '**GAMENAME**', gamename )

    return new
