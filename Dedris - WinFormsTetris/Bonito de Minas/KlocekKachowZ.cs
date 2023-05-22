using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bonito_de_Minas
{
    public class KlocekKachowZ : Klocek
    {
        Byte[,] kachowZMap;
        Byte[,] lastkachowZMap;
        Byte look;
        Board MainBoard;
        int x;
        int y;
        int height = 0;
        bool endgame = false;
        public KlocekKachowZ()
        {
            height = 2;
            this.x = 0;
            this.y = 0;
            look = 7;
            kachowZMap = new Byte[3, 3];
            lastkachowZMap = new Byte[3, 3];
            kachowZMap[0, 0] = look; kachowZMap[0, 1] = look; kachowZMap[1, 1] = look; kachowZMap[1, 2] = look;

        }
        public KlocekKachowZ(Board map, int x, int y)
        {
            MainBoard = map;
            height = 2;
            this.x = x; this.y = y;
            look = 7;
            kachowZMap = new Byte[3, 3];
            lastkachowZMap = new Byte[3, 3];
            kachowZMap[0, 0] = look; kachowZMap[0, 1] = look; kachowZMap[1, 1] = look; kachowZMap[1, 2] = look;
        }
        public override void reset()
        {
            for(int i = 0; i < kachowZMap.GetLength(0); i++)
                for(int j = 0; j < kachowZMap.GetLength(1); j++)
                {
                    kachowZMap[i, j] = 0;
                    lastkachowZMap[i, j] = 0;
                }
            kachowZMap[0, 0] = look; kachowZMap[0, 1] = look; kachowZMap[1, 1] = look; kachowZMap[1, 2] = look;
            x = 0;
            y = 0;
            height = 2;
            endgame = false;
        }
        public override void MoveKlocki()
        {
            if (checkdownside())
            {
                height = 2;
                Byte[,] tmp = new Byte[2, 3];
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 3; j++)
                        tmp[i, j] = kachowZMap[i, j];
                if (MainBoard.DoesItFit(tmp, lastkachowZMap, look, x, y,false, 0))
                {
                    fillklocekinmap(2,kachowZMap);
                    x++;
                }
            }
            else if (MainBoard.DoesItFit(kachowZMap,lastkachowZMap, look, x, y,false, 0))
            {
                height = 3;
                fillklocekinmap(3,kachowZMap);
                x++;
            }
        }
        public override bool getIDifEnd()
        {
            if (x == 0 && endgame == true)
                return true;
            if (x == 0)
                endgame = true;
            //for (int i = 0; i < MainBoard.columns; i++)
            //    if (MainBoard.Map[0, i] != 0 && MainBoard.Map[0, i] != look && MainBoard.Map[0, i] > 50)
            //        return true;
            return false;
        }

        public override Byte[,] Rotate(int direction)
        {
            Byte[,] tmp = new Byte[3, 3];
            if(direction == 0)
            {
                for (int i = 2; i >= 0; i--)   /// w prawo
                {
                    for (int j = 0; j < 3; j++)
                    {
                        tmp[i, j] = kachowZMap[2 - j, i];
                    }
                }
            }
            else if(direction == 1)
            {
                for (int i = 2; i >= 0; i--) // w lewo
                {
                    for (int j = 0; j < 3; j++)
                    {
                        tmp[j, i] = kachowZMap[i, 2 - j];
                    }
                }
            }
            if (MainBoard.DoesItFit(tmp, kachowZMap, look, x, y,true, 0))
            {
                kachowZMap = tmp;
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
                    if(checkblankside() != 1)
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                            if (MainBoard.Map[x + i, 0] != 0)
                                return false;
                        Rotate(0);
                        Rotate(0);
                    }
                }   ///
                MainBoard.DoesItFit(kachowZMap, lastkachowZMap, look, x, y, false, 0);
                if (MainBoard.DoesItFit(kachowZMap, lastkachowZMap, look, x, y-1, false, 0))
                {
                    y--;
                }
            }
            else if (direction == 2)
            {  
                if (y + 3 >= MainBoard.columns)
                {
                    if (checkblankside() != 2)
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                            if (MainBoard.Map[x + i, MainBoard.columns-1] != 0)
                                return false;
                        Rotate(1);
                        Rotate(1);
                    }
                }
                MainBoard.DoesItFit(kachowZMap, lastkachowZMap, look, x, y, false, 0);
                if (MainBoard.DoesItFit(kachowZMap, lastkachowZMap, look, x, y+1, false, 0))
                {
                    y++;
                }
            }
            else if (direction == 3)
                Rotate(0);
            else if (direction == 4)
                Rotate(1);
            return true;
        }
        public override void MoveKlocekDown()
        {
            x++;
        }
        public override void clearside(bool side)  //side w lewo
        {
            if (side)
            {
                
            }
            else
            {

            }
        }
        public override Byte[,] GetTabKlocek()
        {
            return kachowZMap;
        }
        bool checkdownside()
        {
            bool check = true;
            for (int i = 0; i < 3; i++)
            {
                if (kachowZMap[2, i] != 0)
                    check = false;

            }
            return check;
        }
        void fillklocekinmap(int sizeofheight, Byte[,] tmp)
        {
            for (int i = 0; i < sizeofheight; i++)
            {
                for (int j = 0; j < tmp.GetLength(1); j++)
                {
                    if (tmp[i, j] != 0)
                        MainBoard[x + i, y + j] = look;
                }
            }
        }
        bool czyspadl(int sizeofheight)
        {

            if(x==0) return false;
            if (x + sizeofheight-1 == MainBoard.rows)
                return true;
            for (int i = 0; i < 3; i++)
                if (MainBoard.Map[x + sizeofheight - 1, y + i] != 0 && kachowZMap[sizeofheight - 1, i] != 0)
                    return true;
            
            for (int i = 0; i < sizeofheight; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (MainBoard.Map[x + i, y + j] == look && kachowZMap[i, j] == look)
                    {
                        MainBoard.Map[x + i, y + j] = 99;
                    }
                }
            for (int i = 0; i < sizeofheight; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (MainBoard.Map[x + i, y + j] != 99 && MainBoard.Map[x + i, y + j] != 0 && kachowZMap[i, j] != 0)
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
        void resetbloczek()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (kachowZMap[i, j] != 0)
                        MainBoard[x + i - 1, y + j] = 29;
            x = 0;
            y = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    lastkachowZMap[i, j] = 0;
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
            for (int i = 0; i < 3; i++)
            {
                if (kachowZMap[i, 0] == 0)
                    check1++;
            }
            for (int i = 0; i < 3; i++)
            {
                if (kachowZMap[i, 2] == 0)
                    check2++;
            }
            if (check1 == 3) return 1;  // lewo
            if (check2 == 3) return 2;  // prawo
            return 0;
        }
    }
}

/*
 * 
 * else if(checkblankside() > 0)
            {
                Byte[,] tmp = new Byte[3, 2];
                tmp[0, 1] = look;
                tmp[1, 1] = look;
                tmp[1, 0] = look;
                tmp[2, 0] = look;
                if (checkblankside() == 1 && y == 0) //left
                {
                    if (MainBoard.DoesItFit(tmp,lastkachowZMap,look,x,y-1,false,true))
                    {
                        fillklocekinmap(3, tmp);
                        x++;
                    }
                }
                else if(checkblankside() == 2 && y == MainBoard.columns - 2) //right
                {
                    if (MainBoard.DoesItFit(tmp, lastkachowZMap, look, x, y + 1, false, true))
                    {
                        fillklocekinmap(3, tmp);
                        x++;
                    }
                }
            }
 */
