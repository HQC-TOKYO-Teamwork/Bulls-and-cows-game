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
    public class TopCommandTest
    {
        public GameEngine Engine { get; set; }

        [TestInitialize]
        public void GameEngineInitialize()
        {
            this.Engine = new GameEngine(new ConsoleReader(), new ConsoleWriter());
        }

        [TestMethod]
        public void TestTopCommand()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ICommand command = CommandFactory.Create("top", this.Engine);
                command.Execute();
                string expected = this.Engine.ScoreBoard.ToString() + Environment.NewLine;

                Assert.AreEqual(sw.ToString(), expected, "Expected the scoreboard to be printed on the console");
            }
        }
    }
}
