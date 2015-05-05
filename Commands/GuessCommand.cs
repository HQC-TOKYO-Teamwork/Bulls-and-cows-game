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
        public GuessCommand(GameEngine engine, string guess)
            : base(engine)
        {
            this.GameEngine = engine;
            this.GuessString = guess;
            this.NumberForGuess = engine.NumberForGuess;
            this.OutputWriter = engine.OutputWriter;
        }

        public GameEngine GameEngine { get; set; }

        private string GuessString { get; set; }

        private IOutputWriter OutputWriter { get; set; }

        private string NumberForGuess { get; set; }

        public override void Execute()
        {
            ++this.GameEngine.guessesCount;
            Console.WriteLine(++this.GameEngine.guessesCount);
            Console.WriteLine(this.GameEngine.guessesCount);
            this.ProcessGuessedNumber(this.GuessString, this.NumberForGuess);
           
        }

        private void ProcessGuessedNumber(string guess, string answer)
        {
            if (this.GuessNumberIsForGuess(guess, answer))
            {
                this.GameEngine.IsGuessed = true;
                PrintCongratulationMessage();
               // this.GameEngine.ScoreBoard.AddPlayerToScoreboard(this.GameEngine.guessesCount);
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

        private bool GuessNumberIsForGuess(string guess, string numberForGuess)
        {
            if (guess == numberForGuess)
            {
                return true;
            }

            return false;
        }

        private string CountBulls(string guess, string numberForGuess)
        {
            int bullsCount = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == numberForGuess[i])
                {
                    bullsCount++;
                }
            }

            return bullsCount.ToString();
        }

        private string CountCows(string guess, string numberToGuess)
        {
            int cows = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                if (this.NumberForGuess.Contains(guess[i]))
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
            this.OutputWriter.WriteOutput(output.ToString());
        }

        private void UpdateGuessString(int index)
        {
            int indexOfGuessedNumber = this.NumberForGuess.IndexOf(this.GuessString[index]);
            StringBuilder sb = new StringBuilder(this.NumberForGuess);
            sb[indexOfGuessedNumber] = 'x';
            this.NumberForGuess = sb.ToString();
        }

        private void PrintCongratulationMessage()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(String.Format(GameConstants.WinnerMessageWithOutCheats, this.GameEngine.guessesCount));

            if (this.GameEngine.CheatsCount == 0)
            {
                this.OutputWriter.WriteOutput(output.ToString());
            }
            else
            {
                output.AppendFormat(String.Format(GameConstants.CheatMessageExtention, this.GameEngine.guessesCount, this.GameEngine.CheatsCount));
                this.OutputWriter.WriteOutput(output.ToString());
            }
        }
    }
}