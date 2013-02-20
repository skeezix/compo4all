#!/usr/bin/env python

import pygtk
pygtk.require('2.0')
import gtk
import time
import threading
import subprocess
import json
import sys
import os

import ConfigParser
config = ConfigParser.SafeConfigParser()
config.read ( './c4a-fe.conf' )

if config.has_section ( 'PyPath' ):
    for p in config.items ( 'PyPath' ):
        sys.path.append ( p [ 0 ] )
        print "Python module path - adding '", p [ 0 ], "'"
else:
    print "WARN: Config is missing [PyPath] section"

class Frontend:

    def cb_new_profile ( self, widget, data=None ):

        self.new_prof_d = gtk.Dialog ( title="Create Profile", parent=None, flags=0, buttons=None )

        self.new_prof_ok_b = gtk.Button ( "OK" )
        self.new_prof_ok_b.connect ( "clicked", self.cb_new_profile_ok, None )
        self.new_prof_cancel_b = gtk.Button ( "Cancel" )
        self.new_prof_cancel_b.connect ( "clicked", self.cb_new_profile_cancel, None )

        self.new_prof_table_l = gtk.Table ( rows = 4, columns = 3 )

        # labels
        self.new_prof_shortname_l = gtk.Label()
        self.new_prof_shortname_l.set_markup ( "3 Letter Nick (ex <b>SKZ</b>)" )
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
        self.new_prof_longname_e = gtk.Entry ( max = 32 )
        self.new_prof_password_e = gtk.Entry ( max = 32 )
        self.new_prof_email_e = gtk.Entry ( max = 256 )

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

    def cb_new_profile_ok ( self, widget, data=None ):
        pass

    def cb_new_profile_cancel ( self, widget, data=None ):
        pass

    def cb_edit_profile ( self, widget, data=None ):
        pass

    def cb_del_profile ( self, widget, data=None ):
        print "Delete existing profile"

    def cb_set_banner ( self, text ):
        self.banner_l.set_markup ( text )

    def cb_set_gamelist ( self, gamelist ):

        for k,v in gamelist.iteritems():
            b = gtk.Button ( "Start " + v )
            b.connect ( "clicked", self.cb_clicked_game, k )
            self.left_vb.pack_end ( b, False, False, 0 )

            if self.is_profile_exist():
                pass
            else:
                b.set_sensitive ( False )

            b.show()

            self.gamebuttons.append ( b )

    def cb_clicked_game ( self, but, v ):
        print "Desire to start game", v


    def delete_event ( self, widget, event, data=None ):
        # return False -> GTK will ask for destroy
        # return True -> GTK will not ask to destroy (ask "you're sure?"?)
        print "User asks for delete widget"
        return False # kill me

    def destroy ( self, widget, data=None ):
        print "destroy signal occurred"
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

        # handlers
        self.window.connect ( "delete_event", self.delete_event )
        self.window.connect ( "destroy", self.destroy )

        # widgets
        self.outer_hb = gtk.HBox ( False, 0 )
        self.window.add ( self.outer_hb )

        self.left_vb = gtk.VBox ( False, 0 )
        self.right_vb = gtk.VBox ( False, 0 )
        self.outer_hb.pack_start ( self.left_vb )
        self.outer_hb.pack_start ( self.right_vb )
    
        # Buttons
        self.new_profile_b = gtk.Button ( "Create new profile" )
        self.new_profile_b.connect ( "clicked", self.cb_new_profile, None )

        self.edit_profile_b = gtk.Button ( "Edit existing profile" )
        self.edit_profile_b.connect ( "clicked", self.cb_edit_profile, None )
        if not self.is_profile_exist():
            self.edit_profile_b.set_sensitive ( False )

        self.del_profile_b = gtk.Button ( "Delete existing profile" )
        if not self.is_profile_exist():
            self.del_profile_b.set_sensitive ( False )

        self.quit_b = gtk.Button ( "Quit C4A" )
        self.quit_b.connect_object ( "clicked", gtk.Widget.destroy, self.window )

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
        self.banner_l.show()
        self.right_vb.pack_start ( self.banner_l )

        self.profile_l = gtk.Label()
        self.profile_l.set_markup ( "" )
        self.profile_l.show()
        self.right_vb.pack_start ( self.profile_l, True, True )
   
        # The final step is to display this newly created widget.
        self.new_profile_b.show()
        self.edit_profile_b.show()
        self.del_profile_b.show()
        self.quit_b.show()
    
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
            self.pull_profile_and_update_with_ui()
        else:
            self.del_profile_b.set_sensitive ( False )

    def is_server_available ( self ):

        md = gtk.MessageDialog ( self.window, gtk.DIALOG_DESTROY_WITH_PARENT, gtk.MESSAGE_INFO, 
                                 gtk.BUTTONS_NONE, "Checking connectivity ..")
        md.show()

        try:
            b = subprocess.check_output ( config.get ( 'Sources', 'ohai' ), stderr=subprocess.STDOUT, shell=True )
            j = json.loads ( b )

            md.destroy()

            if j [ 'status' ] == 'OK':
                return 1

            return 0

        except:
            md.destroy()
            return 0

    def pull_banner_and_update_with_ui ( self ):
        # blast, python + thread + urllib/httplib2/etc are fubar, skip for now
        # http://zetcode.com/gui/pygtk/dialogs/

        md = gtk.MessageDialog ( self.window, gtk.DIALOG_DESTROY_WITH_PARENT, gtk.MESSAGE_INFO, 
                                 gtk.BUTTONS_NONE, "Fetching banner from the server ..")
        md.show()

        b = subprocess.check_output ( config.get ( 'Sources', 'banner' ), stderr=subprocess.STDOUT, shell=True )
        j = json.loads ( b )

        self.cb_set_banner ( j [ 'banner' ] )

        md.destroy()

    def pull_gamelist_and_update_with_ui ( self ):
        # blast, python + thread + urllib/httplib2/etc are fubar, skip for now
        # http://zetcode.com/gui/pygtk/dialogs/

        md = gtk.MessageDialog ( self.window, gtk.DIALOG_DESTROY_WITH_PARENT, gtk.MESSAGE_INFO, 
                                 gtk.BUTTONS_NONE, "Fetching current game list from the server ..")
        md.show()

        b = subprocess.check_output ( config.get ( 'Sources', 'curgamelist' ), stderr=subprocess.STDOUT, shell=True )
        j = json.loads ( b )

        self.cb_set_gamelist ( j [ 'gamelist' ] )

        md.destroy()

    def is_profile_exist ( self ):
        if os.path.isfile ( "c4a-prof" ):
            return True
        return False

    def fetch_prid ( self ):
        try:
            f = open ( "c4a-prof", "r" )
            pridfile = f.read()
            j = json.loads ( pridfile )
            f.close()
            return j
        except:
            return None

    def pull_profile_and_update_with_ui ( self ):
        prid = self.fetch_prid()

        if not prid:
            return

        md = gtk.MessageDialog ( self.window, gtk.DIALOG_DESTROY_WITH_PARENT, gtk.MESSAGE_INFO, 
                                 gtk.BUTTONS_NONE, "Fetching profile from the server ..")
        md.show()

        url = config.get ( 'Sources', 'getprofile_base' ) + prid [ 'prid' ]

        b = subprocess.check_output ( url, stderr=subprocess.STDOUT, shell=True )
        j = json.loads ( b )

        #self.cb_set_banner ( j [ 'banner' ] )

        md.destroy()

    def main ( self ):
        gtk.main()

if __name__ == "__main__":

    fe = Frontend()
    fe.main()
