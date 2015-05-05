using System;
using System.Collections.Generic;
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

        //[TestMethod]
        //public void TestExecuteRestartCommand()
        //{
        //    ICommand command = CommandFactory.Create("restart", this.Engine);
        //    command.Execute();

        //    var isDefaultHelpingNumber = this.Engine.helpingNumber.Equals(new char[] {'X', 'X', 'X', 'X'});
        //    var isDefaultGuessesCount = this.Engine.guessesCount.Equals(0);
        //    var isDefaultCheatsCount = this.Engine.CheatsCount.Equals(0);
        //    var isDefaultIsGuessed = this.Engine.IsGuessed.Equals(false);
        //    var areDefaultValues = isDefaultHelpingNumber && isDefaultGuessesCount 
        //        && isDefaultCheatsCount && isDefaultIsGuessed;

        //    Assert.IsTrue(areDefaultValues, "Expected the game vairiables to be with their default values");
        //}
    }
}
