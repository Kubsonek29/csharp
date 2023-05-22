using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Bonito_de_Minas
{
    public class BonitoEngine
    {
        public Board mapa;
        public VisualMap printer;
        public List<Klocek> mojeklocki = new List<Klocek>();
        public Klocek currentklocek;
        System.Timers.Timer KlocekTimer = new System.Timers.Timer(300);
        System.Timers.Timer KlocekControler = new System.Timers.Timer(40);
        public BonitoEngine(Board map, VisualMap printing) {
            this.mapa = map;
            this.printer = printing;
        }
        public BonitoEngine(Board map)
        {
            this.mapa = map;
        }
        public void ReadSchema(/*StreamReader st*/)
        {
            Type[] xx = Assembly.GetAssembly(typeof(Klocek)).GetTypes();
            IEnumerable<Type> subclasses = xx.Where(t => t.IsSubclassOf(typeof(Klocek)));
            foreach(var item in subclasses)
            {
                mojeklocki.Add((Klocek)Activator.CreateInstance(item));
            }
        }
        public void cleartheboardandreset()
        {
            for (int i = 0; i < mapa.rows; i++)
                for (int j = 0; j < mapa.columns; j++)
                    mapa[i, j] = 0;
            foreach (var item in mojeklocki)
                item.reset();
        }
        public bool checkifgameend()
        {
            if (currentklocek.getIDifEnd() == true)
                return true;
            return false;
        }
        public void generujKlocek()
        {
            Random c1 = new Random();
            currentklocek = mojeklocki[c1.Next(0, mojeklocki.Count)];
            //currentklocek = new KlocekI();//
            currentklocek.SetMaptoKlocek(mapa);
            currentklocek.setonthemiddle();
        }
        public void testerklockow()
        {
            StartGameEngine();
            while (true)
            {
                if (currentklocek.hasFallen() == true)
                {
                    mapa.linecheck();
                    generujKlocek();
                    currentklocek.setonthemiddle();
                }
                Console.Clear();
                currentklocek.MoveKlocki();
                printer.Print();
                ConsoleKey Klucz = Console.ReadKey(true).Key;
                if (Klucz == ConsoleKey.LeftArrow)
                {
                    currentklocek.ControlKlocek(1);

                }
                else if (Klucz == ConsoleKey.RightArrow)
                {
                    currentklocek.ControlKlocek(2);
                }
                else if (Klucz == ConsoleKey.A)
                {
                    currentklocek.ControlKlocek(3);
                }
                else if (Klucz == ConsoleKey.D)
                {
                    currentklocek.ControlKlocek(4);
                }
                Thread.Sleep(1000);
            }
        }
        void DoVisualStuff(Object source, ElapsedEventArgs e)
        {
            Console.Clear();
            currentklocek.MoveKlocki();
            printer.Print();
        }
        void DoGameStuff(Object source, ElapsedEventArgs e)
        {
            //currentklocek.MoveKlocekDown();
            if (currentklocek.hasFallen() == true)
            {
                mapa.linecheck();
                generujKlocek();
                currentklocek.setonthemiddle();
            }
            Console.Clear();
            currentklocek.MoveKlocki();
            //printer.Print();
            printer.PrintConsoleColor();
            //Console.WriteLine("\n X = " + currentklocek.getXofKlocek());
        }
        void DoControlStuff(Object source, ElapsedEventArgs e)
        {
            ConsoleKey Klucz = Console.ReadKey(true).Key;
            if (Klucz == ConsoleKey.LeftArrow)
            {
                    currentklocek.ControlKlocek(1);
                    Console.Clear();
                    //printer.Print();
                printer.PrintConsoleColor();
                    //currentklocek.MoveKlocki();
            }
            else if (Klucz == ConsoleKey.RightArrow)
            {
                currentklocek.ControlKlocek(2);
                Console.Clear();
                //printer.Print();
                printer.PrintConsoleColor();
                //currentklocek.MoveKlocki();
            }
            else if (Klucz == ConsoleKey.A)
            {
                currentklocek.ControlKlocek(3);
                Console.Clear();
                //printer.Print();
                printer.PrintConsoleColor();
                //currentklocek.MoveKlocki();
            }
            else if (Klucz == ConsoleKey.D)
            {
                currentklocek.ControlKlocek(4);
                Console.Clear();
                //printer.Print();
                printer.PrintConsoleColor();
                //currentklocek.MoveKlocki();
            }
        }
        public void StartGameEngine()
        {
            ReadSchema();
            generujKlocek();
            Console.WriteLine("Press A or D to rotate [right/left] and press leftarrow and rightarrow to move!\n Enjoy!!! - Early Access Game");
            Thread.Sleep(3000);
            /////
            KlocekTimer.AutoReset = true;
            KlocekTimer.Enabled = true;
            KlocekControler.AutoReset = true;
            KlocekControler.Enabled = true;
            //KlocekVisual.AutoReset = true;
            //KlocekVisual.Enabled = true;
            KlocekTimer.Elapsed += DoGameStuff;
            KlocekControler.Elapsed += DoControlStuff;
            //KlocekVisual.Elapsed += DoVisualStuff;
            while (Console.ReadKey(true).Key != ConsoleKey.Q);
            Console.Clear();
            KlocekTimer.Stop();
            KlocekTimer.Dispose();
            Console.WriteLine("END\n");
        }
    }
}





/*
if (Console.ReadKey(true).Key == ConsoleKey.LeftArrow)
{
    currentklocek.ControlKlocek(1);  //
}
if(Console.ReadKey(true).Key == ConsoleKey.RightArrow)
{
    currentklocek.ControlKlocek(2); //prawo
}
if(Console.ReadKey(true).Key == ConsoleKey.A) //rotate w lewo
{
    currentklocek.ControlKlocek(3);
}
if(Console.ReadKey(true).Key == ConsoleKey.D) //rotate w prawo
{
    currentklocek.ControlKlocek(4);
}

while (true)
            {
                ConsoleKey Klucz = Console.ReadKey(true).Key;
                if (Klucz == ConsoleKey.LeftArrow)
                {
                    currentklocek.ControlKlocek(1);
                }
                else if (Klucz == ConsoleKey.RightArrow)
                {
                    currentklocek.ControlKlocek(2);
                }
                else if (Klucz == ConsoleKey.A)
                {
                    currentklocek.ControlKlocek(3);
                }
                else if (Klucz == ConsoleKey.D)
                {
                    currentklocek.ControlKlocek(4);
                }
                else if (Klucz == ConsoleKey.Q)
                {
                    kepasa.Join();
                    break;
                }
            }
        void mamajoe()
        {
            kepasa = new Thread(new ThreadStart(DoControlStuff));
            kepasa.Start();
        }
*/
