using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace _24._04._2023
{
    public partial class Form1 : Form
    {
        int sizekulka = 50;
        int sizekwadrat = 50;
        int sizetrojkat = 75;
        IMoveObject[] TabKulek = new IMoveObject[15];
        //static readonly Color[] Tabkololek = { Color.Magenta, Color.Pink, Color.MediumPurple, Color.Red, Color.Blue, Color.Brown, Color.Yellow, Color.Green};
        public Form1()
        {
            InitializeComponent();
            Random c1 = new Random();
            panel1.BackColor = Color.Black;
            for (int i = 0; i < TabKulek.Length/3; i++)
            {
                TabKulek[i] = new Kulka(c1.Next(sizekulka, panel1.Width - (sizekulka * 2)), c1.Next(sizekulka, panel1.Height - (sizekulka * 2)), c1.NextDouble() * c1.Next(12, 20), c1.NextDouble() * c1.Next(12, 20), sizekulka);
                TabKulek[i].prepare();
            }
            for(int i = TabKulek.Length/3; i< 2*TabKulek.Length/3; i++)
            {
                TabKulek[i] = new Kwadracik(c1.Next(sizekwadrat, panel1.Width - (sizekwadrat * 2)), c1.Next(sizekwadrat, panel1.Height - (sizekwadrat * 2)), c1.NextDouble() * c1.Next(12, 20), c1.NextDouble() * c1.Next(12, 20), sizekwadrat);
                TabKulek[i].prepare();
            }
            for(int i = 2 * TabKulek.Length / 3; i < TabKulek.Length; i++)
            {
                TabKulek[i] = new Trojzab(c1.Next(sizetrojkat, panel1.Width - (sizekwadrat * 2)), c1.Next(sizetrojkat, panel1.Height - (sizekwadrat * 2)), c1.NextDouble() * c1.Next(12, 20), c1.NextDouble() * c1.Next(12, 20), sizetrojkat);
                TabKulek[i].prepare();
            }
            timer1.Start();
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

        private void panel1_Paint(object sender, PaintEventArgs e) 
        {
            for (int i = 0; i < TabKulek.Length; i++)
                TabKulek[i].Draw(e);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < TabKulek.Length; i++)
                TabKulek[i].Move(panel1);
            //panel1.Invalidate();
            panel1.Refresh();
        }
      

        private void Form1_ResizeEnd_1(object sender, EventArgs e)
        {
            for (int i = 0; i < TabKulek.Length; i++)
                TabKulek[i].MoveForResizeEnd(panel1);
        }
        private void SaveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            /*
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "savefile.txt");
            StreamWriter es = new StreamWriter(destPath);
            for (int i = 0; i < TabKulek.Length; i++)
                TabKulek[i].save(es);
            es.Close();
            */
            Figure t1 = new Figure(0, 0, 0, 0, 0);
            t1.Save3(TabKulek);

            t1.jsonreader(TabKulek, TabKulek.Length);

            /*
            Stream s = new FileStream("save", FileMode.Create);
            BinaryFormatter bw = new BinaryFormatter();
            for (int i = 0; i < TabKulek.Length; i++)
                TabKulek[i].save2(TabKulek[i], s, bw);
            s.Close();
            */
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "savefile.txt");
            if (!File.Exists(destPath))
            {
                MessageBox.Show("Brak pliku z zapisem!");
                return;
            }
            StreamReader es = new StreamReader(destPath);
            for (int i = 0; i < TabKulek.Length; i++)
                TabKulek[i].load(es);
            es.Close();
            */

            
            Stream s = new FileStream("save", FileMode.Open);
            BinaryFormatter bw = new BinaryFormatter();
            /*
            for (int i = 0; i < TabKulek.Length; i++)
                TabKulek[i].load2(TabKulek[i], s, bw);
            s.Close();
            */
            Figure t1 = new Figure(0, 0, 0, 0, 0);
            t1.load3(TabKulek,s,bw);
            for (int i = 0; i < TabKulek.Length; i++)
                TabKulek[i].Move(panel1);
            panel1.Refresh();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = true;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            stopToolStripMenuItem.Enabled = false;
            startToolStripMenuItem.Enabled = true;
        }
    }
}
