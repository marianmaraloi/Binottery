namespace Binottery
{
    public class State
    {
        public int guesses;
        public int correct_guesses;
        public int credit;

        public State()
        {
            correct_guesses = 0;
            guesses = 0;
            credit = 0;
        }
    }
}
