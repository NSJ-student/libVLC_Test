namespace libVLC_Test
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pMediaElement = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCurrTime = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.tbVideoPosition = new System.Windows.Forms.TrackBar();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.btnFullScreen = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // pMediaElement
            // 
            this.pMediaElement.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tableLayoutPanel1.SetColumnSpan(this.pMediaElement, 4);
            this.pMediaElement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMediaElement.Location = new System.Drawing.Point(8, 8);
            this.pMediaElement.Name = "pMediaElement";
            this.pMediaElement.Size = new System.Drawing.Size(795, 398);
            this.pMediaElement.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.lblCurrTime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnPlay, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.pMediaElement, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPath, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnOpen, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblState, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbVideoPosition, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalTime, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnFullScreen, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(811, 499);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // lblCurrTime
            // 
            this.lblCurrTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCurrTime.AutoSize = true;
            this.lblCurrTime.Location = new System.Drawing.Point(97, 429);
            this.lblCurrTime.Name = "lblCurrTime";
            this.lblCurrTime.Size = new System.Drawing.Size(65, 15);
            this.lblCurrTime.TabIndex = 2;
            this.lblCurrTime.Text = "00:00:00";
            this.lblCurrTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlay
            // 
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlay.Location = new System.Drawing.Point(8, 462);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(74, 29);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Location = new System.Drawing.Point(88, 462);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(74, 29);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(168, 464);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(555, 25);
            this.txtPath.TabIndex = 4;
            // 
            // btnOpen
            // 
            this.btnOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpen.Location = new System.Drawing.Point(729, 462);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(74, 29);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(8, 429);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(74, 15);
            this.lblState.TabIndex = 7;
            this.lblState.Text = "None";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbVideoPosition
            // 
            this.tbVideoPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbVideoPosition.Location = new System.Drawing.Point(168, 422);
            this.tbVideoPosition.Maximum = 10000;
            this.tbVideoPosition.Name = "tbVideoPosition";
            this.tbVideoPosition.Size = new System.Drawing.Size(555, 29);
            this.tbVideoPosition.TabIndex = 1;
            this.tbVideoPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbVideoPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbVideoPosition_MouseDown);
            this.tbVideoPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbVideoPosition_MouseUp);
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.Location = new System.Drawing.Point(729, 429);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(65, 15);
            this.lblTotalTime.TabIndex = 8;
            this.lblTotalTime.Text = "00:00:00";
            this.lblTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Location = new System.Drawing.Point(8, 412);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(74, 4);
            this.btnFullScreen.TabIndex = 9;
            this.btnFullScreen.Text = "Full";
            this.btnFullScreen.UseVisualStyleBackColor = true;
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 499);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(550, 250);
            this.Name = "Form1";
            this.Text = "Media Player (libVLC)";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pMediaElement;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TrackBar tbVideoPosition;
        private System.Windows.Forms.Label lblCurrTime;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Button btnFullScreen;
    }
}

