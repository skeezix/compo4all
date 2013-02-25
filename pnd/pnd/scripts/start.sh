#!/bin/sh

export PATH="/mnt/utmp/c4a-mame/bin:${PATH:-"/usr/bin:/bin:/usr/local/bin"}"
export LD_LIBRARY_PATH="/mnt/utmp/c4a-mame/lib:${LD_LIBRARY_PATH:-"/usr/lib:/lib"}"
export HOME="/mnt/utmp/c4a-mame" XDG_CONFIG_HOME="/mnt/utmp/c4a-mame"
export SDL_VIDEODRIVER=omapdss
export SDL_OMAP_LAYER_SIZE=800x480
export SDL_OMAP_VSYNC=0
export SDL_OMAP_FORCE_DOUBLEBUF=1

if [ ! -d "/mnt/utmp/c4a-mame/.advance" ]; then
cd $HOME
export README='
<window title="C4A PanMAME First start" window_position="1" skip_taskbar_hint="true" decorated="false" width_request="600" height_request="400">
		<vbox>
			<button><action>cp -n -R /mnt/utmp/c4a-mame/defconf/* .|zenity --progress --title="Copy files progress" --text="Setting up folders..." --auto-close --pulsate && mkdir /mnt/utmp/c4a-mame/.advance && cp -n -R /mnt/utmp/c4a-mame/defconf/.advance/* /mnt/utmp/c4a-mame/.advance/|zenity --progress --pulsate --percentage=100 --title="Copy files progress" --text="Copying default config..." --auto-close</action><action type="exit">Exit by button</action></button>
			<text use-markup="true" wrap="false">
				<label>"<span fgcolor='"'black'"' bgcolor='"'white'"'>Click to setup /pandora/appdata/c4a-mame folder - add rom and restart</span>"</label>
			</text>
			<vbox scrollable="true">
				<text wrap="true">
					<label>C4A PanMAME readme</label>
					<input file>./PanMAME.TXT</input>
				</text>
			</vbox>
			<text use-markup="true">
				<label>"<span fgcolor='"'black'"' bgcolor='"'white'"'> C4A PanMAME readme </span>"</label>
			</text>
		</vbox>
</window>
'
exec /mnt/utmp/c4a-mame/bin/gtkdialog --program=README
else

cd $HOME
export MAIN_DIALOG='
<window window_position="1" title="PanMAME" decorated="false" width_request="600" height_request="360">
    <pixmap>
      <input file>/mnt/utmp/c4a-mame/artwork/splash.png</input>
    </pixmap>
</window>
'
exec /mnt/utmp/c4a-mame/bin/gtkdialog --program=MAIN_DIALOG &
fi

cp -n -R /mnt/utmp/c4a-mame/defconf/* .
mkdir /mnt/utmp/c4a-mame/.advance
cp -n -R /mnt/utmp/c4a-mame/defconf/.advance/* /mnt/utmp/c4a-mame/.advance/

if [ -d /mnt/utmp/c4a-mame/share ];then
	export XDG_DATA_DIRS=/mnt/utmp/c4a-mame/share:$XDG_DATA_DIRS:/usr/share
fi
export SDL_AUDIODRIVER="alsa"
cd $HOME

export NUB0MODE=`cat /proc/pandora/nub0/mode`
export NUB1MODE=`cat /proc/pandora/nub1/mode`
echo absolute > /proc/pandora/nub0/mode
echo absolute > /proc/pandora/nub1/mode

./c4a-fe.py

echo $NUB0MODE > /proc/pandora/nub0/mode
echo $NUB1MODE > /proc/pandora/nub1/mode

killall -9 gtkdialog
