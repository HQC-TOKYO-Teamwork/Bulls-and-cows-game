namespace BullsAndCows.Commands
{
    public class TopCommand : AbstractCommand
    {
        public TopCommand(GameEngine engine)
            :base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.OutputWriter.WriteOutput(this.Engine.ScoreBoard.ToString());
        }
    }
}
