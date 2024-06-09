using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    public static class XO
    {
        static char[,] field2D = new char[3, 3] {
            { '*','*','*' },
            { '*','*','*' },
            { '*','*','*' } };


        private static void ShowField()
        {
            //Console.WriteLine("┬───┬───┬───┬");
            Console.WriteLine($"    1   2   3");
            for (int i = 0; i < field2D.GetLength(0); i++)
            {
                if (i != 0) { Console.WriteLine("  ├───┼───┼───┤"); }
                else { Console.WriteLine("  ┌───┬───┬───┐"); }
                for (int j = 0; j < field2D.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Console.Write($"{i+1} │"); 
                    }
                    Console.Write(" " + field2D[i, j] + " ");
                    Console.Write('│');
                }
                {
                    Console.WriteLine();
                    //Console.WriteLine("├───┼───┼───┤");
                }
            }
            Console.WriteLine("  └───┴───┴───┘");
        }

        public static void Play()
        {
            while (true)
            {
                ShowField();
                PlayerTurn();
                if(WinVerification())
                {
                    ShowField();
                    Console.WriteLine($" Player won ! ");
                    break;
                }
                PCTurn();
                if (WinVerification())
                {
                    ShowField();
                    Console.WriteLine($" PC won ! ");
                    break;
                }
                // TODO:  draw()
            }
        }

        private static void PlayerTurn()
        {
            int row, col;
            while (true)
            {
                Console.WriteLine($"Choose a square (row,col): ");
                row = int.Parse(Console.ReadLine()) - 1;
                col = int.Parse(Console.ReadLine()) - 1;

                if (row >= 0 && col >= 0 && row < 3 && col < 3 && field2D[row, col] == '*')
                {
                    field2D[row, col] = 'X';
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid Player turn, try again.");   //TODO: throw  ?
                }
            }
        }

        private static void PCTurn()   // 1 ДОБАВИТЬ ЛОГИКУ для PC!  // 2 блокировка хода для победы
        {
            int row, col;
            Random random = new Random();
            while (true)
            {
                row = (random.Next(0,3));
                col = (random.Next(0,3));
                if(row >= 0 && col >= 0 && row < 3 && col < 3 && field2D[row, col] == '*')
                {
                    field2D[row, col] = 'O';
                    break;
                }
            }
        }

        private static bool WinVerification()
        {
            // row ?
            for(int i = 0; i < field2D.GetLength(0); i++)
            {
                if (field2D[i, 0] != '*' && field2D[i, 0] == field2D[i, 1] && field2D[i, 0] == field2D[i, 2] )
                {
                    return true;
                }
            }
            // cols
            for (int i = 0; i < field2D.GetLength(0); i++)
            {
                if (field2D[0, i] != '*' && field2D[0, i] == field2D[1, i] && field2D[0, i] == field2D[2, i])
                {
                    return true;
                }
            }
            if ((field2D[0,0]!= '*' && field2D[0,0] == field2D[1,1] && field2D[0,0] == field2D[2,2]) || ( field2D[0,2] !='*' && field2D[0,2]== field2D[1,1] && field2D[0,2]== field2D[2,0]))
            {
                return true;
            }
            return false;
        }
    }
}
