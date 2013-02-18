
all: spaghetti_post

spaghetti_post:	curlpost.o spaghetti.o
	gcc -o spaghetti_post curlpost.o spaghetti.o -lcurl

clean:
	rm -f *~* spaghetti_post *.o
