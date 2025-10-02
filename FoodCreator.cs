using System;

namespace Manu_Uus
{
    class Food : Point
    {
        public string Type { get; private set; } // loeme toidu tüübi

        //asukoht, sümbol, toidu tüüb
        public Food(int x, int y, char sym, string type) : base(x, y, sym)
        {
            Type = type;

            // Määrame värvi sõltuvalt tüübist
            switch (type)
            {
                case "Normal":
                    color = ConsoleColor.Yellow; // Tavaline toit
                    break;
                case "SpeedUp":
                    color = ConsoleColor.Green;  // Kiirendav toit
                    break;
                case "SlowDown":
                    color = ConsoleColor.Red;    // Aeglustav toit
                    break;
                default:
                    color = ConsoleColor.White;  // Vaikimisi värv
                    break;
            }
        }
    }

    class FoodCreator
    {
        int mapWidth;
        int mapHeight;
        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight) //kasutame this. et eristada klassi omadust ja parameetrit
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
        }

         public Food CreateFood()
        {
            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);

            int chance = random.Next(0, 100);

            //tavaline
            if (chance < 70)
                return new Food(x, y, '@', "Normal");
            //kiirendav
            else if (chance < 85)
                return new Food(x, y, 'S', "SpeedUp");
            //aeglustav
            else
                return new Food(x, y, 'D', "SlowDown");
        }
    }
}
