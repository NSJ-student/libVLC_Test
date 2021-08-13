using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace libVLC_Test
{
    public delegate void StartMediaPlay(string filePath);

    public partial class MyMediaList : Form
    {
        StartMediaPlay PlayMedia;
        bool _FormLock;

        public string CurrentPath
        {
            get
            {
                if (lvPcList.SelectedItems.Count > 0)
                {
                    return Path.Combine(lvPcList.SelectedItems[0].SubItems[1].Text,
                                        lvPcList.SelectedItems[0].SubItems[0].Text);
                }
                else
                {
                    return "";
                }
            }
        }

        public bool FormLock 
        { 
            get
            {
                return _FormLock;
            }
            set
            {
                if (value)
                {
                    int target = this.Owner.Left + this.Owner.Width;
                    this.Left = target;
                    this.Top = this.Owner.Top;
                    _FormLock = true;
                }
                else
                {
                    _FormLock = false;
                }
            }
        }

        public MyMediaList()
        {
            InitializeComponent();
            PlayMedia = null;
        }

        public void playNext(string current_path)
        {
            string current_file_name = Path.GetFileName(current_path);

            ListViewItem item = lvPcList.FindItemWithText(current_file_name);

            if(item != null)
            {
                int index = lvPcList.Items.IndexOf(item);
                int next_index = index + 1;

                if(lvPcList.Items.Count <= next_index)
                {
                    next_index = 0;
                }

                string fullPath = Path.Combine(lvPcList.Items[next_index].SubItems[1].Text,
                                               lvPcList.Items[next_index].SubItems[0].Text);
                PlayMedia(fullPath);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                foreach(string item in dialog.FileNames)
                {
                    string[] str = new string[2] { Path.GetFileName(item), Path.GetDirectoryName(item)};
                    ListViewItem value = new ListViewItem(str);
                    lvPcList.Items.Add(value);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(lvPcList.SelectedItems.Count != 0)
            {
                foreach(ListViewItem item  in lvPcList.SelectedItems)
                {
                    lvPcList.Items.Remove(item);
                }
            }
        }

        public void SetPlayCallBack(StartMediaPlay cb)
        {
            PlayMedia = cb;
        }

        private void lvPcList_DoubleClick(object sender, EventArgs e)
        {
            if(lvPcList.SelectedItems.Count > 0)
            {
                if(PlayMedia != null)
                {
                    string fullPath = Path.Combine(lvPcList.SelectedItems[0].SubItems[1].Text, 
                                                   lvPcList.SelectedItems[0].SubItems[0].Text);
                    PlayMedia(fullPath);
                }
            }
        }

        private void MyMediaList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason != CloseReason.FormOwnerClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void MyMediaList_Move(object sender, EventArgs e)
        {
            int target = this.Owner.Left + this.Owner.Width;
            if ((this.Left <= target+30) && (this.Left >= target - 30))
            {
                if ((this.Top >= this.Owner.Top - 30) && (this.Top <= this.Owner.Top + 30))
                {
                    this.Left = target;
                    this.Top = this.Owner.Top;
                    _FormLock = true;
                    return;
                }
            }

            _FormLock = false;
        }
    }
}
