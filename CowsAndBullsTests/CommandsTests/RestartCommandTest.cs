using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows;
using BullsAndCows.Commands.Factories;
using BullsAndCows.InputReaders;
using BullsAndCows.OutputWriters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Interfaces;

namespace BullsAndCowsTest.CommandTests
{
    [TestClass]
    public class RestartCommandTest
    {
        public GameEngine Engine { get; set; }

        [TestInitialize]
        public void GameEngineInitialize()
        {
            this.Engine = new GameEngine(new ConsoleReader(), new ConsoleWriter());
        }

        [TestMethod]
        public void TestExecuteRestartCommand()
        {
            ICommand command = CommandFactory.Create("restart", this.Engine);
            command.Execute();

            var isDefaultHelpingNumber = Enumerable.SequenceEqual(this.Engine.HelpingNumber, new char[] { 'X', 'X', 'X', 'X' });
            var isDefaultGuessesCount = this.Engine.GuessesCount.Equals(0);
            var isDefaultCheatsCount = this.Engine.CheatsCount.Equals(0);
            var isDefaultIsGuessed = this.Engine.IsGuessed.Equals(false);
            var isLegalNumber = CheckIfGuessNumberIsLegal(this.Engine.NumberForGuess);
            var areDefaultValues = isDefaultHelpingNumber && isDefaultGuessesCount
                && isDefaultCheatsCount && isDefaultIsGuessed && isLegalNumber;

            Assert.IsTrue(areDefaultValues, "Expected the game vairiables to be with their default values");
        }

        private bool CheckIfGuessNumberIsLegal(string number)
        {
            int n;        
            if (number.Length == 4 && int.TryParse(number, out n))
            {
                return true;
            }
            return false;
        }
    }
}
