using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyzgak_McQueenoid
{
    [Serializable]
    public class Entity
    {
        public int locationX { get; set; }
        public int locationY { get; set; }
        public int Vx { get; set; }
        public int Vy { get; set; }
        public Color EntityColor { get; set; }
        public MapaGry EntityMap { get; set; }
        public int EntitySizeHeight { get; set; }
        public int EntitySizeWidth { get; set; }
        public Entity(int locationX, int locationY, int Vx, int Vy, Color EntityColor, MapaGry EntityMap, int EntitySizeHeight, int EntitySizeWidth)
        {
            this.locationX = locationX;
            this.locationY = locationY;
            this.Vx = Vx;
            this.Vy = Vy;
            this.EntityColor = EntityColor;
            this.EntityMap = EntityMap;
            this.EntitySizeHeight = EntitySizeHeight;
            this.EntitySizeWidth = EntitySizeWidth;
        }
        public void AdjustLocationAndSpeedAfterResize(int oldpanelwidth, int oldpanelheight, int currentpanelwidth, int currentpanelheight, double resizewidth, double resizeheight)
        {
            //double resizewidth = ((double)currentpanelwidth/(double)oldpanelwidth);
            //double resizeheight = ((double)currentpanelheight/(double)oldpanelheight);
            locationX = (int)(locationX*resizewidth);
            locationY = (int)(locationY*resizeheight);
            Vx = (int)(Vx*resizewidth);
            Vy = (int)(Vy*resizeheight);
            EntitySizeHeight = (int)(EntitySizeHeight*resizeheight);
            EntitySizeWidth = (int)(EntitySizeWidth*resizewidth);
        }
    }
}
