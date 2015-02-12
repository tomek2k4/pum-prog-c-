using System;
using System.IO;
using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest001
    {
        [TestMethod]
        public void _001ConsoleWriter1()
        { 
            var consoleSim = new StringWriter();
            Console.SetOut(consoleSim);

            var writer = Type.GetType(TypeStrings.ConsoleWriter).
                GetConstructor(Type.EmptyTypes).Invoke(null) as IWriter;

            if(writer == null)
                Assert.Fail("Can't create instance of App.ConsoleWriter");

            writer.Write("Dupa");
            consoleSim.Flush();
            Assert.AreEqual(consoleSim.ToString(), "Dupa");

            writer.WriteLine("Dupa2");
            writer.WriteLine("Dupa3");

            consoleSim.Flush();
            Assert.AreEqual(consoleSim.ToString(), "DupaDupa2" + consoleSim.NewLine + "Dupa3" + consoleSim.NewLine);
        }
    }
}
