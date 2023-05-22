﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonito_de_Minas
{
    public class KlocekL : Klocek
    {
        Byte[,] LMap;
        Byte[,] lastLMap;
        Byte look;
        Board MainBoard;
        int x; ///
        int y; ///
        int height;
        bool endgame = false;
        public KlocekL()
        {
            this.x = x; this.y = y;
            look = 9;
            height = 3;
            LMap = new Byte[3, 3];
            lastLMap = new Byte[3, 3];
            for (int i = 0; i < 3; i++)
                LMap[0, i] = look;
            LMap[1, 2] = look;
        }
        public KlocekL(Board map, int x, int y)
        {
            MainBoard = map;
            height = 0;
            this.x = x; this.y = y;
            look = 9;
            LMap = new Byte[3, 3];
            lastLMap = new Byte[3, 3];
            for (int i = 0; i < 3; i++)
                LMap[0, i] = look;
            LMap[1, 2] = look;

        }
        public override void reset()
        {
            for(int i = 0; i < LMap.GetLength(0); i++)
                for(int j = 0; j< LMap.GetLength(1); j++)
                {
                    LMap[i, j] = 0;
                    lastLMap[i, j] = 0;
                }
            for (int i = 0; i < 3; i++)
                LMap[0, i] = look;
            LMap[1, 2] = look;
            x = 0;
            y = 0;
            height = 3;
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
                        tmp[i, j] = LMap[i, j];
                if (MainBoard.DoesItFit(tmp,lastLMap, look, x, y, false, 0))
                {
                    fillklocekinmap(2);
                    x++;
                }
            }
            else if (MainBoard.DoesItFit(LMap,lastLMap, look, x, y, false, 0))
            {
                height = 3;
                fillklocekinmap(3);
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
            //    if (MainBoard.Map[0, i] != 0 && MainBoard.Map[0, i] != look && MainBoard.Map[0,i] >50)
            //        return true;
            return false;
        }
        public override Byte[,] Rotate(int direction)
        {
            Byte[,] tmp = new Byte[3, 3];
            if(direction == 0)
            {
                for(int i = 2; i >= 0; i--)
            {
                    for (int j = 0; j < 3; j++)
                    {
                        tmp[i, j] = LMap[2 - j, i];
                    }
                }
            }
            else if(direction == 1)
            {
                for (int i = 2; i >= 0; i--) // w lewo
                {
                    for (int j = 0; j < 3; j++)
                    {
                        tmp[j, i] = LMap[i, 2 - j];
                    }
                }
            }
            if (MainBoard.DoesItFit(tmp, LMap , look, x, y, true, 0))
            {
                LMap = tmp;
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
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                            if (MainBoard.Map[x + i, 0] != 0)
                                return false;
                        if ((LMap[2,1] == look && LMap[1,1] == look && LMap[0,1] == look && LMap[0,2] == look))
                        {
                            for (int i = 0; i < 3; i++)
                                for (int j = 0; j < 3; j++)
                                {
                                    lastLMap[i, j] = LMap[i, j];
                                    LMap[i, j] = 0;
                                }
                            LMap[0,0] = look;
                            LMap[1,0] = look;
                            LMap[2,0] = look;
                            LMap[0,1] = look;
                        }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                                for (int j = 0; j < 3; j++)
                                {
                                    lastLMap[i, j] = LMap[i, j];
                                    LMap[i, j] = 0;
                                }

                            LMap[0, 1] = look; LMap[1, 1] = look; LMap[2, 1] = look; LMap[2, 0] = look;
                        }
                    }
                }
                MainBoard.DoesItFit(LMap, lastLMap, look, x, y, false, 0);
                if (MainBoard.DoesItFit(LMap, lastLMap, look, x, y-1, false, 0))
                    y--;
            }
            else if (direction == 2)
            {
                if (y + 3 >= MainBoard.columns)
                {
                    if(checkblankside() != 2)
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                            if (MainBoard.Map[x + i, MainBoard.columns - 1] != 0)
                                return false;
                        if (LMap[0, 0] == look && LMap[1, 0] == look && LMap[2, 0] == look && LMap[0, 1] == look)
                        {
                            for (int i = 0; i < 3; i++)
                                for (int j = 0; j < 3; j++)
                                {
                                    lastLMap[i, j] = LMap[i, j];
                                    LMap[i, j] = 0;
                                }
                            LMap[2, 1] = look; LMap[1, 1] = look; LMap[0, 1] = look; LMap[0, 2] = look;
                        }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                                for (int j = 0; j < 3; j++)
                                {
                                    lastLMap[i, j] = LMap[i, j];
                                    LMap[i, j] = 0;
                                }
                            LMap[2, 1] = look; LMap[1, 1] = look; LMap[0, 1] = look; LMap[2, 2] = look;
                        }
                    }
                }
                MainBoard.DoesItFit(LMap, lastLMap, look, x, y, false, 0);
                if (MainBoard.DoesItFit(LMap, lastLMap, look, x, y + 1, false, 0))
                    y++;
            }
            else if (direction == 3)
                Rotate(0);
            else if (direction == 4)
                Rotate(1);
            return true;
        }
        public override Byte[,] GetTabKlocek()
        {
            return LMap;
        }
        public override void MoveKlocekDown()
        {
                x++;
        }
        bool checkdownside()
        {
            bool check = true;
            for (int i = 0; i < 3; i++)
            {
                if (LMap[2, i] != 0)
                    check = false;

            }
            return check;
        }
        public override void clearside(bool side)
        {
            if (side) //left
            {
                for (int i = 0; i < 3; i++)
                    if (MainBoard.Map[x+i, y - 1] == look && LMap[i, 2] == look)
                        MainBoard.Map[x + i, y - 1] = 0;
            }
            else //right
            {
                for (int i = 0; i < 3; i++)
                    if (MainBoard.Map[x + i, y + 3] == look && LMap[i, 0] == look)
                        MainBoard.Map[x + i, y + 3] = 0;
            }
        }
        void fillklocekinmap(int sizeofheight)
        {
            for (int i = 0; i < sizeofheight; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (LMap[i, j] != 0)
                        MainBoard[x + i, y + j] = look;
                }
            }
        }
        bool czyspadl(int sizeofheight)  /////
        {

            if (x == 0)  ///
                return false;
            if (x + sizeofheight - 1 == MainBoard.rows)
                return true;
            for (int i = 0; i < 3; i++)
                if (MainBoard.Map[x + sizeofheight - 1, y + i] != 0 && LMap[sizeofheight - 1, i] != 0)
                    return true;

            for (int i = 0; i < sizeofheight; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (MainBoard.Map[x+i,y+j] == look && LMap[i,j] == look)
                    {
                        MainBoard.Map[x + i, y + j] = 99;
                    }
                }
            for(int i = 0; i < sizeofheight; i++)
                for(int j = 0; j < 3; j++)
                {
                    if ((MainBoard.Map[x+i,y+j] != 99 && MainBoard.Map[x+i,y+j] != 0 && LMap[i,j] != 0))
                    {
                        for(int k = 0; k < sizeofheight; k++)
                            for(int l = 0; l < 3; l++)
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
                    if (LMap[i, j] != 0)
                        MainBoard[x + i - 1, y + j] = 27;
            x = 0;
            y = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    lastLMap[i, j] = 0;
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
                if (LMap[i, 0] == 0)
                    check1++;
                if (LMap[i, 2] == 0)
                    check2++;
            }
            if (check1 == 3) return 1;  // lewo
            if (check2 == 3) return 2;  // prawo
            return 0;
        }
    }
}
