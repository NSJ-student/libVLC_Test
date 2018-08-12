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
        MediaElement element;
        
        public Form1()
        {
            InitializeComponent();

            element = new MediaElement("D:\\MyData\\backup\\study\\library\\vlc-3.0.3");

            pMediaElement.Controls.Add(element);
            element.Show();
            element.Dock = DockStyle.Fill;
        }
        
        private void btnPlay_Click(object sender, EventArgs e)
        {
            element.SetUri(txtPath.Text);

            element.Play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            element.Stop();
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
