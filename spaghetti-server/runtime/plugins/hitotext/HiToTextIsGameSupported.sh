#!/usr/bin/env bash

containsElement () {
    local e
    for e in "${@:2}"; do [[ "$e" == "$1" ]] && return 0; done
    return 1
}

GAME=$1
GAME_LIST=(`./HiToTextSupportedGameList.sh`)

containsElement "$GAME" "${GAME_LIST[@]}"
echo $?
