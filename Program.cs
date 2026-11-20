
namespace szabadkezirajzolo
{
    internal class Program
    {
        static void HelyreIras(string szoveg, int szelesseg, int magassag)
        {
            Console.SetCursorPosition(szelesseg, magassag);
            Console.WriteLine(szoveg);
        }

        static void Karaktervalaszto(char[] valasztottkarakterek)
        {
            //szia Dani azt majd episd be a rajzolo teruletnel hogy oldalt irja mar a karakter tarat esetleg melyik karakter van ki valasztva koszi
            char[] karakterek = {
                '█', '▓', '▒', '░', '@', '#', '%', '&', '$', '+',
                '*', '=', ';', ':', ',', '.', '\'', '`', '▀', '▄',
                '▌', '▐', '-', '_', '~', '¯', '|', '!', '[', ']',
                '/', '\\', '(', ')', '{', '}', '─', '│',
                '┌', '┐', '└', '┘', '├', '┤', '┬', '┴', '┼'
            };

            ConsoleKeyInfo bill;
            int modositasAlattAlloKarakterIdx = 0;
            int valasztohelye = 0;

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                HelyreIras("KARAKTERVÁLASZTÓ", 0, 1);
                Console.ResetColor();
                HelyreIras(
                    $"Valasszon az alabbi karakterek kozul. Jelenlegi karaktertar: {string.Join(" ", valasztottkarakterek)}",
                    0, 3);

                HelyreIras(
                    $"A nyilak hasznalataval tudsz a karakterek kozott lepkedni " +
                    $"\nAz Enterrel a modositas alatt allo karaktert modositod " +
                    $"\nA Space lenyomasaval tovabb lepsz a karaktertar kovetkezo karakterenek modositasara " +
                    $"\nJelenleg a {modositasAlattAlloKarakterIdx + 1}. karaktert modositja." +
                    $"\nBarmely mas gomb megnyomasaval visszalephetsz a kezdo menube.",
                    0, 4);

                for (int i = 0; i < karakterek.Length; i++)
                {
                   if(i == valasztohelye)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        HelyreIras(karakterek[i].ToString(), i, 9);
                    }else {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        HelyreIras(karakterek[i].ToString(), i, 9);
                    }
                    
                }

                Console.ForegroundColor = ConsoleColor.White;
                HelyreIras("1", valasztohelye, 10);

                Console.ResetColor();

                bill = Console.ReadKey(true);

                if (bill.Key == ConsoleKey.RightArrow)
                {
                    if (valasztohelye < karakterek.Length - 1)
                    {
                        valasztohelye++;
                    }
                }
                else if (bill.Key == ConsoleKey.LeftArrow)
                {
                    if (valasztohelye > 0)
                    {
                        valasztohelye--;
                    }
                }
                else if (bill.Key == ConsoleKey.Enter)
                {
                    valasztottkarakterek[modositasAlattAlloKarakterIdx] =
                        karakterek[valasztohelye];
                }
                else if (bill.Key == ConsoleKey.Spacebar)
                {
                    modositasAlattAlloKarakterIdx++;

                    if (modositasAlattAlloKarakterIdx >= valasztottkarakterek.Length)
                    {
                        modositasAlattAlloKarakterIdx = 0;
                    }
                }
                else
                {
                    break;
                }

            } while (true);

            Console.ResetColor();
        }

        static int Menurajzolas(bool rajzolaskozben, int valasztohelye)
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Konzolos Rajzolo alkalmazás (BB&ED)".ToUpper());

            Console.ResetColor();

            HelyreIras(
                "Valassz a menu pontok kozul \na nyilakkal es az enterrel!\nA rajzolas megkezdesehez nyomd le\na SPACE billentyut!",
                0, 1);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            HelyreIras("Menu:", 3, 5);

            int konzolSzelesseg = Console.WindowWidth;
            int konzolMagassag = Console.WindowHeight;

            HelyreIras("->", 1, valasztohelye);

            switch (rajzolaskozben)
            {
                case false:

                    if (valasztohelye == 7)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }

                    HelyreIras("Karakter valasztasa", 3, 7);

                    if (valasztohelye == 8)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    HelyreIras("Szin valasztasa", 3, 8);

                    if (valasztohelye == 9)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }

                    HelyreIras("Fajl beolvasas", 3, 9);

                    if (valasztohelye == 10)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }

                    HelyreIras("Segitseg", 3, 10);

                    if (valasztohelye == 11)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }

                    HelyreIras("Kilepes", 3, 11);

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                case true:
                    break;
            }

            for (int i = 0; i < konzolMagassag - 1; i++)
            {
                HelyreIras("|", konzolSzelesseg - 85, i);
            }

            return valasztohelye;
        }

        static void Main(string[] args)
        {
            char[] valasztottkarakterek = new char[5]
            {
                '#', '#', '#', '#', '#'
            };

            int valasztohelye = 7;

            while (true)
            {
                Menurajzolas(false, valasztohelye);

                ConsoleKeyInfo bill = Console.ReadKey(true);

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

                        switch (valasztohelye)
                        {
                            case 7:
                                Console.Clear();
                                Karaktervalaszto(valasztottkarakterek);
                                break;

                            case 11:
                                return;
                        }

                        break;

                    case ConsoleKey.Spacebar:
                        break;
                }
            }
        }
    }
}
