namespace BullsAndCows.Commands
{
    using Constants;
    using Interfaces;

    public class RestartCommand : AbstractCommand
    {
        public RestartCommand(IGameEngine engine)
            :base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.OutputWriter.WriteOutput(Messages.WelcomeMessage);
            this.Engine.Initialize();
        }
    }
}
