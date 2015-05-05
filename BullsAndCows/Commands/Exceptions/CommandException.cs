using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Commands.Exceptions
{
    public class CommandException : Exception
    {
        public CommandException(string message)
            : base(message)
        {
        }
    }
}
