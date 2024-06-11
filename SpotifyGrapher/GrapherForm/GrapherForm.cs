using GrapherForm.Models;
using System.ComponentModel;

namespace GrapherForm
{
    public partial class GrapherForm : Form
    {
        private Dictionary<string, FoundArtist> _foundArtists = null;
        private Dictionary<string, FoundArtist> _reviewArtists = null;
        private Dictionary<string, FoundArtist> _removedArtists = null;
        private Dictionary<string, string> _musicFinished = null;
        private Dictionary<string, MusicToReview> _musicToReview = null;

        private BackgroundWorker _graphArtistsWorker = null;

        private string _tempAccessToken = null;
        private Random _random = new();

        public GrapherForm()
        {
            InitializeComponent();
        }

        private void btn_Environment_Explorer_Click(object sender, EventArgs e)
        {
            if (ofd_Environment_FileDialog.ShowDialog() == DialogResult.OK)
            {
                tb_Environment_FilePath.Text = ofd_Environment_FileDialog.FileName;
            }
        }

        private void btn_Environment_Load_Click(object sender, EventArgs e)
        {
            EnvironmentG environment = FileHandler.GetEnvironment(tb_Environment_FilePath.Text, out _foundArtists, out _reviewArtists, out _removedArtists, out _musicFinished, out _musicToReview);
            if (environment != null)
            {
                tb_Environment_PlaylistID.Text = environment.PlaylistID;
                tb_Environment_FoundArtists.Text = environment.FoundArtistFile;
                tb_Environment_ArtistsReview.Text = environment.ArtistReviewFile;
                tb_Environment_RemovedArtists.Text = environment.RemovedArtistFile;
                tb_Environment_MusicFinished.Text = environment.MusicFinishedFile;
                tb_Environment_MusicReview.Text = environment.MusicToReviewFile;
                tb_Tokens_ClientID.Text = environment.ClientID;
                tb_Tokens_ClientSecret.Text = environment.ClientSecret;

                ResetReviewArtistListBox();
            }
        }

        private void btn_Environment_Save_Click(object sender, EventArgs e)
        {
            EnvironmentG environment = new()
            {
                PlaylistID = tb_Environment_PlaylistID.Text,
                FoundArtistFile = tb_Environment_FoundArtists.Text,
                ArtistReviewFile = tb_Environment_ArtistsReview.Text,
                RemovedArtistFile = tb_Environment_RemovedArtists.Text,
                MusicFinishedFile = tb_Environment_MusicFinished.Text,
                MusicToReviewFile = tb_Environment_MusicReview.Text,
                ClientID = tb_Tokens_ClientID.Text,
                ClientSecret = tb_Tokens_ClientSecret.Text,
            };
            _foundArtists ??= [];
            _reviewArtists ??= [];
            _removedArtists ??= [];
            _musicFinished ??= [];
            _musicToReview ??= [];
            FileHandler.SaveEnvironment(tb_Environment_FilePath.Text, environment, _foundArtists, _reviewArtists, _removedArtists, _musicFinished, _musicToReview);
            MessageBox.Show("Save Completed");

            ResetReviewArtistListBox();
        }

        private void btn_Tokens_Refresh_Click(object sender, EventArgs e)
        {
            string curRefreshToken = tb_Tokens_Refresh.Text;
            string clientID = tb_Tokens_ClientID.Text;
            string clientSecret = tb_Tokens_ClientSecret.Text;

            string newAccessToken = APIHandler.RefreshAccessToken(curRefreshToken, clientID, clientSecret).Result;
            if (newAccessToken == null)
            {
                MessageBox.Show("ERROR refreshing access token, stopping now.");
            }
            else
            {
                tb_Tokens_Access.Text = newAccessToken;
            }
        }

        private void btn_Actions_GraphArtists_Click(object sender, EventArgs e)
        {
            if (btn_Actions_GraphArtists.Text.Contains("START"))
            {
                //we want to start this action
                btn_Actions_GraphArtists.Text = "Graph Artists - STOP";
                _graphArtistsWorker?.CancelAsync(); //just in case

                _tempAccessToken = tb_Tokens_Access.Text;
                _graphArtistsWorker = new();
                _graphArtistsWorker.DoWork += GraphArtistsWorker;
                _graphArtistsWorker.RunWorkerCompleted += GraphArtistsStop;
                _graphArtistsWorker.WorkerSupportsCancellation = true;
                _graphArtistsWorker.RunWorkerAsync();

            }
            else
            {
                //we want to stop this action
                btn_Actions_GraphArtists.Text = "Graph Artists - START";
                _graphArtistsWorker.CancelAsync();
                _tempAccessToken = null;
            }
        }

        public void GraphArtistsWorker(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < _foundArtists.Count; i++)
            {
                KeyValuePair<string, FoundArtist> curItem = _foundArtists.ElementAt(i);
                if (!curItem.Value.RelatedVisited)
                {
                    APIHandler.RelatedArtistsResponse thisResponse = APIHandler.GetRelatedArtists(curItem.Value.ID, _tempAccessToken).Result;
                    if (thisResponse == null || thisResponse.artists == null)
                    {
                        //not good, exit out of loop now and come back to it after refreshing access token probably
                        break;
                    }
                    else
                    {
                        foreach (APIHandler.RelatedArtistsResponse.Artist artist in thisResponse.artists)
                        {
                            if (!_foundArtists.ContainsKey(artist.id) && !_removedArtists.ContainsKey(artist.id) && !_reviewArtists.ContainsKey(artist.id))
                            {
                                //we haven't found this artist yet, figure out where to put them
                                if (artist.name.Contains("radio", StringComparison.CurrentCultureIgnoreCase) || artist.genres.Any(x => x.Contains("country", StringComparison.CurrentCultureIgnoreCase)))
                                {
                                    _reviewArtists.Add(artist.id, new()
                                    {
                                        Genres = artist.genres,
                                        ID = artist.id,
                                        Name = artist.name,
                                        RelatedVisited = false,
                                    });
                                }
                                else
                                {
                                    //we'll assume they're fine for now
                                    _foundArtists.Add(artist.id, new()
                                    {
                                        ID = artist.id,
                                        Name = artist.name,
                                        RelatedVisited = false,
                                    });
                                }
                            }
                        }
                        curItem.Value.RelatedVisited = true;
                        Task waitTask = Task.Delay(_random.Next(2000, 4000));
                        Task.WaitAll(waitTask);
                    }
                }
            }
        }

        public void GraphArtistsStop(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Stopped graphing artists");
            btn_Actions_GraphArtists.Text = "Graph Artists - START";
        }

        private void lb_artistsReview_artists_Change(object sender, EventArgs e)
        {
            object item = lb_artistsReview_artists.SelectedValue;
            if (item is string typeItem && _reviewArtists.TryGetValue(typeItem, out FoundArtist artist))
            {
                lb_artistsReview_genres.DataSource = artist.Genres;
            }
        }

        private void ResetReviewArtistListBox()
        {
            Dictionary<string, string> artistLBData = _reviewArtists.ToDictionary(x => x.Key, x => x.Value.Name);
            lb_artistsReview_artists.DataSource = new BindingSource(artistLBData, null);
            lb_artistsReview_artists.DisplayMember = "Value";
            lb_artistsReview_artists.ValueMember = "Key";
        }

        private void btn_artistsReview_add_Click(object sender, EventArgs e)
        {
            object item = lb_artistsReview_artists.SelectedValue;
            if (item is string typeItem && _reviewArtists.TryGetValue(typeItem, out FoundArtist artist))
            {
                _foundArtists.Add(artist.ID, new()
                {
                    ID = artist.ID,
                    Name = artist.Name,
                    RelatedVisited = false
                });
                _reviewArtists.Remove(artist.ID);
                ResetReviewArtistListBox();
            }
        }

        private void btn_artistsReview_remove_Click(object sender, EventArgs e)
        {
            object item = lb_artistsReview_artists.SelectedValue;
            if (item is string typeItem && _reviewArtists.TryGetValue(typeItem, out FoundArtist artist))
            {
                _removedArtists.Add(artist.ID, new()
                {
                    ID = artist.ID,
                    Name = artist.Name,
                    RelatedVisited = false
                });
                _reviewArtists.Remove(artist.ID);
                ResetReviewArtistListBox();
            }
        }
    }
}
