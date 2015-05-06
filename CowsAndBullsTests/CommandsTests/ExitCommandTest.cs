namespace CowsAndBullsTests.CommandsTests
{
    using BullsAndCows;
    using BullsAndCows.InputReaders;
    using BullsAndCows.OutputWriters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExitCommandTest
    {
        public GameEngine Engine { get; set; }

        [TestInitialize]
        public void GameEngineInitialize()
        {
            this.Engine = new GameEngine(new ConsoleReader(), new ConsoleWriter());
        }

        //[TestMethod]
        //public void TestExecuteExitCommand()
        //{
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        Console.SetOut(sw);
        //        ICommand command = CommandFactory.Create("exit", this.Engine);
        //        command.Execute();
        //        string expected = GameConstants.GoodbyeMessage + Environment.NewLine;

        //        Assert.AreEqual(sw.ToString(), expected, "Expected good bye message on the console");
        //    }
        //}
    }
}
