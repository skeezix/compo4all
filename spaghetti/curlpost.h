#ifndef h_curlpost_h
#define h_curlpost_h

// HTTP POST a file
// ret: 0 on success
//     -1 on total fail; couldn't init libcurl
//     -2 couldn't reach server (server down, network fubar'd, ...)
int spaghetti_post_file ( char *fullpath, char *url );

#endif
