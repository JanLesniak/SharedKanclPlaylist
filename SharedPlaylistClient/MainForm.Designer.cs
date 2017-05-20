namespace SheredPlaylistClient
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
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.btnSendUrl = new System.Windows.Forms.Button();
            this.lblWCFResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(13, 13);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(338, 20);
            this.textBoxUrl.TabIndex = 0;
            // 
            // btnSendUrl
            // 
            this.btnSendUrl.Location = new System.Drawing.Point(357, 11);
            this.btnSendUrl.Name = "btnSendUrl";
            this.btnSendUrl.Size = new System.Drawing.Size(98, 23);
            this.btnSendUrl.TabIndex = 1;
            this.btnSendUrl.Text = "Pošli do playlistu";
            this.btnSendUrl.UseVisualStyleBackColor = true;
            this.btnSendUrl.Click += new System.EventHandler(this.btnSendUrl_Click);
            // 
            // lblWCFResult
            // 
            this.lblWCFResult.AutoSize = true;
            this.lblWCFResult.Location = new System.Drawing.Point(13, 40);
            this.lblWCFResult.Name = "lblWCFResult";
            this.lblWCFResult.Size = new System.Drawing.Size(10, 13);
            this.lblWCFResult.TabIndex = 2;
            this.lblWCFResult.Text = "-";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 261);
            this.Controls.Add(this.lblWCFResult);
            this.Controls.Add(this.btnSendUrl);
            this.Controls.Add(this.textBoxUrl);
            this.Name = "MainForm";
            this.Text = "Shared Kancl Playlist CLIENT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button btnSendUrl;
        private System.Windows.Forms.Label lblWCFResult;
    }
}

