namespace BullsAndCows.Commands
{
    using Interfaces;

    public class TopCommand : AbstractCommand
    {
        public TopCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.OutputWriter.WriteOutput(this.Engine.ScoreBoard.ToString());
        }
    }
}
