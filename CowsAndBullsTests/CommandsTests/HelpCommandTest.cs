namespace CowsAndBullsTests.CommandsTests
{
    using System.Text.RegularExpressions;
    using BullsAndCows;
    using BullsAndCows.Commands;
    using BullsAndCows.InputReaders;
    using BullsAndCows.OutputWriters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HelpCommandTest
    {
        public GameEngine Engine { get; set; }

        public HelpCommand HelpCommand { get; set; }

        [TestInitialize]
        public void GameEngineInitialize()
        {
            this.Engine = new GameEngine(new ConsoleReader(), new ConsoleWriter());
            this.HelpCommand = new HelpCommand(this.Engine);
        }

        [TestMethod]
        public void TestHelpCommandWithOneInvoke()
        {
            this.Engine.Initialize();
            this.HelpCommand.Execute();
            string helpingNumber = string.Join(string.Empty, this.Engine.HelpingNumber);
            var regex = new Regex(@"\d");
            var matches = regex.Matches(helpingNumber);
            Assert.AreEqual(1, matches.Count);
        }

        [TestMethod]
        public void TestHelpCommandWithTwoInvokes()
        {
            this.Engine.Initialize();
            for (int i = 0; i < 2; i++)
            {
                this.HelpCommand.Execute();
            }

            string helpingNumber = string.Join(string.Empty, this.Engine.HelpingNumber);
            var regex = new Regex(@"\d");
            var matches = regex.Matches(helpingNumber);
            Assert.AreEqual(2, matches.Count);
        }

        public void TestHelpCommandWithThreeInvokes()
        {
            this.Engine.CheatsCount = 8;
            this.Engine.Initialize();
            for (int i = 0; i < 3; i++)
            {
                this.HelpCommand.Execute();
            }

            string helpingNumber = string.Join(string.Empty, this.Engine.HelpingNumber);
            var regex = new Regex(@"\d");
            var matches = regex.Matches(helpingNumber);
            Assert.AreEqual(3, matches.Count);
        }

        public void TestHelpCommandWithFoureInvokes()
        {
            this.Engine.Initialize();
            for (int i = 0; i < 3; i++)
            {
                this.HelpCommand.Execute();
            }

            string helpingNumber = string.Join(string.Empty, this.Engine.HelpingNumber);
            var regex = new Regex(@"\d");
            var matches = regex.Matches(helpingNumber);
            Assert.AreEqual(4, matches.Count);
        }

        public void TestHelpCommandWithTenInvokes()
        {
            this.Engine.Initialize();
            for (int i = 0; i < 10; i++)
            {
                this.HelpCommand.Execute();
            }

            string helpingNumber = string.Join(string.Empty, this.Engine.HelpingNumber);
            var regex = new Regex(@"\d");
            var matches = regex.Matches(helpingNumber);
            Assert.AreEqual(4, matches.Count);
        }
    }
}
