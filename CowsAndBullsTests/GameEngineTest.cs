using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows;
using BullsAndCows.InputReaders;
using BullsAndCows.OutputWriters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CowsAndBullsTests
{
    [TestClass]
    public class GameEngineTest
    {
        public GameEngine Engine { get; set; }

        [TestInitialize]
        public void GameEngineInitialize()
        {
            this.Engine = new GameEngine(new ArrayReader(new List<string>()), new ConsoleWriter());
        }

        //[TestMethod]
        //public void TestWelcomeMessageIsShown()
        //{
        //    this.Engine.InputReader = new ArrayReader(new List<string>() {"top", "exit"});
        //}
    }
}
