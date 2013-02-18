#ifndef h_spaghetti_h
#define h_spaghetti_h

#define SPAGHETTI_VER "1" /* urls base page appended with _+VER */
#define SPAGHETTI_SERVER_BASE "http://127.0.0.1:13001"

// SERVER SHOULD BE-WARY .. all of this could be faked with a wget and full of nasty stuff

//#define SPAGHETTI_POST_URL_BASE "http://127.0.0.1:13001/tally/%GN/%PLATFORM%/%EN%/%PRID%"
// http://127.0.0.1:13001/tally/%EN%/%ES%/%GN%/%PRID%
// http://127.0.0.1:13001/tally/advmame/123455/mspacman/12345:12:13:15

#define PRID_FULLPATH "./c4a-prof"
#define PRID_MAXLEN 128

typedef struct {
  char *prid;           /* profile-id reasonably unique pseudo-random string */
  char *display_name;   /* name to be shown on score tally websites */
  char *short_name;     /* 3 char (or less) name to be stuffed into game score tables */
  char *email_address;  /* email addy to spam to */
} spaghetti_t;

// buflen should be PRID_MAXLEN or larger
// retuns: 0 on success (implies pridbuf is modified)
//        <0 on error (implies buffer unmodified)
int spaghetti_get_prid ( char *r_pridbuf, unsigned int buflen );

// send hi-file to server, nice and easy
// returns: 0 on success
//         <0 on error
//         -1 .. not not determine prid
int spaghetti_post_wrapper ( char *gamename, char *fullpath );

#endif
