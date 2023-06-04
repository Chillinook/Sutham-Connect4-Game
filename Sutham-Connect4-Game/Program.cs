using System;
using System.Collections.Generic;

namespace Sutham_Connect4_Game
{


    public class GuessingGame
    {
        public string Name { get; set; }
        public int Score { get; set; }
        private static int _hiddenNo;
        private static List<GuessingGame> playerList;
        private static Random r;
        private static int count = 0;
        static GuessingGame()
        {
            playerList = new List<GuessingGame>();
            r = new Random();
            _hiddenNo = r.Next(0, 100);
        }
      
        public static void AddAPlayer(string name)
        {
            var player = new GuessingGame
            {
                Name = name,
                Score = 0
            };
            playerList.Add(player);
        }
        public override string ToString()
        {
            return $"Name: {Name}, Score: {Score}";
        }
        public static bool Play()
        {
            Console.WriteLine($"Now Playing Player {count + 1}: {playerList[count].Name}");
            Console.WriteLine("Guess a number: ");
            int guess = int.Parse(Console.ReadLine());
            if (guess == _hiddenNo)
            {
                playerList[count].Score += 10;
                Console.WriteLine($"Congratulations {playerList[count].Name}... You guessed it right.");
                return false;
            }
            else if (guess > _hiddenNo)
            {
                Console.WriteLine("Guess Lower...");
            }
            else
            {
                Console.WriteLine("Guess Heigher...");
            }
            if (Math.Abs(guess - _hiddenNo) <= 5)
            {
                playerList[count].Score += 7;
            }
            else if (Math.Abs(guess - _hiddenNo) <= 10)
            {
                playerList[count].Score += 5;
            }
            else if (Math.Abs(guess - _hiddenNo) <= 15)
            {
                playerList[count].Score += 3;
            }
            else if (Math.Abs(guess - _hiddenNo) <= 20)
            {
                playerList[count].Score += 2;
            }
            else
            {
                playerList[count].Score += 1;
            }

            count = (count + 1) % playerList.Count;
            return true;
        }

        public static void DisplayPlayerInformations()
        {


            for (int i = 0; i < playerList.Count; i++)
            {
                Console.WriteLine(playerList[i]);
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
