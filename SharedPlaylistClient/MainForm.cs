using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SheredPlaylistClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSendUrl_Click(object sender, EventArgs e)
        {
            lblWCFResult.Text = "Odesílám...";
            SharedKanclPlaylistWCFClient.SharedKanclPlaylistWCFSvcClient client = new SharedKanclPlaylistWCFClient.SharedKanclPlaylistWCFSvcClient("BasicHttpBinding_ISharedKanclPlaylistWCFSvc");
            lblWCFResult.Text = client.SendYoutubeUrl(textBoxUrl.Text);
            if (lblWCFResult.Text == "OK")
            {
                lblWCFResult.ForeColor = Color.Green;
            }
            else
            {
                lblWCFResult.ForeColor = Color.Red;
            }
        }
    }
}
