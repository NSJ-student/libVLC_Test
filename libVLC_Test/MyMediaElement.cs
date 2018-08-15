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
    //
    // 요약:
    //     Represents the finite state of a media player.
    public enum MediaPlayerState
    {
        //
        // 요약:
        //     The media player is currently idle.
        NothingSpecial = 0,
        //
        // 요약:
        //     The media player is currently opening a media.
        Opening = 1,
        //
        // 요약:
        //     The media player is currently buffering.
        Buffering = 2,
        //
        // 요약:
        //     The media player is currently playing a media.
        Playing = 3,
        //
        // 요약:
        //     Playback of a media has currently paused.
        Paused = 4,
        //
        // 요약:
        //     The media player has stopped playing a media.
        Stopped = 5,
        //
        // 요약:
        //     The media player has reached the end of a media.
        Ended = 6,
        //
        // 요약:
        //     There has been an error opening a media.
        Error = 7
    }
    public delegate void SetNormalForm();

    public partial class MyMediaElement : Form
    {
        SetNormalForm normalWindowCallback;

        LibVLCLibrary library;
        Uri media_path;
        IntPtr libInstance;
        IntPtr media_player;
        IntPtr media;

        public bool IsSeekable
        {
            get
            {
                return library.libvlc_media_player_is_seekable(media_player) != 0;
            }
        }
        public TimeSpan Length
        {
            get
            {
                long value = library.libvlc_media_player_get_length(media_player);
                if (value <= 0)
                    return TimeSpan.Zero;
                else
                    return TimeSpan.FromMilliseconds(value);
            }
        }

        public TimeSpan Time
        {
            get
            {
                long value = library.libvlc_media_player_get_time(media_player);
                if (value <= 0)
                    return TimeSpan.Zero;
                else
                    return TimeSpan.FromMilliseconds(value);
            }

            set
            {
                library.libvlc_media_player_set_time(media_player, (long)value.TotalMilliseconds);
            }
        }

        public string strState
        {
            get
            {
                MediaPlayerState ms = (MediaPlayerState)library.libvlc_media_player_get_state(media_player);

                switch(ms)
                {
                    case MediaPlayerState.Buffering: return "Buffering";
                    case MediaPlayerState.Ended: return "Ended";
                    case MediaPlayerState.Error: return "Error";
                    case MediaPlayerState.NothingSpecial: return "Nothing Special";
                    case MediaPlayerState.Opening: return "Opening";
                    case MediaPlayerState.Paused: return "Paused";
                    case MediaPlayerState.Playing: return "Playing";
                    case MediaPlayerState.Stopped: return "Stopped";
                    default: return "None";
                }
            }
        }

        public MediaPlayerState State
        {
            get
            {
                return (MediaPlayerState)library.libvlc_media_player_get_state(media_player);
            }
        }

        public MyMediaElement(string library_path)
        {
            InitializeComponent();
            this.TopLevel = false;

            library = LibVLCLibrary.Load(library_path);

            /* Load the VLC engine */
            libInstance = library.libvlc_new();

            /* Create a media player playing environement */
            media_player = library.libvlc_media_player_new(libInstance);
            
            library.libvlc_media_player_set_hwnd(media_player, this.Handle);

            normalWindowCallback = null;
        }

        public void SetUri(string path)
        {
            if (path == null || path.Equals(""))
                return;

            media_path = new Uri(path);
        }

        public bool Play()
        {
            if (media_path == null || media_path.Equals(""))
                return false;

            if (media_path.IsFile)
                media = library.libvlc_media_new_path(libInstance, media_path.LocalPath);
            else
                media = library.libvlc_media_new_location(libInstance, media_path.AbsoluteUri);

            if(media == null)
            {
                return false;
            }

            library.libvlc_media_player_set_media(media_player, media);

            library.libvlc_media_release(media);

            /* play the media_player */
            library.libvlc_media_player_play(media_player);

            return true;
        }

        public void Stop()
        {
            /* Stop playing */
            library.libvlc_media_player_stop(media_player);
        }

        public void SetNormalModeCallBack(SetNormalForm cb)
        {
            normalWindowCallback = cb;
        }

        private void MyMediaElement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Escape)
            {
                if (normalWindowCallback != null)
                {
                    normalWindowCallback();
                }
            }
        }
    }
}
