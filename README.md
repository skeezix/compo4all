compo4all
=========

Compo4All ("c4a") is a simple client/server high score tracking system; desktop or mobiles can compete in high scoring of arcade games or indie games, send messages, obtain reports.. .. bringing social back to gaming.

This is a prototype version; the code is stable and working well for quite some time -- but I'm not particualrly
happy with its hackish nature :)

Currently the server is being rewritten for a number of reasons.. a database store instead of JSON flat files;
assumption about multiple device platforms in one database; expanded profile features -- so someone can compete
with themself, or arbitrarily select devices and timeframes to compare scores against, say. Likewise, we need to
review security -- a very challenging problem given the nature of the software (open client, open server, needs
to be easy to add to indie titles and emulators and so forth..)

A few components are not added into the git yet (the prelimninary web UI, etc.)

Also note .. some components (such as the c4a website itself) are other peoples work so are technically separate
projects.

ie: c4a defines a (crummy :) protocol; it is on purpose agnostic; anyone can write additional frontends (web or
device specific or whatever), and should work fine with c4a backend.
