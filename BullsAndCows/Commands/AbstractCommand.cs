namespace BullsAndCows.Commands
{
    using Interfaces;

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
