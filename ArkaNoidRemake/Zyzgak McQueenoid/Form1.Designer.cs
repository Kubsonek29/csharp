using System.Reflection.Metadata;

namespace Zyzgak_McQueenoid
{
    partial class ArkaNoid
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
            components = new System.ComponentModel.Container();
            MainPanel = new Panel();
            SaveButton = new Button();
            LoadGame = new Button();
            StartGame = new Button();
            MenuLogo = new PictureBox();
            GameTimer = new System.Windows.Forms.Timer(components);
            PanelTimer = new System.Windows.Forms.Timer(components);
            CountPlayerLives = new RichTextBox();
            Scores = new RichTextBox();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MenuLogo).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainPanel.Controls.Add(SaveButton);
            MainPanel.Controls.Add(LoadGame);
            MainPanel.Controls.Add(StartGame);
            MainPanel.Controls.Add(MenuLogo);
            MainPanel.Location = new Point(26, 26);
            MainPanel.Margin = new Padding(2);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(875, 1120);
            MainPanel.TabIndex = 0;
            MainPanel.Paint += MainPanel_Paint;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SaveButton.Location = new Point(100, 830);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(659, 175);
            SaveButton.TabIndex = 7;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // LoadGame
            // 
            LoadGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LoadGame.Location = new Point(100, 640);
            LoadGame.Name = "LoadGame";
            LoadGame.Size = new Size(659, 175);
            LoadGame.TabIndex = 6;
            LoadGame.Text = "Load";
            LoadGame.UseVisualStyleBackColor = true;
            LoadGame.Click += LoadGame_Click;
            // 
            // StartGame
            // 
            StartGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StartGame.Location = new Point(100, 454);
            StartGame.Name = "StartGame";
            StartGame.Size = new Size(659, 175);
            StartGame.TabIndex = 5;
            StartGame.Text = "Play!";
            StartGame.UseVisualStyleBackColor = true;
            StartGame.Click += StartGame_Click;
            // 
            // MenuLogo
            // 
            MenuLogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MenuLogo.Location = new Point(100, 94);
            MenuLogo.Name = "MenuLogo";
            MenuLogo.Size = new Size(659, 345);
            MenuLogo.TabIndex = 4;
            MenuLogo.TabStop = false;
            // 
            // GameTimer
            // 
            GameTimer.Interval = 60;
            GameTimer.Tick += GameTimer_Tick;
            // 
            // PanelTimer
            // 
            PanelTimer.Interval = 60;
            PanelTimer.Tick += PanelTimer_Tick;
            // 
            // CountPlayerLives
            // 
            CountPlayerLives.BackColor = SystemColors.HotTrack;
            CountPlayerLives.Location = new Point(460, 1030);
            CountPlayerLives.Name = "CountPlayerLives";
            CountPlayerLives.Size = new Size(435, 75);
            CountPlayerLives.TabIndex = 1;
            CountPlayerLives.Text = "";
            // 
            // Scores
            // 
            Scores.BackColor = SystemColors.HotTrack;
            Scores.Location = new Point(25, 1030);
            Scores.Name = "Scores";
            Scores.Size = new Size(435, 75);
            Scores.TabIndex = 2;
            Scores.Text = "";
            // 
            // ArkaNoid
            // 
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(920, 1280);
            Controls.Add(Scores);
            Controls.Add(CountPlayerLives);
            Controls.Add(MainPanel);
            DoubleBuffered = true;
            Margin = new Padding(2, 1, 2, 1);
            MinimumSize = new Size(920, 1280);
            Name = "ArkaNoid";
            Text = "McQueeNoid";
            ResizeEnd += ArkaNoid_ResizeEnd;
            SizeChanged += ArkaNoid_ResizeEnd;
            KeyPress += ArkaNoid_KeyPress;
            MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MenuLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        //BackgroundImage = Image.FromFile(Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\..\")) + "/backgroundArkaNoid.png");
        private Panel MainPanel;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Timer PanelTimer;
        private RichTextBox CountPlayerLives;
        private RichTextBox Scores;
        private PictureBox MenuLogo;
        private Button LoadGame;
        private Button StartGame;
        private Button SaveButton;
    }
}