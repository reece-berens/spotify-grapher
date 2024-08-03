using GrapherForm.Models;
using System.ComponentModel;
using static GrapherForm.APIHandler;

namespace GrapherForm
{
    public partial class GrapherForm : Form
    {
        private Dictionary<string, FoundArtist> _foundArtists = null;
        private Dictionary<string, FoundArtist> _reviewArtists = null;
        private Dictionary<string, FoundArtist> _removedArtists = null;
        private Dictionary<string, List<string>> _musicFinished = null;
        private Dictionary<string, List<MusicToReview>> _musicToReview = null;

        private BackgroundWorker _addAlbumsWorker = null;
        private BackgroundWorker _graphArtistsWorker = null;

        private string _tempAccessToken = null;
        private readonly Random _random = new();

        private readonly List<string> badAlbumThings = [
            "live",
            "deluxe",
            "remaster",
            "remastered",
            "box set",
            "boxed set",
            "expanded",
        ];

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
                                        AlbumsVisited = false,
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
                                        AlbumsVisited = false,
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
                    RelatedVisited = false,
                    AlbumsVisited = false,
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

        private void btn_Actions_AddAlbums_Click(object sender, EventArgs e)
        {
            if (btn_Actions_AddAlbums.Text.Contains("START"))
            {
                //we want to start this action
                btn_Actions_AddAlbums.Text = "Add Albums - STOP";
                _addAlbumsWorker?.CancelAsync(); //just in case

                _tempAccessToken = tb_Tokens_Access.Text;
                _addAlbumsWorker = new();
                _addAlbumsWorker.DoWork += AddAlbumsWorker;
                _addAlbumsWorker.RunWorkerCompleted += AddAlbumsStop;
                _addAlbumsWorker.WorkerSupportsCancellation = true;
                _addAlbumsWorker.RunWorkerAsync();

            }
            else
            {
                //we want to stop this action
                btn_Actions_AddAlbums.Text = "Add Albums - START";
                _addAlbumsWorker.CancelAsync();
                _tempAccessToken = null;
            }
        }

        public void AddAlbumsStop(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Stopped adding albums");
            btn_Actions_AddAlbums.Text = "Add Albums - START";
            _addAlbumsWorker?.CancelAsync();
            _tempAccessToken = null;
        }

        public async void AddAlbumsWorker(object sender, DoWorkEventArgs e)
        {
            Task waitTask;
            bool keepWorking = true;
            for (int i = 0; i < _foundArtists.Count && keepWorking; i++)
            {
                KeyValuePair<string, FoundArtist> curArtist = _foundArtists.ElementAt(i);
                if (!curArtist.Value.AlbumsVisited.GetValueOrDefault())
                {
                    //get all albums
                    //for each album
                    //  check if album in finished or to review for each artist listed, continue if not
                    //  if album is named good
                    //      get all songs and add to playlist
                    //  if album is not named good
                    //      add to review list
                    AlbumsOfArtistResponse albumListResponse = new() { next = null};
                    do
                    {
                        albumListResponse = await APIHandler.GetAlbumsOfArtist(curArtist.Key, _tempAccessToken, albumListResponse.next);
                        waitTask = Task.Delay(_random.Next(3000, 4000));
                        waitTask.Wait();
                        if (albumListResponse != null && albumListResponse.items != null)
                        {
                            foreach (AlbumsOfArtistResponse.AlbumItem album in albumListResponse.items)
                            {
                                bool doAlbum = true;
                                if (album.artists != null && album.artists.Count > 0 /*hopefully this should never happen but idk*/)
                                {
                                    foreach (AlbumsOfArtistResponse.Artist artist in album.artists)
                                    {
                                        doAlbum = doAlbum && (!_musicFinished.TryGetValue(artist.id, out List<string> finishedMusic) || !finishedMusic.Contains(album.id));
                                        doAlbum = doAlbum && (!_musicToReview.TryGetValue(artist.id, out List<MusicToReview> reviewMusic) || !reviewMusic.Any(x => x.ID == album.id));
                                    }
                                    if (doAlbum) //we haven't seen this one before
                                    {
                                        if (badAlbumThings.Any(x => album.name.Contains(x, StringComparison.OrdinalIgnoreCase)))
                                        {
                                            //add to review list
                                            if (!_musicToReview.TryGetValue(album.artists[0].id, out List<MusicToReview> reviewItem))
                                            {
                                                reviewItem = [];
                                                _musicToReview.Add(album.artists[0].id, reviewItem);
                                            }
                                            MusicToReview toReviewItem = new()
                                            {
                                                AlbumName = album.name,
                                                ID = album.id,
                                                Artists = []
                                            };
                                            reviewItem.Add(toReviewItem);
                                            foreach (AlbumsOfArtistResponse.Artist artist in album.artists)
                                            {
                                                toReviewItem.Artists.Add(new()
                                                {
                                                    ArtistName = artist.name,
                                                    ID = artist.id,
                                                });
                                            }
                                        }
                                        else
                                        {
                                            TracksResponse tracksResponse = new() { next = null };
                                            do
                                            {
                                                tracksResponse = await APIHandler.GetSongsInAlbum(album.id, _tempAccessToken, tracksResponse.next);
                                                waitTask = Task.Delay(_random.Next(3000, 4000));
                                                waitTask.Wait();
                                                if (tracksResponse != null && tracksResponse.items != null && tracksResponse.items.Count > 0)
                                                {
                                                    AddTracksRequest newRequest = new()
                                                    {
                                                        uris = [.. tracksResponse.items.Select(x => x.uri)]
                                                    };
                                                    bool didSuccessSave = await APIHandler.AddSongsToPlaylist(tb_Environment_PlaylistID.Text, newRequest, _tempAccessToken);
                                                    waitTask = Task.Delay(_random.Next(3000, 4000));
                                                    waitTask.Wait();
                                                    if (!didSuccessSave)
                                                    {
                                                        keepWorking = false;
                                                        break;
                                                    }
                                                }
                                            } while (tracksResponse != null && !string.IsNullOrEmpty(tracksResponse.next));

                                            if (!_musicFinished.TryGetValue(album.artists[0].id, out List<string> finishedItem))
                                            {
                                                finishedItem = [];
                                                _musicFinished.Add(album.artists[0].id, finishedItem);
                                            }
                                            finishedItem.Add(album.id);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            keepWorking = false;
                        }
                    } while (albumListResponse != null && !string.IsNullOrWhiteSpace(albumListResponse.next));
                    if (keepWorking)
                    {
                        curArtist.Value.AlbumsVisited = true;
                    }
                }
            }
        }
    }
}
