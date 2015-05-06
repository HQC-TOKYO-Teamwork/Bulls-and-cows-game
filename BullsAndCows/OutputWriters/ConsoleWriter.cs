namespace BullsAndCows.OutputWriters
{
    using System;
    using Interfaces;

    public class ConsoleWriter : IOutputWriter
    {
        public void WriteOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}
