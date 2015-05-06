namespace BullsAndCows.Commands
{
    using System;
    using Interfaces;

    public class HelpCommand : AbstractCommand
    {
        public HelpCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public string HelpMessage { get; set; }

        public override void Execute()
        {
            if (this.Engine.CheatsCount >= 4)
            {
                this.PrintHelpingNumber();
            }
            else
            {
                this.GenerateHelperDigit();
                this.Engine.CheatsCount++;
                this.PrintHelpingNumber();
            }
        }

        private void PrintHelpingNumber()
        {
            this.Engine.OutputWriter.WriteOutput(string.Join(string.Empty, this.Engine.HelpingNumber));
        }

        private void GenerateHelperDigit()
        {
            Random random = new Random();
            int position = this.Engine.RandomGenerator.Next(0, 4);
            while (this.Engine.HelpingNumber[position] != 'X' && this.Engine.DigitForReveal[position] == '_')
            {
                position = random.Next(0, 4);
            }

            this.Engine.HelpingNumber[position] = this.Engine.DigitForReveal[position];
            this.Engine.DigitForReveal[position] = '_';
        }
    }
}