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
            gb_Environment.SuspendLayout();
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
            // GrapherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2008, 919);
            Controls.Add(gb_Environment);
            Name = "GrapherForm";
            Text = "Spotify Grapher v1";
            gb_Environment.ResumeLayout(false);
            gb_Environment.PerformLayout();
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
    }
}
