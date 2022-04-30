using System;
using System.Collections.Generic;

namespace Cse210Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            static List<string> CreateBoard()
            {
                List<string> squares = new List<string>();
                squares.Add("1");
                squares.Add("2");
                squares.Add("3");
                squares.Add("4");
                squares.Add("5");
                squares.Add("6");
                squares.Add("7");
                squares.Add("8");
                squares.Add("9");
                return squares;
            }
            static List<string> TakeTurn(string player, List<string> squares)
            {
                Console.Write($"{player}'s turn to choose a square (1-9): ");
                string userChoiceStr = Console.ReadLine();
                int userChoiceInt = int.Parse(userChoiceStr);
                squares[userChoiceInt - 1] = player;
                return squares;
            }
            static void PrintBoard(List<string> squares)
            {
                Console.WriteLine($"  {squares[0]}  |  {squares[1]}  |  {squares[2]}");
                Console.WriteLine("-----+-----+-----");
                Console.WriteLine($"  {squares[3]}  |  {squares[4]}  |  {squares[5]}");
                Console.WriteLine("-----+-----+-----");
                Console.WriteLine($"  {squares[6]}  |  {squares[7]}  |  {squares[8]}");
            }
            static List<string> CheckWin(string lastTurn, List<string> squares)
            {
                List<string> winStatus = new List<string>();
                if ((squares[0] == squares[1] && squares[0] == squares[2]) ||
                (squares[3] == squares[4] && squares[3] == squares[5]) ||
                (squares[6] == squares[7] && squares[6] == squares[8]) ||
                (squares[0] == squares[3] && squares[0] == squares[6]) ||
                (squares[1] == squares[4] && squares[1] == squares[7]) ||
                (squares[2] == squares[5] && squares[2] == squares[8]) ||
                (squares[0] == squares[4] && squares[0] == squares[8]) ||
                (squares[2] == squares[4] && squares[2] == squares[6]))
                {
                    winStatus.Add("true");
                    winStatus.Add(lastTurn);
                    return winStatus;
                }
                else
                {
                    winStatus.Add("false");
                    return winStatus;
                }
            }


            string x = "x";
            string o = "o";
            int turn = 0;
            string lastTurn = "o";
            List<string> squares = CreateBoard();
            while (turn < 9)
            {
                PrintBoard(squares);
                if (lastTurn == "o")
                {
                    squares = TakeTurn(x, squares);
                    lastTurn = "x";
                }
                else if (lastTurn == "x")
                {
                    squares = TakeTurn(o, squares);
                    lastTurn = "o";
                }

                if (turn < 4) {
                    List<string> winStatus = CheckWin(lastTurn, squares);
                    bool win = Boolean.Parse(winStatus[0]);
                    if (win) {
                        string winner = lastTurn;
                        Console.WriteLine($"{lastTurn} wins! Three in a row! ");
                        break;
                    } else if (turn == 8 && !win) {
                        Console.WriteLine("Tie! No one wins. ");
                        break;
                    }
                }
                    turn++;
            }


        }
    }
}