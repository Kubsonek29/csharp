using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonito_de_Minas
{
    internal class VisualMap
    {
        Board Mainboard;
        public VisualMap(Board Map)
        {
            Mainboard = Map;
        }
        public void Print()
        {
            for (int i = 0; i < Mainboard.rows; i++)
            {
                for (int j = 0; j < Mainboard.columns; j++)
                {
                    if (Mainboard[i,j]==0)
                        Console.Write(" ~");
                    else if (Mainboard[i,j]>20)
                        Console.Write(Mainboard[i,j]);
                    else
                        Console.Write(" " + Mainboard[i,j]);
                }
                Console.WriteLine();
            }
        }
        public void PrintConsoleColor()
        {
            for (int i = 0; i < Mainboard.rows; i++)
            {
                for (int j = 0; j < Mainboard.columns; j++)
                {
                    if (Mainboard[i, j] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.DarkGray;  
                        Console.Write("  ");
                    }
                    else
                    {
                        if (Mainboard[i,j] == 6  || Mainboard[i, j] == 25)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (Mainboard[i, j] == 4 || Mainboard[i, j] == 26)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (Mainboard[i, j] == 9 || Mainboard[i, j] == 27)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else if (Mainboard[i, j] == 5 || Mainboard[i, j] == 28)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (Mainboard[i, j] == 7 || Mainboard[i, j] == 29)
                        {
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else if (Mainboard[i, j] == 8 || Mainboard[i, j] == 30)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        if (Mainboard[i, j] > 20)
                            Console.Write(Mainboard[i, j]);
                        else
                            Console.Write(Mainboard[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
