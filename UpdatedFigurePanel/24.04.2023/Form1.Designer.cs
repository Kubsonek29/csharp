using Microsoft.VisualBasic.Devices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using static _24._04._2023.Form1;

namespace _24._04._2023
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(33, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 523);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.animacjaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(71, 38);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click_1);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // animacjaToolStripMenuItem
            // 
            this.animacjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.animacjaToolStripMenuItem.Name = "animacjaToolStripMenuItem";
            this.animacjaToolStripMenuItem.Size = new System.Drawing.Size(131, 38);
            this.animacjaToolStripMenuItem.Text = "Animacja";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Enabled = false;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 672);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem plikToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem animacjaToolStripMenuItem;
        private ToolStripMenuItem startToolStripMenuItem;
        private ToolStripMenuItem stopToolStripMenuItem;

        [Serializable]
        public class Figure
        {
            [NonSerialized]
            private Dictionary<string, string> dicfield = new Dictionary<string, string>();
            [NonSerialized]
            private Dictionary<string, MemberInfo> dicmem = new Dictionary<string, MemberInfo>();
            [Description("PositionX")]
            public double x { get; set; }

            [Description("PositionY")]
            public double y { get; set; }

            [Description("VelocityX")]
            public double Vx { get; set; }

            [Description("VelocityY")]
            public double Vy { get; set; }

            [Description("Size")]
            public double size { get; set; }

            [Description("Color")]
            public Color colorek { get; set; }

            public Figure(double x, double y, double Vx, double Vy, double size)
            {
                this.x = x;
                this.y = y;
                this.Vx = Vx;
                this.Vy = Vy;
                this.size = size;
            }

            public void PrepareFieldsToSaveorLoad()
            {
                Type t = this.GetType();
                MemberInfo[] members = t.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                dicfield.Clear();
                dicmem.Clear();
                foreach (MemberInfo m in members)
                {
                    object[] attributes = m.GetCustomAttributes(true);
                    if (attributes.Length != 0 && m.MemberType.ToString() == "Field")
                    {
                        string key = "";
                        foreach (object attribute in attributes)
                        {
                            DescriptionAttribute de = attribute as DescriptionAttribute;
                            if (de != null)
                                key = de.Description;
                        }
                        FieldInfo f = m.ReflectedType.GetField(m.Name);
                        if (f == null)
                            continue;
                        object o = m.ReflectedType.GetField(m.Name).GetValue(this);
                        if (o != null)
                        {
                            dicfield.Add(key, m.ReflectedType.GetField(m.Name).GetValue(this).ToString());// { PositionX , 1 }
                            dicmem.Add(key, f); // {PositionX, Double x }
                        }
                    }
                }
            }
            public void Save3(IMoveObject[] Figury)
            {
                Stream s = new FileStream("save", FileMode.Create);
                BinaryFormatter bw = new BinaryFormatter();
                bw.Serialize(s, Figury);
                s.Close();
            }
            public void jsonreader(IMoveObject[] mbappe, int size)
            {
                Figure[] cisco = new Figure[size];
                for(int i = 0; i < cisco.Length; i++)
                    cisco[i] = (Figure)mbappe[i];
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(cisco, options);
                //MessageBox.Show(json);
                StreamWriter essa = new StreamWriter("savejson");
                essa.Write(json);
                essa.Close();
            }
            public void load3(IMoveObject[] Figury, Stream s, BinaryFormatter bf)
            {
                IMoveObject[] checky = (IMoveObject[])bf.Deserialize(s);
                for (int i = 0; i < Figury.Length; i++)
                    Figury[i] = checky[i];
                s.Close();
            }
            public void saver(IMoveObject OneFigure, Stream s, BinaryFormatter bw)
            {
                bw.Serialize(s, OneFigure);
            }
            public void reader(Stream s, BinaryFormatter bf, object onefigure)
            {
                var checky = (Figure)bf.Deserialize(s);
                onefigure = checky;
            }
            public void SaveToTheFile(StreamWriter es, string Name)
            {
                PrepareFieldsToSaveorLoad();
                es.WriteLine(Name);
                for(int i = 0; i < dicfield.Count && i < dicmem.Count; i++)
                {
                    KeyValuePair<string, string> entry = dicfield.ElementAt(i);
                    KeyValuePair<string, MemberInfo> entrytwo = dicmem.ElementAt(i);
                    es.WriteLine(entry.Key + " # " + entry.Value + " # " + entrytwo.Value);
                }
                es.WriteLine("#####");
            }
            public void ReadTheFile(StreamReader es)
            {
                Type t = this.GetType();
                MemberInfo[] members = t.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                Dictionary<string, MemberInfo> correctmembers = new Dictionary<string, MemberInfo>();
                foreach (MemberInfo m in members)
                {
                    object[] attributes = m.GetCustomAttributes(true);
                    if (attributes.Length != 0 && m.MemberType.ToString() == "Field")
                    {
                        string key = "";
                        foreach (object attribute in attributes)
                        {
                            DescriptionAttribute de = attribute as DescriptionAttribute;
                            if (de != null)
                                key = de.Description;
                        }
                        FieldInfo f = m.ReflectedType.GetField(m.Name);
                        if (f != null)
                            correctmembers.Add(key,f);
                    }
                }
                es.ReadLine();
                while (!es.EndOfStream)
                {
                    string tmp = es.ReadLine();
                    foreach (KeyValuePair<string, MemberInfo> TypesFigures in correctmembers)
                    {
                        if (tmp.Contains("#####"))
                            return;
                        if (tmp.Contains(TypesFigures.Value.ToString()))
                        {
                            tmp = tmp.Substring(tmp.IndexOf('#')+2);
                            tmp = tmp.Substring(0,tmp.LastIndexOf('#')-1);
                            if (TypesFigures.Value.ToString().Contains("Double"))
                            {
                                if (TypesFigures.Value.ToString().Contains("Vx"))
                                    this.Vx = Double.Parse(tmp);
                                else if (TypesFigures.Value.ToString().Contains("Vy"))
                                    this.Vy = Double.Parse(tmp);
                                else if (TypesFigures.Value.ToString().Contains("x"))
                                    this.x = Double.Parse(tmp);
                                else if (TypesFigures.Value.ToString().Contains("y"))
                                    this.y = Double.Parse(tmp);
                                else if (TypesFigures.Value.ToString().Contains("size"))
                                    this.size = Double.Parse(tmp);
                            }
                            else if (TypesFigures.Value.ToString().Contains("Color"))
                            {
                                tmp = tmp.Substring(tmp.IndexOf('[')+1);
                                tmp = tmp.Substring(0,tmp.LastIndexOf("]"));
                                string checky = "";
                                foreach(char c in tmp)
                                    if (c != ' ')
                                        checky += c;
                                List<string> listStrLineElements = checky.Split(',').ToList();
                                string[] rgbcolors = new string[4];
                                for(int i = 0; i < listStrLineElements.Count; i++)
                                {
                                    rgbcolors[i] = listStrLineElements.ElementAt(i).ToString();
                                    rgbcolors[i] = rgbcolors[i].Substring(2);
                                }
                                this.colorek = Color.FromArgb(Convert.ToInt32(rgbcolors[0]), Convert.ToInt32(rgbcolors[1]), Convert.ToInt32(rgbcolors[2]), Convert.ToInt32(rgbcolors[3]));
                            }
                            break;
                        }
                    }
                }
            }

            public void BasicMovement(Panel panelito)
            {
                if (x <= 0 || x + size >= panelito.Width)
                    Vx = -Vx;
                if (y <= 0 || y + size >= panelito.Height)
                    Vy = -Vy;
                x += Vx;
                y += Vy;
            }
            public void BasicPrepare()
            {
                Random c1 = new Random();
                colorek = Color.FromArgb(255, c1.Next(0, 255), c1.Next(0, 255), c1.Next(0, 255));
            }
            public void BasicMoveForResizeEnd(Panel panelito)
            {
                if (x <= 0)
                    x = 5.0;
                if (x + size >= panelito.Width)
                    x = panelito.Width - size - 5.0;
                if (y <= 0)
                    y = 5.0;
                if (y + size >= panelito.Height)
                    y = panelito.Height - size - 5.0;
            }
        }
        [Serializable]
        public class Kulka :Figure, IMoveObject
        {
            public Kulka(double x, double y, double Vx, double Vy, double size) :base(x, y, Vx,Vy,size)
            {
                this.x = x;
                this.y = y;
                this.Vx = Vx;
                this.Vy = Vy;
                this.size = size;
            }
            void IMoveObject.Draw(PaintEventArgs e)  //ctrl+k ctrl+c :3
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen dlugopis = new Pen(colorek, 3);
                Brush kurz = new SolidBrush(dlugopis.Color);
                e.Graphics.FillEllipse(kurz, (int)x, (int)y, (int)size, (int)size);
                kurz.Dispose();
                dlugopis.Dispose();
            }
            void IMoveObject.save2(IMoveObject OneFigure, Stream s, BinaryFormatter bw)
            {
                saver(OneFigure, s, bw);
            }
            void IMoveObject.load2(object OneFigure, Stream s, BinaryFormatter bw)
            {
                reader(s,bw, OneFigure);
            }
            void IMoveObject.Move(Panel panelito)
            {
                BasicMovement(panelito);
            }
            void IMoveObject.prepare()
            {
                BasicPrepare();
            }
            void IMoveObject.MoveForResizeEnd(System.Windows.Forms.Panel panelito)
            {
                BasicMoveForResizeEnd(panelito);
            }
            void IMoveObject.save(StreamWriter es)
            {
                Type t = this.GetType();
                SaveToTheFile(es, t.ToString());
            }
            void IMoveObject.load(StreamReader es)
            {
                ReadTheFile(es);
            }
        }
        [Serializable]
        public class Kwadracik :Figure, IMoveObject
        {
            public Kwadracik(double x, double y, double Vx, double Vy, double size) :base(x,y,Vx,Vy,size)
            {
                this.x = x;
                this.y = y;
                this.Vx = Vx;
                this.Vy = Vy;
                this.size = size;
            }
            void IMoveObject.Move(Panel panelito)
            {
                BasicMovement(panelito);
            }
            void IMoveObject.Draw(PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen dlugopis = new Pen(colorek, 3);
                Brush kurz = new SolidBrush(dlugopis.Color);
                e.Graphics.FillRectangle(kurz, (int)x, (int)y, (int)size, (int)size);
                kurz.Dispose();
                dlugopis.Dispose();
            }
            void IMoveObject.save2(IMoveObject OneFigure, Stream s, BinaryFormatter bw)
            {
                saver(OneFigure, s, bw);
            }
            void IMoveObject.load2(object OneFigure, Stream s, BinaryFormatter bw)
            {
                reader(s, bw, OneFigure);
            }
            void IMoveObject.prepare()
            {
                BasicPrepare();
            }
            void IMoveObject.MoveForResizeEnd(Panel panelito)
            {
                BasicMoveForResizeEnd(panelito);
            }
            void IMoveObject.save(StreamWriter es)
            {
                Type t = this.GetType();
                SaveToTheFile(es, t.ToString());
            }
            void IMoveObject.load(StreamReader es)
            {
                ReadTheFile(es);
            }
        }
        [Serializable]
        public class Trojzab :Figure, IMoveObject
        {
            public Trojzab(double x, double y, double Vx, double Vy, double size) : base(x, y, Vx, Vy, size)
            {
                this.x = x;
                this.y = y;
                this.Vx = Vx;
                this.Vy = Vy;
                this.size = size;
            }
            void IMoveObject.Move(Panel panelito)
            {
                BasicMovement(panelito);
            }
            void IMoveObject.Draw(PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen dlugopis = new Pen(colorek, 3);
                Brush kurz = new SolidBrush(dlugopis.Color);
                Point[] tmp = new Point[3];
                tmp[0].X = (int)x;
                tmp[0].Y = (int)y;
                tmp[1].X = (int)(x+size/2);
                tmp[1].Y = (int)(y+size/2);
                tmp[2].X = (int)x;
                tmp[2].Y = (int)(y+size);
                e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                e.Graphics.FillPolygon(kurz, tmp);
                kurz.Dispose();
                dlugopis.Dispose();
            }
            void IMoveObject.save2(IMoveObject OneFigure, Stream s, BinaryFormatter bw)
            {
                saver(OneFigure, s, bw);
            }
            void IMoveObject.load2(Object OneFigure, Stream s, BinaryFormatter bw)
            {
                reader(s, bw, OneFigure);
            }
            void IMoveObject.prepare()
            {
                BasicPrepare();
            }
            void IMoveObject.MoveForResizeEnd(Panel panelito)
            {
                BasicMoveForResizeEnd(panelito);
            }
            void IMoveObject.save(StreamWriter es)
            {
                Type t = this.GetType();
                SaveToTheFile(es, t.ToString());
            }
            void IMoveObject.load(StreamReader es)
            {
                ReadTheFile(es);
            }
        }
    }

}