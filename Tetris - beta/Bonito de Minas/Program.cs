using Bonito_de_Minas;
using System.Reflection;

class Program
{
    public static void Main()
    {
        Board Plansza = new Board(15, 11);
        VisualMap SeeMap = new VisualMap(Plansza);
        BonitoEngine DieselEngine = new BonitoEngine(Plansza, SeeMap);
        DieselEngine.StartGameEngine();
        //DieselEngine.testerklockow();
    }
}










/*
        SeeMap.Print();
        //Plansza.wypelnij();
        Plansza.wypelnij2();
        Console.WriteLine();
        SeeMap.Print();
        Plansza.linecheck();
        Console.WriteLine();
        SeeMap.Print();
        bool helloIamInside = Plansza.IsInside(9, 14);
        Console.WriteLine(helloIamInside);
        */

/*
Byte[,] tmp = new byte[10, 10];
tmp[8, 3] = 2;
tmp[8, 4] = 2;
tmp[7, 4] = 2;
tmp[7, 5] = 2;
for (int i = 0; i < 3; i++)
    for (int j = 0; j < 3; j++)
    {
        if (tmp[6 + i, 1 + j] != 0)
            tmp[6 + i, 1 + j] = 1;
    }

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        if (tmp[6 + i, 1 + j] != 1)
            tmp[6 + i, 1 + j] = 5;
    }
}
for (int i = 0; i < 3; i++)
    for (int j = 0; j < 3; j++)
        if (tmp[6 + i, 1 + j] == 1)
            tmp[6 + i, 1 + j] = 2;
for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        Console.Write(" " + tmp[i, j]);
    }
    Console.WriteLine();
}
*/