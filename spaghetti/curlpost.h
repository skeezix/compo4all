#ifndef h_curlpost_h
#define h_curlpost_h

#define SPAGHETTI_URL ""

// HTTP POST a file
// ret: 0 on success
//     -1 on total fail; couldn't init libcurl
int spaghetti_post_file ( char *fullpath, char *url );

#endif
