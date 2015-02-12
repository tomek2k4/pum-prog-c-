using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helpers;

namespace Tests
{
    [TestClass]
    public class UnitTest002
    {
        [TestMethod]
        public void _002ControlFlow1()
        {
            var c = new ControlFlowExamples();
            var b = c.EvenSecond(new DateTime(
                2000, 1, 1, 1, 1, 2));
            Assert.IsTrue(b);
            b = c.EvenSecond(new DateTime(2000, 1, 1, 1, 1, 3));
            Assert.IsFalse(b);

        }

        [TestMethod]
        public void _002ControlFlow2()
        {
            var c = new ControlFlowExamples();
            var w = new Writer();
            c.FromOneToN(5, w);
            w.EqualsTo("1", "2", "3", "4", "5");
        }

        [TestMethod]
        public void _002ControlFlow3()
        {
            var c = new ControlFlowExamples();
            var w = new Writer();
            for(int i = 0; i <= 8; ++i)
                w.WriteLine(c.DayName(i));
            Assert.IsTrue( w.EqualsTo("",
                "MON",
                "TUE",
                "WED",
                "THR",
                "FRI",
                "SAT",
                "SUN", ""));
        }

        [TestMethod]
        public void _002ControlFlow4()
        {
            var c = new ControlFlowExamples();
            var w = new Writer();
            var s = new String[]
            {
                "One", "Two", "Three"
            };

            c.PrintAll(s, w);

            Assert.IsTrue(w.EqualsTo(s));
        }


        [TestMethod]
        public void _002ControlFlow5()
        {
            var c = new ControlFlowExamples();

            var x = c.log2(1);
            Assert.AreEqual(x, 0);

            x = c.log2(2);
            Assert.AreEqual(x, 1);

            x = c.log2(4);
            Assert.AreEqual(x, 2);

            x = c.log2(64);
            Assert.AreEqual(x, 6);

            try
            {
                c.log2(0);
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected ArgumentException but catched "+ex.GetType().Name);
            }

            try
            {
                c.log2(3);
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected ArgumentException but catched " + ex.GetType().Name);
            }

            try
            {
                c.log2(500);
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected ArgumentException but catched " + ex.GetType().Name);
            }
        }

    }
}
