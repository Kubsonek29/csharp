using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonito_de_Minas
{
    public abstract class Klocek
    {
        public Board mapa;
        public abstract void MoveKlocki();
        public abstract Byte[,] Rotate(int direction);
        public abstract bool ControlKlocek(int direction);
        public abstract Byte[,] GetTabKlocek();
        public abstract void SetMaptoKlocek(Board map);
        public abstract bool hasFallen();
        public abstract void setonthemiddle();
        public abstract void MoveKlocekDown();
        public abstract void clearside(bool side);
        public abstract int getXofKlocek();
        public abstract void reset();
        public abstract bool getIDifEnd();
    }
}
