
CFLAGS=-Wall -O3

all: sc

sc:	curlpost.o spaghetti.o spaghetti_client.o spaghetti_get.o
	gcc -o sc curlpost.o spaghetti.o spaghetti_client.o spaghetti_get.o -lcurl

clean:
	rm -f *~* spaghetti_post *.o
