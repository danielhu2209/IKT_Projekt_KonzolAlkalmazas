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
        static void RajzolasMod()
        {

        }
        static int Menurajzolas(bool rajzolaskozben, int valasztohelye)
        {
            Console.Clear();
            HelyreIras("Konzolos rajzolo program (BB&ED)\n\n", 0, 0);
            HelyreIras("Valassz a menu pontok kozul a nyilakkal es az enterrel!\n A rajzolas megkezdesehez nyomd le a SPACE billentyut!", 0, 1);
            HelyreIras("Menu:", 3, 3);
            int konzolSzelesseg = Console.WindowWidth;
            int konzolMagassag = Console.WindowHeight;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            HelyreIras("->", 1, valasztohelye);

            switch (rajzolaskozben)
            {
                case false:


                    ConsoleColor szin = ConsoleColor.Red;


                    if (valasztohelye == 5)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        HelyreIras("Karakter valasztasa", 3, 5);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        HelyreIras("Karakter valasztasa", 3, 5);
                    }

                    if (valasztohelye == 6)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        HelyreIras("Szin valasztasa", 3, 6);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        HelyreIras("Szin valasztasa", 3, 6);
                    }

                    if (valasztohelye == 7)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        HelyreIras("Fajl beolvasas", 3, 7);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        HelyreIras("Fajl beolvasas", 3, 7);
                    }

                    if (valasztohelye == 8)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        HelyreIras("Segitseg", 3, 8);

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        HelyreIras("Segitseg", 3, 8);

                    }

                    if (valasztohelye == 9)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        HelyreIras("Kilepes", 3, 9);

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        HelyreIras("Kilepes", 3, 9);

                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;








                    break;
                case true:
                    Console.WriteLine("Konzolos rajzolo program (BB&ED)");
                    break;
            }


            for (int i = 0; i < konzolMagassag; i++)
            {

                HelyreIras("|", konzolSzelesseg - 85, i);
            }
            return valasztohelye;
        }
        static void Main(string[] args)
        {

            int valasztohelye = 5;
            while (true)
            {
                Menurajzolas(false, valasztohelye);
                ConsoleKeyInfo bill = Console.ReadKey();
                switch (bill.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (valasztohelye > 5)
                        {
                            valasztohelye--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (valasztohelye < 9)
                        {
                            valasztohelye++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Spacebar:
                        RajzolasMod();
                        break;
                }
            }
        }
    }
}

