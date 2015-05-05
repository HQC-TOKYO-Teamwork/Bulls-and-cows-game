using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BullsAndCows.Commands.Exceptions;
using BullsAndCows.Commands.Factories;
using BullsAndCows.InputReaders;
using BullsAndCows.Interfaces;
using BullsAndCows.Constants;

namespace BullsAndCows
{
    public class GameEngine
    {
        //Change to ScoreBoard class instance   
        public int guessesCount;
        internal char[] digitForReveal;
        public char[] helpingNumber;
        internal Random randomGenerator;

        public GameEngine(IInputReader inputReader, IOutputWriter outputWriter)
        {
            this.ScoreBoard = new Scoreboard(this);
            this.InputReader = inputReader;
            this.OutputWriter = outputWriter;
            this.randomGenerator = new Random();
        }

        public bool IsGuessed { get; set; }

        public Scoreboard ScoreBoard { get; private set; }

        public int CheatsCount { get; set; }

        public string NumberForGuess { get; private set; }

        //public StringBuilder Output { get; private set; }

        public IInputReader InputReader { get; private set; }

        public IOutputWriter OutputWriter { get; private set; }

        public void Play()
        {
            this.OutputWriter.WriteOutput(GameConstants.WelcomeMessage);
            this.Initialize();

            while (!this.IsGuessed)
            {
                Console.Write(GameConstants.EnterCommand);
                this.ExecuteCommandLoop();
            }

            if (this.CheatsCount > 0)
            {
                this.OutputWriter.WriteOutput("You are not allowed to enter the top scoreboard.");
            }
            else
            {
                PlayerInfo player = this.ScoreBoard.GetPlayerInfo(this.guessesCount);
                this.ScoreBoard.AddPlayerToScoreboard(player);
                this.OutputWriter.WriteOutput(this.ScoreBoard.ToString());
            }

            this.CreateNewGame();
        }

        protected virtual void ExecuteCommandLoop()
        {
            //this.Output.Clear();
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
                this.OutputWriter.WriteOutput(GameConstants.InvalidOperation);
            }

            //this.OutputWriter.WriteOutput(this.Output.ToString());
        }

        private void Initialize()
        {
            this.guessesCount = 0;
            this.CheatsCount = 0;
            this.IsGuessed = false;
            this.helpingNumber = new char[] { 'X', 'X', 'X', 'X' };
            this.NumberForGuess = this.GenerateNumberForGuess();
            //this.Output = new StringBuilder();
        }

        private string GenerateNumberForGuess()
        {
            StringBuilder digits = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                int digit = randomGenerator.Next(0, 10);
                digits.Append(digit);
            }
            this.digitForReveal = digits.ToString().ToCharArray();
            return digits.ToString();
        }

        private void CreateNewGame()
        {
            Play();
        }
    }
}
