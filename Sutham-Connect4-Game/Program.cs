using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
 
    public class Tracker
    {
        public string Name { get; set; }
        public int SlotIn { get; set; }

        public Tracker()
        {
            
        }

        private void Inputchecher()
        { 
        
        
        
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
        public static List<Tracker> GameTracker; 

        public static List<TheColumn> TheBoardList; 
        private static List<Player> playerList;
        public static int turncount = 1;
        static bool answer;
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
            Referee.RecieveBoard(TheBoardList);
            if (Referee.ColumnCheck() || Referee.RowCheck() || Referee.DiagonalCheck() )
            {                
                return false;
            }
            if (turncount % 2 == 0)
            {
                //DisplayBoard();
                Console.Write($"Player >> {playerList[1]} << symbol X please enter slot number(1-7): ");
                int _tempPos = int.Parse(Console.ReadLine());
                TheBoardList[_tempPos - 1].InsertX();
                DisplayBoard();
                turncount++;
                return true;
            }
            else 
            {
                //DisplayBoard();
                Console.Write($"Player >> {playerList[0]} << symbol O please enter slot number(1-7): ");
                int _tempPos = int.Parse(Console.ReadLine());
                TheBoardList[_tempPos - 1].InsertO();
                DisplayBoard();
                turncount++;
                return true;              
            }            
        }        

        public static void DisplayBoard()
        {
            Console.Clear();       
            Console.WriteLine("Sutham's Connect4Game");
            Console.WriteLine($" {playerList[0]} VS {playerList[1]}\n");
            //Referee.RecieveBoard(TheBoardList);
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
            //Referee.RecieveBoard(TheBoardList);
            //Referee.RowCheck();
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
                        if (Ocounter == 4)
                        {
                            Console.WriteLine("O Win Row");
                            return true;
                        }
                    }
                    else if (TheBoardArr[6 - i - 1, j] == 'X')
                    {
                        Xcounter++;
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

/*
                    else if (j< 6)
                    {
                        if (TheBoardArr[i,j] == 'O')
                        {
                            if (TheBoardArr[i, j - 1] == 'O' && TheBoardArr[i, j + 1] == 'O')
                                Ocounter++;// = 1;
                            else 
                                Ocounter=1;
                        }
                        else if (TheBoardArr[i,j] == 'X')
                        {
                            if (TheBoardArr[i, j - 1] == 'X' && TheBoardArr[i, j + 1] == 'X')
                                Xcounter++;// = 1;
                            else
                                Xcounter = 1;
                        }
                    }
                    else if ((j == 6))
                    {
                        if (TheBoardArr[i, j] == 'O')
                        {
                            if (TheBoardArr[i, j - 1]  == 'O')
                                Ocounter++;// = 1;
                            else
                                Ocounter = 1;
                        }
                        else if (TheBoardArr[i, j] == 'X')
                        {
                            if (TheBoardArr[i, j - 1] == 'X' )
                                Xcounter++;// = 1;
                            else
                                Xcounter = 1;
                        }
                    }
*/

               }
              //  if (Xcounter == 4 || Ocounter == 4)
              //  {
              //      if(Xcounter==4)Console.WriteLine("X Win Row");
              //      else if(Ocounter == 4) Console.WriteLine("O Win Row");
              //      return true;                    
               // }
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
                    if (j == 0)
                    {
                        if (TheBoardArr[j,i ] == 'O')
                        {
                            Ocounter++;
                        }
                        else if (TheBoardArr[j,i] == 'X')
                        {
                            Xcounter++;
                        }
                    }
                    else if (j > 0)
                    {
                        if (TheBoardArr[j, i] == 'O')
                        {
                            if (TheBoardArr[j-1,i] != 'O')
                                Ocounter = 1;
                            else Ocounter++;
                        }
                        else if (TheBoardArr[j, i] == 'X')
                        {
                            if (TheBoardArr[j-1, i] != 'X')
                                Xcounter = 1;
                            else Xcounter++;
                        }
                    }
                }
                if (Xcounter == 4 || Ocounter == 4)
                {
                    if (Xcounter == 4) Console.WriteLine("X Win Column");
                    else if (Ocounter == 4) Console.WriteLine("O Win Column");
                    return true;
                }
            }
            return false;
        }
        public static bool DiagonalCheck()
        {  
            int Ocounter = 0;
            int Xcounter = 0;
            for (int i = 0; i < 6 ; i++)
            {                
                for (int j = 0; j <  7; j++)
                {
                    if (i == j)
                    {                        
                        if (i == 0)
                        {                           
                            if (TheBoardArr[6-i-1, j] == 'O')
                            {
                                Ocounter++;                               
                            }
                            else if (TheBoardArr[6 - i - 1, j] == 'X')
                            {
                                Xcounter++;                               
                            }
                        }
                        else if (i > 0)
                        {                            
                            if (TheBoardArr[6 - i - 1, j] == 'O')
                            {
                                if (TheBoardArr[6 - i - 1 , j - 1] != 'O')
                                    Ocounter = 1;
                                else Ocounter++;
                            }
                            else if (TheBoardArr[6 - i - 1, j] == 'X')
                            {
                                if (TheBoardArr[6 - i - 1 , j - 1] != 'X')
                                    Xcounter = 1;
                                else Xcounter++;
                            }
                        }
                    }






                }
                if (Xcounter == 4 || Ocounter == 4)
                {
                    if (Xcounter == 4) Console.WriteLine("X Win Diagonal");
                    else if (Ocounter == 4) Console.WriteLine("O Win Diagonal");
                    return true;
                }
            }          
            Ocounter = 0;
            Xcounter = 0;

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
            while (Connect4Game.Play()); 
           
            //do
            //{
            //    Connect4Game.Play();
                
            //}              
            //while( Referee.ColumnCheck() || Referee.RowCheck() );

        }
    }
}

