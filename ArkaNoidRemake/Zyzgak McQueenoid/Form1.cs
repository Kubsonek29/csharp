using Microsoft.VisualBasic.Devices;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Zyzgak_McQueenoid
{
    public partial class ArkaNoid : Form
    {
        PotatoEngine ArkaNoidEngine;
        int OldPanelWidth;
        int OldPanelHeight;
        public ArkaNoid()
        {
            InitializeComponent();
            PreparePanel();
            InitalizeObjects();
            PrepareMenu();
            MainPanel.Refresh();
        }
        void PreparePanel()
        {
            OldPanelHeight = MainPanel.Height;
            OldPanelWidth = MainPanel.Width;
            MainPanel.BackColor = Color.Transparent;
        }
        void PrepareMenu()
        {
            ArkaNoidEngine.Menu = true;
            CountPlayerLives.Hide();
            Scores.Hide();
            MainPanel.BackColor = Color.Black;
            MenuLogo.Image = Image.FromFile(Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\..\")) + "/AkraLogo.png");
            MenuLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            MenuLogo.Visible = true;
            StartGame.BackColor = Color.Red;
            StartGame.Font = new Font(Scores.Font.FontFamily, 18f, FontStyle.Bold);
            StartGame.ForeColor = Color.White;
            LoadGame.BackColor = Color.Green;
            LoadGame.Font = new Font(Scores.Font.FontFamily, 18f, FontStyle.Bold);
            LoadGame.ForeColor = Color.White;
            SaveButton.BackColor = Color.Orange;
            SaveButton.Font = new Font(Scores.Font.FontFamily, 18f, FontStyle.Bold);
            SaveButton.ForeColor = Color.White;
        }
        void InitalizeObjects()
        {
            ArkaNoidEngine = new PotatoEngine(MainPanel);
            ArkaNoidEngine.Obstacles = ArkaNoidEngine.setupObstaclesLevel(ArkaNoidEngine.currentResMultiplyWidth, ArkaNoidEngine.currentResMultiplyHeight, ArkaNoidEngine.currentlevel, MainPanel);
            ArkaNoidEngine.PlayerLives = 3;
            CountPlayerLives.Text = "Pozostalo zyc: " + ArkaNoidEngine.PlayerLives + "\nCurrent Level = " + ArkaNoidEngine.currentlevel;
            CountPlayerLives.Enabled = false;
            Scores.Text = "SCORE = " + ArkaNoidEngine.score + "\nHIGHSCORE = " + ArkaNoidEngine.highscore;
            Scores.Enabled = false;
            Scores.Font = new Font(Scores.Font.FontFamily, 10f, FontStyle.Bold);
            Scores.ForeColor = Color.DarkOrange;
            CountPlayerLives.Font = new Font(Scores.Font.FontFamily, 10f, FontStyle.Bold);
            CountPlayerLives.ForeColor = Color.DarkOrange;
        }
        void PrepareGame()
        {
            //MenuHide();
            GameTimer.Start();
            PanelTimer.Start();
            if(ArkaNoidEngine.resumingcount == -1)
                ArkaNoidEngine.tinyboard.PreparePaletkaToTheLevel();
            //tinyboard.setpaddledisplay(MainPanel);
            ArkaNoid.ActiveForm.Focus(); ///!!!!!
            ArkaNoidEngine.Menu = false;
        }
        private void PanelTimer_Tick(object sender, EventArgs e)
        {
            MainPanel.Refresh();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                cp.ExStyle |= 0x00080000;
                return cp;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //ArkaNoidEngine.ForceLevelEnd();
            if (ArkaNoidEngine.checkLeveComplete() == true)
            {
                ArkaNoidEngine.currentlevel++;
                GameTimer.Stop();
                PanelTimer.Stop();
                ArkaNoidEngine.Obstacles = ArkaNoidEngine.setupObstaclesLevel(ArkaNoidEngine.currentResMultiplyWidth, ArkaNoidEngine.currentResMultiplyHeight, ArkaNoidEngine.currentlevel, MainPanel);
                MessageBox.Show(ArkaNoidEngine.currentlevel + "lvl complete!");
                ArkaNoidEngine.tinyball.followpaddle = true;
                ArkaNoidEngine.Bonus.forcemetodespawn();
                ArkaNoidEngine.RemoveAdditionalBallsAfterLevelCompletes(); ///?
                MainPanel.Refresh();
                GameTimer.Start();
                PanelTimer.Start();
            }
            if (ArkaNoidEngine.tinyball.followpaddle == false)
            {
                //ArkaNoidEngine.score = ArkaNoidEngine.tinyball.BallCollisionObstaclePaletka(ArkaNoidEngine.Obstacles, ArkaNoidEngine.score);
                ArkaNoidEngine.score = ArkaNoidEngine.tinyball.AdvancedCollisions(ArkaNoidEngine.Obstacles, ArkaNoidEngine.score);
                ArkaNoidEngine.PlayerLives = ArkaNoidEngine.tinyball.BasicBallMovement(ArkaNoidEngine.PlayerLives);
            }
            else
                ArkaNoidEngine.tinyball.followpaddlemovement();
            ///additional balls
            foreach (var item in ArkaNoidEngine.tinyballs)
                if (item.IsMainBall == false)
                {
                    //item.BallCollisionObstaclePaletka(ArkaNoidEngine.Obstacles, ArkaNoidEngine.score);
                    item.AdvancedCollisions(ArkaNoidEngine.Obstacles, ArkaNoidEngine.score);
                    item.BasicBallMovement(ArkaNoidEngine.PlayerLives);
                }
            ArkaNoidEngine.CheckBallStatusAndRemoveFallenOnes();
            ArkaNoidEngine.Bonus.RollToSpawnTheBonus();
            ArkaNoidEngine.Bonus.Movingdown();
            if (ArkaNoidEngine.PlayerLives == -1)
            {
                GameTimer.Stop();
                PanelTimer.Stop();
                MessageBox.Show("Unluckily but u lost ;c");
                GetBackToMenu();
                ArkaNoidEngine.resethegame();
                ArkaNoidEngine.Obstacles = ArkaNoidEngine.setupObstaclesLevel(ArkaNoidEngine.currentResMultiplyWidth, ArkaNoidEngine.currentResMultiplyHeight, ArkaNoidEngine.currentlevel, MainPanel);
            }
            if (ArkaNoidEngine.score > ArkaNoidEngine.highscore)
                ArkaNoidEngine.highscore = ArkaNoidEngine.score;
            CountPlayerLives.Text = "SCORE = " + ArkaNoidEngine.score + "\nPozostalo zyc =  " + ArkaNoidEngine.PlayerLives;
            Scores.Text = "HIGHSCORE = " + ArkaNoidEngine.highscore + "\ncurrentlevel = " + ArkaNoidEngine.currentlevel;
            Scores.SelectionBackColor = Color.Red;
            CountPlayerLives.SelectAll();
            CountPlayerLives.SelectionAlignment = HorizontalAlignment.Center;
            CountPlayerLives.DeselectAll();
            Scores.SelectAll();
            Scores.SelectionAlignment = HorizontalAlignment.Center;
            Scores.DeselectAll();
        }

        private void ArkaNoid_ResizeEnd(object sender, EventArgs e) 
        {
            ReSizeFunction();
        }
        private void ArkaNoid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ArkaNoidEngine.Menu == true) return;
            //foreach (var item in ArkaNoidEngine.Entities)
            //    item.keypressMoveEntity(e);
            ArkaNoidEngine.tinyboard.keypressMoveEntity(e);
            foreach (var item in ArkaNoidEngine.tinyballs)
                item.keypressMoveEntity(e);
            if (e.KeyChar == 'm' && ArkaNoidEngine.Menu == false)
            {
                GetBackToMenu();
                ArkaNoidEngine.resumingcount = 3;
            }
            if(e.KeyChar == 'R' && ArkaNoidEngine.Menu == false)
            {
                GameTimer.Stop();
                PanelTimer.Stop();
                MessageBox.Show("The game was force Reset");
                GetBackToMenu();
                ArkaNoidEngine.resethegame();
                ArkaNoidEngine.Obstacles = ArkaNoidEngine.setupObstaclesLevel(ArkaNoidEngine.currentResMultiplyWidth, ArkaNoidEngine.currentResMultiplyHeight, ArkaNoidEngine.currentlevel, MainPanel);
            }
        }
        void GetBackToMenu()
        {
            PrepareMenu();
            ArkaNoid.ActiveForm.BackgroundImage = null;
            ArkaNoid.ActiveForm.BackColor = Color.Black;
            StartGame.Visible = true;
            LoadGame.Visible = true;
            SaveButton.Visible = true;
            StartGame.Enabled = true;
            LoadGame.Enabled = true;
            SaveButton.Enabled = true;
            StartGame.BringToFront();
            LoadGame.BringToFront();
            SaveButton.BringToFront();
            GameTimer.Stop();
            PanelTimer.Stop();
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            if (ArkaNoidEngine.Menu == true) return;
            //foreach (var item in ArkaNoidEngine.Entities)
            //    item.displayentity(e);
            ArkaNoidEngine.tinyboard.displayentity(e);
            foreach (var item in ArkaNoidEngine.tinyballs)
                item.displayentity(e);
            foreach (var item in ArkaNoidEngine.Obstacles)
                item.displayentity(e);
            ArkaNoidEngine.Bonus.displayentity(e);
            if (ArkaNoidEngine.resumingcount > -1) ResumeGameAfterPausing(e);
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            ArkaNoid.ActiveForm.BackgroundImage = BackgroundImage = Image.FromFile(Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\..\")) + "/backgroundArkaNoid.png");
            //MainPanel.Height = 1000*(int)currentResMultiplyHeight;
            //MainPanel.Width = 875*(int)currentResMultiplyWidth;
            ReSizeFunction();
            MenuHide();
            PrepareGame();
        }
        private void LoadGame_Click(object sender, EventArgs e)
        {
            ArkaNoidEngine.LoadTheGame();
            StartGame_Click(sender, e);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ArkaNoidEngine.SaveTheGame();
        }
        private void ResumeGameAfterPausing(PaintEventArgs e)
        {
            if(ArkaNoidEngine.resumingcount == 3)
            {
                GameTimer.Stop();
                PanelTimer.Interval = 1000;
            }
            Brush pencil = new SolidBrush(Color.Yellow);
            Font countdownFont = new Font("Arial", 90, FontStyle.Bold);
            if(ArkaNoidEngine.resumingcount > 0)
            {
                e.Graphics.DrawString(ArkaNoidEngine.resumingcount.ToString(), countdownFont, pencil, MainPanel.Width / 2, MainPanel.Height / 2,
                new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
            else if(ArkaNoidEngine.resumingcount == 0)
            {
                e.Graphics.DrawString("Go!", countdownFont, pencil, MainPanel.Width / 2, MainPanel.Height / 2,
                new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                PanelTimer.Interval = 60;
                GameTimer.Start();
                PanelTimer.Start();
            }
            ArkaNoidEngine.resumingcount--;
        }
        private void ReSizeFunction()
        {
            ArkaNoidEngine.currentResMultiplyWidth = ((double)MainPanel.Width / (double)OldPanelWidth);
            ArkaNoidEngine.currentResMultiplyHeight = ((double)MainPanel.Height / (double)OldPanelHeight);
            ArkaNoidEngine.Map.updateMapSize(MainPanel.Height, MainPanel.Width);
            ArkaNoidEngine.tinyboard.AdjustLocationAndSpeedAfterResize(OldPanelWidth, OldPanelHeight, MainPanel.Width, MainPanel.Height, ArkaNoidEngine.currentResMultiplyWidth, ArkaNoidEngine.currentResMultiplyHeight);
            ArkaNoidEngine.tinyball.AdjustLocationAndSpeedAfterResize(OldPanelWidth, OldPanelHeight, MainPanel.Width, MainPanel.Height, ArkaNoidEngine.currentResMultiplyWidth, ArkaNoidEngine.currentResMultiplyHeight);
            foreach (var item in ArkaNoidEngine.Obstacles)
                item.AdjustLocationAndSpeedAfterResize(OldPanelWidth, OldPanelHeight, MainPanel.Width, MainPanel.Height, ArkaNoidEngine.currentResMultiplyWidth, ArkaNoidEngine.currentResMultiplyHeight);
            ///
            Scores.Top = ArkaNoid.ActiveForm.Height - Scores.Height*2;
            CountPlayerLives.Top = ArkaNoid.ActiveForm.Height - Scores.Height*2;
            OldPanelHeight = MainPanel.Height;
            OldPanelWidth = MainPanel.Width;     //res 25;1030    playerlives 460;1030  //435; 75
            Scores.Width = MainPanel.Width / 2;
            CountPlayerLives.Width = MainPanel.Width / 2;
            CountPlayerLives.Left = 25 + Scores.Width; //415 550
            ///
            if(SaveButton.Top + SaveButton.Height > 1000)
            {
                StartGame.Height = 200;
                LoadGame.Height = 200;
                SaveButton.Height = 200;
            }
            StartGame.Top = 15 + MenuLogo.Top + MenuLogo.Height;
            LoadGame.Top = 10 + StartGame.Top + StartGame.Height;
            SaveButton.Top = 10 + LoadGame.Top + LoadGame.Height;
            MainPanel.Refresh();
        }
        private void MenuHide()
        {
            CountPlayerLives.Visible = true;
            Scores.Visible = true;
            PreparePanel();
            MenuLogo.Hide();
            MenuLogo.Enabled = false;
            StartGame.Hide();
            StartGame.Enabled = false;
            LoadGame.Hide();
            LoadGame.Enabled = false;
            SaveButton.Hide();
            SaveButton.Enabled = false;
        }
    }
}
