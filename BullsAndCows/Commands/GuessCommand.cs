namespace BullsAndCows.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BullsAndCows.Constants;
    using BullsAndCows.Interfaces;

    public class GuessCommand : AbstractCommand
    {
        public GuessCommand(IGameEngine engine, string guess)
            : base(engine)
        {
            this.GuessString = guess;
            this.NumberForGuessAsString = engine.NumberForGuess;
            this.OutputWriter = engine.OutputWriter;
        }

        public string BullsAndCowsOutPut { get; set; }

        private string GuessString { get; set; }

        private IOutputWriter OutputWriter { get; set; }

        private string NumberForGuessAsString { get; set; }

        public override void Execute()
        {
            ++this.Engine.GuessesCount;
            this.ProcessGuessedNumber(this.GuessString, this.NumberForGuessAsString);

        }

        private void ProcessGuessedNumber(string guess, string answer)
        {
            if (this.GuessNumberIsForGuess(guess, answer))
            {
                this.Engine.IsGuessed = true;
                PrintCongratulationMessage();
            }
            else
            {
                string[] bullsAndCows = this.CountBullsAndCows(guess, answer);
                this.PrintBullsAndCows(bullsAndCows);
            }
        }

        private string[] CountBullsAndCows(string guess, string numberForGuess)
        {
            var bulls = this.CountBulls(guess, numberForGuess);
            var cows = this.CountCows(guess, numberForGuess);
            return new string[] { bulls, cows };
        }

        private bool GuessNumberIsForGuess(string guess, string numberForGuessAsString)
        {
            if (guess == numberForGuessAsString)
            {
                return true;
            }

            return false;
        }

        private string CountBulls(string guess, string numberForGuessAsString)
        {
            int bullsCount = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == numberForGuessAsString[i])
                {
                    this.UpdateGuessString(i);
                    bullsCount++;
                }
            }

            return bullsCount.ToString();
        }

        private string CountCows(string guess, string numberForGuessAsString)
        {
            int cows = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                if (this.NumberForGuessAsString.Contains(guess[i]))
                {
                    this.UpdateGuessString(i);
                    cows++;
                }
            }

            return cows.ToString();
        }

        private void PrintBullsAndCows(string[] bullsAndCows)
        {
            StringBuilder output = new StringBuilder();
            output.Append(String.Format(GameConstants.BullsAndCowsOutPut, bullsAndCows[0], bullsAndCows[1]));
            this.BullsAndCowsOutPut = output.ToString();
            this.OutputWriter.WriteOutput(this.BullsAndCowsOutPut);
        }

        private void UpdateGuessString(int index)
        {
            int indexOfGuessedNumber = this.NumberForGuessAsString.IndexOf(this.GuessString[index]);
            StringBuilder sb = new StringBuilder(this.NumberForGuessAsString);
            sb[indexOfGuessedNumber] = 'x';
            this.NumberForGuessAsString = sb.ToString();
        }

        private void PrintCongratulationMessage()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(String.Format(Messages.WinnerMessageWithOutCheats, this.Engine.GuessesCount));

            if (this.Engine.CheatsCount == 0)
            {
                this.OutputWriter.WriteOutput(output.ToString());
            }
            else
            {
                output.AppendFormat(Messages.CheatMessageExtention, this.Engine.GuessesCount, this.Engine.CheatsCount);
                this.OutputWriter.WriteOutput(output.ToString());
            }
        }
    }
}