namespace BullsAndCows.Commands
{
    using Interfaces;

    public abstract class AbstractCommand : ICommand
    {
        protected AbstractCommand(IGameEngine engine)
        {
            this.Engine = engine;
        }

        public IGameEngine Engine { get; private set; }

        public abstract void Execute();
    }
}
