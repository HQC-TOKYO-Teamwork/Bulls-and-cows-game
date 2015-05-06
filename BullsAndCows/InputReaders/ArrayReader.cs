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

        public ArrayReader()
        {
            this.Commands = new List<string>();
        }

        public List<string> Commands { get; set; }

        public string ReadInput()
        {
            string command = this.Commands[position];
            position++;
            return command;
        }
    }
}
