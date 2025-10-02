using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Manu_Uus
{
    class HighScores
    {
        private string filePath = "Nimed.txt";

        public void SaveScore(string playerName, int score)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine($"{playerName},{score}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Viga salvestamisel: " + ex.Message);
            }
        }

        public List<(string name, int score)> LoadScores()
        {
            var list = new List<(string name, int score)>();

            if (!File.Exists(filePath))
                return list;

            try
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                    {
                        list.Add((name: parts[0], score: score));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Viga loemisel: " + ex.Message);
            }

            return list.OrderByDescending(s => s.score).ToList();
        }

        public void ShowTopScores(int topN = 5)
        {
            var scores = LoadScores();

            Console.Clear();
            Console.WriteLine("=== Parimad mängujad ===");
            for (int i = 0; i < Math.Min(topN, scores.Count); i++)
            {
                Console.WriteLine($"{i + 1}. {scores[i].name} - {scores[i].score}");
            }
            Console.WriteLine("\nVajuta mõni nupp");
            Console.ReadKey();
        }
    }
}
