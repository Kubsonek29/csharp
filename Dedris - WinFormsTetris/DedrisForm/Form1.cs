using System.Reflection;
using Bonito_de_Minas;

namespace DedrisForm
{
    public partial class DedrisTheCoolGame : Form
    {
        public PictureBox[,] Pixels;
        public BonitoEngine DedrisEngine;
        public Board DedrisMap;
        int sizepixelheight;
        int sizepixelwidth;
        public DedrisTheCoolGame()
        {
            InitializeComponent();
            sizepixelheight = 25; //ilosc klockow w gore i w bok
            sizepixelwidth = 20;
            ///
            Pixels = new PictureBox[sizepixelheight,sizepixelwidth];
            DedrisMap = new Board(sizepixelheight, sizepixelwidth);
            DedrisEngine = new BonitoEngine(DedrisMap);
            ///
            DisplayArt.Image = Image.FromFile("dedrislogo.png");
            DisplayArt.SizeMode = PictureBoxSizeMode.StretchImage;
            Instructions.SizeMode = PictureBoxSizeMode.StretchImage;
            Instructions.Image = Image.FromFile("dedristext.png");
            panel1.BackColor = Color.White;
            stopToolStripMenuItem.Enabled = false;
            startToolStripMenuItem.Enabled = true;
            ///
            PreparePanelBoxes();
            PrepareEngineToStart();
            panel1.Refresh();
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
        public void PrepareEngineToStart()
        {
            DedrisEngine.ReadSchema();
            DedrisEngine.generujKlocek();
            foreach(var item in DedrisEngine.mojeklocki)
                item.SetMaptoKlocek(DedrisMap);
            PanelRefreshes.Start();
            GameRefreshes.Start();
        }
        public void PreparePanelBoxes()
        {
            int sizeboxheight = (int)(panel1.Height/sizepixelheight); //offset
            int sizeboxwidth = (int)(panel1.Width/sizepixelwidth);
            for (int i = 0; i < sizepixelheight; i++)
            {
                for(int j = 0; j < sizepixelwidth; j++)
                {
                    Pixels[i,j] = new PictureBox();
                    panel1.Controls.Add(Pixels[i, j]);
                    Pixels[i, j].Height = sizeboxheight;
                    Pixels[i, j].Width = sizeboxwidth;
                    Pixels[i, j].Top = 0 + i*sizeboxheight;
                    Pixels[i, j].Left = 0 + j*sizeboxwidth;
                    Pixels[i, j].Visible = true;
                    Pixels[i, j].BackColor = Color.Gray;
                }
            }
        }

        public void RefreshPanelBoxes()
        {
            int sizeboxheight = (int)(panel1.Height / sizepixelheight);
            int sizeboxwidth = (int)(panel1.Width / sizepixelwidth);
            for (int i = 0; i < sizepixelheight; i++)
                for (int j = 0; j < sizepixelwidth; j++)
                {
                    Pixels[i, j].Height = sizeboxheight;
                    Pixels[i, j].Width = sizeboxwidth;
                    Pixels[i, j].Top = 0 + i * sizeboxheight;
                    Pixels[i, j].Left = 0 + j * sizeboxwidth;
                    Pixels[i, j].Visible = true;
                }
        }
        public void ColorMovementForPanel()
        {
            for (int i = 0; i < sizepixelheight; i++)
                for (int j = 0; j < sizepixelwidth; j++)
                    if (DedrisMap[i, j] == 6 || DedrisMap[i, j] == 25)
                        Pixels[i, j].BackColor = Color.Red;
                    else if (DedrisMap[i, j] == 4 || DedrisMap[i, j] == 26)
                        Pixels[i, j].BackColor = Color.Blue;
                    else if (DedrisMap[i, j] == 9 || DedrisMap[i, j] == 27)
                        Pixels[i, j].BackColor = Color.Yellow;
                    else if (DedrisMap[i, j] == 5 || DedrisMap[i, j] == 28)
                        Pixels[i, j].BackColor = Color.Green;
                    else if (DedrisMap[i, j] == 7 || DedrisMap[i, j] == 29)
                        Pixels[i, j].BackColor = Color.Cyan;
                    else if (DedrisMap[i, j] == 8 || DedrisMap[i, j] == 30)
                        Pixels[i, j].BackColor = Color.BlueViolet;
                    else if (DedrisMap[i, j] == 0)
                        Pixels[i, j].BackColor = Color.Gray;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            RefreshPanelBoxes();
            panel1.Refresh();
        }

        private void PanelRefreshes_Tick(object sender, EventArgs e)
        {
            ColorMovementForPanel();
            panel1.Refresh();
        }
        private void GameRefreshes_Tick(object sender, EventArgs e)
        {
            if (DedrisEngine.checkifgameend() == true)
            {
                resetToolStripMenuItem_Click(sender, e);
                MessageBox.Show("The game ended!");
            }
            if (DedrisEngine.currentklocek.hasFallen() == true)
            {
                DedrisEngine.mapa.linecheck();
                DedrisEngine.generujKlocek();
                DedrisEngine.currentklocek.setonthemiddle();
            }
            DedrisEngine.currentklocek.MoveKlocki();
            ColorMovementForPanel();
            panel1.Refresh();
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'd')
                DedrisEngine.currentklocek.ControlKlocek(2);
            else if(e.KeyChar == 'a')
                DedrisEngine.currentklocek.ControlKlocek(1);
            if(e.KeyChar == 'j')
                DedrisEngine.currentklocek.ControlKlocek(3);
            if(e.KeyChar == 'k')
                DedrisEngine.currentklocek.ControlKlocek(4);
            DedrisEngine.currentklocek.MoveKlocki();
            ColorMovementForPanel();
            panel1.Refresh();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelRefreshes.Start();
            GameRefreshes.Start();
            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = true;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelRefreshes.Stop();
            GameRefreshes.Stop();
            startToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = false;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DedrisEngine.cleartheboardandreset();
            ColorMovementForPanel();
            DedrisEngine.currentklocek.setonthemiddle();
            PanelRefreshes.Stop();
            GameRefreshes.Stop();
            startToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = false;
        }

        private void DedrisTheCoolGame_Load(object sender, EventArgs e)
        {
            PanelRefreshes.Stop();
            GameRefreshes.Stop();
            MessageBox.Show("Welcome to the Dedris game\n press on the menu and select start\n to start enjoying this awesome game");
        }
    }
}