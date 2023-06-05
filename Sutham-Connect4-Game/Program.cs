using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.X86;
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
            Name = name.Substring(0,1).ToUpper() + name.Substring(1,name.Length-1);
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

        private bool insertcheck()
        {
            if (chars.Count == 6)
                return true;
            else return false;
        }
        public void InsertX()
        {
            if(insertcheck())
                Console.WriteLine("This slot is full");
            else
            {
                chars.Add('X');
                //Console.WriteLine("X success");
            }
        }

        public void InsertO()
        {
            if (insertcheck())
                Console.WriteLine("This slot is full");
            else
            {
                chars.Add('O');
                //Console.WriteLine("O success");
            }

        }
        public void DisplayOne()
        {
            if (Checker() == 6)
            {
                
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine($" {chars[chars.Count - i - 1]} ");
                }
            }
            else if (Checker() == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine(" # ");
                }
            }
           
            else if(Checker() < 6 )
            {
                
                for (int i = 0 ; i < 6 - chars.Count; i++)
                {
                    Console.WriteLine(" # ");
                }
                for (int i = 0 ; i< chars.Count ; i++)
                {
                    Console.WriteLine($" {chars[chars.Count-i-1]} ");
                }
                
            }
           
        }

        public char DisplayRow(int position)
        {
            if (chars.Count == 6)
            {
                return chars[position];
            }
            else if (chars.Count == 0)
            {
                return '#';
            }                    
            else if (chars.Count < 6 )
            {
                if (position > chars.Count)
                {
                    return '#';
                }
                else if (position < chars.Count)
                {
                    return chars[position];
                }
                else return '#';
            }
            else return '#';           
        }

        public int Counter()
        {
            return chars.Count();
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
            //Console.WriteLine(TheBoardList[0].Counter());
            if (turncount==25)
            {
                //Console.WriteLine(TheBoardList);
                return false;
            }
            else if (turncount % 2 == 0)
            {
                DisplayBoard();
                Console.Write($"Player >> {playerList[1]} << symbol X please enter slot number(1-7): ");
                int _tempPos = int.Parse(Console.ReadLine());
                TheBoardList[_tempPos - 1].InsertX();
                turncount++;
                return true;
            }
            else 
            {
                DisplayBoard();
                Console.Write($"Player >> {playerList[0]} << symbol O please enter slot number(1-7): ");
                int _tempPos = int.Parse(Console.ReadLine());
                TheBoardList[_tempPos - 1].InsertO();
                turncount++;
                return true;              
            }            
        }        

        public static void DisplayBoard()
        {
            Console.Clear();
        
        /*    Console.WriteLine("Sutham's Connect4Game");
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
        */
            Console.WriteLine("Sutham's Connect4Game");
            Console.WriteLine($" {playerList[0]} VS {playerList[1]}\n");
      

            for (int i = 0; i < 6 ; i++)
            {
                Console.Write("|");

                for (int j = 0; j < 7; j++)
                {

                    Console.Write($" {TheBoardList[j].DisplayRow(6-i-1)} ");

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
            //Console.WriteLine("Welcome to Sutham's Connect4Game");
            Console.Write("Please enter player 2's name: ");
            name2 = Console.ReadLine();
            var PlayerTwo = new Player(name2);

            Connect4Game.AddAPlayer(name1);
            Connect4Game.AddAPlayer(name2);

            //Connect4Game.DisplayBoard();

            while(Connect4Game.Play());



        }
    }
}

