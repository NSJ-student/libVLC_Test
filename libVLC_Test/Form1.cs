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
using System.Threading;
using System.Windows.Interop;
using LibVLC.NET;
using LibVLC.NET.Presentation;
using System.IO;
using System.Xml.Linq;

namespace libVLC_Test
{
    enum ProgressUpdate
    {
        TotalUpdate = 1,
        CurrentUpdate = 2,
        StateUpdate = 4
    }
    public partial class Form1 : Form
    {
        string libVLC_path;
        BackgroundWorker worker;
        MyMediaElement element;
        MyMediaList list;

        int TotalTime_Pre;
        int CurrentPercent_Pre;
        MediaPlayerState State_Pre;

        TimeSpan TotalTime;
        int CurrentPercent;
        MediaPlayerState State;

        int VideoPosition_Pre;
        bool VideoPositionStart;

        public Form1()
        {
            InitializeComponent();

            libVLC_path = null;

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.ProgressChanged += new ProgressChangedEventHandler(cb_ProgressChanged);
            worker.DoWork += new DoWorkEventHandler(cb_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(cb_RunWorkerCompleted);

            string path = LoadInit();
            element = new MyMediaElement(path);
            pMediaElement.Controls.Add(element);
            element.Show();
            element.Dock = DockStyle.Fill;
            element.SetFullScreenCallBack(setFullScreen);

            list = new MyMediaList();
            list.SetPlayCallBack(PlayMedia);
            list.Hide();

            tbVideoPosition.Maximum = 10000;
            VideoPositionStart = false;
        }

        public string LoadInit()
        {
            try
            {
                if (File.Exists(".\\info.xml"))
                {
                    XElement root = XElement.Load("info.xml");
                    XElement vlc_path = root.Element("libvlc");

                    libVLC_path = vlc_path.Element("path").Value;
                }
                else
                {
//                    libVLC_path = "D:\\MyData\\backup\\study\\library\\vlc-3.0.3";
                    libVLC_path = "..\\..\\vlc-3.0.4";
                }

                return libVLC_path;
            }
            catch
            {
//                libVLC_path = "D:\\MyData\\backup\\study\\library\\vlc-3.0.3";
                libVLC_path = "..\\..\\vlc-3.0.4";
                return libVLC_path;
            }
        }

        public bool SaveInit()
        {
            if (File.Exists(".\\info.xml"))
            {
                XElement root = XElement.Load("info.xml");
                XElement path = root.Element("path");
                XElement element;

                if (path == null)
                {
                    path = new XElement("path", libVLC_path);
                    root.Add(path);
                }
                else
                {
                    path.ReplaceWith(new XElement("path", libVLC_path));
                }

                root.Save("info.xml");
            }
            else
            {
                XElement root = new XElement("libvlc");
                XElement path = new XElement("path", libVLC_path);
                
                root.Add(path);

                root.Save("info.xml");
            }

            return true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(txtPath.Text.Equals(""))
            {
                PlayMedia(list.CurrentPath);
            }
            else
            {
                PlayMedia(txtPath.Text);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if(element.State == MediaPlayerState.Playing)
            {
                element.Pause();
                btnPause.Text = "Resume";
            }
            else if(element.State == MediaPlayerState.Paused)
            {
                element.Resume();
                btnPause.Text = "Pause";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
            element.Stop();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            /*
            OpenFileDialog dialog = new OpenFileDialog();

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                txtPath.Text = path;
            }
            */
            if(list.Visible)
            {
                list.Hide();
            }
            else
            {
                list.Show();
            }
        }

        private void cb_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            TotalTime_Pre = Convert.ToInt32(element.Length.TotalSeconds);
            CurrentPercent_Pre = 0;
            State_Pre = element.State;
            
            while(true)
            {
                int arg = 0;
                TotalTime = element.Length;
                if (element.Length.TotalSeconds != 0)
                {
                    CurrentPercent = tbVideoPosition.Maximum
                        * Convert.ToInt32(element.Time.TotalSeconds)
                        / Convert.ToInt32(element.Length.TotalSeconds);
                }
                else
                {
                    CurrentPercent = 0;
                }
                State = element.State;

                if ((element.State == MediaPlayerState.Stopped) ||
                    (element.State == MediaPlayerState.Error) ||
                    (element.State == MediaPlayerState.Ended) ||
                    (element.State == MediaPlayerState.NothingSpecial))
                {
                    break;
                }

                if (Convert.ToInt32(TotalTime.TotalSeconds) != TotalTime_Pre)
                {
                    arg |= (int)ProgressUpdate.TotalUpdate;
                    TotalTime_Pre = Convert.ToInt32(TotalTime.TotalSeconds);
                }
                if (CurrentPercent != CurrentPercent_Pre)
                {
                    arg |= (int)ProgressUpdate.CurrentUpdate;
                    CurrentPercent_Pre = CurrentPercent;
                }
                if (State != State_Pre)
                {
                    arg |= (int)ProgressUpdate.StateUpdate;
                    State_Pre = State;
                }

                if(arg != 0)
                {
                    worker.ReportProgress(arg);
                }

                //CancellationPending 속성이 true로 set되었다면(위에서 CancelAsync 메소드 호출 시 true로 set된다고 하였죠?
                if ((worker.CancellationPending == true))
                {
                    //루프를 break한다.(즉 스레드 run 핸들러를 벗어나겠죠)
                    e.Cancel = true;
                    break;
                }

                Thread.Sleep(500);
            }
        }

        private void cb_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressUpdate arg = (ProgressUpdate)e.ProgressPercentage;

            
            if((arg & ProgressUpdate.TotalUpdate) == ProgressUpdate.TotalUpdate)
            {
                lblTotalTime.Text = TotalTime.ToString(@"hh\:mm\:ss");
                tbVideoPosition.Maximum = Convert.ToInt32(TotalTime.TotalSeconds);
            }

            if ((arg & ProgressUpdate.CurrentUpdate) == ProgressUpdate.CurrentUpdate)
            {
                lblCurrTime.Text = element.Time.ToString(@"hh\:mm\:ss");
                tbVideoPosition.Value = CurrentPercent;
            }

            if ((arg & ProgressUpdate.StateUpdate) == ProgressUpdate.StateUpdate)
            {
                lblState.Text = element.strState;
            }
        }

        //스레드의 run함수가 종료될 경우 해당 핸들러가 호출됩니다.
        private void cb_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblState.Text = element.strState;

            //스레드가 종료한 이유(사용자 취소, 완료, 에러)에 맞쳐 처리하면 됩니다.
            if ((e.Cancelled == true))
            {
                //this.tbProgress.Text = "Canceled!";
            }

            else if (!(e.Error == null))
            {
                //this.tbProgress.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                //this.tbProgress.Text = "Done!";
            }
        }

        private void tbVideoPosition_MouseUp(object sender, MouseEventArgs e)
        {
            if (VideoPositionStart)
            {
                VideoPositionStart = false;
                if(VideoPosition_Pre != tbVideoPosition.Value)
                {
                    element.Time = new TimeSpan(0,0,0,0, Convert.ToInt32(
                        element.Length.TotalMilliseconds 
                        * tbVideoPosition.Value
                        / tbVideoPosition.Maximum));
                }
            }
        }

        private void tbVideoPosition_MouseDown(object sender, MouseEventArgs e)
        {
            if(element.State == MediaPlayerState.Playing)
            {
                VideoPositionStart = true;
                VideoPosition_Pre = tbVideoPosition.Value;
            }
        }
        
        public void setFullScreen(bool full)
        {
            if (!full && (element.WindowState == FormWindowState.Maximized))
            {
                element.WindowState = FormWindowState.Normal;
                element.TopLevel = false;
                pMediaElement.Controls.Add(element);
            }
            else if (full && (element.WindowState == FormWindowState.Normal))
            {
                pMediaElement.Controls.Remove(element);
                element.TopLevel = true;
                element.WindowState = FormWindowState.Maximized;
            }
        }

        public void PlayMedia(string fullPath)
        {
            txtPath.Text = fullPath;

            if (!element.SetUri(fullPath))
                return;
            
            if ((element.State == MediaPlayerState.Playing) ||
                (element.State == MediaPlayerState.Paused))
            {
                element.Stop();
            }

            if (element.Play())
            {
                tbVideoPosition.Value = 0;

                TotalTime = element.Length;
                if (element.Length.TotalSeconds != 0)
                {
                    CurrentPercent = tbVideoPosition.Maximum
                        * Convert.ToInt32(element.Time.TotalSeconds)
                        / Convert.ToInt32(element.Length.TotalSeconds);
                }
                else
                {
                    CurrentPercent = 0;
                }
                State = element.State;

                TotalTime_Pre = Convert.ToInt32(TotalTime.TotalSeconds);
                CurrentPercent_Pre = 0;
                State_Pre = State;

                lblTotalTime.Text = TotalTime.ToString(@"hh\:mm\:ss");
                lblCurrTime.Text = element.Time.ToString(@"hh\:mm\:ss");
                lblState.Text = element.strState;
                btnPause.Text = "Pause";

                if (!worker.IsBusy)
                    worker.RunWorkerAsync();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Space))
            {
                if (element.WindowState == FormWindowState.Maximized)
                {
                    element.WindowState = FormWindowState.Normal;
                    element.TopLevel = false;
                    pMediaElement.Controls.Add(element);
                }
                else if (element.WindowState == FormWindowState.Normal)
                {
                    pMediaElement.Controls.Remove(element);
                    element.TopLevel = true;
                    element.WindowState = FormWindowState.Maximized;
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveInit();
        }
    }
}
