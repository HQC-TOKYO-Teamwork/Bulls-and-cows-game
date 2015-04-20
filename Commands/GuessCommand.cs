using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Commands
{
    public class GuessCommand : AbstractCommand
    {
        public string Guess { get; private set; }

        public GuessCommand(GameEngine engine, string guess)
            : base(engine)
        {
            this.Guess = guess;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
