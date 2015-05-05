namespace BullsAndCows.Commands
{
    using System;

    public class HelpCommand : AbstractCommand
    {
        public HelpCommand(GameEngine engine)
            : base(engine)
        {
            this.GameEngine = engine;
        }

        private GameEngine GameEngine { get; set; }

        public override void Execute()
        {
            if (this.GameEngine.CheatsCount >= 4)
            {
                this.PrintHelpingNumber();
            }
            else
            {
                this.GenerateHelperDigit();
                this.GameEngine.CheatsCount++;
                this.PrintHelpingNumber();
            }
        }

        private void PrintHelpingNumber()
        {
            this.GameEngine.OutputWriter.WriteOutput(string.Join(string.Empty, this.GameEngine.helpingNumber));
        }

        private void GenerateHelperDigit()
        {
            Random random = new Random();
            int position = this.GameEngine.randomGenerator.Next(0, 4);
            while (this.GameEngine.helpingNumber[position] != 'X' && this.GameEngine.digitForReveal[position] == '_')
            {
                position = random.Next(0, 4);
            }

            this.GameEngine.helpingNumber[position] = this.GameEngine.digitForReveal[position];
            this.GameEngine.digitForReveal[position] = '_';
        }
    }
}