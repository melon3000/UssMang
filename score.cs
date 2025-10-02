using System;

namespace Manu_Uus
{
    class Score
    {
        public int Points { get; private set; }

        public Score()
        {
            Points = 0;
        }

        public void AddPoints(int amount)
        {
            Points += amount;
            ShowScore();
        }


        public void ShowScore()
        {

            int currentScore = Points;
            Console.SetCursorPosition(0, 24);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Points: {Points}");
            Console.ResetColor();
        }
    }
}
