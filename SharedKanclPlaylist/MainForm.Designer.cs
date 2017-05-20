using System.Windows.Forms;

namespace SharedKanclPlaylist
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnProcessVideo = new System.Windows.Forms.Button();
            this.txtBoxLink = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.lblPercentageDownload = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPercentageConvert = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.WindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.progressBarConvert = new System.Windows.Forms.ProgressBar();
            this.lstBoxPlaylist = new System.Windows.Forms.ListBox();
            this.lblSateLine = new System.Windows.Forms.Label();
            this.btnLoadDefaultPlaylist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WindowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcessVideo
            // 
            this.btnProcessVideo.Location = new System.Drawing.Point(406, 32);
            this.btnProcessVideo.Name = "btnProcessVideo";
            this.btnProcessVideo.Size = new System.Drawing.Size(75, 23);
            this.btnProcessVideo.TabIndex = 0;
            this.btnProcessVideo.Text = "&Zpracuj";
            this.btnProcessVideo.UseVisualStyleBackColor = true;
            this.btnProcessVideo.Click += new System.EventHandler(this.btnProcessVideo_Click);
            // 
            // txtBoxLink
            // 
            this.txtBoxLink.Location = new System.Drawing.Point(12, 34);
            this.txtBoxLink.Name = "txtBoxLink";
            this.txtBoxLink.Size = new System.Drawing.Size(388, 20);
            this.txtBoxLink.TabIndex = 1;
            this.txtBoxLink.Text = "https://www.youtube.com/watch?v=FOt3oQ_k008";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "YouTube link:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Location = new System.Drawing.Point(12, 87);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(469, 23);
            this.progressBarDownload.TabIndex = 4;
            // 
            // lblPercentageDownload
            // 
            this.lblPercentageDownload.AutoSize = true;
            this.lblPercentageDownload.Location = new System.Drawing.Point(454, 71);
            this.lblPercentageDownload.Name = "lblPercentageDownload";
            this.lblPercentageDownload.Size = new System.Drawing.Size(21, 13);
            this.lblPercentageDownload.TabIndex = 5;
            this.lblPercentageDownload.Text = "0%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Stahování";
            // 
            // lblPercentageConvert
            // 
            this.lblPercentageConvert.AutoSize = true;
            this.lblPercentageConvert.Location = new System.Drawing.Point(454, 123);
            this.lblPercentageConvert.Name = "lblPercentageConvert";
            this.lblPercentageConvert.Size = new System.Drawing.Size(21, 13);
            this.lblPercentageConvert.TabIndex = 9;
            this.lblPercentageConvert.Text = "0%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Konvertování:";
            // 
            // WindowsMediaPlayer
            // 
            this.WindowsMediaPlayer.Enabled = true;
            this.WindowsMediaPlayer.Location = new System.Drawing.Point(9, 197);
            this.WindowsMediaPlayer.Name = "WindowsMediaPlayer";
            this.WindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WindowsMediaPlayer.OcxState")));
            this.WindowsMediaPlayer.Size = new System.Drawing.Size(469, 267);
            this.WindowsMediaPlayer.TabIndex = 6;
            this.WindowsMediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.WindowsMediaPlayer_PlayStateChange);
            // 
            // progressBarConvert
            // 
            this.progressBarConvert.Location = new System.Drawing.Point(15, 139);
            this.progressBarConvert.Name = "progressBarConvert";
            this.progressBarConvert.Size = new System.Drawing.Size(463, 23);
            this.progressBarConvert.TabIndex = 11;
            // 
            // lstBoxPlaylist
            // 
            this.lstBoxPlaylist.FormattingEnabled = true;
            this.lstBoxPlaylist.Location = new System.Drawing.Point(506, 18);
            this.lstBoxPlaylist.Name = "lstBoxPlaylist";
            this.lstBoxPlaylist.Size = new System.Drawing.Size(308, 446);
            this.lstBoxPlaylist.TabIndex = 12;
            this.lstBoxPlaylist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstBoxPlaylist_KeyDown);
            this.lstBoxPlaylist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstBoxPlaylist_DoubleClick);
            // 
            // lblSateLine
            // 
            this.lblSateLine.AutoSize = true;
            this.lblSateLine.Location = new System.Drawing.Point(12, 58);
            this.lblSateLine.Name = "lblSateLine";
            this.lblSateLine.Size = new System.Drawing.Size(0, 13);
            this.lblSateLine.TabIndex = 13;
            // 
            // btnLoadDefaultPlaylist
            // 
            this.btnLoadDefaultPlaylist.Location = new System.Drawing.Point(506, 471);
            this.btnLoadDefaultPlaylist.Name = "btnLoadDefaultPlaylist";
            this.btnLoadDefaultPlaylist.Size = new System.Drawing.Size(308, 23);
            this.btnLoadDefaultPlaylist.TabIndex = 14;
            this.btnLoadDefaultPlaylist.Text = "Načti playlist";
            this.btnLoadDefaultPlaylist.UseVisualStyleBackColor = true;
            this.btnLoadDefaultPlaylist.Click += new System.EventHandler(this.btnLoadDefaultPlaylist_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 521);
            this.Controls.Add(this.btnLoadDefaultPlaylist);
            this.Controls.Add(this.lblSateLine);
            this.Controls.Add(this.lstBoxPlaylist);
            this.Controls.Add(this.progressBarConvert);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPercentageConvert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WindowsMediaPlayer);
            this.Controls.Add(this.lblPercentageDownload);
            this.Controls.Add(this.progressBarDownload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxLink);
            this.Controls.Add(this.btnProcessVideo);
            this.Name = "MainForm";
            this.Text = "Shared Kancl Playlist PLAYER";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_OnClose);
            ((System.ComponentModel.ISupportInitialize)(this.WindowsMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcessVideo;
        private System.Windows.Forms.TextBox txtBoxLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.Windows.Forms.Label lblPercentageDownload;
        private AxWMPLib.AxWindowsMediaPlayer WindowsMediaPlayer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPercentageConvert;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBarConvert;
        private System.Windows.Forms.ListBox lstBoxPlaylist;
        private Label lblSateLine;
        private Button btnLoadDefaultPlaylist;
    }
}

