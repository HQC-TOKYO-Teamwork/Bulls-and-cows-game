﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Commands
{
    public class TopScoresCommand : AbstractCommand
    {
        public TopScoresCommand(GameEngine engine)
            :base(engine)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
