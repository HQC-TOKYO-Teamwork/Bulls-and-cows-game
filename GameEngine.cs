using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BullsAndCows.Commands.Exceptions;
using BullsAndCows.Commands.Factories;
using BullsAndCows.InputReaders;
using BullsAndCows.Interfaces;

namespace BullsAndCows
{
    public class GameEngine
    {
        //Change to ScoreBoard class instance
        //private List<PlayerInfo> klasirane =
        //    new List<PlayerInfo>();
        private bool isGuessed;
        private int count1;
        private int count2;
        private string numberForGuessString;
        private char[] helpingNumber;
        private Random randomGenerator;

        public GameEngine(IInputReader inputReader)
        {
            this.InputReader = inputReader;
        }

        public StringBuilder Output { get; private set; }

        private IInputReader InputReader { get; set; }

        public void Play()
        {
            Console.WriteLine(
                "Welcome to “Bulls and Cows” game." +
                "Please try to guess my secret 4-digit number." +
                "Use 'top' to view the top scoreboard, 'restart'" +
                "to start a new game and 'help'" +
                " to cheat and 'exit' to quit the game.");
            Initialize();
            GenerateNumberForGuess();

            while (!isGuessed)
            {
                Console.Write("Enter your guess or command: ");
                this.ExecuteCommandLoop();           
            }

            //AddPlayerToScoreboard(count2);
            //PrintScoreboard();
            CreateNewGame();
        }

        protected virtual void ExecuteCommandLoop()
        {
            this.Output.Clear();
            var inputCommand = this.InputReader.ReadInput();

            try
            {
                ICommand command = CommandFactory.Create(inputCommand, this);
                command.Execute();
            }
            catch (CommandException ex)
            {
                this.Output.AppendLine(ex.Message);
            }
            catch (InvalidOperationException)
            {
                this.Output.AppendLine("Invalid operation");
            }

            Console.Write(this.Output);
        }

        private void Initialize()
        {
            randomGenerator = new Random();
            count2 = 0;
            count1 = 0;
            isGuessed = false;
            helpingNumber = new char[] { 'X', 'X', 'X', 'X' };
            this.Output = new StringBuilder();
        }

        private void GenerateNumberForGuess()
        {
            long numberForGuess = randomGenerator.Next(0, 9999);
            numberForGuessString = numberForGuess.ToString();
            AddZeroes();
        }

        private void AddZeroes()
        {
            int zeroesForAdd = 4 - numberForGuessString.Length;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < zeroesForAdd; i++)
            {
                sb.Append("0");
            }
            sb.Append(numberForGuessString);
            numberForGuessString = sb.ToString();
        }

        private void CreateNewGame()
        {
            Play();
        }
    }
}
