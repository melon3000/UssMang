using System;

namespace Manu_Uus
{
    class MainMenu
    {
        private string[] options = { "Uus mäng", "Tulemused", "Välju" };

        public int ShowMenu()
        {
            int selected = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Põhimenüü ===");
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selected)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"> {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]}");
                    }
                }

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\nKasuta nooleklahve valimiseks.");
                Console.ForegroundColor = ConsoleColor.White;

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selected = (selected - 1 + options.Length) % options.Length;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selected = (selected + 1) % options.Length;
                }
                else if (key == ConsoleKey.Enter)
                {
                    return selected;
                }
            }
        }
    }
}
