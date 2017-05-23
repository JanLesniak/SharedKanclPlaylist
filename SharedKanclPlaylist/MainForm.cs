using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExtractor;

namespace SharedKanclPlaylist
{
    public partial class MainForm : Form
    {
        // TODO use wm playlist instead?
        List<string> paths;

        string defaultPath;
        int nowPlayingIndex;
        System.Windows.Forms.Timer pauseBetweenSongs;
        System.Windows.Forms.Timer checkNewUrlTimer;

        SharedKanclPlaylistWCFClient.SharedKanclPlaylistWCFSvcClient client;
        internal static ServiceHost myServiceHost = null;

        public MainForm()
        {
            InitializeComponent();
            paths = new List<string>();
            Directory.CreateDirectory(Environment.CurrentDirectory + @"\songs\");
            defaultPath = Environment.CurrentDirectory + @"\songs\";

            // Pause between songs
            pauseBetweenSongs = new System.Windows.Forms.Timer()
            {
                Interval = 2000
            };
            pauseBetweenSongs.Stop();
            pauseBetweenSongs.Tick += new EventHandler(PauseBetweenSongs_Tick);

            checkNewUrlTimer = new System.Windows.Forms.Timer()
            {
                Interval = 10000
            };
            checkNewUrlTimer.Tick += new EventHandler(CheckNewUrlTimer_Tick);
            checkNewUrlTimer.Start();


            client = new SharedKanclPlaylistWCFClient.SharedKanclPlaylistWCFSvcClient("BasicHttpBinding_ISharedKanclPlaylistWCFSvc");

            Task.Factory.StartNew(() =>
            {
                if (myServiceHost != null)
                {
                    myServiceHost.Close();
                }
                myServiceHost = new ServiceHost(typeof(SharedKanclPlaylistWCFSvc.SharedKanclPlaylistWCFSvc));
                myServiceHost.Open();
            });

        }

        private void CheckNewUrlTimer_Tick(object sender, EventArgs e)
        {
            TryGetNewUrl();
        }

        private void BtnProcessVideo_Click(object sender, EventArgs e)
        {
            lblSateLine.Text = "";
            progressBarConvert.Value = 0;
            progressBarDownload.Value = 0;
            btnProcessVideo.Enabled = false;

            try
            {
                AddSong(txtBoxLink.Text);
            }
            catch (Exception)
            {
                lblSateLine.Text = "Špatný link.";
                lblSateLine.ForeColor = Color.Red;
                btnProcessVideo.Enabled = true;
            }

        }

        private void AddSong(string link)
        {
            var path = Environment.CurrentDirectory + @"\songs\";

            var video = GetVideo(link);
            FetchPaths(path, video, out string videoName, out string videoFullPath);

            var videoDownloader = new VideoDownloader(video, videoFullPath);

            videoDownloader.DownloadProgressChanged += VideoDownloader_DownloadProgressChanged;
            videoDownloader.DownloadFinished += (sender, e) => VideoDownloader_DownloadFinished(sender, e, videoFullPath, path, videoName);

            Thread thread = new Thread(() => { videoDownloader.Execute(); }) { IsBackground = true };
            thread.Start();

        }

        private void FetchPaths(string path, VideoInfo video, out string videoName, out string videoFullPath)
        {
            videoName = video.Title;
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                videoName = videoName.Replace(c, '_');
            }
            videoName = videoName.Replace('.', '_');

            videoFullPath = Path.Combine(path, videoName + video.VideoExtension);
        }

        private VideoInfo GetVideo(string link)
        {
            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(link);


            VideoInfo video = videoInfos
                .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 360);

            if (video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(video);
            }
            return video;
        }

        private void VideoDownloader_DownloadFinished(object sender, EventArgs e, string videoFullPath, string path, string videoName)
        {
            var inputFile = new MediaFile { Filename = videoFullPath };
            string musicFullPath = $"{path + videoName}.mp3";
            var outputFile = new MediaFile { Filename = musicFullPath };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                engine.ConvertProgressEvent += Engine_ConvertProgressEvent;
                engine.Convert(inputFile, outputFile);
            }
            File.Delete(videoFullPath);
            Invoke(new MethodInvoker(delegate ()
            {
                btnProcessVideo.Enabled = true;
                lblSateLine.Text = "Povedlo se!";
                lblSateLine.ForeColor = Color.Green;
            }));
            AddSongToPlayList(musicFullPath, videoName);

            checkNewUrlTimer.Start();

            // DELETE ONLY FOR TEST PURPOSE
            if (paths.Count == 1)
            {
                WindowsMediaPlayer.URL = paths[0];
            }
        }

        private void Engine_ConvertProgressEvent(object sender, ConvertProgressEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                double prct = (e.ProcessedDuration.Ticks / (double)e.TotalDuration.Ticks) * 100;
                progressBarConvert.Value = (int)prct;
                lblPercentageConvert.Text = $"{string.Format("{0:0.#}", prct)}%";
                progressBarConvert.Update();
            }));
        }

        private void VideoDownloader_DownloadProgressChanged(object sender, ProgressEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                progressBarDownload.Value = (int)e.ProgressPercentage;
                lblPercentageDownload.Text = $"{string.Format("{0:0.#}", e.ProgressPercentage)}%";
                progressBarDownload.Update();
            }));
        }

        private void AddSongToPlayList(string path, string name)
        {
            paths.Add(path);
            Invoke(new MethodInvoker(delegate ()
            {
                lstBoxPlaylist.Items.Add(name);
            }));
        }

        // START PLAYING CHOOSEN SONG
        private void LstBoxPlaylist_DoubleClick(object sender, MouseEventArgs e)
        {
            int index = lstBoxPlaylist.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                nowPlayingIndex = lstBoxPlaylist.SelectedIndex;
                WindowsMediaPlayer.URL = paths[nowPlayingIndex];

            }
        }

        private void LstBoxPlaylist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                WindowsMediaPlayer.URL = paths[lstBoxPlaylist.SelectedIndex];
            }

        }

        private void BtnLoadDefaultPlaylist_Click(object sender, EventArgs e)
        {
            paths = new List<string>();
            lstBoxPlaylist.Items.Clear();

            DirectoryInfo d = new DirectoryInfo(defaultPath);
            FileInfo[] Files = d.GetFiles("*.mp3"); //Getting mp3 files
            foreach (FileInfo file in Files)
            {
                paths.Add(file.FullName);
                lstBoxPlaylist.Items.Add(file.Name.Remove(file.Name.Length - 4));
            }
        }

        private void WindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Media ended (next song)
            if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                if (btnRandomPlay.Checked)
                {
                    Random r = new Random();
                    int rInt = r.Next(0, lstBoxPlaylist.Items.Count); //for ints

                    nowPlayingIndex = rInt;
                    WindowsMediaPlayer.URL = paths[rInt];
                }
                else
                {
                    nowPlayingIndex++;
                }

                if (nowPlayingIndex < paths.Count)
                {
                    lstBoxPlaylist.SetSelected(nowPlayingIndex, true);
                    WindowsMediaPlayer.URL = paths[nowPlayingIndex];
                    pauseBetweenSongs.Start();
                }
            }
        }

        void PauseBetweenSongs_Tick(object sender, EventArgs e)
        {
            pauseBetweenSongs.Stop();
            WindowsMediaPlayer.Ctlcontrols.play();
        }

        private void TryGetNewUrl()
        {
            string newUrl = client.GetYoutubeUrl();
            if (!string.IsNullOrEmpty(newUrl))
            {
                checkNewUrlTimer.Stop();
                txtBoxLink.Text = newUrl;

                lblSateLine.Text = "";
                progressBarConvert.Value = 0;
                progressBarDownload.Value = 0;
                btnProcessVideo.Enabled = false;

                try
                {
                    AddSong(newUrl);
                }
                catch (Exception)
                {
                    lblSateLine.Text = "Špatný link.";
                    lblSateLine.ForeColor = Color.Red;
                    btnProcessVideo.Enabled = true;
                }
            }
        }

        private void MainForm_OnClose(object sender, FormClosingEventArgs e)
        {
            if (myServiceHost != null)
            {
                myServiceHost.Close();
                myServiceHost = null;
            }
        }
    }
}
