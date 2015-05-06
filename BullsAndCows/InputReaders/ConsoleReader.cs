namespace BullsAndCows.InputReaders
{
    using System;
    using Interfaces;

    public class ConsoleReader : IInputReader
    {
        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
