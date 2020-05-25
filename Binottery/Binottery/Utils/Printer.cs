using System;

namespace Binottery
{
    public static class Printer
    {
        public static void PrintBoard(Board board, State state)
        {
            for (int i = 0; i < board.board_numbers.Length; i++)
            {
                if (board.board_numbers[i].guess == "")
                {
                    board.board_numbers[i].guess = "   ";
                }

                if (i % 9 != 8)
                    Console.Write(board.board_numbers[i].value + board.board_numbers[i].guess + "   ");
                else
                    Console.WriteLine(board.board_numbers[i].value + board.board_numbers[i].guess);
            }

            Console.WriteLine("Credit: " + state.credit);
        }

        public static void PrintBingoBoard(Board board, State state)
        {
            for (int i = 0; i < board.board_numbers.Length; i++)
            {
                if (board.board_numbers[i].guess == "")
                {
                    board.board_numbers[i].guess = "   ";
                }

                if (i % 9 != 8)
                    Console.Write(board.board_numbers[i].value + board.board_numbers[i].guess + "   ");
                else
                    Console.WriteLine(board.board_numbers[i].value + board.board_numbers[i].guess);
            }

            Console.WriteLine("Bingooo!!! All your 5 guesses were correct! Your credit has been doubled!");
            Console.WriteLine("Credit: " + state.credit);
        }
    }
}