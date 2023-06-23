using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyzgak_McQueenoid
{
    [Serializable]
    public class MapaGry
    {
        public int HeightOfMap { get; set; }
        public int WidthOfMap { get; set; }
        public MapaGry(int HeightOfMap, int WidthOfMap)
        {
            this.WidthOfMap = WidthOfMap; this.HeightOfMap = HeightOfMap;
        }
        public void updateMapSize(int HeightOfMap, int WidthOfMap)
        {
            this.HeightOfMap = HeightOfMap;
            this.WidthOfMap = WidthOfMap;
        }
    }
}
