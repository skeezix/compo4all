
clean:
	@find . -name "*pyc" -exec rm {} \; #-print
	@find . -name "*pyo" -exec rm {} \; #-print
	@find . -name "*~*" -exec rm {} \; #-print
	cd spaghetti; rm -f *.o
	rm -f spaghetti/sc
	cd spaghetti-server/runtime/hidb; rm -rf *
	cd spaghetti-server/runtime/profiles; rm -rf *

deployserver:
	ssh skeezix@skeewalled "cd compo4all && rm -f *.py*"
	cd spaghetti-server && scp *.py* skeezix@skeewalled:./compo4all

deployutil:
	ssh skeezix@skeewalled "cd compo4all/util && rm -f *.py*"
	cd util && scp *.py* skeezix@skeewalled:./compo4all/util
