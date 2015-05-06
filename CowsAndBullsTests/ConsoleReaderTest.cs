namespace CowsAndBullsTests
{
    using System;
    using System.IO;
    using BullsAndCows.InputReaders;
    using BullsAndCows.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsoleReaderTest
    {
        [TestMethod]
        public void TestReadInput()
        {
            IInputReader reader = new ConsoleReader();
            string expected = "test";

            using (StringReader sr = new StringReader(expected))
            {
                Console.SetIn(sr);
                Assert.AreEqual(reader.ReadInput(), expected, "The read value should be the same as the input");
            }
        }
    }
}
