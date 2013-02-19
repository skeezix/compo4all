
// yanked from
// http://curl.haxx.se/libcurl/c/getinmemory.html

#include <curl/curl.h>

#include "spaghetti.h"


#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include <curl/curl.h>

struct MemoryStruct {
  char *memory;
  size_t size;
};

static size_t
WriteMemoryCallback ( void *contents, size_t size, size_t nmemb, void *userp ) {
  size_t realsize = size * nmemb;
  struct MemoryStruct *mem = (struct MemoryStruct *)userp;

  mem->memory = realloc(mem->memory, mem->size + realsize + 1);
  if (mem->memory == NULL) {
    /* out of memory! */
    printf("not enough memory (realloc returned NULL)\n");
    exit(EXIT_FAILURE);
  }

  memcpy(&(mem->memory[mem->size]), contents, realsize);
  mem->size += realsize;
  mem->memory[mem->size] = 0;

  return realsize;
}

int spaghetti_get_ram ( char *url, void **r_buf, unsigned int *r_bufsize ) {
  CURL *curl_handle;
  CURLcode res;

  struct MemoryStruct chunk;

  chunk.memory = malloc ( 1 );  /* will be grown as needed by the realloc above */
  chunk.size = 0;               /* no data at this point */

  curl_global_init ( CURL_GLOBAL_ALL );

  /* init the curl session */
  curl_handle = curl_easy_init();

  if ( ! curl_handle ) {
    return ( -1 );
  }

  /* specify URL to get */
  curl_easy_setopt ( curl_handle, CURLOPT_URL, url );

  /* send all data to this function  */
  curl_easy_setopt ( curl_handle, CURLOPT_WRITEFUNCTION, WriteMemoryCallback );

  /* we pass our 'chunk' struct to the callback function */
  curl_easy_setopt ( curl_handle, CURLOPT_WRITEDATA, (void *)&chunk );

  /* some servers don't like requests that are made without a user-agent
     field, so we provide one */
  curl_easy_setopt ( curl_handle, CURLOPT_USERAGENT, "libcurl-agent/1.0" );

  /* get it! */
  res = curl_easy_perform ( curl_handle );

  if ( res != CURLE_OK ) {
    fprintf ( stderr, "curl_easy_perform() failed: %s\n", curl_easy_strerror(res) );
    return ( -4 );
  }

  /* cleanup curl stuff */
  curl_easy_cleanup ( curl_handle );

  //printf ( "%lu bytes retrieved\n", (long)chunk.size );

  //if ( chunk.memory ) {
  //  free ( chunk.memory );
  //}
  *r_buf = chunk.memory;
  *r_bufsize = chunk.size;

  /* we're done with libcurl, so clean it up */
  curl_global_cleanup();

  return 0;
}
