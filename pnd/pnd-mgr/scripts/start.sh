#!/bin/sh

export PATH="/mnt/utmp/c4a-mame/bin:${PATH:-"/usr/bin:/bin:/usr/local/bin"}"
export LD_LIBRARY_PATH="/mnt/utmp/c4a-mame/lib:${LD_LIBRARY_PATH:-"/usr/lib:/lib"}"
export HOME="/mnt/utmp/c4a-mame" XDG_CONFIG_HOME="/mnt/utmp/c4a-mame"

./c4a-fe.py
