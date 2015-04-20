using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsAndCows.Interfaces;

namespace BullsAndCows.InputReaders
{
    public class ConsoleReader : IInputReader
    {
        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
