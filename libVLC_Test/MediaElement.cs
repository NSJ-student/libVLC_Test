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
    public partial class MediaElement : Form
    {
        LibVLCLibrary library;
        Uri media_path;
        IntPtr libInstance;
        IntPtr media_player;
        IntPtr media;

        public MediaElement(string library_path)
        {
            InitializeComponent();
            this.TopLevel = false;

            library = LibVLCLibrary.Load(library_path);

            /* Load the VLC engine */
            libInstance = library.libvlc_new();

            /* Create a media player playing environement */
            media_player = library.libvlc_media_player_new(libInstance);
            
            library.libvlc_media_player_set_hwnd(media_player, this.Handle);
        }

        public void SetUri(string path)
        {
            media_path = new Uri(path);
        }

        public void Play()
        {
            if (media_path == null)
                return;

            if (media_path.IsFile)
                media = library.libvlc_media_new_path(libInstance, media_path.LocalPath);
            else
                media = library.libvlc_media_new_location(libInstance, media_path.AbsoluteUri);

            library.libvlc_media_player_set_media(media_player, media);

            library.libvlc_media_release(media);

            /* play the media_player */
            library.libvlc_media_player_play(media_player);
        }

        public void Stop()
        {
            /* Stop playing */
            library.libvlc_media_player_stop(media_player);
        }

    }
}
