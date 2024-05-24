using GrapherForm.Models;

namespace GrapherForm
{
    public partial class GrapherForm : Form
    {
        private Dictionary<string, FoundArtist> _foundArtists = null;
        private Dictionary<string, FoundArtist> _reviewArtists = null;
        private Dictionary<string, FoundArtist> _removedArtists = null;
        private Dictionary<string, string> _musicFinished = null;
        private Dictionary<string, MusicToReview> _musicToReview = null;

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
    }
}
