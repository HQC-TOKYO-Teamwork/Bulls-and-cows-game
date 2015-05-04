using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Commands
{
    public class HelpCommand : AbstractCommand
    {
        private GameEngine GameEngine { get; set; }
        public HelpCommand(GameEngine engine)
            :base(engine)
        {
            this.GameEngine = engine;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
