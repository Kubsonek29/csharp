using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zyzgak_McQueenoid
{
    [Serializable]
    public class Obstacle : Entity, EntityDisplayKeyMove
    {
        public int ObstacleLives { get; set; }
        public Obstacle(int locationX, int locationY, int Vx, int Vy, Color ObstacleColor, MapaGry Map, int ObstacleSizeHeight,int ObstacleSizeWidth, int ObstacleLives) :base(locationX,locationY, Vx, Vy, ObstacleColor, Map, ObstacleSizeHeight, ObstacleSizeWidth)
        {
            this.locationX = locationX; this.locationY = locationY; this.Vx = Vx; this.Vy = Vy; this.EntityColor = ObstacleColor; this.EntitySizeHeight = ObstacleSizeHeight; this.EntitySizeWidth = ObstacleSizeWidth; EntityMap = Map;
            this.ObstacleLives = ObstacleLives;
        }
        public void displayentity(PaintEventArgs e)
        {
            if (locationX == 0 && locationY == 0) return;

            if (ObstacleLives == 3)
                EntityColor = Color.Green;
            else if (ObstacleLives == 2)
                EntityColor = Color.Yellow;
            else if (ObstacleLives == 1)
                EntityColor = Color.Red;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Brush kurz = new SolidBrush(EntityColor);
            Pen outliner = new Pen(Color.Black, 5);
            e.Graphics.DrawRectangle(outliner, (int)locationX, (int)locationY, (int)EntitySizeWidth, (int)EntitySizeHeight);
            e.Graphics.FillRectangle(kurz, (int)locationX, (int)locationY, (int)EntitySizeWidth, (int)EntitySizeHeight);
            e.Graphics.DrawRectangle(outliner, (int)(locationX + (EntitySizeWidth / 5)), (int)(locationY +(EntitySizeHeight/5)), (int)(EntitySizeWidth - (EntitySizeWidth / 3)), (int)(EntitySizeHeight - (EntitySizeHeight / 3)));
            kurz.Dispose();
            outliner.Dispose();
        }
        public void keypressMoveEntity(KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
