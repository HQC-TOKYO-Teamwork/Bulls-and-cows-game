using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Commands
{
    public class TopCommand : AbstractCommand
    {
        public TopCommand(GameEngine engine)
            :base(engine)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
