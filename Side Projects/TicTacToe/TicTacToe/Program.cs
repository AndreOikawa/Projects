using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        class Board
        {
            char[,] board = new char[3, 3];
            int boardLength = 3;
            bool xTurn = false;
            public Board()
            {
                for (int x = 0; x < boardLength; x++)
                {
                    for (int y = 0; y < boardLength; y++)
                    {
                        board[x, y] = '.';
                    }
                }
            }
            private void PrintBoard()
            {
                for (int y = 0; y < boardLength; y++)
                {
                    for (int x = 0; x < boardLength; x++)
                    {
                        Console.Write(board[x, y]);
                        if (x != boardLength - 1)
                        {
                            Console.Write("|");
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
                    if (y != boardLength - 1) Console.WriteLine("-+-+-");
                }
            }
            public void PlayerMove()
            {
                while (!IsGameOver())
                {
                    xTurn = !xTurn;
                    Console.WriteLine("Player {0}'s turn", (xTurn) ? "x" : "o");
                    PrintBoard();
                    bool validInput = false;
                    while (!validInput)
                    {
                        string input = Console.ReadLine();
                        if (!Regex.Match(input, @"^[0-2],[0-2]$").Success) Console.WriteLine("Format issue, try again: #,# [0-2]");
                        else
                        {
                            var x = Convert.ToInt32((input.Split(new char[] { ',' }))[0]);
                            var y = Convert.ToInt32((input.Split(new char[] { ',' }))[1]);
                            if (board[x,y] == '.')
                            {
                                validInput = true;
                                board[x, y] = (xTurn) ? 'x' : 'o';
                            } else
                            {
                                Console.WriteLine("Space already occupied");
                            }
                        }
                    }


                }
                PrintBoard();
                Console.WriteLine("Player {0} wins!", (xTurn) ? "x" : "o");
                Console.ReadKey();
            }
            private bool IsGameOver()
            {
                if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[1,1] != '.') return true;
                else if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[1, 1] != '.') return true;
                for (int x = 0; x < boardLength; x++)
                {
                    if (board[x, 0] == board[x, 1] && board[x, 1] == board[x, 2] && board[x, 1] != '.') return true;
                    else if (board[0, x] == board[1, x] && board[1, x] == board[2, x] && board[1, x] != '.') return true;

                }
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Move format: #,#");
            Console.WriteLine("# 0-2 inclusive, 0,0 top left, 2,2 bottom right");
            Board field = new Board();
            field.PlayerMove();
            //Console.ReadKey();
        }

    }
}
