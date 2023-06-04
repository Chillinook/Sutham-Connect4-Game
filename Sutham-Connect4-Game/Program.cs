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
        public override string ToString()
        {
          return Name;
        }

    }
    public class TheColumn
    {
        List<char> chars;
        public TheColumn()
        {
            chars = new List<char>();    

        }

    }

    public class Tracker
    {



    }

   

        
    public class Connect4Game
    {
        //public string Name { get; set; }
        //public int Score { get; set; }
        //private static int _hiddenNo;
        //private static Random r;

        public static char[,] TheBoardArr =new char[,] { 
            { '#', '#', '#', '#', '#', '#', '#' }, { '#', '#', '#', '#', '#', '#', '#' },
            { '#', '#', '#', '#', '#', '#', '#' }, { '#', '#', '#', '#', '#', '#', '#' },
            { '#', '#', '#', '#', '#', '#', '#' }, { '#', '#', '#', '#', '#', '#', '#' }
            };

        public static List<TheColumn>[] TheBoardList; 
        private static List<Player> playerList;
        public static int turncount = 0;
        static Connect4Game()
        {
            playerList = new List<Player>();
            TheBoardList = new List<TheColumn>[7];
        }
      
        public static void AddAPlayer(string name)
        {
            var player = new Player(name);
            playerList.Add(player);
        }
     
        public bool Checker(char checkNum)
        {
            return true;


        }
        
        public static bool Play()
        {
            //Console.WriteLine(turncount);
            if (turncount == 10)
            {
                return false;
            }
            if (turncount % 2 == 0)
            {
                Console.WriteLine($"Player {playerList[1]} symbol X please enter row number: ");
                //Console.WriteLine(turncount);
                if(TheBoardArr[5, int.Parse(Console.ReadLine())] == '#')
                {
                    TheBoardArr[4, int.Parse(Console.ReadLine())] =  'X';

                }
                turncount++;
                DisplayBoard();
                return true;
            }
            else 
            {
                Console.WriteLine($"Player {playerList[0]} symbol O please enter row number: ");
                //Console.WriteLine(turncount);
                TheBoardArr[0, int.Parse(Console.ReadLine())] = 'O';
                turncount++;
                DisplayBoard();
                return true;
            }
            //return true;



            /*


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
            */
        }

        

        public static void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine("Sutham's Connect4Game");
            Console.WriteLine($" {playerList[0]} VS {playerList[1]}\n");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("|");

                for (int j=0; j< 7; j++)
                {
                    
                    Console.Write($" {TheBoardArr[i,j]} ");

                }
                Console.WriteLine("|");
            }
            Console.WriteLine("  1  2  3  4  5  6  7 \n");
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

            Connect4Game.DisplayBoard();

            while(Connect4Game.Play());



        }
    }
}

