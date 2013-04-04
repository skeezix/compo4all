
LIBPND_INC=../../libpnd/include
LIBPND_STATLIB=../../libpnd/libpnd.a

CFLAGS=-Wall -O3 -I${LIBPND_INC}

all: sc

sc:	curlpost.o spaghetti.o spaghetti_client.o spaghetti_get.o
	gcc -o sc curlpost.o spaghetti.o spaghetti_client.o spaghetti_get.o -lcurl ${LIBPND_STATLIB}

clean:
	rm -f *~* spaghetti_post *.o
