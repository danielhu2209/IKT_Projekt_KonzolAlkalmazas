using Microsoft.Win32.SafeHandles;
using System.Runtime.ExceptionServices;

namespace szabadkezirajzolo
{
    internal class Program
    {
        static void HelyreIras(string szoveg, int szelesseg, int magassag)
        {
            Console.SetCursorPosition(szelesseg, magassag);
            Console.WriteLine(szoveg);
        }
        static string Karaktervalaszto()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("KARAKTERVÁLASZTÓ");
            Console.WriteLine("Választhat az alábbi előre beállított karakterek közűl vagy Használhat saját karaktert is.");
        }
        static void RajzolasMod()
        {

        }
        static int Menurajzolas(bool rajzolaskozben, int valasztohelye)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Konzolos Rajzolo alkamazás(BB&ED)".ToUpper());
            Console.ResetColor();
            HelyreIras("Valassz a menu pontok kozul \na nyilakkal es az enterrel!\nA rajzolas megkezdesehez nyomd le\na SPACE billentyut!", 0, 1);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            HelyreIras("Menu:", 3, 5);
            
            int konzolSzelesseg = Console.WindowWidth;
            int konzolMagassag = Console.WindowHeight;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            HelyreIras("->", 1, valasztohelye);

            switch (rajzolaskozben)
            {
                case false:


                    ConsoleColor szin = ConsoleColor.Red;


                    if (valasztohelye == 7)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        HelyreIras("Karakter valasztasa", 3, 7);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        HelyreIras("Karakter valasztasa", 3, 7);
                    }

                    if (valasztohelye == 8)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        HelyreIras("Szin valasztasa", 3, 8);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        HelyreIras("Szin valasztasa", 3, 8);
                    }

                    if (valasztohelye == 9)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        HelyreIras("Fajl beolvasas", 3, 9);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        HelyreIras("Fajl beolvasas", 3, 9);
                    }

                    if (valasztohelye == 10)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        HelyreIras("Segitseg", 3, 10);

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        HelyreIras("Segitseg", 3, 10);

                    }

                    if (valasztohelye == 11)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        HelyreIras("Kilepes", 3, 11);

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        HelyreIras("Kilepes", 3, 11);

                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;








                    break;
                case true:
                    
                    break;
            }


            for (int i = 0; i < konzolMagassag-1; i++)
            {

                HelyreIras("|", konzolSzelesseg - 85, i);
            }
            return valasztohelye;
        }
        static void Main(string[] args)
        {
            char karakter = '#';
            int valasztohelye = 7;
            while (true)
            {
                Menurajzolas(false, valasztohelye);
                ConsoleKeyInfo bill = Console.ReadKey();
                switch (bill.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (valasztohelye > 7)
                        {
                            valasztohelye--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (valasztohelye < 11)
                        {
                            valasztohelye++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (Menurajzolas()) {
                            case 7;
                                Karaktervalaszto();


                        }
                            
                                

                    case ConsoleKey.Spacebar:
                        RajzolasMod();
                        break;
                }
            }
        }
    }
}

