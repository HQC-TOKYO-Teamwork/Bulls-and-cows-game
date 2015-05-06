namespace BullsAndCows
{
    using InputReaders;
    using Interfaces;
    using OutputWriters;

    public class BullsAndCowsStart
    {
        private static void Main(string[] args)
        {
            IInputReader inputReader = new ConsoleReader();
            IOutputWriter outputWriter = new ConsoleWriter();
            GameEngine engine = new GameEngine(inputReader, outputWriter);

            engine.Play();
        }
    }
}

