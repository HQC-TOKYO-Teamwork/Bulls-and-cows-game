namespace CowsAndBullsTests
{
    using System;
    using System.IO;
    using BullsAndCows.Interfaces;
    using BullsAndCows.OutputWriters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsoleWriterTest
    {
        [TestMethod]
        public void TestWriteOutput()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                IOutputWriter writer = new ConsoleWriter();
                string output = "test";
                writer.WriteOutput(output);
                string expected = output + Environment.NewLine;

                Assert.AreEqual(sw.ToString(), expected, "Expected the output to be printed on the console");
            }
        }
    }
}
