#!/usr/bin/env bash
GAME=$1

#echo "Processing game: $GAME"

export HISTIGNORE="expect*";
 
expect -c "
    set timeout 5
    spawn mono ../HiToText.exe
    match_max 100000
    expect \">\"
    send -- \"-r $GAME\n\"
    expect \">\"
    send -- \"-q\n\"
    expect eof" | head -n -4 | tail -n +6
    #| sed '/.*/d' | sed '/>.*/d' | sed '/spawn.*/d' | sed '/Exiting.*/d' | sed '/Error.*/d' | sed '/HiToText.*/d' | sed '/RANK.*/d' | sed -e "1d" | sed 's/\r//g'

#echo $OUTPUT | cut -d';' -f2
#$OUTPUT=`echo '$OUTPUT' | sed 's///g'`
#$OUTPUT=`echo '$OUTPUT' | sed 's/\r//g'`
#echo $OUTPUT

export HISTIGNORE="";
