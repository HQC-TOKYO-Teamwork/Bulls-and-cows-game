using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            Console.WriteLine("Exit executed!");
        }
    }
}
