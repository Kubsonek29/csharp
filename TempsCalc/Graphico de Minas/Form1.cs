namespace Graphico_de_Minas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Przycisk1_Click(object sender, EventArgs e)
        {
            TekstC.Text += ((Button)sender).Text;
        }

        private void Tekst_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                try
                {
                    CalculateTemps();
                    TekstC.Text = C.ToString();
                    tekstF.Text = F.ToString();
                    tekstK.Text = K.ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        private void CalculateTemps()
        {

            if (TekstC.Text != "")
            {
                if (double.TryParse(TekstC.Text, out double n))
                {
                    if (double.Parse(TekstC.Text) != C)
                    {
                        C = double.Parse(TekstC.Text);
                        F = C * (9.0 / 5.0) + 32.0;
                        K = C + 273.15;
                    }
                }
                else
                    throw new Exception("B³êdnie podano temperature na pozycji *C");
            }
            else if(tekstK.Text != "")
            {
                if (double.TryParse(tekstK.Text, out double n))
                {
                    if (double.Parse(tekstK.Text) != K)
                    {
                        K = double.Parse(tekstK.Text);
                        F = (K - 273.15) * (9.0 / 5.0) + 32;
                        C = K - 273.15;
                    }
                }
                else
                    throw new Exception("B³êdnie podano temperature na pozycji K");
            }
            else if(tekstF.Text != "")
            {
                if (double.TryParse(tekstF.Text, out double n))
                {
                    if (double.Parse(tekstF.Text) != F)
                    {
                        F = double.Parse(tekstF.Text);
                        K = (F - 32.0) * (5.0 / 9.0) + 273.15;
                        C = (F - 32.0) * (5.0 / 9.0);
                    }
                }
                else
                    throw new Exception("B³êdnie podano temperature na pozycji F");
            }
        }
    }
}