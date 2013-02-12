#!/bin/bash

DIR_FILE="./dirs.rc"

mkdir -p artwork cfg frontend hi inp memcard nvram roms samples snap
if [ ! -f frontend/mame.cfg ] ; then
	cp default.cfg frontend/mame.cfg
fi

if [ -f $DIR_FILE ] ; then
	. $DIR_FILE
else
	touch $DIR_FILE
	TEXT="MAME4ALL needs to know the locations of the following items:\n\n"
	TEXT="${TEXT} - Your ROM files (the games you wish to play).\n"
	TEXT="${TEXT} - Optionally, sound samples for the above.\n\n"
	TEXT="${TEXT}You will be prompted for each of these locations. It is "
	TEXT="${TEXT}safe to cancel these requests, in which case the default "
	TEXT="${TEXT}locations will be assumed. You can change these settings "
	TEXT="${TEXT}later by running \"Settings\" -\> \"MAME4ALL Settings\"."
	zenity --info --title="MAME4ALL" --text="$TEXT"
	./settings.sh
	. $DIR_FILE
fi

export ROMPATH="$ROM_DIR"
export SAMPLEPATH="$SAMPLE_DIR"

op_runfbapp ./mame-fe

# In case we bailed out...
sudo /usr/pandora/scripts/op_videofir.sh default
ofbset -fb /dev/fb1 -pos 0 0 -size 0 0 -mem 0 -en 0

