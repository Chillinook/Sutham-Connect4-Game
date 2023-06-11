using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.CompilerServices;
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
 
    public class InputTracker
    {
        public List<string> PlayerTracker;  
        public string Name { get; set; }
        public int TurnCounter { get; set; } = 0;

        //public int SlotIn { get; set; } 

        public InputTracker()
        {
            var PlayerTracker = new List<string>();
        }
        public void PlusCounter()
        {
            TurnCounter++;
            //Console.WriteLine(TurnCounter);
        }
        public int InputProof(string inkey)
        {
            int _keyinput;
            if ((int.TryParse(inkey, out _keyinput) && _keyinput >= 1 && _keyinput <= 7))
            {
                PlusCounter();
                return int.Parse(inkey);
            }
            else 
            {            
                while( !(int.TryParse(inkey, out _keyinput) && _keyinput >= 1 && _keyinput <= 7) )
                {
                    Console.Write("please enter only number(1 - 7): ");
                    //inkey = "";
                    inkey = Console.ReadLine();
                }
                PlusCounter();
                int _tempPos = int.Parse(inkey);
                return _tempPos;
            }      
          //   else //(int.Parse(inkey) == 1 || int.Parse(inkey) == 2 || int.Parse(inkey) == 3 || int.Parse(inkey) == 4 || int.Parse(inkey) == 5 || int.Parse(inkey) == 6 || int.Parse(inkey) == 7)
          //  {
          //      //int _tempPos = int.Parse(inkey);
          //      PlusCounter();
          //      return int.Parse(inkey);

           // }

        }
        public void RecordSuccessInput()
        {
            if (TurnCounter == 43)
            {


            }

        }

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
            }
        }
        public void InsertO()
        {
            if (insertcheck())
                Console.WriteLine("This slot is full");
            else
            {
                chars.Add('O');               
            }
        }

        /*
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
        */

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
        public static InputTracker GameTracker; 
        public static List<TheColumn> TheBoardList; 
        private static List<Player> playerList;
        public static int turncount = 1;
        static bool answer;
        static Connect4Game()
        {
            GameTracker = new InputTracker();
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
            Referee.RecieveBoard(TheBoardList);
            DisplayBoard();
            GameTracker.PlusCounter();
            if (Referee.ColumnCheck() || Referee.RowCheck() || Referee.DiagonalCheck() )
            {                
                return false;
            }
            else if (GameTracker.TurnCounter==43)
            {
                Console.WriteLine("It is a draw, and no one wins. ");
                return false;
            }
         
            if (turncount % 2 == 0)
            {
                
                Console.Write($"Player >>");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {playerList[1]} ");
                Console.ResetColor();
                Console.Write("<< symbol X please enter slot number(1-7): ");
                string _tempPos = (Console.ReadLine());
                //GameTracker.InputProof(_tempPos);
                TheBoardList[GameTracker.InputProof(_tempPos) - 1].InsertX();         
                turncount++;
                return true;
            }
            else 
            {               
                Console.Write($"Player >>");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($" {playerList[0]} ");
                Console.ResetColor();
                Console.Write("<< symbol O please enter slot number(1-7): ");

                int _tempPos = int.Parse(Console.ReadLine());
                
                TheBoardList[_tempPos - 1].InsertO();
                
             
                turncount++;
                return true;              
            }            
        }

        public static bool Play(bool end)
        {
            return false;
        }

            public static void DisplayBoard()
            {
           
            Console.Clear();       
            Console.WriteLine("Sutham's Connect4Game");
            Console.WriteLine($"    {playerList[0]} VS {playerList[1]}\n");
           
            for (int i = 0; i < 6 ; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 7; j++)
                {
                    if( TheBoardList[j].DisplayRow(6 - i - 1) == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($" {TheBoardList[j].DisplayRow(6-i-1)} ");
                        Console.ResetColor();
                    }
                    else if( TheBoardList[j].DisplayRow(6 - i - 1) == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($" {TheBoardList[j].DisplayRow(6 - i - 1)} ");
                        Console.ResetColor();
                    }else Console.Write($" {TheBoardList[j].DisplayRow(6 - i - 1)} ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("  1  2  3  4  5  6  7 \n");            
        }  
    } 

    public static class Referee
    {
        public static char[,] TheBoardArr = new char[,] {
            { '#', '#', '#', '#', '#', '#', '#' }, 
            { '#', '#', '#', '#', '#', '#', '#' },
            { '#', '#', '#', '#', '#', '#', '#' },
            { '#', '#', '#', '#', '#', '#', '#' },
            { '#', '#', '#', '#', '#', '#', '#' },
            { '#', '#', '#', '#', '#', '#', '#' }
            };
        public static void RecieveBoard(List<TheColumn> board)
        {
            for (int i = 0; i < 6; i++)
            {             
                for (int j = 0; j < 7; j++)
                {
                    TheBoardArr[i,j] = board[j].DisplayRow(6-i-1);
                }                
            }           
        }
        public static bool RowCheck()
        {
            int Ocounter;
            int Xcounter;                   
            for (int i = 0; i < 6; i++)
            {
                Ocounter = 0;
                Xcounter = 0;
                for (int j = 0; j < 7; j++)
                {
                    if (TheBoardArr[6 - i - 1, j] == 'O')
                    {
                        Ocounter++;
                        Xcounter=0;
                        if (Ocounter == 4)
                        {
                            Console.WriteLine("O Win Row");
                            return true;
                        }
                    }
                    else if (TheBoardArr[6 - i - 1, j] == 'X')
                    {
                        Xcounter++;
                        Ocounter = 0;
                        if (Xcounter == 4)
                        {
                            Console.WriteLine("X Win Row");
                            return true;
                        }
                    }
                    else if (TheBoardArr[6 - i - 1, j] == '#')
                    {
                        Ocounter = 0;
                        Xcounter = 0;
                    }      
                }            
            }           
            return false;
        }
        public static bool ColumnCheck()
        {
            int Ocounter;
            int Xcounter;
            for (int i = 0; i < 7; i++)
            {
                Ocounter = 0;
                Xcounter = 0;
                for (int j = 0; j < 6; j++)
                {
                    if (TheBoardArr[j,i ] == 'O')
                    {
                        Ocounter++;
                        Xcounter = 0;
                        if (Ocounter == 4)
                        {
                            Console.WriteLine("O Win Column");
                            return true;
                        }
                    }
                    else if (TheBoardArr[j,i] == 'X')
                    {
                        Xcounter++;
                        Ocounter= 0;
                        if (Xcounter == 4)
                        {
                            Console.WriteLine("X Win Column");
                            return true;
                        }
                    }
                    else if (TheBoardArr[j,i] == '#')
                    {
                        Ocounter = 0;
                        Xcounter = 0;
                    }
                }             
            }
            return false;
        }
        public static bool DiagonalCheck()
        {
            int Ocounter;
            int Xcounter;         

            for (int counter = 3; counter < 9; counter++)
            {
                Ocounter = 0;
                Xcounter = 0;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (i + j == counter)
                        {
                            if (TheBoardArr[6 - i - 1, j] == '#')
                            {
                                Ocounter = 0;
                                Xcounter = 0;
                            }
                            else if (TheBoardArr[6 - i - 1,j] == 'O')
                            {
                                Ocounter++;
                                Xcounter = 0;
                                if (Ocounter == 4)
                                {
                                    Console.WriteLine("OO Win Diagonal");
                                    return true;
                                }
                            }
                            else if (TheBoardArr[6 - i - 1,j] == 'X')
                            {
                                Xcounter++;
                                Ocounter = 0;
                                if (Xcounter == 4)
                                {
                                    Console.WriteLine("XX Win Diagonal");
                                    return true;
                                }
                            }
                            
                        }
                    }
                }
            }
            
            for (int counter = -3; counter < 3; counter++)
            {
                Ocounter = 0;
                Xcounter = 0;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (i - j == counter)
                        {
                            if (TheBoardArr[6-i-1, j] == '#')
                            {
                                Ocounter = 0;
                                Xcounter = 0;
                            }
                            else if (TheBoardArr[6 - i - 1, j] == 'O')
                            {
                                Ocounter++;
                                Xcounter = 0;
                                if (Ocounter == 4)
                                {
                                    Console.WriteLine("O Win Diagonal");
                                    return true;
                                }
                            }
                            else if (TheBoardArr[6 - i - 1, j] == 'X')
                            {
                                Xcounter++;
                                Ocounter = 0;
                                if (Xcounter == 4)
                                {
                                    Console.WriteLine("X Win Diagonal");
                                    return true;
                                }
                            }
                         
                        }
                    }
                }
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string name1,name2;
            //Console.ForegroundColor = ConsoleColor.;
            
            string[] str = new string[]
            {
                "                                               ",
                "   _________   _________  __        ________   ",
                "  /        /| /       /| / /|      /       /|  ",
                "  $$$$$$$$$/  $$$$$$$$/| $$ |      $$$$$$$$/   ",
                "  $$ | /   /| $$    $$ | $$ |      $$ |___     ",
                "  $$ | $$$$ | $$    $$ | $$ |      $$/   /|    ",
                "  $$ /   $$ | $$    $$ | $$ |_____ $$$$$$/     ",
                "  $$/    $$ | $$    $$ | $$/    /| $$ /        ",
                "  $$$$$$$$$/  $$$$$$$$/  $$$$$$$/  $$/         "
            };
            var index = 3;
            foreach (var item in str)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    Console.Write(item[i]);
                    Console.ForegroundColor = (ConsoleColor)index;
                    index++;
                    if (index == 15)
                        index = 3;
                    if (i == item.Length - 1)
                    {
                        Console.Write("\n");
                        continue;
                    }
                }
            }
            /*     Console.ForegroundColor = ConsoleColor.Green;
                 for (int i = 0; i < str.Length; i++)
                 {
                     for (int j = 0; j < str[i].Length; j++)
                     {
                         if (i >= 4 && i < 7 && j > 3 && j < 5)
                         {
                             Console.ForegroundColor = ConsoleColor.Blue;
                         }
                         Console.Write(str[i][j]);
                     }
                     Console.WriteLine();
                 }
              */
            Console.ResetColor();        
            Console.WriteLine("\n   Welcome to Sutham's Connect4Game");            
          
            Console.Write("   Please enter player 1's name: ");
            name1 = Console.ReadLine();
            var PlayerOne = new Player(name1);           
            Console.Write("   Please enter player 2's name: ");
            name2 = Console.ReadLine();
            var PlayerTwo = new Player(name2);
            Connect4Game.AddAPlayer(name1);
            Connect4Game.AddAPlayer(name2);
            Connect4Game.DisplayBoard();



  //          string input;
 //           while ( (input = Console.ReadLine() ) != "Y")
  //          {
  //              Connect4Game.Play();

  //          }

            while (Connect4Game.Play())
            { 
                   
            
            }
           
            //do
            //{
            //    Connect4Game.Play();
                
            //}              
            //while( Referee.ColumnCheck() || Referee.RowCheck() );

        }
    }
}

