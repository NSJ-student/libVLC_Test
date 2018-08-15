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

        public MyMediaList()
        {
            InitializeComponent();
            PlayMedia = null;
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
                foreach(ListView.SelectedListViewItemCollection item  in lvPcList.SelectedItems)
                {
                    //lvPcList.Items.Remove(item);
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
    }
}
