
clean:
	@find . -name "*pyc" -exec rm {} \; #-print
	@find . -name "*pyo" -exec rm {} \; #-print
	@find . -name "*~*" -exec rm {} \; #-print
	cd spaghetti; rm -f *.o
	cd spaghetti-server/runtime/hidb; rm -rf *
