using System;
using System.Text;
using System.Threading;
using Manu_Uus;

namespace Manu_Uus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;

            var mainMenu = new MainMenu();

            while (true)
            {
                int selectedOption = mainMenu.ShowMenu();

                if (selectedOption == 0) //mangi
                {
                    Console.Clear();
                    StartGame();
                }
                else if (selectedOption == 1) //scores
                {
                    HighScores highScores = new HighScores();
                    Console.Clear();
                    highScores.ShowTopScores();
                }
                else if (selectedOption == 2) //lopp
                {
                    Console.Clear();
                    Console.WriteLine("Head aega!");
                    break;
                }
            }
        }

        static void StartGame()
        {
            int mapWidth = 80;
            int mapHeight = 25;

            Console.Clear();
            Console.WriteLine("Vali raskusaste: 1 - Easy, 2 - Medium, 3 - Hard");
            string difficulty = "Medium";


            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1) { difficulty = "Easy"; break; }
                else if (key.Key == ConsoleKey.D2) { difficulty = "Medium"; break; }
                else if (key.Key == ConsoleKey.D3) { difficulty = "Hard"; break; }
            }

            Console.Clear();

            //loeme lisandid
            GameSettings settings = new GameSettings(difficulty);
            int currentSpeed = settings.BaseSpeed;

            Walls walls = new Walls(mapWidth, mapHeight);
            walls.Draw();

            Point p = new Point(4, 5, '■');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(mapWidth, mapHeight);
            Food food = foodCreator.CreateFood();
            food.Draw();

            Score score = new Score();
            score.ShowScore();

            HighScores highScores = new HighScores();
            Player player = new Player();

            DateTime lastMoveTime = DateTime.Now;

            while (true)
            {
                if (snake.IsHitTail() || walls.IsHit(snake))
                    break;

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }

                if ((DateTime.Now - lastMoveTime).TotalMilliseconds >= currentSpeed)
                {
                    string? eatenType = snake.Eat(food);

                    if (eatenType != null)
                    {
                        score.AddPoints(1);

                        if (eatenType == "SpeedUp")
                        {
                            currentSpeed -= settings.SpeedStep;
                            if (currentSpeed < settings.MinSpeed)
                                currentSpeed = settings.MinSpeed;
                        }
                        else if (eatenType == "SlowDown")
                        {
                            currentSpeed += settings.SpeedStep;
                        }

                        food = foodCreator.CreateFood();
                        food.Draw();
                    }
                    else
                    {
                        snake.Move();
                    }

                    score.ShowScore();
                    lastMoveTime = DateTime.Now;
                }

                Thread.Sleep(1);
            }

            //mängu lõpp
            GameOver.WriteGameOver();

            player.AskName();
            highScores.SaveScore(player.Name, score.Points);
        }
    }
}
