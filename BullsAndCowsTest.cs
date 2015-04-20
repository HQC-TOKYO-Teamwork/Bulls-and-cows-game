
using System.Runtime.InteropServices;
using BullsAndCows;
using BullsAndCows.InputReaders;
using BullsAndCows.Interfaces;

public class BullsAndCowsTest
{
    static void Main(string[] args)
    {
        IInputReader inputReader = new ConsoleReader();
        GameEngine engine = new GameEngine(inputReader);
        engine.Play();
    }
}

