
using System.Runtime.InteropServices;
using BullsAndCows;
using BullsAndCows.InputReaders;
using BullsAndCows.Interfaces;
using BullsAndCows.OutputWriters;

public class BullsAndCowsTest
{
    static void Main(string[] args)
    {
        IInputReader inputReader = new ConsoleReader();
        IOutputWriter outputWriter = new ConsoleWriter();
        GameEngine engine = new GameEngine(inputReader, outputWriter);

        engine.Play();
    }
}

