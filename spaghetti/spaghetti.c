
//#define SPAG_MAIN 1

#include <stdio.h>
#include <strings.h> // bzero
#include <string.h> // strncpy
#include <unistd.h> // exit

#include "spaghetti.h"

int spaghetti_get_prid ( char *r_pridbuf, unsigned int buflen ) {
  char buf [ PRID_MAXLEN + 1 ];

  bzero ( buf, PRID_MAXLEN + 1 );

  FILE *f = fopen ( PRID_FULLPATH, "rb" );

  if ( ! f ) {
    return ( -1 );
  }

  if ( ! fgets ( buf, PRID_MAXLEN, f ) ) {
    fclose ( f );
    return ( -1 );
  }

  fclose ( f );

  if ( strchr ( buf, '\n' ) ) {
    * strchr ( buf, '\n' ) = '\0';
  }

  strncpy ( r_pridbuf, buf, buflen );

  return ( 0 );
}

int spaghetti_post_wrapper ( char *gamename, char *fullpath ) {
  char final_url [ 1024 ];

  char pridbuf [ PRID_MAXLEN + 1 ];
  char emuname [ 10 ];
  char platbuf [ 20 ];

  // reset
  bzero ( final_url, 1024 );
  bzero ( pridbuf, PRID_MAXLEN + 1 );

  // intuit..
  sprintf ( emuname, "advmame" );
  sprintf ( platbuf, "pandora" );
  if ( spaghetti_get_prid ( pridbuf, PRID_MAXLEN ) < 0 ) {
    return ( -1 );
  }

  // update urlbase for live details
  // EN -> emuname
  // ES -> emu size (swapped top/bottom 16bits)
  // GN -> game name (such as "mspacman")
  // PRID -> user "unique-id"

  // determine url
  snprintf ( final_url, 1023, "%s/%s_%s/%s/%s/%s/%s",
             SPAGHETTI_SERVER_BASE, "tally", SPAGHETTI_VER,
             gamename, platbuf, emuname, pridbuf );

  // attempt to POST it
  return ( spaghetti_post_file ( fullpath, final_url ) );
}

#ifdef SPAG_MAIN
int main ( int argc, char **argv ) {

  if ( argc < 3 ) {
    fprintf ( stderr, "Not enough arguments. gamename, file-to-send.\n" );
    _exit ( -1 );
  }

  int r = spaghetti_post_wrapper ( argv [ 1 ], argv [ 2 ] );

  printf ( "retval: %d\n", r );

  return ( 0 );
}
#endif

int spaghetti_plugpost_wrapper ( char *plugin, char *gamename, char *platform, char *data, char *fullpath ) {
  char final_url [ 1024 ];
  char pridbuf [ PRID_MAXLEN + 1 ];

  // reset
  bzero ( final_url, 1024 );
  bzero ( pridbuf, PRID_MAXLEN + 1 );

  // intuit..
  if ( spaghetti_get_prid ( pridbuf, PRID_MAXLEN ) < 0 ) {
    return ( -1 );
  }

  // update urlbase for live details
  // EN -> emuname
  // ES -> emu size (swapped top/bottom 16bits)
  // GN -> game name (such as "mspacman")
  // PRID -> user "unique-id"

  // determine url
  snprintf ( final_url, 1023, "%s/%s_%s/%s/%s/%s/%s?%s",
             SPAGHETTI_SERVER_BASE, "plugtally", SPAGHETTI_VER,
             plugin, gamename, platform, pridbuf, data );

  // attempt to POST it
  return ( spaghetti_post_file ( fullpath, final_url ) );
}
