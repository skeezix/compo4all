#!/usr/bin/env python

import pygtk
pygtk.require('2.0')
import gtk
import gobject
import time
import threading
import subprocess
import json
import sys
import os
import os.path
import string
import uuid
import urllib2
import tempfile
import datetime

# monkey patch py2.7's check_output() into py2.6's missing one :)
if "check_output" not in dir( subprocess ): # duck punch it in!
    def f(*popenargs, **kwargs):
        if 'stdout' in kwargs:
            raise ValueError('stdout argument not allowed, it will be overridden.')
        process = subprocess.Popen(stdout=subprocess.PIPE, *popenargs, **kwargs)
        output, unused_err = process.communicate()
        retcode = process.poll()
        if retcode:
            cmd = kwargs.get("args")
            if cmd is None:
                cmd = popenargs[0]
            raise CalledProcessError(retcode, cmd)
        return output
    subprocess.check_output = f

import ConfigParser
config = ConfigParser.SafeConfigParser()
config.read ( './c4a-fe.conf' )

if config.has_section ( 'PyPath' ):
    for p in config.items ( 'PyPath' ):
        sys.path.append ( p [ 0 ] )
        print "Python module path - adding '", p [ 0 ], "'"
else:
    print "WARN: Config is missing [PyPath] section"

PRIDFILENAME = "c4a-prof"

class Frontend:

    def cb_newedit_profile ( self, widget, data=None, edit=False ):

        prid = None

        self.new_prof_d = gtk.Dialog ( title="Create Profile", parent=None, flags=0, buttons=None )

        self.new_prof_ok_b = gtk.Button ( "OK" )
        self.new_prof_ok_b.connect ( "clicked", self.cb_new_profile_ok, None )
        self.new_prof_cancel_b = gtk.Button ( "Cancel" )
        self.new_prof_cancel_b.connect ( "clicked", self.cb_new_profile_cancel, None )

        self.new_prof_table_l = gtk.Table ( rows = 4, columns = 3 )

        # labels
        self.new_prof_shortname_l = gtk.Label()
        self.new_prof_shortname_l.set_markup ( "3 Letter Nick (ex <b>EVD</b>)" )
        self.new_prof_shortname_l.show()
        self.new_prof_shortname_l.set_alignment ( xalign=0.0, yalign=0.5 )

        self.new_prof_longname_l = gtk.Label()
        self.new_prof_longname_l.set_markup ( "Display Nick (ex <b>EvilDragon</b>)" )
        self.new_prof_longname_l.show()
        self.new_prof_longname_l.set_alignment ( xalign=0.0, yalign=0.5 )

        self.new_prof_password_l = gtk.Label()
        self.new_prof_password_l.set_markup ( "Alphanumeric Password (ex <b>aBc123</b>)" )
        self.new_prof_password_l.show()
        self.new_prof_password_l.set_alignment ( xalign=0.0, yalign=0.5 )

        self.new_prof_email_l = gtk.Label()
        self.new_prof_email_l.set_markup ( "Email Address for score\nbeing beaten notifications (ex <b>billg@microsoft.com.</b>)" )
        self.new_prof_email_l.show()
        self.new_prof_email_l.set_alignment ( xalign=0.0, yalign=0.5 )

        # text entry fields
        self.new_prof_shortname_e = gtk.Entry ( max = 3 )
        self.new_prof_shortname_e.connect ( "insert_text", self.cb_password_insert_handler )
        self.new_prof_longname_e = gtk.Entry ( max = 32 )
        self.new_prof_longname_e.connect ( "insert_text", self.cb_password_insert_handler )
        self.new_prof_password_e = gtk.Entry ( max = 32 )
        self.new_prof_password_e.connect ( "insert_text", self.cb_password_insert_handler )
        self.new_prof_email_e = gtk.Entry ( max = 256 )
        self.new_prof_email_e.connect ( "insert_text", self.cb_email_insert_handler )

        self.new_prof_shortname_e.show()
        self.new_prof_longname_e.show()
        self.new_prof_password_e.show()
        self.new_prof_email_e.show()

        self.new_prof_table_l.attach ( self.new_prof_shortname_l, 0, 1, 0, 1 )
        self.new_prof_table_l.attach ( self.new_prof_shortname_e, 1, 2, 0, 1 )
        self.new_prof_table_l.attach ( self.new_prof_longname_l, 0, 1, 1, 2 )
        self.new_prof_table_l.attach ( self.new_prof_longname_e, 1, 2, 1, 2 )
        self.new_prof_table_l.attach ( self.new_prof_password_l, 0, 1, 2, 3 )
        self.new_prof_table_l.attach ( self.new_prof_password_e, 1, 2, 2, 3 )
        self.new_prof_table_l.attach ( self.new_prof_email_l, 0, 1, 3, 4 )
        self.new_prof_table_l.attach ( self.new_prof_email_e, 1, 2, 3, 4 )

        self.new_prof_table_l.set_col_spacings ( 10 )
        self.new_prof_table_l.set_row_spacings ( 10 )

        self.new_prof_table_l.show()
        self.new_prof_ok_b.show()
        self.new_prof_cancel_b.show()

        self.new_prof_d.vbox.pack_start ( self.new_prof_table_l, False, False, 10 )
        self.new_prof_d.action_area.pack_start ( self.new_prof_ok_b, False, False, 0 )
        self.new_prof_d.action_area.pack_start ( self.new_prof_cancel_b, False, False, 0 )

        self.new_prof_d.show()

        # edit?
        if edit:
            pridfile = self.fetch_pridfile()

            prid = pridfile [ 'prid' ]

            self.new_prof_shortname_e.set_text ( pridfile [ 'shortname' ] )
            self.new_prof_longname_e.set_text ( pridfile [ 'longname' ] )
            self.new_prof_password_e.set_text ( pridfile [ 'password' ] )
            self.new_prof_email_e.set_text ( pridfile [ 'email' ] )

        # run it..
        #
        r = self.new_prof_d.run()

        if r == True:
            pridfile = dict()

            if edit:
                pridfile [ 'prid' ] = prid
            else:
                pridfile [ 'prid' ] = str( uuid.uuid4() )
            pridfile [ 'shortname' ] = self.new_prof_shortname_e.get_text().upper()
            pridfile [ 'longname' ] = self.new_prof_longname_e.get_text()
            pridfile [ 'password' ] = self.new_prof_password_e.get_text()
            pridfile [ 'email' ] = self.new_prof_email_e.get_text()

            self.write_pridfile ( pridfile )
            self.push_profile ( pridfile )

        self.update_grayed_out()

        self.new_prof_d.hide()
        self.new_prof_d.destroy()

    def cb_password_insert_handler ( self, entry, text, length, position ):

        position = entry.get_position() # Because the method parameter 'position' is useless

        # Build a new string with allowed characters only.
        result = ''.join([c for c in text if c in string.ascii_letters+string.digits ])

        # The above line could also be written like so (more readable but less efficient):
        # result = ''
        # for c in text:
        #     if c in string.hexdigits:
        #         result += c

        if result != '':
            # Insert the new text at cursor (and block the handler to avoid recursion).
            entry.handler_block_by_func ( self.cb_password_insert_handler )
            entry.insert_text ( result, position )
            entry.handler_unblock_by_func ( self.cb_password_insert_handler )

            # Set the new cursor position immediately after the inserted text.
            new_pos = position + len ( result )

            # Can't modify the cursor position from within this handler,
            # so we add it to be done at the end of the main loop:
            gobject.gobject.idle_add ( entry.set_position, new_pos )

        # We handled the signal so stop it from being processed further.
        entry.stop_emission("insert_text")

    def cb_email_insert_handler ( self, entry, text, length, position ):

        position = entry.get_position() # Because the method parameter 'position' is useless

        # Build a new string with allowed characters only.
        result = ''.join([c for c in text if c in string.ascii_letters+string.digits+string.punctuation ])

        # The above line could also be written like so (more readable but less efficient):
        # result = ''
        # for c in text:
        #     if c in string.hexdigits:
        #         result += c

        if result != '':
            # Insert the new text at cursor (and block the handler to avoid recursion).
            entry.handler_block_by_func ( self.cb_email_insert_handler )
            entry.insert_text ( result, position )
            entry.handler_unblock_by_func ( self.cb_email_insert_handler )

            # Set the new cursor position immediately after the inserted text.
            new_pos = position + len ( result )

            # Can't modify the cursor position from within this handler,
            # so we add it to be done at the end of the main loop:
            gobject.gobject.idle_add ( entry.set_position, new_pos )

        # We handled the signal so stop it from being processed further.
        entry.stop_emission("insert_text")

    def is_entry_valid ( self, t ):

        if len ( t ) == 0:
            return False

        return True

    def cb_new_profile_ok ( self, widget, data=None ):

        t = self.new_prof_shortname_e.get_text().upper()
        if not self.is_entry_valid ( t ):
            return

        t = self.new_prof_longname_e.get_text()
        if not self.is_entry_valid ( t ):
            return

        t = self.new_prof_password_e.get_text()
        if not self.is_entry_valid ( t ):
            return

        t = self.new_prof_email_e.get_text()
        if not self.is_entry_valid ( t ):
            return

        self.new_prof_d.response ( True )

    def cb_new_profile_cancel ( self, widget, data=None ):
        self.new_prof_d.response ( False )

    def cb_edit_profile ( self, widget, data=None ):
        self.cb_newedit_profile ( widget, data, edit = True )

    def cb_del_profile ( self, widget, data=None ):

        dialog = gtk.MessageDialog ( self.window, gtk.DIALOG_MODAL, gtk.MESSAGE_INFO, gtk.BUTTONS_YES_NO,
                                     "Delete current profile? (may not recovered!)" )
        r = dialog.run()
        dialog.destroy()

        if r == gtk.RESPONSE_YES:
            if self.push_delete_profile ( self.fetch_pridfile() ):
                os.unlink ( PRIDFILENAME )
                self.update_grayed_out()

    def cb_play_game ( self, widget, data=None ):

        if self.is_profile_exist():
            self.invoke_emu ( self.selected_gamename )
        else:
            md = gtk.MessageDialog ( self.window, gtk.DIALOG_DESTROY_WITH_PARENT, gtk.MESSAGE_ERROR, 
                                     gtk.BUTTONS_CLOSE, "Please create a profile first" )
            md.run()
            md.destroy()

    def cb_set_banner ( self, text ):
        self.banner_l.set_markup ( text )

    def cb_set_gamelist ( self, gamelist ):

        # build sorted gamelist
        names = reversed ( sorted ( gamelist, key = lambda ge: ge [ 'longname' ].lower() ) )

        for gent in names:

            if gent [ 'field' ] != 'arcade':
                continue

            b = gtk.Button ( "Select " + gent [ 'longname' ] )
            b.connect ( "clicked", self.cb_clicked_game, gent [ 'gamename' ] )
            self.left_vb.pack_end ( b, False, False, 0 )

            """
            if self.is_profile_exist():
                pass
            else:
                b.set_sensitive ( False )
            """

            b.show()

            self.gamebuttons.append ( b )

    def cb_clicked_game ( self, but, v ):
        #print "Desire to start game", v

        self.selected_gamename = v

        self.update_grayed_out()

        b = self.pull_highscore_with_ui ( v )
        j = json.loads ( b )

        text = 'Highest this month (full list available at c4a.openpandora.org)\n'
        text += "\n"
        runlen = 1
        last = None

        if j [ 'hi' ] == 0:
            text += "No scores registered yet (or server unavailable.)"
            self.cb_set_banner ( text )
            return

        for ent in j [ 'scoreboard' ]:

            if last == ent [ 'longname' ]:
                pass
            else:
                #text += str ( runlen ).ljust ( 5 )
                #text += "\t"
                text += ent [ 'shortname' ].ljust ( 5 )
                text += "\t"
                text += ent [ 'longname' ].ljust ( 30 )
                text += "\t"
                text += str ( ent [ 'score' ] )
                text += "\n"

                runlen += 1

            if runlen > 6:
                break

            last = ent [ 'longname' ]

        self.cb_set_banner ( text )

    def invoke_emu ( self, gamename ):

        # sync scores - pull
        # we pull them all, since they can switch games in-emu..
        self.sync_gamelist_with_ui ( push = False, current = gamename ) # pull

        # run the emu
        emubase = config.get ( 'Exec', 'mamebase' )
        emu = emubase % { "gamename": gamename }
        print "REM: Invoking '%s'" % ( emu )
        subprocess.call ( emu, shell=True )

        # sync scores - push
        self.sync_gamelist_with_ui ( push = True, current = gamename ) # push

    def update_grayed_out ( self ):

        if self.is_profile_exist():
            self.new_profile_b.set_sensitive ( False )
        else:
            self.new_profile_b.set_sensitive ( True )

        if self.is_profile_exist():
            self.edit_profile_b.set_sensitive ( True )
        else:
            self.edit_profile_b.set_sensitive ( False )

        if self.is_profile_exist():
            self.del_profile_b.set_sensitive ( True )
        else:
            self.del_profile_b.set_sensitive ( False )

        if self.selected_gamename == None:
            self.play_b.set_sensitive ( False )
        else:
            self.play_b.set_sensitive ( True )

    def delete_event ( self, widget, event, data=None ):
        # return False -> GTK will ask for destroy
        # return True -> GTK will not ask to destroy (ask "you're sure?"?)
        #print "User asks for delete widget"
        return False # kill me

    def destroy ( self, widget, data=None ):
        #print "destroy signal occurred"
        gtk.main_quit() # exeunt

    def __init__(self):

        # create a new window
        self.window = gtk.Window ( gtk.WINDOW_TOPLEVEL )
        self.window.set_default_size ( config.getint ( 'Display', 'width' ), config.getint ( 'Display', 'height' ) )
        self.window.set_position ( gtk.WIN_POS_CENTER )
        if config.getint ( 'Display', 'fullscreen' ) > 0:
            self.window.fullscreen()
        self.window.set_title ( "Compo4All" )
        self.window.set_border_width ( 10 )

        # state
        self.selected_gamename = None

        # handlers
        self.window.connect ( "delete_event", self.delete_event )
        self.window.connect ( "destroy", self.destroy )

        # widgets
        self.outer_hb = gtk.HBox ( False, 0 )
        self.window.add ( self.outer_hb )

        self.left_vb_s = gtk.ScrolledWindow()
        self.left_vb_s.set_policy ( gtk.POLICY_NEVER, gtk.POLICY_ALWAYS )
        self.left_vb_s.show()

        self.left_vb = gtk.VBox ( False, 0 )
        self.right_vb = gtk.VBox ( False, 0 )
        self.outer_hb.pack_start ( self.left_vb_s, True ) # False for thin column
        self.left_vb_s.add_with_viewport ( self.left_vb )
        self.outer_hb.pack_start ( self.right_vb )

        image = gtk.Image()
        image.set_from_file ( config.get ( 'Display', 'banner_image' ) )
        image.show()
        self.right_vb.pack_start ( image )
    
        # Buttons
        self.new_profile_b = gtk.Button ( "Create new profile" )
        self.new_profile_b.connect ( "clicked", self.cb_newedit_profile, None )

        self.edit_profile_b = gtk.Button ( "Edit existing profile" )
        self.edit_profile_b.connect ( "clicked", self.cb_edit_profile, None )

        self.del_profile_b = gtk.Button ( "Delete existing profile" )
        self.del_profile_b.connect ( "clicked", self.cb_del_profile, None )

        self.quit_b = gtk.Button ( "Quit C4A" )
        self.quit_b.connect_object ( "clicked", gtk.Widget.destroy, self.window )

        self.play_b = gtk.Button ( "Play" )
        self.play_b.connect_object ( "clicked", self.cb_play_game, None )

        self.gamebuttons = list()
    
        # This packs the button into the window (a GTK container).
        self.left_vb.pack_start ( self.new_profile_b, False, False, 0 )
        self.left_vb.pack_start ( self.edit_profile_b, False, False, 0 )
        self.left_vb.pack_start ( self.del_profile_b, False, False, 0 )
        s = gtk.HSeparator(); s.show(); self.left_vb.add ( s )
        self.left_vb.pack_start ( self.quit_b, False, False, 0 )
        s = gtk.HSeparator(); s.show(); self.left_vb.add ( s )

        self.banner_l = gtk.Label()
        self.banner_l.set_markup ( "Banner: <i>Waiting for server...</i>" )
        self.banner_l.set_line_wrap ( True )
        self.banner_l.set_alignment ( xalign=0.22, yalign=0.5 )
        self.banner_l.show()
        self.right_vb.pack_start ( self.banner_l )

        self.log_l = gtk.Label()
        self.log_l.set_markup ( "Waiting for server..." )
        self.log_l.set_line_wrap ( True )
        self.log_l.set_alignment ( xalign=0.0, yalign=0.0 )
        self.log_l.show()
        self.right_vb.pack_end ( self.log_l, True, True )

        self.right_vb.pack_end ( self.play_b )

        # The final step is to display this newly created widget.
        self.new_profile_b.show()
        self.edit_profile_b.show()
        self.del_profile_b.show()
        self.quit_b.show()
        self.play_b.show()
    
        # and the window
        self.left_vb.show()
        self.right_vb.show()
        self.outer_hb.show()
        self.window.show()

        # data pull notification..
        if not self.is_server_available():
            md = gtk.MessageDialog ( self.window, gtk.DIALOG_DESTROY_WITH_PARENT, gtk.MESSAGE_ERROR, 
                                     gtk.BUTTONS_CLOSE, "Error contacting server!")
            md.run()
            md.destroy()
            sys.exit ( -1 )

        self.pull_banner_and_update_with_ui()
        self.pull_gamelist_and_update_with_ui()

        if self.is_profile_exist():
            #self.pull_profile_and_update_with_ui()
            pass
        else:
            self.del_profile_b.set_sensitive ( False )

        self.update_grayed_out()

    def is_server_available ( self ):

        self.append_log ( "Checking connectivity .." )

        try:
            b = subprocess.check_output ( config.get ( 'Sources', 'ohai' ), stderr=subprocess.STDOUT, shell=True )
            j = json.loads ( b )

            if j [ 'status' ] == 'OK':
                self.finish_log()
                return 1

            print "Bad status from server OHAI"

        except:
            print "avail: Unexpected error:", sys.exc_info()[0]

        self.finish_log()
        return 0

    def pull_highscore_with_ui ( self, gamename ):
        self.append_log ( "Fetching scores from the server .." )

        url = config.get ( 'Sources', 'highscore_base' ) + gamename + "/"

        b = subprocess.check_output ( url, stderr=subprocess.STDOUT, shell=True )

        self.finish_log()

        return b

    def pull_banner_and_update_with_ui ( self ):
        # blast, python + thread + urllib/httplib2/etc are fubar, skip for now
        # http://zetcode.com/gui/pygtk/dialogs/

        self.append_log ( "Fetching banner from the server .." )

        b = subprocess.check_output ( config.get ( 'Sources', 'banner' ), stderr=subprocess.STDOUT, shell=True )
        j = json.loads ( b )

        self.cb_set_banner ( j [ 'banner' ] )

        self.finish_log()

    def sync_gamelist_with_ui ( self, push = True, current = None ):
        scpath = config.get ( 'Exec', 'spaghetti' )

        self.append_log ( "Syncing scores for current season .." )

        if push: # push
            for gn in self.gamelist:

                if gn [ 'field' ] != 'arcade':
                    continue

                # strategy options: see below...
                # - but in essence, let us look for modified 'recently' (today?) and existance
                #   --> if file _exists_, and if modified recently, sync it

                # check existance
                scorepath = './hi/' + gn [ 'gamename' ] + '.hi'
                if os.path.exists ( scorepath ):
                    # check today-ness
                    timestamp = os.path.getmtime ( scorepath )
                    if datetime.date.fromtimestamp ( timestamp ) == datetime.date.today():

                        scrun = scpath + " push -d " + gn [ 'gamename' ]
                        self.append_log ( "Syncing scores for current season .. " + gn [ 'gamename' ] )

                        try:
                            print "sync push: scrun", scrun
                            subprocess.call ( scrun, shell = True )
                        except:
                            print "sync push: Unexpected error:", sys.exc_info()
                            print scrun

        else: # pull
            for gn in self.gamelist:

                if gn [ 'field' ] != 'arcade':
                    continue

                # strategy options..
                # - pull them all (in case of game switching in the emu, and to get fresh default scores from server)
                # - pull only the one (ignore game switching case, runs fast, and get from server)
                # - rm them all (let emu generate fresh scores of its own, no server pull at all); we basicly trust the user
                #   all the time anyway (cheating avoidance etc), so this is not so bad..
                # - combined: rm them all, but pull the target game from server
                self.append_log ( "Pulling scores for current season .. " + gn [ 'gamename' ] )

                if gn [ 'gamename' ] == current:
                    scrun = scpath + " pull " + gn [ 'gamename' ]
                    try:
                        print "sync pull: scrun", scrun
                        subprocess.call ( scrun, shell = True )
                    except:
                        print "sync pull: Unexpected error:", sys.exc_info()
                        print scrun
                else:
                    try:
                        print "sync pull: rm", gn [ 'gamename' ]
                        os.remove ( './hi/' + gn [ 'gamename' ] + '.hi' )
                    except:
                        pass

        self.finish_log()

    def pull_gamelist_and_update_with_ui ( self ):
        # blast, python + thread + urllib/httplib2/etc are fubar, skip for now
        # http://zetcode.com/gui/pygtk/dialogs/

        self.append_log ( "Fetching current game list from the server .." )

        b = subprocess.check_output ( config.get ( 'Sources', 'curgamelist' ), stderr=subprocess.STDOUT, shell=True )
        j = json.loads ( b )

        self.cb_set_gamelist ( j [ 'gamelist' ] )
        self.gamelist = j [ 'gamelist' ]

        self.finish_log()

    def is_profile_exist ( self ):
        if os.path.isfile ( PRIDFILENAME ):
            return True
        return False

    def fetch_pridfile ( self ):
        try:
            f = open ( PRIDFILENAME, "r" )
            f.readline() # pull off leading prid
            pridfile = f.read()
            j = json.loads ( pridfile )
            f.close()
            return j
        except:
            return None

    def write_pridfile ( self, d ):
        f = open ( PRIDFILENAME, "w" )
        f.write ( d [ 'prid' ] + "\n" )
        f.write ( json.dumps ( d ) )
        f.close()

    def push_delete_profile ( self, d ):
        curlpath = config.get ( 'Exec', 'curl' )

        url = config.get ( 'Sources', 'delprofile' )
        j = json.dumps ( d )

        f = tempfile.NamedTemporaryFile ( delete = False )
        f.write ( j )
        f.close()

        curlrun = curlpath + " -T " + f.name + " " + url

        subprocess.call ( curlrun, shell = True )

        os.unlink ( f.name )

        return True

    def push_profile ( self, d ):
        curlpath = config.get ( 'Exec', 'curl' )

        url = config.get ( 'Sources', 'setprofile' )
        j = json.dumps ( d )

        #opener = urllib2.build_opener(urllib2.HTTPHandler)
        #request = urllib2.Request ( url, data=j )
        #request.add_header ( 'Content-Type', 'text/json' )
        #request.get_method = lambda: 'PUT'
        #url = opener.open(request)

        f = tempfile.NamedTemporaryFile ( delete = False )
        f.write ( j )
        f.close()

        #curlrun = curlpath + " -T - " + url
        #curlrun = curlpath + " -T ../Makefile " + url
        curlrun = curlpath + " -T " + f.name + " " + url

        #p = subprocess.Popen ( [ '/usr/bin/curl', '-T', '-', url ], stdin=subprocess.PIPE )
        #p.communicate ( input=j )
        subprocess.call ( curlrun, shell = True )

        os.unlink ( f.name )

        return True

    def pull_profile_and_update_with_ui ( self ):
        prid = self.fetch_pridfile()

        if not prid:
            return

        self.append_log ( "Fetching profile from the server .." )

        url = config.get ( 'Sources', 'getprofile_base' ) + prid [ 'prid' ]

        b = subprocess.check_output ( url, stderr=subprocess.STDOUT, shell=True )
        j = json.loads ( b )

        #self.cb_set_banner ( j [ 'banner' ] )

        self.finish_log()

    def append_log ( self, message ):
        self.log_l.show()
        self.log_l.set_markup ( message )

        while gtk.events_pending():
            gtk.main_iteration()

    def finish_log ( self ):
        self.log_l.set_markup ( "" )
        self.log_l.hide()

    def main ( self ):
        gtk.main()

if __name__ == "__main__":

    fe = Frontend()
    fe.main()
