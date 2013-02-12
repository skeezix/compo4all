#!/bin/sh

DIR_FILE="./dirs.rc"

# Get any existing settings
if [ -f $DIR_FILE ] ; then
	. $DIR_FILE
fi

# Remember our current location
OLDPWD=`pwd`

if [ -n "$ROM_DIR" ] ; then
	cd $ROM_DIR/..
fi
ROM_DIR="`zenity --file-selection --directory --title='Select your ROMs directory'`"

if [ -n "$SAMPLE_DIR" ] ; then
	cd $SAMPLE_DIR/..
fi
SAMPLE_DIR="`zenity --file-selection --directory --title='Select your samples directory'`"

rm -f $DIR_FILE
echo "ROM_DIR=\"$ROM_DIR\"" >> $DIR_FILE
echo "SAMPLE_DIR=\"$SAMPLE_DIR\"" >> $DIR_FILE

