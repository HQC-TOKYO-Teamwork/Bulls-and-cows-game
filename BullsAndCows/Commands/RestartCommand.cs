using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsAndCows.Constants;

namespace BullsAndCows.Commands
{
    public class RestartCommand : AbstractCommand
    {
        public RestartCommand(GameEngine engine)
            :base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.OutputWriter.WriteOutput(GameConstants.WelcomeMessage);
            this.Engine.Initialize();
        }
    }
}
