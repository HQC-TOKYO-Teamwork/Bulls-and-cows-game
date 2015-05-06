namespace BullsAndCows
{
    using System;
    using System.Text;
    using Commands.Exceptions;
    using Commands.Factories;
    using Interfaces;
    using Constants;

    public class GameEngine
    {        
        internal char[] digitForReveal;
        internal Random randomGenerator;

        public GameEngine(IInputReader inputReader, IOutputWriter outputWriter)
        {
            this.ScoreBoard = new Scoreboard(this);
            this.InputReader = inputReader;
            this.OutputWriter = outputWriter;
            this.randomGenerator = new Random();
        }

        public char[] HelpingNumber { get; set; }

        public int GuessesCount { get; set; }

        public bool IsGuessed { get; set; }

        public Scoreboard ScoreBoard { get; private set; }

        public int CheatsCount { get; set; }

        public string NumberForGuess { get; private set; }

        public IInputReader InputReader { get; private set; }

        public IOutputWriter OutputWriter { get; private set; }

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

        protected virtual void ExecuteCommandLoop()
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
            catch (InvalidOperationException ex)
            {
                this.OutputWriter.WriteOutput(ExceptionConstants.InvalidOperation);
            }
        }

        private string GenerateNumberForGuess()
        {
            StringBuilder digits = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                int digit = randomGenerator.Next(0, 10);
                digits.Append(digit);
            }
            digits = new StringBuilder("1234"); // for testing
            this.digitForReveal = digits.ToString().ToCharArray();
            return digits.ToString();
        }
    }
}
