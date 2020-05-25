namespace Binottery
{
    public class Game
    {
        public State state;
        public Board board;

        public Game()
        {
            state = new State();
            board = new Board();
        }
    }
}