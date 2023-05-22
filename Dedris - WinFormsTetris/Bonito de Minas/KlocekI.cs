using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bonito_de_Minas
{
    public class KlocekI : Klocek
    {
        Byte[,] IMap;
        Byte[,] lastIMap;
        Byte look;
        Board MainBoard;
        int x;
        int y;
        int height;
        bool rotated = false;
        bool endgame = false;
        public KlocekI()
        {
            x = 0;
            y = 0;
            height = 4;
            look = 8;
            IMap = new byte[4, 4];
            lastIMap = new byte[4, 4];
            for (int i = 0; i < 4; i++)
                IMap[1, i] = look;
        }
        public KlocekI(Board map, int x, int y)
        {
            MainBoard = map;
            x = 0;
            y = 0;
            height = 4;
            look = 8;
            IMap = new byte[4, 4];
            lastIMap = new byte[4, 4];
            for (int i = 0; i < 4; i++)
                IMap[1, i] = look;
        }
        public override void reset()
        {
            for(int i = 0; i < IMap.GetLength(0); i++)
                for(int j = 0; j < IMap.GetLength(1); j++)
                {
                    IMap[i, j] = 0;
                    lastIMap[i, j] = 0;
                }
            for (int i = 0; i < 4; i++)
                IMap[1, i] = look;
            x = 0;
            y = 0;
            height = 4;
            endgame= false;
        }
        public override void MoveKlocki()
        {
            if (rotated)
                height = 4;
            if (checkdownsidewhichoption() > 0)
            {
                Byte[,] tmp;
                if (checkdownsidewhichoption() == 1)  //[i,1]
                {
                    tmp = new Byte[2, 4];
                    for (int i = 0; i < 2; i++)
                        for (int j = 0; j < 4; j++)
                            tmp[i, j] = IMap[i, j];
                    height = 2;
                    rotated = true;
                }
                else if(checkdownsidewhichoption() == 2) //[i,2]
                {
                    tmp = new Byte[3, 4];
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 4; j++)
                            tmp[i, j] = IMap[i, j];
                    height = 3;
                    rotated = true;
                }
                else
                {
                    tmp = new Byte[4, 4];
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 4; j++)
                            tmp[i, j] = IMap[i, j];
                    height = 4;
                    rotated = false;
                }
                if (MainBoard.DoesItFit(tmp, lastIMap, look, x, y, false, 0))
                {
                    fillklocekinmap(height);
                    x++;
                }
            }
            else if (MainBoard.DoesItFit(IMap, lastIMap, look, x, y, false, 0))
            {
                fillklocekinmap(height);
                x++;
            }
        }
        public override bool getIDifEnd()
        {
            if (x == 0 && endgame == true)
                return true;
            if (x == 0)
                endgame = true;
            return false;
        }
        public override Byte[,] Rotate(int direction)
        {
            Byte[,] tmp = new Byte[4, 4];
            if(direction == 0)
            {
                for (int i = 3; i >= 0; i--)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        tmp[i, j] = IMap[3 - j, i];
                    }
                }
            }
            else if(direction == 1)
            {
                for (int i = 3; i >= 0; i--) // w lewo
                {
                    for (int j = 0; j < 4; j++)
                    {
                        tmp[j, i] = IMap[i, 3 - j];
                    }
                }
            }
            if (MainBoard.DoesItFit(tmp, lastIMap, look, x, y, true, 0))
            {
                IMap = tmp;
            }
            //IMap = tmp;
            return tmp;
        }
        public override void clearside(bool side)
        {
            if (side) //left
            {
                for (int i = 0; i < 4; i++)
                    if (MainBoard.Map[x+i, y - 1] == look && IMap[i, 3] == look)
                        MainBoard.Map[x+i, y - 1] = 0;
            }
            else //right
            { 
                for (int i = 0; i < 4; i++)
                    if (MainBoard.Map[x+i, y + 4] == look && IMap[i, 0] == look)
                        MainBoard.Map[x+i, y + 4] = 0;
            }
        }
        public override bool ControlKlocek(int direction)
        {
            if (czyspadl(height)) return false;
            if (direction == 1)  //tylko KlocekI zostal
            {
                if (y - 1 < 0)
                {
                    int helper = checkblankside();
                    if (helper == 3)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            IMap[i, 2] = IMap[i, 3];
                            IMap[i, 3] = 0;
                        }
                    }
                    else if (helper == 2)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            IMap[i, 1] = IMap[i, 2];
                            IMap[i, 2] = 0;
                        }
                    }
                    else if (helper == 1)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            IMap[i, 0] = IMap[i, 1];
                            IMap[i, 1] = 0;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                MainBoard.DoesItFit(IMap, lastIMap, look, x, y, false, 0);
                if (MainBoard.DoesItFit(IMap, lastIMap, look, x, y-1, false, 0))
                    y--;
            }
            else if (direction == 2)
            {
                if(y+4 >= MainBoard.columns)
                {
                    int helper = checkblankside();
                    if (helper == 0)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            IMap[i, 1] = IMap[i, 0];
                            IMap[i, 0] = 0;
                        }
                    }
                    else if (helper == 1)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            IMap[i, 2] = IMap[i, 1];
                            IMap[i, 1] = 0;
                        }
                    }
                    else if (helper == 2)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            IMap[i, 3] = IMap[i, 2];
                            IMap[i, 2] = 0;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                MainBoard.DoesItFit(IMap, lastIMap, look, x, y, false, 0);
                if (MainBoard.DoesItFit(IMap, lastIMap, look, x, y + 1, false, 0))
                    y++;
            }
            else if (direction == 3)
            {
                int helpy = checkblankside();
                if (helpy == 0)
                {
                    for(int i = 0; i < 4; i++)
                    {
                        IMap[i,1] = IMap[i, 0];
                        IMap[i, 0] = 0;
                    }
                    height = 2;
                }
                else if(helpy == 3)
                {
                    for(int i = 0; i < 4; i++)
                    {
                        IMap[i, 2] = IMap[i, 3];
                        IMap[i, 3] = 0;
                    }
                    height = 3;
                }
                    Rotate(0);
            }
            else if (direction == 4)
            {
                int helpy = checkblankside();
                if (helpy == 3)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        IMap[i, 2] = IMap[i, 3];
                        IMap[i, 3] = 0;
                    }
                    height = 2;
                }
                else if(helpy == 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        IMap[i, 1] = IMap[i, 0];
                        IMap[i, 0] = 0;
                    }
                    height = 3;
                }
                    Rotate(1);
            }
            return true;
        }
        public override Byte[,] GetTabKlocek()
        {
            return IMap;
        }
        public override void MoveKlocekDown()
        {
                x++;
        }
        bool czyspadl(int sizeofheight)
        {
            if (x == 0) return false;
            if (x + sizeofheight - 1 == MainBoard.rows)
                return true;
            for (int i = 0; i < 4; i++)
                if (MainBoard.Map[x + sizeofheight - 1, y + i] != 0 && IMap[sizeofheight - 1, i] != 0)
                    return true;

            for (int i = 0; i < sizeofheight; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (MainBoard.Map[x + i, y + j] == look && IMap[i, j] == look)
                    {
                        MainBoard.Map[x + i, y + j] = 99;
                    }
                }
            for (int i = 0; i < sizeofheight; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (MainBoard.Map[x + i, y + j] != 99 && MainBoard.Map[x + i, y + j] != 0 && IMap[i, j] != 0)
                    {
                        for (int k = 0; k < sizeofheight; k++)
                            for (int l = 0; l < 4; l++)
                            {
                                if (MainBoard.Map[x + k, y + l] == 99)
                                    MainBoard.Map[x + k, y + l] = look;
                            }
                        return true;
                    }
                }
            for (int k = 0; k < sizeofheight; k++)
                for (int l = 0; l < 4; l++)
                {
                    if (MainBoard.Map[x + k, y + l] == 99)
                        MainBoard.Map[x + k, y + l] = look;
                }
            return false;
        }
        void resetbloczek()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (IMap[i, j] != 0)
                        MainBoard[x + i - 1, y + j] = 30;
            x = 0;
            y = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    lastIMap[i, j] = 0;
        }
        int checkdownsidewhichoption()
        {
            int counter = 0;
            int counter2 = 0;
            for (int i = 0; i < 4; i++)
                if (IMap[1, i] != 0)
                    counter++;
                else if (IMap[2, i] != 0)
                    counter2++;
            if (counter == 4)
                return 1;
            else if(counter2 == 4)
                return 2;
            return 0;
        }
        int checkblankside()
        {
            int check1 = 0;
            int check2 = 0;
            int check3 = 0;
            int check0 = 0;
            for (int i = 0; i < 4; i++)
            {
                if (IMap[i, 1] == look)
                    check1++;
                if (IMap[i, 2] == look)
                    check2++;
                if (IMap[i, 3] == look)
                    check3++;
                if (IMap[i, 0] == look)
                    check0++;
            }
            if (check1 == 4) return 1; 
            if (check2 == 4) return 2; 
            if (check3 == 4) return 3; 
            if (check0 == 4) return 0; 
            return -1;
        }
        public override bool hasFallen()
        {
            if (czyspadl(height) == true)
            {
                if (x != 0)
                {
                    resetbloczek();
                }
                setonthemiddle();
                return true;
            }
            return false;
        }
        void fillklocekinmap(int sizeofheight)
        {
            for (int i = 0; i < sizeofheight; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (IMap[i, j] != 0)
                        MainBoard[x + i, y + j] = look;
                }
            }
        }
        public override void SetMaptoKlocek(Board map)
        {
            this.MainBoard = map;
        }
        public override void setonthemiddle()
        {
            y = ((int)MainBoard.columns / 2) - 4;
            x = 0;
        }
        public override int getXofKlocek()
        {
            return x;
        }
    }
}
