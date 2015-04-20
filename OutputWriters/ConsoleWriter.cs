using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsAndCows.Interfaces;

namespace BullsAndCows.OutputWriters
{
    public class ConsoleWriter : IOutputWriter
    {
        public void WriteOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}
