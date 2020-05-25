using Binottery.Utils;
using System;

namespace Binottery
{
    class Program
    {       
        static void Main(string[] args)
        {
            string command;
            Game game = new Game();
            bool resumed = true;

            game = Backup.Load("savedgame.xml");
            if (game != null)
            {
                Console.WriteLine("The is an open game available! Would you like to resume the saved game?");
                Console.WriteLine("Type \"continue\" to resume or \"new\" for a new game");

                while (resumed)
                {
                    command = Console.ReadLine();
                    switch (command)
                    {
                        case "new":
                            game = new Game();
                            game.board.RandomizeBoard();
                            resumed = false;
                            break;
                        case "continue":
                            game = Backup.Load("savedgame.xml");
                            resumed = false;
                            break;
                        case "exit":                           
                            System.Environment.Exit(1);
                            break;
                        default:
                            Console.WriteLine("Invalid command! Type \"continue\" to resume or \"new\" for a new game");
                            break;
                    }
                }
            }

            while ((command = Console.ReadLine()) != null)
            {
                switch (command)
                {
                    case "show":
                        if (game.board.chosen_numbers.Count == 0)
                            game.board.RandomizeBoard();
                        Printer.PrintBoard(game.board, game.state);
                        break;
                    case "end":
                        if (game.board.chosen_numbers.Count == 0)
                        {
                            Console.WriteLine("There is no active game! Type \"show\" in order to populate the board!");
                        }
                        else
                        {
                            Console.WriteLine("The game has ended! This is the board and your credit:");
                            Printer.PrintBoard(game.board, game.state);
                            game = new Game();
                        }

                        break;
                    case "exit":
                        if (game.state.guesses > 0 && game.state.guesses < 5)
                        {
                            Backup.Save(game, "savedgame.xml");
                        }
                        System.Environment.Exit(1);
                        break;
                    default:
                        try
                        {
                            int number = Int32.Parse(command);

                            if (number >= 90)
                            {
                                Console.WriteLine("The Number must be between 0 and 89!");
                            }
                            else if (number < 0)
                            {
                                Console.WriteLine("The Number must be between 0 and 89!");
                            }
                            else
                            {
                                if (game.board.chosen_numbers.Count == 0)
                                    Console.WriteLine("The board is empty! Type \"show\" in order to populate the board!");
                                else
                                {
                                    game.board.ChooseNumber(number, game.state);
                                    if (game.state.guesses == 5)
                                    {
                                        var save_credit = game.state.credit;
                                        game = new Game();
                                        game.state.credit = save_credit;
                                    }
                                }                               
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid Command!");
                        }
                        break;
                }
            }
        }
    }
}