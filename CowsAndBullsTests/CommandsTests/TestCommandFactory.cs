using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows;
using BullsAndCows.Commands;
using BullsAndCows.Commands.Factories;
using BullsAndCows.InputReaders;
using BullsAndCows.Interfaces;
using BullsAndCows.OutputWriters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCowsTest.CommandTests
{
    [TestClass]
    public class TestCommandFactory
    {
        public GameEngine Engine { get; set; }

        [TestInitialize]
        public void GameEngineInitialize()
        {
            this.Engine = new GameEngine(new ConsoleReader(), new ConsoleWriter());
        }

        [TestMethod]
        public void TestCreateExitCommand()
        {
            string input = "exit";
            ICommand command = CommandFactory.Create(input, this.Engine);
            Assert.IsInstanceOfType(command, typeof(ExitCommand), "Instance of ExitCommand is expected");
        }

        [TestMethod]
        public void TestCreateGuessCommand()
        {
            string input = "1234";
            ICommand command = CommandFactory.Create(input, this.Engine);
            var a = 5;
            Assert.IsInstanceOfType(command, typeof(GuessCommand), "Instance of GuessCommand is expected");
        }

        [TestMethod]
        public void TestCreateHelpCommand()
        {
            string input = "help";
            ICommand command = CommandFactory.Create(input, this.Engine);
            Assert.IsInstanceOfType(command, typeof(HelpCommand), "Instance of HelpCommand is expected");
        }

        [TestMethod]
        public void TestCreateRestartCommand()
        {
            string input = "restart";
            ICommand command = CommandFactory.Create(input, this.Engine);
            Assert.IsInstanceOfType(command, typeof(RestartCommand), "Instance of RestartCommand is expected");
        }

        [TestMethod]
        public void TestCreateTopCommand()
        {
            string input = "top";
            ICommand command = CommandFactory.Create(input, this.Engine);
            Assert.IsInstanceOfType(command, typeof(TopCommand), "Instance of TopCommand is expected");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "InvalidOperationException expected")]
        public void TestInvalidCommandInputThrowException()
        {
            string input = "asdf";
            ICommand command = CommandFactory.Create(input, this.Engine);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "InvalidOperationException expected")]
        public void TestInvalidGuessCommandInputThrowException()
        {
            string input = "12345";
            ICommand command = CommandFactory.Create(input, this.Engine);
        }
    }
}
