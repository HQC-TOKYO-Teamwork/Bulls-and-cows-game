namespace BullsAndCows
{
    using System;
    using System.Text;
    using Commands.Exceptions;
    using Commands.Factories;
    using Constants;
    using Interfaces;

    public class GameEngine : IGameEngine
    {
        public GameEngine(IInputReader inputReader, IOutputWriter outputWriter)
        {
            this.ScoreBoard = new Scoreboard(this);
            this.InputReader = inputReader;
            this.OutputWriter = outputWriter;
            this.RandomGenerator = new Random();
        }

        public char[] DigitForReveal { get; private set; }

        public Random RandomGenerator { get; private set; }

        public Scoreboard ScoreBoard { get; private set; }

        public IInputReader InputReader { get; private set; }

        public IOutputWriter OutputWriter { get; private set; }

        public string NumberForGuess { get; set; }

        public char[] HelpingNumber { get; set; }

        public int GuessesCount { get; set; }

        public bool IsGuessed { get; set; }

        public int CheatsCount { get; set; }

        public void Play()
        {
            this.OutputWriter.WriteOutput(Messages.WelcomeMessage);
            this.Initialize();

            while (!this.IsGuessed)
            {
                Console.Write(Messages.EnterCommand);
                this.ExecuteCommandLoop();
            }

            if (this.CheatsCount > 0)
            {
                this.OutputWriter.WriteOutput(Messages.NotAllowedToEnterScoreboard);
            }
            else
            {
                PlayerInfo player = this.ScoreBoard.GetPlayerInfo(this.GuessesCount);
                this.ScoreBoard.AddPlayerToScoreboard(player);
                this.OutputWriter.WriteOutput(this.ScoreBoard.ToString());
            }

            this.Play();
        }

        public void Initialize()
        {
            this.GuessesCount = 0;
            this.CheatsCount = 0;
            this.IsGuessed = false;
            this.HelpingNumber = new char[] { 'X', 'X', 'X', 'X' };
            this.NumberForGuess = this.GenerateNumberForGuess();
        }

        private void ExecuteCommandLoop()
        {
            var inputCommand = this.InputReader.ReadInput();

            try
            {
                ICommand command = CommandFactory.Create(inputCommand, this);
                command.Execute();
            }
            catch (CommandException ex)
            {
                this.OutputWriter.WriteOutput(ex.Message);
            }
            catch (InvalidOperationException)
            {
                this.OutputWriter.WriteOutput(ExceptionConstants.InvalidOperation);
            }
        }

        private string GenerateNumberForGuess()
        {
            StringBuilder digits = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                int digit = this.RandomGenerator.Next(0, 10);
                digits.Append(digit);
            }

            this.DigitForReveal = digits.ToString().ToCharArray();
            return digits.ToString();
        }
    }
}
