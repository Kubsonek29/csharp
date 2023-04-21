using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonito_de_Minas
{
    internal class KlocekT : Klocek
    {
        Byte[,] TMap;
        Byte[,] lastTMap;
        Byte look;
        Board MainBoard;
        int x;
        int y;
        int height;
        public KlocekT()
        {
            x = 0;
            y = 0;
            height = 3;
            look = 6;
            TMap = new Byte[3, 3];
            lastTMap = new Byte[3, 3];
            for (int i = 0; i < 3; i++)
                TMap[0, i] = look;
            TMap[1, 1] = look;
        }
        public KlocekT(Board map, int x, int y)
        {
            MainBoard = map;
            x = 0;
            y = 0;
            height = 3;
            look = 6;
            TMap = new Byte[3, 3];
            lastTMap = new Byte[3, 3];
            for (int i = 0; i < 3; i++)
                TMap[0, i] = look;
            TMap[1, 1] = look;
        }
        public override void MoveKlocki()
        {
            if (checkdownside())
            {
                height = 2;
                Byte[,] tmp = new Byte[2, 3];
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 3; j++)
                        tmp[i, j] = TMap[i, j];
                if (MainBoard.DoesItFit(tmp,lastTMap, look, x, y, false, 0))
                {
                    fillklocekinmap(2);
                    x++;
                }
            }
            else if (MainBoard.DoesItFit(TMap,lastTMap, look, x, y, false, 0))
            {
                height = 3;
                fillklocekinmap(3);
                x++;
            }
        }
        public override Byte[,] Rotate(int direction)
        {
            Byte[,] tmp = new Byte[3, 3];
            if(direction == 0)
            {
                for (int i = 2; i >= 0; i--)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        tmp[i, j] = TMap[2 - j, i];
                    }
                }
            }
            else if(direction == 1)
            {
                for (int i = 2; i >= 0; i--) // w lewo
                {
                    for (int j = 0; j < 3; j++)
                    {
                        tmp[j, i] = TMap[i, 2 - j];
                    }
                }
            }
            if (MainBoard.DoesItFit(tmp, TMap, look, x, y, true,0))
            {
                TMap = tmp;
            }

            return tmp;
        }
        public override bool ControlKlocek(int direction)
        {
            if (czyspadl(height)) return false;
            if (direction == 1)
            {
                if (y - 1 < 0)
                {
                    if (checkblankside() != 1)
                        return false;
                    else if (TMap[0,2] != 0 && TMap[1,2] != 0 && TMap[2,2]!=0 && TMap[1,1]!=0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            TMap[i, 1] = TMap[i, 2];
                            TMap[i, 2] = 0;
                        }
                        TMap[1, 0] = look;
                        height = 3;
                    }
                    else if (TMap[0,1] != 0 && TMap[1, 1] != 0 && TMap[2, 1] != 0 && TMap[1, 2] != 0)
                    {
                        for(int i = 0; i < 3; i++)
                        {
                            TMap[i,0] = TMap[i, 1];
                            TMap[i, 1] = 0;
                        }
                        TMap[1, 2] = 0;
                        TMap[1, 1] = look;
                        height = 3;
                    }

                }
                MainBoard.DoesItFit(TMap, lastTMap, look, x, y, false, 0);
                if (MainBoard.DoesItFit(TMap, lastTMap, look, x, y-1, false, 0))
                    y--;
            }
            else if (direction == 2)
            {
                if (y + 3 >= MainBoard.columns)
                {
                    if(checkblankside()!=2) return false;
                    else if(TMap[0, 0] != 0 && TMap[1, 0] != 0 && TMap[2, 0] != 0 && TMap[1,1] != 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            TMap[i, 1] = TMap[i, 0];
                            TMap[i, 0] = 0;
                        }
                        TMap[1, 2] = look;
                        height = 3;
                    }
                    else if (TMap[0, 1] != 0 && TMap[1, 1] != 0 && TMap[2, 1] != 0 && TMap[1, 0] != 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            TMap[i, 2] = TMap[i, 1];
                            TMap[i, 1] = 0;
                        }
                        TMap[1, 0] = 0;
                        TMap[1, 1] = look;
                        height = 3;
                    }
                }
                MainBoard.DoesItFit(TMap, lastTMap, look, x, y, false,0);
                if (MainBoard.DoesItFit(TMap, lastTMap, look, x, y+1, false,0))
                    y++;
            }
            else if (direction == 3)
                Rotate(0);
            else if (direction == 4)
                Rotate(1);
            return true;
        }
        public override void clearside(bool side)
        {
            if (side) //left
            {
                for (int i = 0; i < 3; i++)
                    if (MainBoard.Map[x+i, y - 1] == look && TMap[i, 2] == look)
                        MainBoard.Map[x+i, y - 1] = 0;
            }
            else //right
            {
                for (int i = 0; i < 3; i++)
                    if (MainBoard.Map[x+i, y + 3] == look && TMap[i, 0] == look)
                        MainBoard.Map[x+i, y + 3] = 0;
            }
        }
        public override Byte[,] GetTabKlocek()
        {
            return TMap;
        }
        bool checkdownside()
        {
            bool check = true;
            for (int i = 0; i < 3; i++)
            {
                if (TMap[2, i] != 0)
                    check = false;

            }
            return check;
        }
        void fillklocekinmap(int sizeofheight)
        {
            for (int i = 0; i < sizeofheight; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (TMap[i, j] != 0)
                        MainBoard[x + i, y + j] = look;
                }
            }
        }
        bool czyspadl(int sizeofheight)
        {
            if (x == 0) return false;
            if (x + sizeofheight - 1 == MainBoard.rows)
                return true;
            for (int i = 0; i < 3; i++)
                if (MainBoard.Map[x + sizeofheight - 1, y + i] != 0 && TMap[sizeofheight - 1, i] != 0)
                    return true;
            for (int i = 0; i < sizeofheight; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (MainBoard.Map[x + i, y + j] == look && TMap[i, j] == look)
                    {
                        MainBoard.Map[x + i, y + j] = 99;
                    }
                }
            for (int i = 0; i < sizeofheight; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (MainBoard.Map[x + i, y + j] != 99 && MainBoard.Map[x + i, y + j] != 0 && TMap[i, j] != 0)
                    {
                        for (int k = 0; k < sizeofheight; k++)
                            for (int l = 0; l < 3; l++)
                            {
                                if (MainBoard.Map[x + k, y + l] == 99)
                                    MainBoard.Map[x + k, y + l] = look;
                            }
                        return true;
                    }
                }
            for (int k = 0; k < sizeofheight; k++)
                for (int l = 0; l < 3; l++)
                {
                    if (MainBoard.Map[x + k, y + l] == 99)
                        MainBoard.Map[x + k, y + l] = look;
                }
            
            return false;
        }
        public override void MoveKlocekDown()
        {
                x++;
        }
        public override bool hasFallen()
        {
            if (czyspadl(height) == true)
            {
                resetbloczek(); return true;
            }
            return czyspadl(height);
        }
        void resetbloczek()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (TMap[i, j] != 0)
                        MainBoard[x + i-1, y + j] = 25;
            x = 0;
            y = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    lastTMap[i, j] = 0;
        }
        public override void SetMaptoKlocek(Board map)
        {
            this.MainBoard = map;
        }
        public override void setonthemiddle()
        {
            y = ((int)MainBoard.columns / 2) - 3;
            x = 0;
        }
        public override int getXofKlocek()
        {
            return x;
        }
        int checkblankside()
        {
            int check1 = 0;
            int check2 = 0;
            for(int i = 0; i < 3; i++)
            {
                if (TMap[i, 0] == 0)
                    check1++;
            }
            if (check1 == 3) return 1;  // lewo
            for(int j = 0; j < 3; j++)
            {
                if (TMap[j, 2] == 0)
                    check2++;
            }
            if (check2 == 3) return 2; //prawo
            return 0;
        }
    }
}
