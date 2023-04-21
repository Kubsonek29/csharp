namespace Graphico_de_Minas
{
    partial class Form1
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
            this.TekstC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tekstF = new System.Windows.Forms.TextBox();
            this.tekstK = new System.Windows.Forms.TextBox();
            this.CLabel = new System.Windows.Forms.Label();
            this.FLabel = new System.Windows.Forms.Label();
            this.KLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TekstC
            // 
            this.TekstC.Location = new System.Drawing.Point(92, 113);
            this.TekstC.Name = "TekstC";
            this.TekstC.Size = new System.Drawing.Size(200, 39);
            this.TekstC.TabIndex = 1;
            this.TekstC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TekstC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tekst_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Temps";
            // 
            // tekstF
            // 
            this.tekstF.Location = new System.Drawing.Point(92, 231);
            this.tekstF.Name = "tekstF";
            this.tekstF.Size = new System.Drawing.Size(200, 39);
            this.tekstF.TabIndex = 4;
            this.tekstF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tekstF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tekst_KeyDown);
            // 
            // tekstK
            // 
            this.tekstK.Location = new System.Drawing.Point(92, 364);
            this.tekstK.Name = "tekstK";
            this.tekstK.Size = new System.Drawing.Size(200, 39);
            this.tekstK.TabIndex = 5;
            this.tekstK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tekstK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tekst_KeyDown);
            // 
            // CLabel
            // 
            this.CLabel.AutoSize = true;
            this.CLabel.Location = new System.Drawing.Point(298, 116);
            this.CLabel.Name = "CLabel";
            this.CLabel.Size = new System.Drawing.Size(39, 32);
            this.CLabel.TabIndex = 6;
            this.CLabel.Text = "*C";
            // 
            // FLabel
            // 
            this.FLabel.AutoSize = true;
            this.FLabel.Location = new System.Drawing.Point(308, 231);
            this.FLabel.Name = "FLabel";
            this.FLabel.Size = new System.Drawing.Size(26, 32);
            this.FLabel.TabIndex = 7;
            this.FLabel.Text = "F";
            // 
            // KLabel
            // 
            this.KLabel.AutoSize = true;
            this.KLabel.Location = new System.Drawing.Point(308, 367);
            this.KLabel.Name = "KLabel";
            this.KLabel.Size = new System.Drawing.Size(28, 32);
            this.KLabel.TabIndex = 8;
            this.KLabel.Text = "K";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 545);
            this.Controls.Add(this.KLabel);
            this.Controls.Add(this.FLabel);
            this.Controls.Add(this.CLabel);
            this.Controls.Add(this.tekstK);
            this.Controls.Add(this.tekstF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TekstC);
            this.Name = "Form1";
            this.Text = "Calc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox TekstC;
        private Label label1;
        private TextBox tekstF;
        private TextBox tekstK;
        private Label CLabel;
        private Label FLabel;
        private Label KLabel;
        double C = 0;
        double K = 0;
        double F = 0;
    }
}