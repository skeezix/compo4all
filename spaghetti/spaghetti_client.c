
// #define SPAG_DEBUG 1

#include <limits.h> // PATHNAME_MAX
#include <unistd.h> // unlink
#include <stdio.h>
#include <string.h> // strcmp

#include "spaghetti.h"

static unsigned char fexist ( char *path ) {
  // lamely done
  FILE *f = fopen ( path, "r" );
  if ( ! f ) {
    return ( 0 );
  }
  fclose ( f );
  return ( 1 );
}

int main ( int argc, char **argv ) {

  // sc push [-d] gamename
  // sc pull gamename

  if ( argc < 3 ) {
    fprintf ( stderr, "Not enough arguments.\n" );
    _exit ( -1 );
  }

  // push mode?
  if ( strcmp ( argv [ 1 ], "push" ) == 0 ) {
    char fullpath [ PATH_MAX + 1 ];
    char *gamename;
    unsigned char delflag = 0;

    // determine gamename in args
    gamename = argv [ 2 ];
    if ( gamename [ 0 ] == '-' ) {

      // .. and delete flag?
      if ( strcmp ( gamename + 1, "d" ) == 0 ) {
        delflag = 1;
#ifdef SPAG_DEBUG
        printf ( ".. and wishing to delete file\n" );
#endif
      }

      gamename = argv [ 3 ];
    }

    // .. and full path
    snprintf ( fullpath, PATH_MAX, "./hi/%s.hi", gamename );

    // good?
    if ( ! fexist ( fullpath ) ) {
      fprintf ( stderr, "Abort, Retry, Fail?\n" );
      _exit ( -3 );
    }

#ifdef SPAG_DEBUG
    printf ( "debug: %s\n", fullpath );
#endif

    // push up to the server
    int r = spaghetti_post_wrapper ( gamename, fullpath );

    if ( r != 0 ) {
      fprintf ( stderr, "retval: %d\n", r );
      _exit ( -1 );
    }

    // and if good, maybe kill the local file as well
    if ( delflag ) {
#ifdef SPAG_DEBUG
      printf ( "Deleting file!\n" );
#endif
      unlink ( fullpath );
    }

    return ( 0 );
  }

  // pull mode?
  // sc pull gamename
  char fullpath [ PATH_MAX + 1 ];
  char tmppath [ PATH_MAX + 1 ];
  char *gamename = argv [ 2 ];
  char url [ PATH_MAX + 1 ];

  // .. and full path
  snprintf ( fullpath, PATH_MAX, "./hi/%s.hi", gamename );
  snprintf ( tmppath, PATH_MAX, "./hi/%s.tmp", gamename );

  // .. and url
  snprintf ( url, PATH_MAX, "%s/%s_%s/%s",
             SPAGHETTI_SERVER_BASE, "hi", SPAGHETTI_VER, gamename );

  void *hibuf;
  unsigned int hibuflen;
  int r = spaghetti_get_ram ( url, &hibuf, &hibuflen );

  if ( r < 0 ) {
    fprintf ( stderr, "retval: %d\n", r );
    _exit ( -1 );
  }

  FILE *f = fopen ( tmppath, "w" );

  if ( ! f ) {
    fprintf ( stderr, "couldn't write file\n" );
    _exit ( -2 );
  }

#ifdef SPAG_DEBUG
  printf ( "get: received %d bytes\n", hibuflen );
#endif

  if ( fwrite ( hibuf, hibuflen, 1, f ) != 1 ) {
    fprintf ( stderr, "couldn't transfer whole file\n" );
    fclose ( f );
    unlink ( tmppath );
    _exit ( -3 );
  }

  fclose ( f );

  unlink ( fullpath );

  rename ( tmppath, fullpath );

  return ( 0 );
}
