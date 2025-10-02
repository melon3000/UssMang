using System;

namespace Manu_Uus
{
    class Player
    {
        public string Name { get; private set; }

        public string x_offset = "+                         ";
        public void AskName()
        {
            while (true)
            {
                Console.Write($"{x_offset} Nimi: ");
                try
                {
                    string input = Console.ReadLine();
                    if (input.Length >= 3)
                    {
                        Name = input;
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{x_offset} Nimi on väga lühike, proovi uuest.");
                        Console.ResetColor();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{x_offset} Viga, proovige uuesti.");
                    Console.ResetColor();
                }
            }
        }
    }
}
