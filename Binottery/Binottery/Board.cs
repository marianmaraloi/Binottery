using System;
using System.Collections.Generic;
using Binottery.Utils;

namespace Binottery
{
    public class Board
    {
        public Number[] board_numbers;
        public List<int> chosen_numbers;

        public Board()
        {
            board_numbers = new Number[27];
            chosen_numbers = new List<int>();
            for (int i = 0; i < 27; i++)
            {
                board_numbers[i] = new Number();
            }
        }

        public void RandomizeBoard()
        {
            Random rand = new Random();
            
            for (int i = 0; i < 9; i++)
            {
                List<int> values = new List<int>();
                for(int j = 0; j < 3; j ++)
                {
                    while (true)
                    {
                        int randomNumber = rand.Next(i * 10, (i + 1) * 10);
                        if (!values.Contains(randomNumber))
                        {
                            values.Add(randomNumber);
                            break;
                        }
                    }                    
                }
                board_numbers[i].value = values[0];
                board_numbers[i + 9].value = values[1];
                board_numbers[i + 18].value = values[2];
            }

            for (int i = 0; i < 6; i++)
            {
                while (true)
                {
                    int randomNumber = rand.Next(0, 27);
                    if (!chosen_numbers.Contains(board_numbers[randomNumber].value))
                    {
                        chosen_numbers.Add(board_numbers[randomNumber].value);
                        break;
                    }
                }
            }
        }

        public void ChooseNumber(int number, State state)
        {
            bool isOnTable = false;
            for (int i = 0; i < board_numbers.Length; i++)
            {
                if(board_numbers[i].value == number)
                {
                    isOnTable = true;

                    if (board_numbers[i].guess != "*+*" && board_numbers[i].guess != "*-*")
                    {
                        state.guesses++;

                        if (chosen_numbers.Contains(number))
                        {
                            board_numbers[i].guess = "*+*";
                            state.credit++;
                            state.correct_guesses++;
                        }
                        else
                            board_numbers[i].guess = "*-*";

                        if(state.guesses == 5)
                        {
                            Console.WriteLine("The game has ended! This is the board and your credit:");
                            if(state.correct_guesses == 5)
                            {
                                state.credit = state.credit * 2;
                                Printer.PrintBingoBoard(this, state);
                            }
                            Printer.PrintBoard(this, state);
                        }
                    }

                    else
                        Console.WriteLine("You already selected this number. Please select another number from the board!");
                }
            }

            if(!isOnTable)
                Console.WriteLine("The Number you selected is not on the board. Please select a number from the board!");
        }
    }
}
