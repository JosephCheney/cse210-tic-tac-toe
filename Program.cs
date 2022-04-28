// See https://aka.ms/new-console-template for more information
using System;

namespace tic_tac_toe
{
    class Program
    {
        static void Main(string[] args)
        {
            /* While the program still has empty spaces (zeros)
            * keep it running and calling turn, once the board has a winner, but if the board is full with no winners, return no winner.
            */
            Console.WriteLine("This is a game of Tic Tac Toe. Player 1 goes first");
            //This would normally be a set up class
            Console.WriteLine("Enter Player 1 then player 2");
            Console.Write("Player1: ");
            string player1 = Console.ReadLine();
            Console.Write("Player2: ");
            string player2 = Console.ReadLine();

            List<string> currPlayerlist = new List<string>();
            currPlayerlist.Add("X");
            currPlayerlist.Add("O");
            currPlayerlist.Add("X");
            currPlayerlist.Add("O");
            currPlayerlist.Add("X");
            currPlayerlist.Add("O");
            currPlayerlist.Add("X");
            currPlayerlist.Add("O");
            currPlayerlist.Add("X");
            currPlayerlist.Add("O");

            Console.WriteLine("This is the board, choose the Number on the board where you want to play. ");
            //This would normally be an object
            List<string> board1 = new List<string>();
            List<string> board2 = new List<string>();
            List<string> board3 = new List<string>();

            board1.Add("1");
            board1.Add("2");
            board1.Add("3");
            board2.Add("4");
            board2.Add("5");
            board2.Add("6");
            board3.Add("7");
            board3.Add("8");
            board3.Add("9");

            Display(board1, board2, board3);
            //While no winner, keep running turns
            //Turns then print the board.
            var it = 0;
            bool winner = false;
            string currPlayer = currPlayerlist[it];
            string currPlayerName= "";

            /* GAME LOOP */
            while (winner == false)
            {
                if (currPlayer == "X")
                {
                    currPlayerName = player1;
                }
                else if (currPlayer == "O")
                {
                    currPlayerName = player2;
                }
                Console.WriteLine($"It's {currPlayerName}'s turn!");
                Console.WriteLine("Please Choose a spot");
                Turn(board1, board2, board3, currPlayer);
                

                int win = CheckWin(board1, board2, board3);
                if (win == 1)
                {
                    Console.WriteLine($"Congradulations!! {player1} Wins!");
                    winner = true;
                }
                else if (win == 2)
                {
                    Console.WriteLine($"Congradulations!! {player2} Wins!");
                    winner = true;
                }
                else if (win == 4)
                {
                    Console.WriteLine($"Congradulations!! No one wins!");
                    winner = true;
                }

                Display(board1, board2, board3);
                it ++;
                currPlayer = currPlayerlist[it];
            }

        

        }
    
        static void Turn(List<string> board1, List<string> board2, List<string> board3, string currPlayer)
        {
            /* This funtion in the class handles the goings on in a player's turn
            * A turn would be picking which spot on the board you are giong to put your x or o on
            * This also needs to make sure that that spot is not already taken. 
            */
            string spot = Console.ReadLine();
            int i = 0;
            bool replaced = false;
            while (replaced == false)
            {
                Console.WriteLine(i);
                if (board1[i] == spot)
                {
                    board1[i] = currPlayer;
                    replaced = true;
                    return;
                }
                if (board2[i] == spot)
                {
                    board2[i] = currPlayer;
                    replaced = true;
                    return;
                }
                if (board3[i] == spot)
                {
                    board3[i] = currPlayer;
                    replaced = true;
                    return;
                }
                if (i == 2)
                {
                    Console.WriteLine("The number you chose is not on the board.");
                    Console.Write("Pick another spot please: ");
                    i = 0;
                    Turn(board1, board2, board3, currPlayer);
                }
                i ++;
            }
            
            
        }

        static int CheckWin(List<string> board1, List<string> board2, List<string> board3)
        {
            if (board1[0] == "X" && board1[1] == "X" && board1[2] == "X" ||
                board2[0] == "X" && board2[1] == "X" && board2[2] == "X" ||
                board3[0] == "X" && board3[1] == "X" && board3[2] == "X" ||
                board1[0] == "X" && board2[0] == "X" && board3[0] == "X" ||
                board1[1] == "X" && board2[1] == "X" && board3[1] == "X" ||
                board1[2] == "X" && board2[2] == "X" && board3[2] == "X" ||
                board1[0] == "X" && board2[1] == "X" && board3[2] == "X" ||
                board1[2] == "X" && board2[1] == "X" && board3[0] == "X")
                {
                    return 1;
                }
            else if (board1[0] == "O" && board1[1] == "O" && board1[2] == "O" ||
                board2[0] == "O" && board2[1] == "O" && board2[2] == "O" ||
                board3[0] == "O" && board3[1] == "O" && board3[2] == "O" ||
                board1[0] == "O" && board2[0] == "O" && board3[0] == "O" ||
                board1[1] == "O" && board2[1] == "O" && board3[1] == "O" ||
                board1[2] == "O" && board2[2] == "O" && board3[2] == "O" ||
                board1[0] == "O" && board2[1] == "O" && board3[2] == "O" ||
                board1[2] == "O" && board2[1] == "O" && board3[0] == "O")

            {
                return 2;
            }
            else if (board1[0] == "1" || board1[1] == "2" || board1[2] == "3" ||
                board2[0] == "4" || board2[1] == "5" || board2[2] == "6" ||
                board3[0] == "7" || board3[1] == "8" || board3[2] == "9")
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }
        static void Display(List<string> board1, List<string> board2, List<string> board3)
        {
            Console.WriteLine("---------------");
            foreach (string item in board1)
                Console.Write($"| {item} |");
            Console.WriteLine("");
            Console.WriteLine("---------------");
            foreach (string item in board2)
                Console.Write($"| {item} |");
            Console.WriteLine("");
            Console.WriteLine("---------------");
            foreach (string item in board3)
                Console.Write($"| {item} |");
            Console.WriteLine("");
            Console.WriteLine("---------------");
        }
    }
}
