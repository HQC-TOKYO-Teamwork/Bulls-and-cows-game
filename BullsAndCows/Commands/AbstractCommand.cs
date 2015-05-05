using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BullsAndCows.Interfaces;

namespace BullsAndCows.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        public GameEngine Engine { get; private set; }

        // GameEngine should be changed to IGameEngine
        protected AbstractCommand(GameEngine engine)
        {
            this.Engine = engine;
        }

        public abstract void Execute();
    }
}
