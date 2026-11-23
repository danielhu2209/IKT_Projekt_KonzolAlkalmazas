using System.Security;
using System.Text;
using System.Windows.Forms;
namespace szabadkezirajzolo

{
    internal class Program
    {
        static void HelyreIras(string szoveg, int szelesseg, int magassag)
        {
            Console.SetCursorPosition(szelesseg, magassag);
            Console.Write(szoveg);
        }


        static ConsoleColor SzinSorszambol(int sorszam)
        {
            switch (sorszam)
            {
                case 0: return ConsoleColor.White;
                case 1: return ConsoleColor.Red;
                case 2: return ConsoleColor.Green;
                case 3: return ConsoleColor.Blue;
                case 4: return ConsoleColor.Yellow;
                case 5: return ConsoleColor.Cyan;
                case 6: return ConsoleColor.Magenta;
                default: return ConsoleColor.Gray;
            }
        }


        static string SzinNeve(ConsoleColor szin)
        {
            switch (szin)
            {
                case ConsoleColor.White: return "feher";
                case ConsoleColor.Red: return "piros";
                case ConsoleColor.Green: return "zold";
                case ConsoleColor.Blue: return "kek";
                case ConsoleColor.Yellow: return "sarga";
                case ConsoleColor.Cyan: return "cian";
                case ConsoleColor.Magenta: return "magenta";
                case ConsoleColor.Gray: return "szurke";
                default: return "ismeretlen";
            }
        }


        static ConsoleColor SzinValaszto(ConsoleColor jelenlegiSzin)
        {
            int szinekSzama = 8;
            int panelSzelesseg = 35;


            int kijelolt = 0;
            for (int i = 0; i < szinekSzama; i++)
            {
                if (SzinSorszambol(i) == jelenlegiSzin)
                {
                    kijelolt = i;
                }
            }

            while (true)
            {
                Console.ResetColor();
                for (int sor = 1; sor < 17; sor++)
                {
                    HelyreIras("".PadRight(panelSzelesseg), 0, sor);
                }


                HelyreIras("Valassz szint a nyilakkal!", 0, 1);
                HelyreIras("Enter: kivalasztas", 0, 2);
                HelyreIras("Esc: vissza a menube", 0, 3);

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                HelyreIras("Szin valasztasa:", 3, 5);
                Console.ResetColor();


                for (int i = 0; i < szinekSzama; i++)
                {
                    ConsoleColor szin = SzinSorszambol(i);
                    string sorSzoveg = SzinNeve(szin);
                    if (szin == jelenlegiSzin)
                    {
                        sorSzoveg = sorSzoveg + " (jelenlegi)";
                    }

                    if (i == kijelolt)
                    {
                        Console.ResetColor();
                        HelyreIras("->", 1, 7 + i);
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.ForegroundColor = szin;
                    HelyreIras(sorSzoveg, 4, 7 + i);
                    Console.ResetColor();
                }

                ConsoleKeyInfo bill = Console.ReadKey(true);
                switch (bill.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (kijelolt > 0)
                        {
                            kijelolt--;
                        }
                        else
                        {
                            Console.Beep();
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (kijelolt < szinekSzama - 1)
                        {
                            kijelolt++;
                        }
                        else
                        {
                            Console.Beep();
                        }
                        break;

                    case ConsoleKey.Enter:
                        return SzinSorszambol(kijelolt);

                    case ConsoleKey.Escape:
                        return jelenlegiSzin;

                    default:
                        Console.Beep();
                        break;
                }
            }
        }

        static void RajzlapKirajzolas(StringBuilder sb, ConsoleColor[] szinek, int maxmagassag)
        {
        
            Console.CursorVisible = false;

            for (int sor = 0; sor < maxmagassag; sor++)
            {
                Console.SetCursorPosition(36, sor);

               
                int kezdet = 0;
                while (kezdet < 82)
                {
                    int kezdoIdx = sor * 82 + kezdet;
                    int veg = kezdet;
                    while (veg < 82 && szinek[sor * 82 + veg] == szinek[kezdoIdx])
                    {
                        veg++;
                    }
                    Console.ForegroundColor = szinek[kezdoIdx];
                    Console.Write(sb.ToString(kezdoIdx, veg - kezdet)); 
                    kezdet = veg;
                }
            }
            Console.ResetColor();
        }

        static void Karaktervalaszto(char[] valasztottkarakterek)
        {

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
                    if (i == valasztohelye)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        HelyreIras(karakterek[i].ToString(), i, 9);
                    }
                    else
                    {
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
        static void RajzolasMod(char[] valasztottkarakterek, int idx, StringBuilder sb, int maxmagassag, ConsoleColor szin, ConsoleColor[] szinek)
        {
            bool felemelve = true;
            bool radir = false;
            int konzolSzelesseg = Console.WindowWidth;
            int konzolMagassag = Console.WindowHeight;
            int[] kurzorPozicio = new int[2];
            kurzorPozicio[0] = 120 - 84;
            kurzorPozicio[1] = 0;
            bool running = true;

            while (running)
            {
                Console.Clear();



                for (int i = 0; i < konzolMagassag - 1; i++)
                {
                    HelyreIras("|", 35, i);
                }
                for (int i = 0; i < konzolMagassag - 1; i++)
                {
                    Console.SetCursorPosition(118, i);
                    Console.Write("|");
                }
                RajzlapKirajzolas(sb, szinek, maxmagassag);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                HelyreIras("Rajzolasi mod", 0, 0);
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                HelyreIras($"Jelenlegi eszkoztar:{string.Join(' ', valasztottkarakterek)}", 0, 2);
                Console.ResetColor();
                HelyreIras("A karaktertarban valo lepegeteshez \nhasznalja a 1-5 billentyuket", 0, 3);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                HelyreIras($"A kivalasztot karakter:{valasztottkarakterek[idx]}", 0, 5);
                Console.ResetColor();
                HelyreIras("A kivalasztott szin:", 0, 7);
                Console.ForegroundColor = szin;
                HelyreIras(SzinNeve(szin), 21, 7);
                Console.ResetColor();
                HelyreIras($"Kurzor pozicio", 0, 8);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;


                if (felemelve)
                {
                    HelyreIras("Az eszkoz felvan emelve\nnem fogsz rajzolni!", 0, 9);
                }
                else
                {
                    HelyreIras("Az eszkoz le van teve\nrajzolni fogsz!", 0, 9);
                }
                Console.ResetColor();
                HelyreIras("A radir bekapcsolasahoz nyomd meg \na CTRL gombot", 0, 11);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                if (radir)
                {
                    HelyreIras("A radir be van kapcsolva", 0, 13);
                }
                else
                {
                    HelyreIras("A radir k ivan kapcsolva", 0, 13);
                }
                Console.ResetColor();
                HelyreIras("A kilepeshez nyomd le megegyszer \na Space Billentyut", 0, 14);
                Console.SetCursorPosition(kurzorPozicio[0], kurzorPozicio[1]);
                Console.CursorVisible = true; // rajzoláskor a kurzornak látszania kell
                ConsoleKeyInfo bill = Console.ReadKey(true);



                switch (bill.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                    case ConsoleKey.D4:
                    case ConsoleKey.D5:
                        idx = (int)bill.Key - (int)ConsoleKey.D1;
                        break;





                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop > 0)
                        {
                            kurzorPozicio[1]--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.CursorTop < 27)
                        {
                            kurzorPozicio[1]++;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Console.CursorLeft < 117)
                        {
                            kurzorPozicio[0]++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Console.CursorLeft > 36)
                        {
                            kurzorPozicio[0]--;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.ForegroundColor = szin; 
                        
                        Console.ResetColor();
                        int sbIdx = kurzorPozicio[1] * 82 + kurzorPozicio[0] - 36;
                        sb[sbIdx] = valasztottkarakterek[idx];
                        szinek[sbIdx] = szin; 
                        break;
                    case ConsoleKey.Spacebar:
                        running = false;
                        break;
                    case ConsoleKey.F1:
                        if ((kurzorPozicio[0] - 3 >= 36) &&
                            (kurzorPozicio[0] + 3 <= 117) &&
                            (kurzorPozicio[1] - 3 >= 0) &&
                            (kurzorPozicio[1] + 3 <= 27))
                        {
                            int eredetihelyX = kurzorPozicio[0];
                            int eredetihelyY = kurzorPozicio[1];

                            int nyomdaIdx;

                            // Bal felső sarok
                            nyomdaIdx = (eredetihelyY - 3) * 82 + (eredetihelyX - 3 - 36);
                            sb[nyomdaIdx] = valasztottkarakterek[idx];
                            szinek[nyomdaIdx] = szin;

                            // Jobb felső sarok
                            nyomdaIdx = (eredetihelyY - 3) * 82 + (eredetihelyX + 3 - 36);
                            sb[nyomdaIdx] = valasztottkarakterek[idx];
                            szinek[nyomdaIdx] = szin;

                            // Jobb alsó sarok
                            nyomdaIdx = (eredetihelyY + 3) * 82 + (eredetihelyX + 3 - 36);
                            sb[nyomdaIdx] = valasztottkarakterek[idx];
                            szinek[nyomdaIdx] = szin;

                            // Bal alsó sarok
                            nyomdaIdx = (eredetihelyY + 3) * 82 + (eredetihelyX - 3 - 36);
                            sb[nyomdaIdx] = valasztottkarakterek[idx];
                            szinek[nyomdaIdx] = szin;

                            
                        }
                        else
                        {
                            Console.Beep(1000, 1000);
                        }

                        break;
                        /*
                    case ConsoleKey.F2:

                    case ConsoleKey.F3:

                    case ConsoleKey.F4:

                    case ConsoleKey.F5:

                    case ConsoleKey.F6:

                    case ConsoleKey.F7:

                    case ConsoleKey.F8:

                    case ConsoleKey.F9:

                    case ConsoleKey.F10:

                    case ConsoleKey.F11:

                    case ConsoleKey.F12:
                        */

                }
            }
        }
        static void Mentes(string vegsoSzoveg, int mSzama)
        {
            HelyreIras("milyen neven legyen elmentve a fajl?",45,15);
            String nev = Console.ReadLine();


            string eredmenyHelye = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + $"\\{nev}.txt";
            File.WriteAllText(eredmenyHelye, string.Join(
                "\n", Enumerable.Range(0, 28).Select(x => vegsoSzoveg.Substring(x * 82, 82)
                )));
            Console.WriteLine("Sikeresen elmentve(az asztalra) a folytatashoz nyomjon meg egy gombot");
            Console.ReadKey(true);

        }
        static string Menurajzolas(bool rajzolaskozben, int valasztohelye, StringBuilder sb)
        {
            Console.CursorVisible = false; 
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Konzolos Rajzolo alkalmazás (BB&ED)".ToUpper());

            Console.ResetColor();

            HelyreIras("Valassz a menu pontok kozul \na nyilakkal es az enterrel!\nA rajzolas megkezdesehez nyomd le\na SPACE billentyut!", 0, 1);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            HelyreIras("Menu:", 3, 5);

            int konzolSzelesseg = Console.WindowWidth;
            int konzolMagassag = Console.WindowHeight;

            HelyreIras("->", 1, valasztohelye);

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

            HelyreIras("Mentes", 3, 10);

            if (valasztohelye == 11)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            HelyreIras("Segitseg", 3, 11);

            if (valasztohelye == 12)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }

            HelyreIras("Kilepes", 3, 12);

            Console.ResetColor();
            for (int i = 0; i < konzolMagassag - 1; i++)
            {
                HelyreIras("|", 35, i);
            }

            for (int i = 0; i < konzolMagassag - 1; i++)
            {
                Console.SetCursorPosition(118, i);
                Console.Write("|");
            }

            string vegsoSzoveg = sb.ToString();
            Console.SetCursorPosition(0, 28);

            return vegsoSzoveg;
        }
        static string Beolvasas()
        {
            OpenFileDialog fajl = new OpenFileDialog();
            fajl.Filter = "Text files (*.txt)|*.txt";

            if (fajl.ShowDialog() == DialogResult.OK)
            {
                string beolvasottFajl = string.Concat(File.ReadAllText(fajl.FileName));
                return beolvasottFajl;
            }

            return "";
        }

        [STAThread]
        static void Main(string[] args)
        {
            int maxmagassag = 28;
            int mentesekSzama = 0;
            StringBuilder rajzSzovegesFormaja = new StringBuilder();
            rajzSzovegesFormaja.Length = 82 * 28;
            for (int i = 0; i < rajzSzovegesFormaja.Length; i++)
            {
                rajzSzovegesFormaja[i] = ' ';
            }
         
            ConsoleColor szin = ConsoleColor.White;
           
            ConsoleColor[] rajzSzinek = new ConsoleColor[82 * 28];
            for (int i = 0; i < rajzSzinek.Length; i++)
            {
                rajzSzinek[i] = ConsoleColor.White; 
            }
            char[] valasztottkarakterek = new char[5]
            {
                '#', '#', '#', '#', '#'
            };
            int valKarIdx = 0;
            //meg csinald mar azt meg hogy a szamokkal lehet kraktert valtoztatni
            //en ugy talatam ki hoyg az index lesz valtoztatva mindig es a valasztotkarakterek[valkaridx] el irunk majd ki mindent
            int valasztohelye = 7;

            while (true)
            {
                string szoveg = Menurajzolas(false, valasztohelye, rajzSzovegesFormaja);
                RajzlapKirajzolas(rajzSzovegesFormaja, rajzSzinek, maxmagassag); 

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

                        if (valasztohelye < 12)
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
                            case 8:
                                szin = SzinValaszto(szin); 
                                break;
                            case 9:

                                string beolvasottSzoveg = Beolvasas();
                                if(beolvasottSzoveg != "") { 
                                beolvasottSzoveg = beolvasottSzoveg.Replace("\n", "");

                                if (beolvasottSzoveg.Length <= 82 * 28)
                                {
                                    for (int i = 0; i < rajzSzovegesFormaja.Length; i++)
                                    {
                                        rajzSzovegesFormaja[i] = ' ';
                                    }
                                    rajzSzovegesFormaja.Insert(0, beolvasottSzoveg);
                                   
                                    for (int i = 0; i < rajzSzinek.Length; i++)
                                    {
                                        rajzSzinek[i] = szin;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("a beolvasas sikertelen volt");
                                    Console.WriteLine(beolvasottSzoveg.Length);
                                    Console.ReadKey(true);
                                    Console.ReadKey();
                                }
                                }
                                break;
                            case 10:
                                Mentes(szoveg, mentesekSzama);
                                break;
                            case 12:
                                return;

                        }

                        break;

                    case ConsoleKey.Spacebar:
                        RajzolasMod(valasztottkarakterek, valKarIdx, rajzSzovegesFormaja, maxmagassag, szin, rajzSzinek); 
                        break;
                }
            }
        }
    }
}
