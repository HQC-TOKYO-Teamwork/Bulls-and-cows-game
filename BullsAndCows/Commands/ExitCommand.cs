namespace BullsAndCows.Commands
{
    using System;
    using Constants;

    public class ExitCommand : AbstractCommand
    {
        public ExitCommand(GameEngine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.OutputWriter.WriteOutput(Messages.GoodbyeMessage);
            Environment.Exit(0);
        }
    }
}
