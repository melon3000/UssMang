namespace Manu_Uus
{
    class GameSettings
    {
        public string Difficulty { get; private set; } //loeme / kirjutame raskusastet
        public int BaseSpeed { get; private set; }
        public int SpeedStep { get; private set; }
        public int MinSpeed { get; private set; }

        public GameSettings(string difficulty)
        {
            Difficulty = difficulty;

            switch (difficulty)
            {
                case "Easy":
                    BaseSpeed = 150;
                    SpeedStep = 10;
                    MinSpeed = 50;
                    break;

                case "Medium":
                    BaseSpeed = 100;
                    SpeedStep = 15;
                    MinSpeed = 30;
                    break;

                case "Hard":
                    BaseSpeed = 70;
                    SpeedStep = 20;
                    MinSpeed = 10;
                    break;

                default:
                    BaseSpeed = 100;
                    SpeedStep = 15;
                    MinSpeed = 30;
                    break;
            }
        }
    }
}
