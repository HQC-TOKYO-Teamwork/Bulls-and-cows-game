using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsAndCows.Interfaces;

namespace BullsAndCows.OutputWriters
{
    public class ArrayWriter : IOutputWriter
    {
        public ArrayWriter()
        {
            this.Output = new List<string>();
        }

        public List<string> Output { get; set; }

        public void WriteOutput(string output)
        {
            this.Output.Add(output);
        }
    }
}
