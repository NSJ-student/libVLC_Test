namespace libVLC_Test
{
    partial class MyMediaList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabMediaList = new System.Windows.Forms.TabControl();
            this.tpLocalMedia = new System.Windows.Forms.TabPage();
            this.tlpPcList = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvPcList = new System.Windows.Forms.ListView();
            this.chFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFileDir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpStream = new System.Windows.Forms.TabPage();
            this.lbStreamList = new System.Windows.Forms.ListBox();
            this.tabMediaList.SuspendLayout();
            this.tpLocalMedia.SuspendLayout();
            this.tlpPcList.SuspendLayout();
            this.tpStream.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMediaList
            // 
            this.tabMediaList.Controls.Add(this.tpLocalMedia);
            this.tabMediaList.Controls.Add(this.tpStream);
            this.tabMediaList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMediaList.ItemSize = new System.Drawing.Size(80, 50);
            this.tabMediaList.Location = new System.Drawing.Point(4, 4);
            this.tabMediaList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMediaList.Name = "tabMediaList";
            this.tabMediaList.SelectedIndex = 0;
            this.tabMediaList.Size = new System.Drawing.Size(347, 409);
            this.tabMediaList.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMediaList.TabIndex = 0;
            // 
            // tpLocalMedia
            // 
            this.tpLocalMedia.Controls.Add(this.tlpPcList);
            this.tpLocalMedia.Location = new System.Drawing.Point(4, 54);
            this.tpLocalMedia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpLocalMedia.Name = "tpLocalMedia";
            this.tpLocalMedia.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpLocalMedia.Size = new System.Drawing.Size(339, 351);
            this.tpLocalMedia.TabIndex = 0;
            this.tpLocalMedia.Text = "My PC";
            this.tpLocalMedia.UseVisualStyleBackColor = true;
            // 
            // tlpPcList
            // 
            this.tlpPcList.BackColor = System.Drawing.SystemColors.Window;
            this.tlpPcList.ColumnCount = 3;
            this.tlpPcList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPcList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpPcList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpPcList.Controls.Add(this.btnRemove, 2, 1);
            this.tlpPcList.Controls.Add(this.btnAdd, 1, 1);
            this.tlpPcList.Controls.Add(this.lvPcList, 0, 0);
            this.tlpPcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPcList.Location = new System.Drawing.Point(3, 2);
            this.tlpPcList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpPcList.Name = "tlpPcList";
            this.tlpPcList.RowCount = 2;
            this.tlpPcList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPcList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpPcList.Size = new System.Drawing.Size(333, 347);
            this.tlpPcList.TabIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemove.Location = new System.Drawing.Point(266, 317);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(64, 28);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Location = new System.Drawing.Point(196, 317);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 28);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvPcList
            // 
            this.lvPcList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.chFileDir});
            this.tlpPcList.SetColumnSpan(this.lvPcList, 3);
            this.lvPcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPcList.FullRowSelect = true;
            this.lvPcList.HideSelection = false;
            this.lvPcList.Location = new System.Drawing.Point(3, 2);
            this.lvPcList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvPcList.Name = "lvPcList";
            this.lvPcList.Size = new System.Drawing.Size(327, 311);
            this.lvPcList.TabIndex = 2;
            this.lvPcList.UseCompatibleStateImageBehavior = false;
            this.lvPcList.View = System.Windows.Forms.View.Details;
            this.lvPcList.DoubleClick += new System.EventHandler(this.lvPcList_DoubleClick);
            // 
            // chFileName
            // 
            this.chFileName.Text = "Name";
            this.chFileName.Width = 150;
            // 
            // chFileDir
            // 
            this.chFileDir.Text = "Directory";
            this.chFileDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chFileDir.Width = 186;
            // 
            // tpStream
            // 
            this.tpStream.Controls.Add(this.lbStreamList);
            this.tpStream.Location = new System.Drawing.Point(4, 54);
            this.tpStream.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpStream.Name = "tpStream";
            this.tpStream.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpStream.Size = new System.Drawing.Size(338, 351);
            this.tpStream.TabIndex = 1;
            this.tpStream.Text = "Stream";
            this.tpStream.UseVisualStyleBackColor = true;
            // 
            // lbStreamList
            // 
            this.lbStreamList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStreamList.FormattingEnabled = true;
            this.lbStreamList.ItemHeight = 12;
            this.lbStreamList.Location = new System.Drawing.Point(3, 2);
            this.lbStreamList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbStreamList.Name = "lbStreamList";
            this.lbStreamList.Size = new System.Drawing.Size(332, 347);
            this.lbStreamList.TabIndex = 0;
            // 
            // MyMediaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 417);
            this.Controls.Add(this.tabMediaList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MyMediaList";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Text = "s";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyMediaList_FormClosing);
            this.tabMediaList.ResumeLayout(false);
            this.tpLocalMedia.ResumeLayout(false);
            this.tlpPcList.ResumeLayout(false);
            this.tpStream.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMediaList;
        private System.Windows.Forms.TabPage tpLocalMedia;
        private System.Windows.Forms.TabPage tpStream;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TableLayoutPanel tlpPcList;
        private System.Windows.Forms.ListView lvPcList;
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.ColumnHeader chFileDir;
        private System.Windows.Forms.ListBox lbStreamList;
    }
}