using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonito_de_Minas
{
    public class KlocekKwadrat : Klocek
    {
        Byte[,] SquareMap;
        Byte[,] lastSquareMap;
        Byte look;
        int height;
        Board MainBoard;
        int x;
        int y;
        bool endgame = false;
        public KlocekKwadrat()
        {
            x = 0;
            y = 0;
            look = 5;
            height = 2;
            SquareMap = new byte[2, 2];
            lastSquareMap = new byte[2, 2];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    SquareMap[i, j] = look;
        }
        public KlocekKwadrat(Board map, int x, int y)
        {
            MainBoard = map;
            x = 0;
            y = 0;
            height = 2;
            look = 5;
            SquareMap = new byte[2, 2];
            lastSquareMap = new byte[2, 2];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    SquareMap[i, j] = look;
        }
        public override void reset()
        {
            for(int i = 0; i < SquareMap.GetLength(0); i++)
                for(int j = 0; j < SquareMap.GetLength(1); j++)
                {
                    SquareMap[i, j] = 0;
                    lastSquareMap[i, j] = 0;
                }
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    SquareMap[i, j] = look;
            x = 0;
            y = 0;
            height = 2;
            endgame = false;
        }
        public override void MoveKlocki()
        {
            if (MainBoard.DoesItFit(SquareMap, lastSquareMap, look, x, y, false, 0)) //////
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (SquareMap[i, j] != 0)
                            MainBoard[x + i, y + j] = look;
                    }
                }
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
            //       return true;
            return false;
        }
        public override Byte[,] Rotate(int direction)
        {
            return null;
        }
        public override bool ControlKlocek(int direction)
        {
            if (czyspadl(height)) return false;
            int checker = y;
            if (direction == 1)
            {
                if (y - 1 < 0) return false;
                MainBoard.DoesItFit(SquareMap, lastSquareMap, look, x, checker, false, 0);
                checker--;
                if (MainBoard.DoesItFit(SquareMap, lastSquareMap, look, x, checker, false, 0))
                    y--;
            }
            else if (direction == 2)
            {
                if (y + 2 >= MainBoard.columns) return false;
                MainBoard.DoesItFit(SquareMap, lastSquareMap, look, x, checker, false, 0);
                checker++;
                if (MainBoard.DoesItFit(SquareMap, lastSquareMap, look, x, checker, false, 0))
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
                for (int i = 0; i < 2; i++)
                    if (MainBoard.Map[x + i, y - 1] == look && SquareMap[i, 2] == look)
                        MainBoard.Map[x + i, y - 1] = 0;
            }
            else //right
            {
                for (int i = 0; i < 2; i++)
                    if (MainBoard.Map[x + i, y + 2] == look && SquareMap[i, 0] == look)
                        MainBoard.Map[x + i, y + 2] = 0;
            }
        }
        public override Byte[,] GetTabKlocek()
        {
            return SquareMap;
        }
        bool czyspadl(int sizeofheight)
        {
            if (x + sizeofheight - 1 == MainBoard.rows)
                return true;
            for (int i = 0; i < 2; i++)
                if (MainBoard.Map[x + sizeofheight - 1, y + i] != 0 && SquareMap[sizeofheight - 1, i] != 0)
                    return true;
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
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    if (SquareMap[i, j] != 0)
                        MainBoard[x + i - 1, y + j] = 28;
            x = 0;
            y = 0;
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    lastSquareMap[i, j] = 0;
        }
        public override void SetMaptoKlocek(Board map)
        {
            this.MainBoard = map;
        }
        public override void setonthemiddle()
        {
            y = ((int)MainBoard.columns / 2) - 2;
            x = 0;
        }
        public override void MoveKlocekDown()
        {
                x++;
        }
        public override int getXofKlocek()
        {
            return x;
        }
    }
}



/*
        if(MainBoard.DoesItFit(SquareMap, x, y)) //////
            {
                for (int i = 0; i < 2; i++)
                {
                    for(int j = 0; j < 2; j++)
                    {
                        if (SquareMap[i, j] != 0)
                            MainBoard[x+i, y+j] = look;
                    }
                }
                x++;
            }
if(Console.ReadKey(true).Key == ConsoleKey.D)
                {
                    y++;
                }
*/
