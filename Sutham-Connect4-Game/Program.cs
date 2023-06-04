using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Sutham_Connect4_Game
{
    public class Player
    {
        public string Name { get; set; }
        public Player(string name)
        {
            Name = name;
        }
    }


    
    public class Connect4Game
    {
        //public string Name { get; set; }
        //public int Score { get; set; }
        //private static int _hiddenNo;
        //private static Random r;


        private static List<Player> playerList;
        private static int turncount = 1;
        static Connect4Game()
        {
            playerList = new List<Player>();
            //r = new Random();
            //_hiddenNo = r.Next(0, 100);
        }
      
        public static void AddAPlayer(string name)
        {
            var player = new Player(name);
            playerList.Add(player);
        }
     
        /*
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

        */

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
            string name1,name2;
            Console.WriteLine("Welcome to Sutham's Connect4Game");
            Console.Write("Please enter player 1's name: ");
            name1 = Console.ReadLine();
            var PlayerOne = new Player(name1);
            Console.WriteLine("Welcome to Sutham's Connect4Game");
            Console.Write("Please enter player 2's name: ");
            name2 = Console.ReadLine();
            var PlayerTwo = new Player(name2);

            Connect4Game.AddAPlayer(name1);
            Connect4Game.AddAPlayer(name2);



        }
    }
}

