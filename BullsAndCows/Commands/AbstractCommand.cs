namespace BullsAndCows.Commands
{
    using Interfaces;

    public abstract class AbstractCommand : ICommand
    {
        public IGameEngine Engine { get; private set; }

        protected AbstractCommand(IGameEngine engine)
        {
            this.Engine = engine;
        }

        public abstract void Execute();
    }
}
