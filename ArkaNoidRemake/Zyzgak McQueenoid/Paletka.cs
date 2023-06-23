using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyzgak_McQueenoid
{
    [Serializable]
    public class Paletka : Entity, EntityDisplayKeyMove
    {
        public bool canGetBallToMe = false;
        public Paletka(int locationX, int locationY, int Vx, int Vy, Color PaletkaColor, int PaletkaSizeHeight, int PaletkaSizeWidth, MapaGry Map) : base(locationX, locationY, Vx, Vy, PaletkaColor, Map, PaletkaSizeHeight, PaletkaSizeWidth)
        {
            this.locationX = locationX; this.locationY = locationY; this.Vx = Vx; this.Vy = Vy; this.EntityColor = PaletkaColor; this.EntityMap = Map; this.EntitySizeHeight = PaletkaSizeHeight; this.EntitySizeWidth = PaletkaSizeWidth;
        }
        public void keypressMoveEntity(KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a' && locationX > 0)
                locationX += -Vx;
            else if(e.KeyChar == 'd' && locationX+EntitySizeWidth < EntityMap.WidthOfMap)
                locationX += Vx;
        }
        public void displayentity(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Brush kurz = new SolidBrush(Color.Red);
            Brush kurzorange = new SolidBrush(Color.Orange);
            Pen outliner = new Pen(Color.Black, 5);
            e.Graphics.FillRectangle(kurzorange, (int)locationX, (int)locationY, (int)EntitySizeWidth / 5, (int)EntitySizeHeight);
            e.Graphics.DrawRectangle(outliner, (int)locationX, (int)locationY, (int)EntitySizeWidth / 5, (int)EntitySizeHeight);
            ///
            e.Graphics.FillRectangle(kurz, (int)locationX+(EntitySizeWidth/5), (int)locationY, (int)EntitySizeWidth*3/5, (int)EntitySizeHeight);
            e.Graphics.DrawRectangle(outliner, (int)locationX + (EntitySizeWidth / 5), (int)locationY, (int)EntitySizeWidth * 3 / 5, (int)EntitySizeHeight);
            ///
            e.Graphics.FillRectangle(kurzorange, (int)locationX+(EntitySizeWidth*4/5), (int)locationY, (int)EntitySizeWidth/5, (int)EntitySizeHeight);
            e.Graphics.DrawRectangle(outliner, (int)locationX + (EntitySizeWidth * 4 / 5), (int)locationY, (int)EntitySizeWidth / 5, (int)EntitySizeHeight);
            kurz.Dispose();
            kurzorange.Dispose();
            outliner.Dispose();
            //paddle.Top = locationY;
            //paddle.Left = locationX;
            //paddle.Width = EntitySizeWidth;
            //paddle.Height = EntitySizeHeight;
        }
        public void PreparePaletkaToTheLevel()
        {
            locationX = (EntityMap.WidthOfMap / 2) - (EntitySizeWidth / 2);
            locationY = EntityMap.HeightOfMap - EntitySizeHeight*3;
        }
        public void setpaddledisplay(Panel panelito)
        {
            /*
            paddle = new Panel();
            panelito.Controls.Add(paddle);
            paddle.Top = locationY;
            paddle.Left = locationX;
            paddle.Width = EntitySizeWidth;
            paddle.Height = EntitySizeHeight;
            //paddle.Image = Image.FromFile(Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\..\")) + "/paddle.jpg");
            //paddle.SizeMode = PictureBoxSizeMode.StretchImage;
            paddle.BackgroundImage = Image.FromFile(Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\..\")) + "/paddle.jpg");
            paddle.BackgroundImageLayout = ImageLayout.Stretch;
            paddle.Enabled = true;
            paddle.Visible = true;
            */
        }
    }
}
