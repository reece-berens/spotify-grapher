namespace GrapherForm
{
    partial class GrapherForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gb_Environment = new GroupBox();
            lbl_Environment_MusicReview = new Label();
            tb_Environment_MusicReview = new TextBox();
            lbl_Environment_MusicFinished = new Label();
            tb_Environment_MusicFinished = new TextBox();
            lbl_Environment_RemovedArtists = new Label();
            tb_Environment_RemovedArtists = new TextBox();
            lbl_Environment_ArtistReview = new Label();
            tb_Environment_ArtistsReview = new TextBox();
            lbl_Environment_FoundArtists = new Label();
            tb_Environment_FoundArtists = new TextBox();
            lbl_Environment_PlaylistID = new Label();
            tb_Environment_PlaylistID = new TextBox();
            btn_Environment_Save = new Button();
            btn_Environment_Load = new Button();
            btn_Environment_Explorer = new Button();
            lbl_Environment_FilePath = new Label();
            tb_Environment_FilePath = new TextBox();
            ofd_Environment_FileDialog = new OpenFileDialog();
            gb_Tokens = new GroupBox();
            lbl_Tokens_ClientSecret = new Label();
            tb_Tokens_ClientSecret = new TextBox();
            lbl_Tokens_ClientID = new Label();
            tb_Tokens_ClientID = new TextBox();
            btn_Tokens_Refresh = new Button();
            lbl_Tokens_Refresh = new Label();
            tb_Tokens_Refresh = new TextBox();
            lbl_Tokens_Access = new Label();
            tb_Tokens_Access = new TextBox();
            gb_Actions = new GroupBox();
            btn_Actions_GraphArtists = new Button();
            gb_artistsReview = new GroupBox();
            btn_artistsReview_remove = new Button();
            btn_artistsReview_add = new Button();
            lb_artistsReview_genres = new ListBox();
            lb_artistsReview_artists = new ListBox();
            gb_Environment.SuspendLayout();
            gb_Tokens.SuspendLayout();
            gb_Actions.SuspendLayout();
            gb_artistsReview.SuspendLayout();
            SuspendLayout();
            // 
            // gb_Environment
            // 
            gb_Environment.Controls.Add(lbl_Environment_MusicReview);
            gb_Environment.Controls.Add(tb_Environment_MusicReview);
            gb_Environment.Controls.Add(lbl_Environment_MusicFinished);
            gb_Environment.Controls.Add(tb_Environment_MusicFinished);
            gb_Environment.Controls.Add(lbl_Environment_RemovedArtists);
            gb_Environment.Controls.Add(tb_Environment_RemovedArtists);
            gb_Environment.Controls.Add(lbl_Environment_ArtistReview);
            gb_Environment.Controls.Add(tb_Environment_ArtistsReview);
            gb_Environment.Controls.Add(lbl_Environment_FoundArtists);
            gb_Environment.Controls.Add(tb_Environment_FoundArtists);
            gb_Environment.Controls.Add(lbl_Environment_PlaylistID);
            gb_Environment.Controls.Add(tb_Environment_PlaylistID);
            gb_Environment.Controls.Add(btn_Environment_Save);
            gb_Environment.Controls.Add(btn_Environment_Load);
            gb_Environment.Controls.Add(btn_Environment_Explorer);
            gb_Environment.Controls.Add(lbl_Environment_FilePath);
            gb_Environment.Controls.Add(tb_Environment_FilePath);
            gb_Environment.Location = new Point(12, 12);
            gb_Environment.Name = "gb_Environment";
            gb_Environment.Size = new Size(499, 489);
            gb_Environment.TabIndex = 0;
            gb_Environment.TabStop = false;
            gb_Environment.Text = "Environment Information";
            // 
            // lbl_Environment_MusicReview
            // 
            lbl_Environment_MusicReview.AutoSize = true;
            lbl_Environment_MusicReview.Location = new Point(6, 414);
            lbl_Environment_MusicReview.Name = "lbl_Environment_MusicReview";
            lbl_Environment_MusicReview.Size = new Size(179, 15);
            lbl_Environment_MusicReview.TabIndex = 1;
            lbl_Environment_MusicReview.Text = "Music To Review File Path/Name";
            // 
            // tb_Environment_MusicReview
            // 
            tb_Environment_MusicReview.Location = new Point(6, 432);
            tb_Environment_MusicReview.Name = "tb_Environment_MusicReview";
            tb_Environment_MusicReview.Size = new Size(441, 23);
            tb_Environment_MusicReview.TabIndex = 9;
            // 
            // lbl_Environment_MusicFinished
            // 
            lbl_Environment_MusicFinished.AutoSize = true;
            lbl_Environment_MusicFinished.Location = new Point(6, 363);
            lbl_Environment_MusicFinished.Name = "lbl_Environment_MusicFinished";
            lbl_Environment_MusicFinished.Size = new Size(171, 15);
            lbl_Environment_MusicFinished.TabIndex = 1;
            lbl_Environment_MusicFinished.Text = "Music Finished File Path/Name";
            // 
            // tb_Environment_MusicFinished
            // 
            tb_Environment_MusicFinished.Location = new Point(6, 381);
            tb_Environment_MusicFinished.Name = "tb_Environment_MusicFinished";
            tb_Environment_MusicFinished.Size = new Size(441, 23);
            tb_Environment_MusicFinished.TabIndex = 8;
            // 
            // lbl_Environment_RemovedArtists
            // 
            lbl_Environment_RemovedArtists.AutoSize = true;
            lbl_Environment_RemovedArtists.Location = new Point(6, 313);
            lbl_Environment_RemovedArtists.Name = "lbl_Environment_RemovedArtists";
            lbl_Environment_RemovedArtists.Size = new Size(178, 15);
            lbl_Environment_RemovedArtists.TabIndex = 12;
            lbl_Environment_RemovedArtists.Text = "Removed Artists File Path/Name";
            // 
            // tb_Environment_RemovedArtists
            // 
            tb_Environment_RemovedArtists.Location = new Point(6, 331);
            tb_Environment_RemovedArtists.Name = "tb_Environment_RemovedArtists";
            tb_Environment_RemovedArtists.Size = new Size(441, 23);
            tb_Environment_RemovedArtists.TabIndex = 7;
            // 
            // lbl_Environment_ArtistReview
            // 
            lbl_Environment_ArtistReview.AutoSize = true;
            lbl_Environment_ArtistReview.Location = new Point(6, 260);
            lbl_Environment_ArtistReview.Name = "lbl_Environment_ArtistReview";
            lbl_Environment_ArtistReview.Size = new Size(180, 15);
            lbl_Environment_ArtistReview.TabIndex = 10;
            lbl_Environment_ArtistReview.Text = "Artists To Review File Path/Name";
            // 
            // tb_Environment_ArtistsReview
            // 
            tb_Environment_ArtistsReview.Location = new Point(6, 278);
            tb_Environment_ArtistsReview.Name = "tb_Environment_ArtistsReview";
            tb_Environment_ArtistsReview.Size = new Size(441, 23);
            tb_Environment_ArtistsReview.TabIndex = 6;
            // 
            // lbl_Environment_FoundArtists
            // 
            lbl_Environment_FoundArtists.AutoSize = true;
            lbl_Environment_FoundArtists.Location = new Point(6, 202);
            lbl_Environment_FoundArtists.Name = "lbl_Environment_FoundArtists";
            lbl_Environment_FoundArtists.Size = new Size(162, 15);
            lbl_Environment_FoundArtists.TabIndex = 8;
            lbl_Environment_FoundArtists.Text = "Found Artists File Path/Name";
            // 
            // tb_Environment_FoundArtists
            // 
            tb_Environment_FoundArtists.Location = new Point(6, 220);
            tb_Environment_FoundArtists.Name = "tb_Environment_FoundArtists";
            tb_Environment_FoundArtists.Size = new Size(441, 23);
            tb_Environment_FoundArtists.TabIndex = 5;
            // 
            // lbl_Environment_PlaylistID
            // 
            lbl_Environment_PlaylistID.AutoSize = true;
            lbl_Environment_PlaylistID.Location = new Point(6, 143);
            lbl_Environment_PlaylistID.Name = "lbl_Environment_PlaylistID";
            lbl_Environment_PlaylistID.Size = new Size(58, 15);
            lbl_Environment_PlaylistID.TabIndex = 6;
            lbl_Environment_PlaylistID.Text = "Playlist ID";
            // 
            // tb_Environment_PlaylistID
            // 
            tb_Environment_PlaylistID.Location = new Point(6, 161);
            tb_Environment_PlaylistID.Name = "tb_Environment_PlaylistID";
            tb_Environment_PlaylistID.Size = new Size(441, 23);
            tb_Environment_PlaylistID.TabIndex = 4;
            // 
            // btn_Environment_Save
            // 
            btn_Environment_Save.Location = new Point(293, 92);
            btn_Environment_Save.Name = "btn_Environment_Save";
            btn_Environment_Save.Size = new Size(124, 30);
            btn_Environment_Save.TabIndex = 3;
            btn_Environment_Save.Text = "Save Environment";
            btn_Environment_Save.UseVisualStyleBackColor = true;
            btn_Environment_Save.Click += btn_Environment_Save_Click;
            // 
            // btn_Environment_Load
            // 
            btn_Environment_Load.Location = new Point(146, 92);
            btn_Environment_Load.Name = "btn_Environment_Load";
            btn_Environment_Load.Size = new Size(124, 30);
            btn_Environment_Load.TabIndex = 2;
            btn_Environment_Load.Text = "Load Environment";
            btn_Environment_Load.UseVisualStyleBackColor = true;
            btn_Environment_Load.Click += btn_Environment_Load_Click;
            // 
            // btn_Environment_Explorer
            // 
            btn_Environment_Explorer.Location = new Point(6, 92);
            btn_Environment_Explorer.Name = "btn_Environment_Explorer";
            btn_Environment_Explorer.Size = new Size(124, 30);
            btn_Environment_Explorer.TabIndex = 1;
            btn_Environment_Explorer.Text = "Open Explorer";
            btn_Environment_Explorer.UseVisualStyleBackColor = true;
            btn_Environment_Explorer.Click += btn_Environment_Explorer_Click;
            // 
            // lbl_Environment_FilePath
            // 
            lbl_Environment_FilePath.AutoSize = true;
            lbl_Environment_FilePath.Location = new Point(6, 28);
            lbl_Environment_FilePath.Name = "lbl_Environment_FilePath";
            lbl_Environment_FilePath.Size = new Size(52, 15);
            lbl_Environment_FilePath.TabIndex = 1;
            lbl_Environment_FilePath.Text = "File Path";
            // 
            // tb_Environment_FilePath
            // 
            tb_Environment_FilePath.Location = new Point(6, 46);
            tb_Environment_FilePath.Name = "tb_Environment_FilePath";
            tb_Environment_FilePath.Size = new Size(441, 23);
            tb_Environment_FilePath.TabIndex = 0;
            // 
            // ofd_Environment_FileDialog
            // 
            ofd_Environment_FileDialog.FileName = "openFileDialog1";
            // 
            // gb_Tokens
            // 
            gb_Tokens.Controls.Add(lbl_Tokens_ClientSecret);
            gb_Tokens.Controls.Add(tb_Tokens_ClientSecret);
            gb_Tokens.Controls.Add(lbl_Tokens_ClientID);
            gb_Tokens.Controls.Add(tb_Tokens_ClientID);
            gb_Tokens.Controls.Add(btn_Tokens_Refresh);
            gb_Tokens.Controls.Add(lbl_Tokens_Refresh);
            gb_Tokens.Controls.Add(tb_Tokens_Refresh);
            gb_Tokens.Controls.Add(lbl_Tokens_Access);
            gb_Tokens.Controls.Add(tb_Tokens_Access);
            gb_Tokens.Location = new Point(517, 12);
            gb_Tokens.Name = "gb_Tokens";
            gb_Tokens.Size = new Size(906, 252);
            gb_Tokens.TabIndex = 1;
            gb_Tokens.TabStop = false;
            gb_Tokens.Text = "Auth Tokens";
            // 
            // lbl_Tokens_ClientSecret
            // 
            lbl_Tokens_ClientSecret.AutoSize = true;
            lbl_Tokens_ClientSecret.Location = new Point(436, 143);
            lbl_Tokens_ClientSecret.Name = "lbl_Tokens_ClientSecret";
            lbl_Tokens_ClientSecret.Size = new Size(73, 15);
            lbl_Tokens_ClientSecret.TabIndex = 8;
            lbl_Tokens_ClientSecret.Text = "Client Secret";
            // 
            // tb_Tokens_ClientSecret
            // 
            tb_Tokens_ClientSecret.Location = new Point(436, 161);
            tb_Tokens_ClientSecret.Name = "tb_Tokens_ClientSecret";
            tb_Tokens_ClientSecret.Size = new Size(439, 23);
            tb_Tokens_ClientSecret.TabIndex = 7;
            // 
            // lbl_Tokens_ClientID
            // 
            lbl_Tokens_ClientID.AutoSize = true;
            lbl_Tokens_ClientID.Location = new Point(6, 143);
            lbl_Tokens_ClientID.Name = "lbl_Tokens_ClientID";
            lbl_Tokens_ClientID.Size = new Size(52, 15);
            lbl_Tokens_ClientID.TabIndex = 6;
            lbl_Tokens_ClientID.Text = "Client ID";
            // 
            // tb_Tokens_ClientID
            // 
            tb_Tokens_ClientID.Location = new Point(6, 161);
            tb_Tokens_ClientID.Name = "tb_Tokens_ClientID";
            tb_Tokens_ClientID.Size = new Size(333, 23);
            tb_Tokens_ClientID.TabIndex = 5;
            // 
            // btn_Tokens_Refresh
            // 
            btn_Tokens_Refresh.Location = new Point(6, 202);
            btn_Tokens_Refresh.Name = "btn_Tokens_Refresh";
            btn_Tokens_Refresh.Size = new Size(189, 32);
            btn_Tokens_Refresh.TabIndex = 4;
            btn_Tokens_Refresh.Text = "Refresh Access Token";
            btn_Tokens_Refresh.UseVisualStyleBackColor = true;
            btn_Tokens_Refresh.Click += btn_Tokens_Refresh_Click;
            // 
            // lbl_Tokens_Refresh
            // 
            lbl_Tokens_Refresh.AutoSize = true;
            lbl_Tokens_Refresh.Location = new Point(6, 83);
            lbl_Tokens_Refresh.Name = "lbl_Tokens_Refresh";
            lbl_Tokens_Refresh.Size = new Size(80, 15);
            lbl_Tokens_Refresh.TabIndex = 3;
            lbl_Tokens_Refresh.Text = "Refresh Token";
            // 
            // tb_Tokens_Refresh
            // 
            tb_Tokens_Refresh.Location = new Point(6, 101);
            tb_Tokens_Refresh.Name = "tb_Tokens_Refresh";
            tb_Tokens_Refresh.Size = new Size(869, 23);
            tb_Tokens_Refresh.TabIndex = 2;
            // 
            // lbl_Tokens_Access
            // 
            lbl_Tokens_Access.AutoSize = true;
            lbl_Tokens_Access.Location = new Point(6, 28);
            lbl_Tokens_Access.Name = "lbl_Tokens_Access";
            lbl_Tokens_Access.Size = new Size(77, 15);
            lbl_Tokens_Access.TabIndex = 1;
            lbl_Tokens_Access.Text = "Access Token";
            // 
            // tb_Tokens_Access
            // 
            tb_Tokens_Access.Location = new Point(6, 46);
            tb_Tokens_Access.Name = "tb_Tokens_Access";
            tb_Tokens_Access.Size = new Size(869, 23);
            tb_Tokens_Access.TabIndex = 0;
            // 
            // gb_Actions
            // 
            gb_Actions.Controls.Add(btn_Actions_GraphArtists);
            gb_Actions.Location = new Point(1451, 12);
            gb_Actions.Name = "gb_Actions";
            gb_Actions.Size = new Size(429, 252);
            gb_Actions.TabIndex = 2;
            gb_Actions.TabStop = false;
            gb_Actions.Text = "Actions";
            // 
            // btn_Actions_GraphArtists
            // 
            btn_Actions_GraphArtists.Location = new Point(25, 46);
            btn_Actions_GraphArtists.Name = "btn_Actions_GraphArtists";
            btn_Actions_GraphArtists.Size = new Size(161, 33);
            btn_Actions_GraphArtists.TabIndex = 0;
            btn_Actions_GraphArtists.Text = "Graph Artists - START";
            btn_Actions_GraphArtists.UseVisualStyleBackColor = true;
            btn_Actions_GraphArtists.Click += btn_Actions_GraphArtists_Click;
            // 
            // gb_artistsReview
            // 
            gb_artistsReview.Controls.Add(btn_artistsReview_remove);
            gb_artistsReview.Controls.Add(btn_artistsReview_add);
            gb_artistsReview.Controls.Add(lb_artistsReview_genres);
            gb_artistsReview.Controls.Add(lb_artistsReview_artists);
            gb_artistsReview.Location = new Point(523, 290);
            gb_artistsReview.Name = "gb_artistsReview";
            gb_artistsReview.Size = new Size(900, 378);
            gb_artistsReview.TabIndex = 3;
            gb_artistsReview.TabStop = false;
            gb_artistsReview.Text = "Artists To Review";
            // 
            // btn_artistsReview_remove
            // 
            btn_artistsReview_remove.Location = new Point(170, 329);
            btn_artistsReview_remove.Name = "btn_artistsReview_remove";
            btn_artistsReview_remove.Size = new Size(105, 29);
            btn_artistsReview_remove.TabIndex = 3;
            btn_artistsReview_remove.Text = "Remove";
            btn_artistsReview_remove.UseVisualStyleBackColor = true;
            btn_artistsReview_remove.Click += btn_artistsReview_remove_Click;
            // 
            // btn_artistsReview_add
            // 
            btn_artistsReview_add.Location = new Point(6, 329);
            btn_artistsReview_add.Name = "btn_artistsReview_add";
            btn_artistsReview_add.Size = new Size(105, 29);
            btn_artistsReview_add.TabIndex = 2;
            btn_artistsReview_add.Text = "Add";
            btn_artistsReview_add.UseVisualStyleBackColor = true;
            btn_artistsReview_add.Click += btn_artistsReview_add_Click;
            // 
            // lb_artistsReview_genres
            // 
            lb_artistsReview_genres.FormattingEnabled = true;
            lb_artistsReview_genres.ItemHeight = 15;
            lb_artistsReview_genres.Location = new Point(492, 35);
            lb_artistsReview_genres.Name = "lb_artistsReview_genres";
            lb_artistsReview_genres.Size = new Size(377, 274);
            lb_artistsReview_genres.TabIndex = 1;
            // 
            // lb_artistsReview_artists
            // 
            lb_artistsReview_artists.FormattingEnabled = true;
            lb_artistsReview_artists.ItemHeight = 15;
            lb_artistsReview_artists.Location = new Point(6, 35);
            lb_artistsReview_artists.Name = "lb_artistsReview_artists";
            lb_artistsReview_artists.Size = new Size(418, 274);
            lb_artistsReview_artists.TabIndex = 0;
            lb_artistsReview_artists.SelectedValueChanged += lb_artistsReview_artists_Change;
            // 
            // GrapherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1894, 767);
            Controls.Add(gb_artistsReview);
            Controls.Add(gb_Actions);
            Controls.Add(gb_Tokens);
            Controls.Add(gb_Environment);
            Name = "GrapherForm";
            Text = "Spotify Grapher v1";
            gb_Environment.ResumeLayout(false);
            gb_Environment.PerformLayout();
            gb_Tokens.ResumeLayout(false);
            gb_Tokens.PerformLayout();
            gb_Actions.ResumeLayout(false);
            gb_artistsReview.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gb_Environment;
        private Button btn_Environment_Save;
        private Button btn_Environment_Load;
        private Button btn_Environment_Explorer;
        private Label lbl_Environment_FilePath;
        private TextBox tb_Environment_FilePath;
        private OpenFileDialog ofd_Environment_FileDialog;
        private Label lbl_Environment_PlaylistID;
        private TextBox tb_Environment_PlaylistID;
        private Label lbl_Environment_FoundArtists;
        private TextBox tb_Environment_FoundArtists;
        private Label lbl_Environment_MusicFinished;
        private TextBox tb_Environment_MusicFinished;
        private Label lbl_Environment_RemovedArtists;
        private TextBox tb_Environment_RemovedArtists;
        private Label lbl_Environment_ArtistReview;
        private TextBox tb_Environment_ArtistsReview;
        private Label lbl_Environment_MusicReview;
        private TextBox tb_Environment_MusicReview;
        private GroupBox gb_Tokens;
        private Button btn_Tokens_Refresh;
        private Label lbl_Tokens_Refresh;
        private TextBox tb_Tokens_Refresh;
        private Label lbl_Tokens_Access;
        private TextBox tb_Tokens_Access;
        private Label lbl_Tokens_ClientSecret;
        private TextBox tb_Tokens_ClientSecret;
        private Label lbl_Tokens_ClientID;
        private TextBox tb_Tokens_ClientID;
        private GroupBox gb_Actions;
        private Button btn_Actions_GraphArtists;
        private GroupBox gb_artistsReview;
        private ListBox lb_artistsReview_artists;
        private Button btn_artistsReview_remove;
        private Button btn_artistsReview_add;
        private ListBox lb_artistsReview_genres;
    }
}
