using System;

namespace Manu_Uus
{
    static class GameOver
    {
        public static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine("============================");

            yOffset++; 
            Console.SetCursorPosition(xOffset + 1, yOffset);
            Console.WriteLine("          L Õ P P");

            yOffset++; 

            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine("============================");
            Console.ResetColor();
        }
    }
}
