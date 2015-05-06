namespace BullsAndCows.Commands
{
    using System;
    using Constants;
    using Interfaces;

    public class ExitCommand : AbstractCommand
    {
        public ExitCommand(IGameEngine engine)
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
