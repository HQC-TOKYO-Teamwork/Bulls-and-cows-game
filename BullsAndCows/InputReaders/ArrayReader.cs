using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsAndCows.Interfaces;

namespace BullsAndCows.InputReaders
{
    public class ArrayReader : IInputReader
    {
        private static int position = 0;
        private IList<string> commands;

        public ArrayReader(IList<string> commands)
        {
            this.commands = commands;
        }

        public string ReadInput()
        {
            string command = this.commands[position];
            position++;
            return command;
        }
    }
}
