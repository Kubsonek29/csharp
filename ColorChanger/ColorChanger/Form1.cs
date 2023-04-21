namespace ColorChanger
{
    public partial class ColorChanger : Form
    {
        public ColorChanger()
        {
            InitializeComponent();
            preparetopaint();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0) //left
            {
                Color tmp = tab[0].BackColor;
                for(int i = 0; i < 3; i++)
                    tab[i].BackColor = tab[i+1].BackColor;
                tab[3].BackColor = tmp;
            }
            else //right
            {
                Color tmp = tab[3].BackColor;
                for (int i = 3; i >= 1; i--)
                    tab[i].BackColor = tab[i - 1].BackColor;
                tab[0].BackColor = tmp;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                RGBPAINTER.Enabled = true;
            else
                RGBPAINTER.Enabled = false;
        }
    }
}