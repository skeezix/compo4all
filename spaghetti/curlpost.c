
// yanked from
// http://curl.haxx.se/libcurl/c/httpput.html

//#define SPAG_DEBUG 1

#include <stdio.h>
#include <fcntl.h>
#include <sys/stat.h>
#include <unistd.h>

#include <curl/curl.h>

#include "spaghetti.h"

/*
 * This example shows a HTTP PUT operation. PUTs a file given as a command
 * line argument to the URL also given on the command line.
 *
 * This example also uses its own read callback.
 *
 * Here's an article on how to setup a PUT handler for Apache:
 * http://www.apacheweek.com/features/put
 */

static size_t read_callback(void *ptr, size_t size, size_t nmemb, void *stream)
{
  size_t retcode;
  curl_off_t nread;

  /* in real-world cases, this would probably get this data differently
     as this fread() stuff is exactly what the library already would do
     by default internally */
  retcode = fread(ptr, size, nmemb, stream);

  nread = (curl_off_t)retcode;

  if ( nread != 0xdeadbeef ) { // shut up gcc warnings
#ifdef SPAG_DEBUG
    fprintf ( stderr, "*** We read %d bytes from file\n", nread );
#endif
  }

  return retcode;
}

int spaghetti_post_file ( char *fullpath, char *url ) {
  // URL is explicit for now

  CURL *curl;
  CURLcode res;
  FILE * hd_src ;
  int hd ;
  struct stat file_info;

  /* get the file size of the local file */
  hd = open ( fullpath, O_RDONLY ) ;
  fstat ( hd, &file_info );
  close ( hd );

  /* get a FILE * of the same file, could also be made with
     fdopen() from the previous descriptor, but hey this is just
     an example! */
  hd_src = fopen ( fullpath, "rb" );

  /* In windows, this will init the winsock stuff */
  curl_global_init ( CURL_GLOBAL_ALL );

  /* get a curl handle */
  curl = curl_easy_init();

  if ( ! curl ) {
    fclose ( hd_src ); /* close the local file */
#ifdef SPAG_DEBUG
    printf ( "Couldn't init libcurl\n" );
#endif
    return ( -1 );
  }

  {
    /* we want to use our own read function */
    curl_easy_setopt(curl, CURLOPT_READFUNCTION, read_callback);

    /* enable uploading */
    curl_easy_setopt(curl, CURLOPT_UPLOAD, 1L);

    /* HTTP PUT please */
    curl_easy_setopt(curl, CURLOPT_PUT, 1L);

    /* specify target URL, and note that this URL should include a file
       name, not only a directory */
    curl_easy_setopt(curl, CURLOPT_URL, url);

    /* now specify which file to upload */
    curl_easy_setopt(curl, CURLOPT_READDATA, hd_src);

    /* provide the size of the upload, we specicially typecast the value
       to curl_off_t since we must be sure to use the correct data size */
    curl_easy_setopt(curl, CURLOPT_INFILESIZE_LARGE,
                     (curl_off_t)file_info.st_size);

    /* Now run off and do what you've been told! */
    res = curl_easy_perform(curl);
    /* Check for errors */
    if ( res != CURLE_OK ) {
      fprintf ( stderr, "curl_easy_perform() failed: %s\n", curl_easy_strerror(res) );
      fclose ( hd_src ); /* close the local file */
      return ( -2 );
    }

    /* always cleanup */
    curl_easy_cleanup(curl);
  }

  fclose ( hd_src ); /* close the local file */

  curl_global_cleanup();

  return ( 0 );
}
