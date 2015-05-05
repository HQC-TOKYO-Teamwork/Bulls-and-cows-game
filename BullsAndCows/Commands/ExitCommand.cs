using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsAndCows.Constants;
namespace BullsAndCows.Commands
{
    public class ExitCommand : AbstractCommand
    {
        public ExitCommand(GameEngine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.OutputWriter.WriteOutput(GameConstants.GoodbyeMessage);
            Environment.Exit(0);
        }
    }
}
