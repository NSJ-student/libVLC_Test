using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Interop;
using LibVLC.NET;
using LibVLC.NET.Presentation;

namespace libVLC_Test
{
    public partial class Form1 : Form
    {
        LibVLCLibrary library;
        Uri media_path;
        IntPtr inst, mp, m;
        
        public Form1()
        {
            InitializeComponent();
            library = LibVLCLibrary.Load("D:\\MyData\\backup\\study\\library\\vlc-3.0.3");
            try
            {
                /* Load the VLC engine */
                inst = library.libvlc_new();

                /* Create a new item */
                //m = library.libvlc_media_new_location(inst, "https://www.freedesktop.org/software/gstreamer-sdk/data/media/sintel_trailer-480p.webm");

                /* Create a media player playing environement */
                mp = library.libvlc_media_player_new(inst);
                //library.libvlc_media_player_set_media(mp, m);
                //mp = library.libvlc_media_player_new_from_media(m);


                /* No need to keep the media now */
                //library.libvlc_media_release(m);

                library.libvlc_media_player_set_hwnd(mp, pMediaElement.Handle);
            }
            finally
            {
                /* Free the media_player */
                //library.libvlc_media_player_release(mp);
                //library.libvlc_release(inst);
            }
        }
        

        private void btnPlay_Click(object sender, EventArgs e)
        {
            media_path = new Uri(txtPath.Text);

            if (media_path.IsFile)
                m = library.libvlc_media_new_path(inst, media_path.LocalPath);
            else
                m = library.libvlc_media_new_location(inst, media_path.AbsoluteUri);

            library.libvlc_media_player_set_media(mp, m);

            library.libvlc_media_release(m);

            /* play the media_player */
            library.libvlc_media_player_play(mp);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            /* Stop playing */
            library.libvlc_media_player_stop(mp);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                txtPath.Text = path;
            }
        }
    }
}
