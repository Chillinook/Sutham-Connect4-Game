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
    public abstract class Player             //Abstract superclass player
    {
        protected string Name {  get; set; }        
      
        public Player(string name)
        {
            Name = name;
        }

        public abstract void TobigName();               //Abstract method in abstract class

        public override string ToString()
        {
            if (Name != null) 
               return "Players";
            return Name; 
        }
    }
    public class Human : Player        
    {
        //public string Name { get; set; }
        //  public Player()//(string name)
        //   {
        //      Name = name.Substring(0,1).ToUpper() + name.Substring(1,name.Length-1);
        //  }
        public Human(string name) : base(name)          // call and use constuctor from superclass
        {           
            
        }

        public override void TobigName()                // polymorpishm override abstract method on superclass
        {
            //if (Name != null)
                Name = "Human: " + Name.Substring(0, 1).ToUpper() + Name.Substring(1, Name.Length - 1);
            //else
                //Name = "Players";
                //Name = Name.Substring(0, 1).ToUpper() + Name.Substring(1, Name.Length - 1);
        }

        public override string ToString()
        {
          return Name;
        }
        
    }

    public class Ai : Player
    {
        public Ai(string name) : base (name)
        {
            //Name = "AI: " + name;
        }
        public override void TobigName()            // polymorpishm override abstract method on superclass
        {
            Name = "AI: " + Name.Substring(0, 1).ToUpper() + Name.Substring(1, Name.Length - 1);
        }
        public override string ToString()
        {
            return Name;
        }

    }

    public class InputTracker
    {
       // public List<string> PlayerTracker;  
       // public string Name { get; set; }
        private int GameCounter { get; set; } = 0;             // Private field for counter 
       
    //    public InputTracker()
    //    {
            // PlayerTracker = new List<string>();
     //   }
        public void PlusCounter()                               //Method for access private field
        {
            GameCounter++;            
        }

        public int ShowGameCounter()                            //Method for access private field
        {
            return GameCounter;
        }
        public int InputProof(string inkey)
        {
            int _keyinput=0;
            do
            {
                if ((int.TryParse(inkey, out _keyinput) && _keyinput >= 1 && _keyinput <= 7))
                {
                   return int.Parse(inkey);
                }
                Console.Write("Please enter only number(1 - 7): ");
                inkey = Console.ReadLine();
            } while ( true );  
        }
     //   public void RecordSuccessInput()
     //   {
      //     PlayerTracker.Add(Name);

      //  }

    }

 
    public class TheColumn
    {
        List<char> chars;
        public TheColumn()
        {
            chars = new List<char>();
        }
        public bool Insertcheck()
        {
            if (chars.Count >= 0 && chars.Count < 6)
                return false;
            else
            {
                Console.Write("This slot is full. Please try select another slot: ");
                return true;
            }
                
        }
        public void InsertX()
        {           
                chars.Add('X');           
        }
        public void InsertO()
        {        
                chars.Add('O');             
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
  
        public override string ToString()
        {          
            return chars.ToString();
        }

    }
    public class Connect4Game
    {
        public  InputTracker GameTracker; 
        private List<TheColumn> TheBoardList; 
        private List<Player> playerList;
        public int Turncount { get; set; } = 0;
        //static bool answer;
        public Connect4Game()
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

      //  public void AddAPlayer(string name)
      //  {
      //      //var player = new Player(name);
      //      playerList.Add(player);
      //      
      //  }

        public void AddAPlayer(Player playerOBJ)
        {
            //var player = new Player(name);
            //name.Name = name.Name.Substring(0, 1).ToUpper() + name.Name.Substring(1, name.Name.Length - 1);  //add abstract
            playerOBJ.TobigName();
            playerList.Add(playerOBJ);

        }

        public bool Play()
        {
            Referee.RecieveBoard(TheBoardList);
            DisplayBoard();
            int _goodinput;
            //int _keyinput;
            Turncount++;
            if (Referee.ColumnCheck() || Referee.RowCheck() || Referee.DiagonalCheck() )
            {                
                if(Turncount % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($" {playerList[0]}: O ");
                    Console.ResetColor();
                    Console.WriteLine($" Win the Game !!!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  ÛÛÛÛÛ ÛÛÛÛÛ                        ÛÛÛÛÛ   ÛÛÛ   ÛÛÛÛÛ                     ÛÛÛ ÛÛÛ     ");
                    Console.WriteLine(" °°ÛÛÛ °°ÛÛÛ                        °°ÛÛÛ   °ÛÛÛ  °°ÛÛÛ                     °ÛÛÛ°ÛÛÛ     ");
                    Console.WriteLine("  °°ÛÛÛ ÛÛÛ    ÛÛÛÛÛÛ  ÛÛÛÛÛ ÛÛÛÛ    °ÛÛÛ   °ÛÛÛ   °ÛÛÛ   ÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛ  °ÛÛÛ°ÛÛÛ     ");
                    Console.WriteLine("   °°ÛÛÛÛÛ    ÛÛÛ°°ÛÛÛ°°ÛÛÛ °ÛÛÛ     °ÛÛÛ   °ÛÛÛ   °ÛÛÛ  ÛÛÛ°°ÛÛÛ°°ÛÛÛ°°ÛÛÛ °ÛÛÛ°ÛÛÛ     ");
                    Console.WriteLine("    °°ÛÛÛ    °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ     °°ÛÛÛ  ÛÛÛÛÛ  ÛÛÛ  °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ°ÛÛÛ     ");
                    Console.WriteLine("     °ÛÛÛ    °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ      °°°ÛÛÛÛÛ°ÛÛÛÛÛ°   °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ °°° °°°      ");
                    Console.WriteLine("     ÛÛÛÛÛ   °°ÛÛÛÛÛÛ  °°ÛÛÛÛÛÛÛÛ       °°ÛÛÛ °°ÛÛÛ     °°ÛÛÛÛÛÛ  ÛÛÛÛ ÛÛÛÛÛ ÛÛÛ ÛÛÛ     ");
                    Console.WriteLine("     °°°°°     °°°°°°    °°°°°°°°         °°°   °°°       °°°°°°  °°°° °°°°° °°° °°°     ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($" {playerList[1]}: X ");
                    Console.ResetColor();
                    Console.WriteLine($" Win the Game !!!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  ÛÛÛÛÛ ÛÛÛÛÛ                        ÛÛÛÛÛ   ÛÛÛ   ÛÛÛÛÛ                     ÛÛÛ ÛÛÛ     ");
                    Console.WriteLine(" °°ÛÛÛ °°ÛÛÛ                        °°ÛÛÛ   °ÛÛÛ  °°ÛÛÛ                     °ÛÛÛ°ÛÛÛ     ");
                    Console.WriteLine("  °°ÛÛÛ ÛÛÛ    ÛÛÛÛÛÛ  ÛÛÛÛÛ ÛÛÛÛ    °ÛÛÛ   °ÛÛÛ   °ÛÛÛ   ÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛ  °ÛÛÛ°ÛÛÛ     ");
                    Console.WriteLine("   °°ÛÛÛÛÛ    ÛÛÛ°°ÛÛÛ°°ÛÛÛ °ÛÛÛ     °ÛÛÛ   °ÛÛÛ   °ÛÛÛ  ÛÛÛ°°ÛÛÛ°°ÛÛÛ°°ÛÛÛ °ÛÛÛ°ÛÛÛ     ");
                    Console.WriteLine("    °°ÛÛÛ    °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ     °°ÛÛÛ  ÛÛÛÛÛ  ÛÛÛ  °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ°ÛÛÛ     ");
                    Console.WriteLine("     °ÛÛÛ    °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ      °°°ÛÛÛÛÛ°ÛÛÛÛÛ°   °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ °°° °°°      ");
                    Console.WriteLine("     ÛÛÛÛÛ   °°ÛÛÛÛÛÛ  °°ÛÛÛÛÛÛÛÛ       °°ÛÛÛ °°ÛÛÛ     °°ÛÛÛÛÛÛ  ÛÛÛÛ ÛÛÛÛÛ ÛÛÛ ÛÛÛ     ");
                    Console.WriteLine("     °°°°°     °°°°°°    °°°°°°°°         °°°   °°°       °°°°°°  °°°° °°°°° °°° °°°     ");
                    Console.ResetColor();
                }
                return false;
            }
            else if (GameTracker.ShowGameCounter() == 42) 
            //else if (GameTracker.GameCounter==42)
            {
                Console.WriteLine("It is a draw, and no one wins. ");
                return false;
            }
         
            if (Turncount % 2 == 0)
            {               
                Console.Write($"Player >>");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {playerList[1]}: X ");
                Console.ResetColor();
                Console.Write("<< please enter slot number(1-7): ");          
                do
                    _goodinput = GameTracker.InputProof(Console.ReadLine()) - 1;
                while (TheBoardList[_goodinput].Insertcheck());
                TheBoardList[_goodinput].InsertX();  
                //Turncount++;
                GameTracker.PlusCounter();
                return true;
            }
            else 
            {               
                Console.Write($"Player >>");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($" {playerList[0]}: O ");
                Console.ResetColor();
                Console.Write("<< please enter slot number(1-7): ");
                do
                    _goodinput = GameTracker.InputProof(Console.ReadLine()) - 1;
                while (TheBoardList[_goodinput].Insertcheck());
                TheBoardList[_goodinput].InsertO();             
                //Turncount++;
                GameTracker.PlusCounter();
                return true;              
            }            
        }

       // public bool Play(bool end)
       // {
       //     return false;
       // }
        public void DisplayBoard()
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

    public static class Referee     //Static class referee judge winner from common board 
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
                            //Console.WriteLine("O Win Row");
                            return true;
                        }
                    }
                    else if (TheBoardArr[6 - i - 1, j] == 'X')
                    {
                        Xcounter++;
                        Ocounter = 0;
                        if (Xcounter == 4)
                        {
                            //Console.WriteLine("X Win Row");
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
                           // Console.WriteLine("O Win Column");
                            return true;
                        }
                    }
                    else if (TheBoardArr[j,i] == 'X')
                    {
                        Xcounter++;
                        Ocounter= 0;
                        if (Xcounter == 4)
                        {
                            //Console.WriteLine("X Win Column");
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
                                    //Console.WriteLine("OO Win Diagonal");
                                    return true;
                                }
                            }
                            else if (TheBoardArr[6 - i - 1,j] == 'X')
                            {
                                Xcounter++;
                                Ocounter = 0;
                                if (Xcounter == 4)
                                {
                                    //Console.WriteLine("XX Win Diagonal");
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
                                    //Console.WriteLine("O Win Diagonal");
                                    return true;
                                }
                            }
                            else if (TheBoardArr[6 - i - 1, j] == 'X')
                            {
                                Xcounter++;
                                Ocounter = 0;
                                if (Xcounter == 4)
                                {
                                    //Console.WriteLine("X Win Diagonal");
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
            var GolfConnect4 = new Connect4Game();

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
            Player PlayerOne = new Human(name1);


            //var PlayerOne = new Player(name1);        
            //Player PlayerOne = new Human
            // { 

            //    Name = name1,
            // };


            Console.Write("   Please enter player 2's name: ");
            name2 = Console.ReadLine();
            Player PlayerTwo = new Human(name2);
         //   Player PlayerTwo = new Human
        //    {
         //       Name = name2,
         //   };

                     
            //var GolfConnect4 = new Connect4Game();

            //GolfConnect4.AddAPlayer(name1);
            //GolfConnect4.AddAPlayer(name2);

            GolfConnect4.AddAPlayer(PlayerOne);
            GolfConnect4.AddAPlayer(PlayerTwo);
            GolfConnect4.DisplayBoard();

           // string reset = null;
            while ( GolfConnect4.Play())// || reset.ToUpper() == "Y")
            {
                //Console.Write("Restart? Yes(Y) or No(N): ");
                //reset = Console.ReadLine();
            }
           
            //do
            //{
            //    Connect4Game.Play();
                
            //}              
            //while( Referee.ColumnCheck() || Referee.RowCheck() );

        }
    }
}

