using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bonito_de_Minas
{
    public class Board
    {
        public byte[,] Map;
        int x;
        int y;
        public int rows { get { return Map.GetLength(0); } }
        public int columns { get { return Map.GetLength(1);  } }
        public byte this[int i, int j]
        {
            get
            {
                return Map[i, j];
            }
            set
            {
                Map[i, j] = value;
            }
        }
        public Board(int x, int y)
        {
            this.x = x;
            this.y = y;
            Map = new byte[x,y];
        }
        public bool IsInside(int cx, int cy)
        {
            return cx >= 0 && cx < x && cy >= 0 && cy < y;
        }
        public bool DoesItFit(Byte[,] tabKlocek, Byte[,] lasttabKlocek, Byte look, int x, int y, bool rotation, int offset) // lewy gorny rog klocka
        {
            if (x == 0)
                for (int i = 0; i < tabKlocek.GetLength(0); i++)
                    for (int j = 0; j < tabKlocek.GetLength(1); j++)
                        if (lasttabKlocek[i, j] != 0 && Map[x + i, y + j] == look)
                            Map[x + i, y + j] = 0;
            if ((y > this.y+tabKlocek.GetLength(1) || y < 0) && offset == 0) return false;
            if (x <= this.x - tabKlocek.GetLength(0) && y <= this.y - tabKlocek.GetLength(1) && x > 0)
            {
                for (int i = 0; i < tabKlocek.GetLength(0); i++)
                    for (int j = 0; j < tabKlocek.GetLength(1); j++)
                    {
                        if (lasttabKlocek[i, j] != 0 && Map[x+i-1,y+j] == look)
                        {
                            Map[x + i - 1, y + j] = 0;
                        }
                    }
            }

            for (int i = 0; i < tabKlocek.GetLength(0); i++)
            {
                for(int j = 0; j < tabKlocek.GetLength(1); j++)
                {
                    if (!IsInside(x + i, y + j))
                    {
                        return false;
                    }
                    if (tabKlocek[i,j] != 0 && Map[x + i, y + j] != 0)
                    {
                        return false;
                    }
                }
            }
            if (!rotation)
                for (int i = 0; i < tabKlocek.GetLength(0); i++)
                    for (int j = 0; j < tabKlocek.GetLength(1); j++)
                        lasttabKlocek[i, j] = tabKlocek[i, j];
            return true;
        }
        public void wypelnij()
        {
            Random c1 = new Random(404);
            byte[] tmp = new byte[x+y];
            for(int i = 0; i < x; i++)
            {
                c1.NextBytes(tmp);
                for(int j = 0; j < y; j++)
                {
                    Map[i, j] = tmp[j];
                }
            }
        }
        public void wypelnij2()
        {
            for(int i = 0; i < y-1; i++)
            {
                Map[9, i] = 1;
            }
        }
        public void linecheck()
        {
            int check = 0;
            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    if (Map[i,j] != 0)
                    {
                        check++;
                    }
                }
                if(check == y)
                {
                    for (int k = 0; k < i; k++)
                    {
                        for(int l = 0; l < y; l++)
                        {
                            Map[i-k, l]=Map[i-k-1,l];
                        }
                    }
                    for (int k = 0; k < y; k++)
                    {
                        if (i - 1 < 0)
                            continue;
                        Map[i-1, k] = 0;
                    }
                    i=0;
                }
                check = 0;
            }
        }
    }
}


/*
for (int i = 0; i < tabKlocek.GetLength(0); i++)
    for (int j = 0; j < tabKlocek.GetLength(1); j++)
           Map[x + i - 1, y + j] = 0; //maybe 



Console.WriteLine("\nup");
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write("  " + Map[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n");
                for(int i = 0; i < tabKlocek.GetLength(0); i++)
                {
                    for(int j = 0; j < tabKlocek.GetLength(1); j++)
                    {
                        Console.Write("  " + tabKlocek[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n last klocek na dole");
                for (int i = 0; i < tabKlocek.GetLength(0); i++)
                {
                    for (int j = 0; j < tabKlocek.GetLength(1); j++)
                    {
                        Console.Write("  " + lastKlocekMap[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("down\n");
            }
*/
