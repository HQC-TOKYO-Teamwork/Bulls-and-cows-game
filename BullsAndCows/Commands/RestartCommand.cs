namespace BullsAndCows.Commands
{
    using Constants;

    public class RestartCommand : AbstractCommand
    {
        public RestartCommand(GameEngine engine)
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
