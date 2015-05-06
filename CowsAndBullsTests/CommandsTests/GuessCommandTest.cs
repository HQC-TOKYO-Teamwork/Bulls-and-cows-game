using System;
using System.Collections.Generic;
using System.Linq;
namespace CowsAndBullsTests.CommandsTests
{
    using BullsAndCows;
    using BullsAndCows.Commands;
    using BullsAndCows.InputReaders;
    using BullsAndCows.Interfaces;
    using BullsAndCows.OutputWriters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GuessCommandTest
    {
        public GameEngine Engine { get; set; }

        public string GuessString { get; set; }

        public GuessCommand GuessCommand { get; set; }

        public string ConsoleOutPutForBullsAndCows { get; set; }

        public IOutputWriter OutputWriter { get; set; }

        [TestInitialize]
        public void GameEngineInitialize()
        {
            this.Engine = new GameEngine(new ConsoleReader(), new ConsoleWriter());
            this.GuessString = this.Engine.NumberForGuess;
            this.OutputWriter = new ConsoleWriter();
        }

        [TestMethod]
        public void WinGameWithOneGuess()
        {
            this.GuessCommand = new GuessCommand(this.Engine, this.GuessString);
            this.GuessCommand.Execute();
            int output = this.Engine.GuessesCount;
            Assert.AreEqual(output, 1);
        }

        [TestMethod]
        public void TestTwoBullsAndTwoCows()
        {
            this.GuessString = "1243";
            this.Engine.NumberForGuess = "1234";
            this.GuessCommand = new GuessCommand(this.Engine, this.GuessString);
            this.GuessCommand.Execute();
            this.ConsoleOutPutForBullsAndCows = this.GuessCommand.BullsAndCowsOutPut;
            string expectedOutput = "Bulls: 2, Cows: 2";
            Assert.AreEqual(expectedOutput, this.ConsoleOutPutForBullsAndCows);
        }

        [TestMethod]
        public void TestZeroBullsAndZeroCows()
        {
            this.GuessString = "5555";
            this.Engine.NumberForGuess = "1234";
            this.GuessCommand = new GuessCommand(this.Engine, this.GuessString);
            this.GuessCommand.Execute();
            this.ConsoleOutPutForBullsAndCows = this.GuessCommand.BullsAndCowsOutPut;
            string expectedOutput = "Bulls: 0, Cows: 0";
            Assert.AreEqual(expectedOutput, this.ConsoleOutPutForBullsAndCows);
        }

        [TestMethod]
        public void TestOneBullAndZeroCows()
        {
            this.GuessString = "1555";
            this.Engine.NumberForGuess = "1234";
            this.GuessCommand = new GuessCommand(this.Engine, this.GuessString);
            this.GuessCommand.Execute();
            this.ConsoleOutPutForBullsAndCows = this.GuessCommand.BullsAndCowsOutPut;
            string expectedOutput = "Bulls: 1, Cows: 0";
            Assert.AreEqual(expectedOutput, this.ConsoleOutPutForBullsAndCows);
        }

        [TestMethod]
        public void TestOneBullAndThreeCows()
        {
            this.GuessString = "1432";
            this.Engine.NumberForGuess = "1243";
            this.GuessCommand = new GuessCommand(this.Engine, this.GuessString);
            this.GuessCommand.Execute();
            this.ConsoleOutPutForBullsAndCows = this.GuessCommand.BullsAndCowsOutPut;
            string expectedOutput = "Bulls: 1, Cows: 3";
            Assert.AreEqual(expectedOutput, this.ConsoleOutPutForBullsAndCows);
        }

       [TestMethod]
        public void TestOneBullAndThreeCowsWithCheat()
        {
            this.Engine.CheatsCount = 2;
            this.GuessString = "1432";
            this.Engine.NumberForGuess = "1243";
            this.GuessCommand = new GuessCommand(this.Engine, this.GuessString);
            this.GuessCommand.Execute();
            this.ConsoleOutPutForBullsAndCows = this.GuessCommand.BullsAndCowsOutPut;
            string expectedOutput = "Bulls: 1, Cows: 3";
            Assert.AreEqual(expectedOutput, this.ConsoleOutPutForBullsAndCows);
        }
    }
}
