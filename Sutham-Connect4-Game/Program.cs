﻿using System;
using System.Collections.Generic;
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
            
            if (Referee.ColumnCheck() || Referee.RowCheck() )
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
            Referee.RecieveBoard(TheBoardList);
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
                    if (j == 0)
                    {                        
                        if (TheBoardArr[i, j] == 'O')
                        {
                            Ocounter++;
                        }
                        else if (TheBoardArr[i, j] == 'X')
                        {
                            Xcounter++;
                        }
                    }
                    else if (j > 0 )
                    {
                        if (TheBoardArr[i,j] == 'O')
                        {
                            if (TheBoardArr[i,j-1] == 'X')
                                Ocounter = 1;
                            else Ocounter++;
                        }
                        else if (TheBoardArr[i, j] == 'X')
                        {
                            if(TheBoardArr[i, j-1] == 'O')
                                Xcounter = 1;
                            else Xcounter++;
                        }
                    }
                }
                if (Xcounter == 4 || Ocounter == 4)
                {
                    if(Xcounter==4)Console.WriteLine("X Win Row");
                    else if(Ocounter == 4) Console.WriteLine("O Win Row");
                    return true;                    
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
                            if (TheBoardArr[j-1,i] == 'X')
                                Ocounter = 1;
                            else Ocounter++;
                        }
                        else if (TheBoardArr[j-1, i] == 'X')
                        {
                            if (TheBoardArr[j-1, i] == 'O')
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
            Console.Write("Please enter player 2's name: ");
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

