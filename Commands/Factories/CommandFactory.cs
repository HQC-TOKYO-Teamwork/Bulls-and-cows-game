using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using BullsAndCows.Commands.Exceptions;
using BullsAndCows.Interfaces;
using BullsAndCows.Constants;

namespace BullsAndCows.Commands.Factories
{
    public class CommandFactory
    {
        private const string CommandSuffix = GameConstants.CommandSuffix;
        private const string GuessPattern = GameConstants.GuessPattern;

        // Should be changed to IGameEngine
        public static ICommand Create(string commandInput, GameEngine engine)
        {
            Regex guessPattern = new Regex(GuessPattern);
            if (guessPattern.IsMatch(commandInput) && commandInput.Length == 4)
            {
                return new GuessCommand(engine, commandInput);
            }

            var commandClass = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && t.Namespace == typeof(AbstractCommand).Namespace)
                .Where(t => t.Name.EndsWith(CommandSuffix))
                .First(t => t.Name
                    .Replace(CommandSuffix, string.Empty)
                    .ToLower()
                    .Equals(commandInput.ToLower()));

            var command = Activator.CreateInstance(commandClass, engine) as AbstractCommand;
            return command;
        }
    }
}
