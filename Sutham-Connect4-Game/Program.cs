using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

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
 

    public class Tracker
    {



    }
    public class TheColumn
    {
        List<char> chars;
        public TheColumn()
        {
            chars = new List<char>();
        }

        public void InsertX()
        {
            chars.Add( 'X' );
        }

        public void InsertO()
        {
            chars.Add('O');
        }
        public void DisplayOne()
        {
            if (Checker() == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine('#');
                }
            }
            else if (Checker() == 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    //Console.WriteLine(chars[i]);
                    Console.WriteLine(chars[chars.Count - i - 1]);
                }
            }
            else if(Checker() < 6 )
            {
                //int freeSlot = 6 - chars.Count;
                for (int i = 0; i < 6 - chars.Count; i++)
                {
                    Console.WriteLine('#');
                }
                for (int i=0; i< chars.Count ;i++)
                {
                    Console.WriteLine(chars[chars.Count-i-1]);
                }
                
            }
           
        }
        public int Checker()
        {
            if (chars.Count == 6)
            {
                return 6;
            }
            else { return chars.Count; }

        }

        public override string ToString()
        {          
            return chars.ToString();
        }

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

        public static List<TheColumn> TheBoardList; 
        private static List<Player> playerList;
        public static int turncount = 0;
        static Connect4Game()
        {
            playerList = new List<Player>();
            TheBoardList = new List<TheColumn>();
            TheBoardList.Add(new TheColumn());
            TheBoardList.Add(new TheColumn());
            TheBoardList.Add(new TheColumn());
            TheBoardList.Add(new TheColumn());
            TheBoardList.Add(new TheColumn());
            TheBoardList.Add(new TheColumn());
            TheBoardList.Add(new TheColumn());

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
            if (turncount == 12)
            {
                return false;
            }
            if (turncount % 2 == 0)
            {
                Console.WriteLine($"Player {playerList[1]} symbol X please enter column number(1-7): ");
                int _tempPos = int.Parse(Console.ReadLine());
                for (int i = 5; i > 0;i-- )
                {
                    //int _tempPos = int.Parse(Console.ReadLine());
                    if (TheBoardArr[i, _tempPos-1] == '#')
                    {
                        TheBoardArr[i, _tempPos-1] =  'X';
                        turncount++;
                        DisplayBoard();
                        return true;
                    }
                    else if(TheBoardArr[i, _tempPos-1] == 'X')
                    {
                        TheBoardArr[i-1, _tempPos-1] = 'X';
                        turncount++;
                        DisplayBoard();
                        return true;
                       
                    }                
                }
                //turncount++;
                //DisplayBoard();
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

            Console.WriteLine("Sutham's Connect4Game");
            Console.WriteLine($" {playerList[0]} VS {playerList[1]}\n");

            
            TheBoardList[6].InsertX();
            //TheBoardList[6].InsertO();
            //char test =
            TheBoardList[6].DisplayOne();
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

