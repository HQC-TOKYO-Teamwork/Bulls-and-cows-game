﻿namespace BullsAndCows.Commands.Exceptions
{
    using System;

    public class CommandException : Exception
    {
        public CommandException(string message)
            : base(message)
        {
        }
    }
}
