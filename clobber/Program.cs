using System;
using System.Collections.Generic;

namespace clobber
{
    class Player
    {
        public int win;
        public string color;
        public string name;
        public Player(string name, int win, string color)
        {
            this.win = win;
            this.color = color;
            this.name = name;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] move = new int[4];
            int xstart = 0, ystart = 0, xfinish = 0, yfinish = 0;
            int motion = 0;//0-player1
                           //1-player2
            string name = "";
            int[,] firsttable =
            //{
            //    {2,0,2,0,2 },    //0-white
            //    {1,2,1,2,0 },    //1-black
            //    {2,0,2,0,2 },    //2-empty
            //    {0,2,0,0,0 },
            //    {2,0,2,0,2 },
            //    {0,0,1,0,0 }
            //};
            {
                { 0,1,0,1,0 },    //0-white
                { 1,0,1,0,1 },    //1-black
                { 0,1,0,1,0 },    //2-empty
                { 1,0,1,0,1 },
                { 0,1,0,1,0 },
                { 1,0,1,0,1 }
            };
            Print(firsttable);
            

            //Random rand = new();
            //int first = rand.Next(0, 1);
            //if (first == 0)
            //{ string color = "white"; }
            Console.WriteLine("Введите имя игрока");
            name = Console.ReadLine();
            Player player1 = new Player(name, 0, "white");
            Player player2 = new Player("bot", 0, "black");
            do
            {
                switch (motion)
                {
                    case 0: 



                        Console.WriteLine($"Делайте свой ход игрок: \n" + player1.name);
                        Console.WriteLine("Выберите начальную фишку");
                        xstart = Convert.ToInt16(Console.ReadLine());
                        ystart = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Теперь введите куда хотите поставить");
                        xfinish = Convert.ToInt16(Console.ReadLine());
                        yfinish = Convert.ToInt16(Console.ReadLine());


                        if (Canmove(xstart, ystart, xfinish, yfinish, firsttable, motion))
                        {
                            firsttable[xstart, ystart] = 2;
                            firsttable[xfinish, yfinish] = 0;
                            Print(firsttable);
                            motion = 1;

                        }
                        break;




                    case 1:
                        
                            Console.Clear();
                            move = computer_move(firsttable);
                            firsttable[move[0], move[1]] = 2;
                            firsttable[move[2], move[3]] = 1;
                            Print(firsttable);
                        motion = 0;
                        break;
                        
                }



            }
            
            while (!win(firsttable));
            if (motion == 0)
            {
                Console.WriteLine("Win:" + player2.name);
            }
            else
                Console.WriteLine("Win:" + player1.name);
        }









            //int[,] proverka =
            //{
            //    {0,0,0,0,0 },
            //    {0,0,0,0,0 },
            //    {0,0,0,0,0 },
            //    {0,0,0,0,0 },
            //    {0,0,0,0,0 },
            //    {0,0,0,0,0 }
            //};
            ////for (int i = 0; i < 6; i++)
            ////{
            ////    for (int j = 0; j < 5; j++)
            ////    {

            ////        if (i == 0 && j > 0 && j < 4 || j == 0 && i > 0 && i < 5 || i == 5 && j > 0 && j < 4 || j == 4 && i > 0 && i < 5)
            ////        {
            ////            proverka[i, j] = 2;

            ////        }



            ////    }
            ////}

            //for (int i = 0; i < 6; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {

            //        Console.Write(proverka[i, j] + " ");



            //    }
            //    Console.WriteLine();
            //}

        static int[] computer_move(int[,] table)
        {
            List<int[]> canmove = avaib_move(table);
            int xstart = 0, ystart=0, xfinish=0, yfinish=0;
            int[] move = new int[4];
            
            
            
            int count = canmove.Count;
            for(int i=0;i<count-1;i++)
            {

                
                
                    move = canmove[i];
                    xstart = move[0];
                    ystart = move[1];
                    xfinish = move[2];
                    yfinish = move[3];
                    //if (minimax(xstart, ystart, xfinish, yfinish, table))
                    //{
                    //    return move;
                    //    break;

                    //}
                
                
                
            }
            if (minimax(xstart, ystart, xfinish, yfinish, table))
                return move;
            return computer_move(table);
        }
        static List<int[]> avaib_move(int[,] table)
        {
            List<int[]> avaib = new List<int[]>();
            int[] move = new int[4];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] == 1)
                    {
                        if (i != 0 && j != 0 && i != 5 && j != 4)
                        {
                            if (table[i + 1, j] == 0)
                            {
                                move[0] = i;
                                move[1] = j;
                                move[2] = i + 1;
                                move[3] = j;


                                avaib.Add(move);

                            }
                            if (table[i - 1, j] == 0)
                            {
                                move[0] = i;
                                move[1] = j;
                                move[2] = i - 1;
                                move[3] = j;


                                avaib.Add(move);

                            }
                            if (table[i, j + 1] == 0)
                            {
                                move[0] = i;
                                move[1] = j;
                                move[2] = i;
                                move[3] = j + 1;


                                avaib.Add(move);

                            }
                            if (table[i, j - 1] == 0)
                            {
                                move[0] = i;
                                move[1] = j;
                                move[2] = i;
                                move[3] = j - 1;


                                avaib.Add(move);

                            }

                        }
                        if (i == 0 && j == 0)
                        {
                            if (table[i + 1, j] == 0)
                            {
                                move[0] = i;
                                move[1] = j;
                                move[2] = i + 1;
                                move[3] = j;


                                avaib.Add(move);

                            }
                            if (table[i, j + 1] == 0)
                            {
                                move[0] = i;
                                move[1] = j;
                                move[2] = i;
                                move[3] = j + 1;


                                avaib.Add(move);

                            }
                        }
                        if (i == 0 && j == 4)
                        {
                            if (table[i + 1, j] == 0)
                            {
                                move[0] = i;
                                move[1] = j;
                                move[2] = i + 1;
                                move[3] = j;


                                avaib.Add(move);

                            }
                            if (table[i, j - 1] == 0)
                            {
                                move[0] = i;
                                move[1] = j;
                                move[2] = i;
                                move[3] = j - 1;


                                avaib.Add(move);

                            }
                        }
                        if (i == 5 && j == 0)
                        {
                            if (table[i - 1, j] == 0)
                            {
                                move[0] = i;
                                move[1] = j;
                                move[2] = i - 1;
                                move[3] = j;


                                avaib.Add(move);

                            }
                            if (table[i, j + 1] == 0)
                            {
                                move[0] = i;
                                move[1] = j;
                                move[2] = i;
                                move[3] = j + 1;


                                avaib.Add(move);

                            }
                        }
                        if (i == 5 && j == 4)
                        {
                            if (table[i - 1, j] == 0)
                            {
                                move[0] = i;
                                move[1] = j;
                                move[2] = i - 1;
                                move[3] = j;


                                avaib.Add(move);

                            }
                            if (table[i, j - 1] == 0)
                            {
                                move[0] = i;
                                move[1] = j;
                                move[2] = i;
                                move[3] = j - 1;


                                avaib.Add(move);

                            }
                        }
                        if (i == 0 && j > 0 && j < 4 || j == 0 && i > 0 && i < 5 || i == 5 && j > 0 && j < 4 || j == 4 && i > 0 && i < 5)
                        {
                            if (i == 0)
                            {
                                if (table[i, j - 1] == 0 && table[i + 1, j] == 0 && table[i, j + 1] == 0)
                                {
                                    move[0] = i;
                                    move[1] = j;
                                    move[2] = i;
                                    move[3] = j - 1;
                                    avaib.Add(move);
                                    move[0] = i;
                                    move[1] = j;
                                    move[2] = i;
                                    move[3] = j + 1;
                                    avaib.Add(move);
                                    move[0] = i;
                                    move[1] = j;
                                    move[2] = i + 1;
                                    move[3] = j;
                                    avaib.Add(move);

                                }
                                if (i == 5)
                                {
                                    if (table[i, j - 1] == 0 && table[i - 1, j] == 0 && table[i, j + 1] == 0)
                                    {
                                        move[0] = i;
                                        move[1] = j;
                                        move[2] = i;
                                        move[3] = j - 1;
                                        avaib.Add(move);
                                        move[0] = i;
                                        move[1] = j;
                                        move[2] = i;
                                        move[3] = j + 1;
                                        avaib.Add(move);
                                        move[0] = i;
                                        move[1] = j;
                                        move[2] = i - 1;
                                        move[3] = j;
                                        avaib.Add(move);
                                    }



                                }
                                if (j == 0)
                                {
                                    if (table[i - 1, j] == 0 && table[i + 1, j] == 0 && table[i, j + 1] == 0)

                                    {
                                        move[0] = i;
                                        move[1] = j;
                                        move[2] = i;
                                        move[3] = j + 1;
                                        avaib.Add(move);
                                        move[0] = i;
                                        move[1] = j;
                                        move[2] = i + 1;
                                        move[3] = j;
                                        avaib.Add(move);
                                        move[0] = i;
                                        move[1] = j;
                                        move[2] = i - 1;
                                        move[3] = j;
                                        avaib.Add(move);
                                    }
                                }
                                if (j == 4)
                                {
                                    if (table[i - 1, j] == 0 && table[i + 1, j] == 2 && table[i, j - 1] == 0)

                                    {
                                        move[0] = i;
                                        move[1] = j;
                                        move[2] = i;
                                        move[3] = j - 1;
                                        avaib.Add(move);
                                        move[0] = i;
                                        move[1] = j;
                                        move[2] = i + 1;
                                        move[3] = j;
                                        avaib.Add(move);
                                        move[0] = i;
                                        move[1] = j;
                                        move[2] = i - 1;
                                        move[3] = j;
                                        avaib.Add(move);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return avaib;
        }
                                    
                                  
                                
                            
                                       
        static int[,] Copy(int[,] table)
        {
            int[,] copytable = new int[table.GetLength(0), table.GetLength(1)];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)

                {
                    copytable[i, j] = table[i, j];
                }
            }
                    return copytable;
        }
        static bool minimax(int xstart,int ystart,int xfinish,int yfinish,int [,] table)
        {
            int[,] copytable = Copy(table);
            int best_score = int.MaxValue;
            int score = 0;

            for (int i = 0; i < copytable.GetLength(0); i++)
            {
                for (int j = 0; j < copytable.GetLength(0); i++)
                {
                    if (copytable[xfinish, yfinish] == 0)
                    {

                        if (copytable[xstart, yfinish] != 3)
                            if (score > best_score)
                                best_score = score;

                        return true;

                    }
                }
            }
          
            

         

            
           
            return true;
        }
            static bool Canmove(int xstart, int ystart, int xfinish, int yfinish, int[,] table, int motion)
            {
                if (motion == 0)
                {
                if(xstart>xfinish+1||ystart>yfinish+1)
                {
                    Console.WriteLine("Нельзя туда ходить");
                    return false;
                }

                if(table[xstart,ystart]==2)
                {
                    Console.WriteLine("Вы не можете выбрать пустую фишку");
                    return false;
                }
                    if (xstart >= 6 || ystart >= 5 || xfinish >= 6 || yfinish >= 5)
                    {
                        Console.WriteLine("0<X<6, 0<Y<5");
                        return false;
                    }
                    if (table[xstart, ystart] == 1)
                    {
                        Console.WriteLine("Выберите белую фишку!");
                        return false;
                    }
                    if (table[xfinish, yfinish] == 2)
                    {
                        Console.WriteLine("Вы не можете ходить на пустую ячейку!");
                        return false;

                    }
                    if (table[xfinish, yfinish] == 0)
                    {
                        Console.WriteLine("Вы не можете ходить сами на себя!");
                        return false;

                    }
                }




                return true;
            }
            static bool win(int[,] table)
            {
                int win1 = 0;
                int win2 = 0;
                int win3 = 0;
                int win4 = 0;
                int win5 = 0;
                int win6 = 0;
                int win7 = 0;
                int win8 = 0;
                int win9 = 0;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {

                        if (table[i, j] != 2)
                        {
                            if (i != 0 && j != 0 && i != 5 && j != 4)
                            {
                                if (table[i + 1, j] == 2 || table[i + 1, j] == table[i, j] && table[i - 1, j] == 2 || table[i - 1, j] == table[i, j] && table[i, j - 1] == 2 || table[i, j - 1] == table[i, j] && table[i, j - 1] == 2 || table[i, j - 1] == table[i, j])
                                {
                                    win1 = 1;//+

                                }

                            }
                            if (i == 0 && j == 0)
                            {
                                if (table[i + 1, j] == 2 || table[i + 1, j] == table[i, j] && table[i, j + 1] == 2 || table[i, j + 1] == table[i, j])
                                    win2 = 1;//+
                            }
                            if (i == 5 && j == 0)
                            {
                                if (table[i - 1, j] == 2 || table[i - 1, j] == table[i, j] && table[i, j + 1] == 2 || table[i, j + 1] == table[i, j])
                                    win3 = 1;//+
                            }
                            if (i == 0 && j == 4)
                            {
                                if (table[i, j - 1] == 2 || table[i, j - 1] == table[i, j] && table[i + 1, j] == 2 || table[i + 1, j] == table[i, j])
                                    win4 = 1;//+
                            }
                            if (i == 5 && j == 4)
                            {
                                if (table[i - 1, j] == 2 || table[i - 1, j] == table[i, j] && table[i, j - 1] == 2 || table[i, j - 1] == table[i, j])
                                    win5 = 1;//+
                            }
                            if (i == 0 && j > 0 && j < 4 || j == 0 && i > 0 && i < 5 || i == 5 && j > 0 && j < 4 || j == 4 && i > 0 && i < 5)
                            {
                                if (i == 0)
                                {
                                    if (table[i, j - 1] == 2 || table[i, j - 1] == table[i, j] && table[i + 1, j] == 2 || table[i + 1, j] == table[i, j] && table[i, j + 1] == 2 || table[i, j + 1] == table[i, j])
                                        win6 = 1;//+
                                }
                                if (i == 5)
                                {
                                    if (table[i, j - 1] == 2 || table[i, j - 1] == table[i, j] && table[i - 1, j] == 2 || table[i - 1, j] == table[i, j] && table[i, j + 1] == 2 || table[i, j + 1] == table[i, j])
                                        win7 = 1;//+
                                }
                                if (j == 0)
                                {
                                    if (table[i - 1, j] == 2 || table[i - 1, j] == table[i, j] && table[i + 1, j] == 2 || table[i + 1, j] == table[i, j] && table[i, j + 1] == 2 || table[i, j + 1] == table[i, j])
                                        win8 = 1;
                                }
                                if (j == 4)
                                {
                                    if (table[i - 1, j] == 2 || table[i - 1, j] == table[i, j] && table[i + 1, j] == 2 || table[i + 1, j] == table[i, j] && table[i, j - 1] == 2 || table[i, j - 1] == table[i, j])
                                        win9 = 1;
                                }

                            }


                        }
                          if(i==0&&j==0)
                           {
                            if(table[i,j]==2)
                            {
                            win2 = 1;
                             }
                            }
                    if (i ==5 && j == 0)
                    {
                        if (table[i, j] == 2)
                        {
                            win3 = 1;
                        }
                    }
                    if (i == 0&& j == 4)
                    {
                        if (table[i, j] == 2)
                        {
                            win4 = 1;
                        }
                    }
                    if (i == 5 && j == 4)
                    {
                        if (table[i, j] == 2)
                        {
                            win5 = 1;
                        }
                    }


                }
                }
  

                if (win1 == 1 && win2 == 1 && win3 == 1 && win4 == 1 && win5 == 1 && win6 == 1 && win7 == 1 && win8 == 1 && win9 == 1)
                    return true;
                else
                    return false;
            }
        static void Print(int[,] firsttable)
        {

            for (int i = 0; i < firsttable.GetLength(0); i++)
            {
                for (int j = 0; j < firsttable.GetLength(1); j++)

                {


                    if (firsttable[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.White; // устанавливаем цвет
                        Console.Write("\t\t*");
                        Console.ResetColor();

                    }
                    else if (firsttable[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Black; // устанавливаем цвет
                        Console.Write("\t\t*");
                        Console.ResetColor();
                    }
                    else if (firsttable[i, j] == 2)
                    {
                        Console.Write("\t\t");
                    }
                }
                Console.WriteLine("\n\n");
            }
        }
        }
    }

