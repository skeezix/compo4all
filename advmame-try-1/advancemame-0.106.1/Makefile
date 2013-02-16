#############################################################################
# Automatic configuration
#
# Setup by the ./configure script. If you want to use the manual
# configuration edit the Makefile.usr file and NOT this file.
#

prefix=/mnt/utmp/panmame
datadir=${prefix}/share
sysconfdir=${prefix}/etc
exec_prefix=${prefix}
bindir=${exec_prefix}/bin
mandir=${prefix}/share/man
docdir=${prefix}/share/doc
CONF_EMU=mame
CONF_SYSTEM=unix
CONF_HOST=linux
CONF_BUILD=linux
CONF_LIB_DIRECT=yes
CONF_LIB_ZLIB=yes
CONF_LIB_EXPAT=yes
CONF_LIB_SVGALIB=no
CONF_LIB_FB=yes
CONF_LIB_ALSA=yes
CONF_LIB_OSS=yes
CONF_LIB_SDL=yes
CONF_LIB_FREETYPE=yes
CONF_LIB_SVGAWIN=no
CONF_LIB_PTHREAD=yes
CONF_LIB_SLANG=no
CONF_LIB_NCURSES=yes
CONF_LIB_KRAW=yes
CONF_LIB_JRAW=yes
CONF_LIB_MRAW=yes
CONF_LIB_KEVENT=yes
CONF_LIB_JEVENT=yes
CONF_LIB_MEVENT=yes
CONF_LIB_MRAWINPUT=no
CONF_LIB_MCPN=no
CONF_CFLAGS_ARCH= -DUSE_LSB
CONF_CFLAGS_OPT=-DPANDORA -DHAVE_GLES -O3 -pipe -march=armv7-a -mtune=cortex-a8 -mfpu=neon -mfloat-abi=softfp -ftree-vectorize -ffast-math -fsingle-precision-constant -fsigned-char
PNDPREFIX=/home/skeezix/archive/devo/projects/pandora-image/current/
CONF_LDFLAGS=-L${PNDPREFIX}/usr/lib -Wl,-rpath,${PNDPREFIX}/usr/lib -L/mnt/utmp/panmame/lib
CONF_DEBUGGER=no
CONF_DEBUG=no
CONF_DEFS=-DHAVE_CONFIG_H

# Checks
ifeq (CONF_EMU,$(findstring CONF_EMU,$(CONF_EMU)))
$(error For manual configuration you must use Makefile.usr)
endif

#############################################################################
# Extra configuration common for ./configure and manual

# Enable the creation of the map files
ifndef CONF_MAP
CONF_MAP=no
endif

# Name of the architecture. Used in the distribution file names.
ifndef CONF_ARCH
ifeq ($(CONF_DEBUG),yes)
CONF_ARCH=debug
else
CONF_ARCH=blend
endif
endif

# Pack also the emulator source in the dist package
ifndef CONF_DIFFSRC
CONF_DIFFSRC=no
endif

############################################################################
# Tools configuration for ./configure

srcdir=.
# Don't add the prefix @. This command must be used also in a shell script
INSTALL=/usr/bin/install -c
CC=@arm-none-linux-gnueabi-gcc -I./include
CXX=@arm-none-linux-gnueabi-g++
LD=arm-none-linux-gnueabi-gcc
LDXX=@arm-none-linux-gnueabi-g++
AR=@arm-none-linux-gnueabi-ar
ASM=@
RC=@
LN_S=@ln -s
MD=-@mkdir -p
RM=@rm -f
ECHO=@echo
CC_FOR_BUILD=@gcc
LD_FOR_BUILD=@gcc
CXX_FOR_BUILD=@g++
LDXX_FOR_BUILD=@g++
EXE=
EXE_FOR_BUILD=
SDLCFLAGS=-I./include/SDL -D_GNU_SOURCE=1 -D_REENTRANT -I./include
SDLLIBS=-L${PNDPREFIX}/usr/lib -Wl,-rpath,${PNDPREFIX}/lib -lSDL -lpthread
FREETYPECFLAGS=-I./include/freetype2/ -I./include/freetype2/freetype/config
FREETYPELIBS=-L${PNDPREFIX}/lib -lfreetype
ASMFLAGS=-f elf
CFLAGS_FOR_BUILD=-O0 -DUSE_COMPILER_GNUC -DUSE_OBJ_ELF -DUSE_OS_UNIX
INSTALL_PROGRAM_DIR = $(INSTALL) -d -m 755
INSTALL_MAN_DIR = $(INSTALL) -d -m 755
INSTALL_DATA_DIR = $(INSTALL) -d -m 755
INSTALL_PROGRAM = $(INSTALL) -c -m 755
INSTALL_MAN = $(INSTALL) -c -m 644
INSTALL_DATA = $(INSTALL) -c -m 644

#############################################################################
# Root makefile

include $(srcdir)/root.mak


