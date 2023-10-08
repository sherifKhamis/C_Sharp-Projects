using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] starting_board = { { '1', '2', '3' }, { '4', '5', '6', }, { '7', '8', '9' } };

            game(ref starting_board);
        }

        static void game (ref char[,] board)
        {
            string greeting_message = "Welcome to Tic Tac Toe in C#";
            Console.WriteLine(greeting_message);
            string boardBase = String.Format("\n\n------------\n {0} | {1} | {2}\n------------\n {3} | {4} | {5}\n------------\n {6} | {7} | {8}\n------------\n", board[0, 0], board[0, 1], board[0, 2], board[1, 0], board[1, 1], board[1, 2], board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine(boardBase);

            bool valid = false;
            char player_x = default;
            while (!valid)
            {
                Console.Write("\nPlayer X choose your field: ");
                player_x = Console.ReadKey().KeyChar;
                valid = validPlacement(player_x, board);
            } 
            
            fieldMarkerX(player_x,ref board);
            printBoard(board);

            Console.Write("Player O choose your field: ");
            char player_o = Console.ReadKey().KeyChar;
            fieldMarkerO(player_o, ref board);
            printBoard(board);

            game(ref board);

        }

        static void printBoard(char[,] board)
        {
            string printedBoard = String.Format("\n\n------------\n {0} | {1} | {2}\n------------\n {3} | {4} | {5}\n------------\n {6} | {7} | {8}\n------------\n", board[0, 0], board[0, 1], board[0, 2], board[1, 0], board[1, 1], board[1, 2], board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine(printedBoard);
        }

        static void fieldMarkerX(char number, ref char[,] board)
        {
            switch (number)
            {
                case '1':
                    board[0, 0] = 'X';
                    break;
                case '2':
                    board[0, 1] = 'X';
                    break;
                case '3':
                    board[0, 2] = 'X';
                    break;
                case '4':
                    board[1, 0] = 'X';
                    break;
                case '5':
                    board[1, 1] = 'X';
                    break;
                case '6':
                    board[1, 2] = 'X';
                    break;
                case '7':
                    board[2, 0] = 'X';
                    break;
                case '8':
                    board[2, 1] = 'X';
                    break;
                case '9':
                    board[2, 2] = 'X';
                    break;

            }
        }
        static void fieldMarkerO(char number, ref char[,] board)
        {
            switch (number)
            {
                case '1':
                    board[0, 0] = 'O';
                    break;
                case '2':
                    board[0, 1] = 'O';
                    break;
                case '3':
                    board[0, 2] = 'O';
                    break;
                case '4':
                    board[1, 0] = 'O';
                    break;
                case '5':
                    board[1, 1] = 'O';
                    break;
                case '6':
                    board[1, 2] = 'O';
                    break;
                case '7':
                    board[2, 0] = 'O';
                    break;
                case '8':
                    board[2, 1] = 'O';
                    break;
                case '9':
                    board[2, 2] = 'O';
                    break;

            }
        }

        static bool validPlacement(char number, char[,] board)
        {
            switch(number)
            {
                case '1':
                    return (board[0, 0] == '1' ? true : false);
                case '2':
                    return (board[0, 1] == '2' ? true : false);
                case '3':
                    return (board[0, 2] == '3' ? true : false);
                case '4':
                    return (board[1, 0] == '4' ? true : false);
                case '5':
                    return (board[1, 1] == '5' ? true : false);
                case '6':
                    return (board[1, 2] == '6' ? true : false);
                case '7':
                    return (board[2, 0] == '7' ? true : false);
                case '8':
                    return (board[2, 1] == '8' ? true : false);
                case '9':
                    return (board[2, 2] == '9' ? true : false);
                default:
                    Console.WriteLine("\nWrong Input, try again");
                    return false;


            }
        }
            
    }
}
