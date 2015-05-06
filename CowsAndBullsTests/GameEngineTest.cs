using System;
using System.Collections.Generic;
using System.Threading;
using BullsAndCows.Constants;

namespace CowsAndBullsTests
{
    using BullsAndCows;
    using BullsAndCows.InputReaders;
    using BullsAndCows.OutputWriters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading.Tasks;

    [TestClass]
    public class GameEngineTest
    {
        public GameEngine Engine { get; set; }

        [TestInitialize]
        public void GameEngineInitialize()
        {
            this.Engine = new GameEngine(new ConsoleReader(), new ConsoleWriter());
        }

        //[TestMethod]      
        //public void TestWelcomeMessageIsShowing()
        //{
        //    var reader = new ArrayReader(new List<string>(){"top"});
        //    var writer = new ArrayWriter();
        //    this.Engine = new GameEngine(reader, writer);

        //    Task task = Task.Run(() => this.Engine.Play());
        //    Thread.Sleep(20);

        //    Assert.AreEqual(writer.Output[0], Messages.WelcomeMessage,
        //        "Welcome message should appear in the output");
        //}

        //[TestMethod]
        //public void TestInvalidOperationMessageIsShowing()
        //{
        //    var reader = new ArrayReader(new List<string>() { "invalidCommand" });
        //    var writer = new ArrayWriter();
        //    this.Engine = new GameEngine(reader, writer);

        //    Task task = Task.Run(() => this.Engine.Play());
        //    Thread.Sleep(20);

        //    Assert.AreEqual(writer.Output[1], ExceptionConstants.InvalidOperation,
        //        "Invalid operation message should appear in the output");
        //}
    }
}
