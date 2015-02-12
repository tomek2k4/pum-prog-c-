using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helpers;

namespace Tests
{
    [TestClass]
    public class UnitTest006
    {
        public dynamic CR(int numerator, int denominator)
        {
            return (dynamic)
                Type.GetType(TypeStrings.Rational)
                    .GetConstructor(new[] {typeof (int), typeof (int)})
                    .Invoke(new object[] {numerator, denominator});
        }

       

        [TestMethod]
        public void _006Rational1OperatorsAndMutation()
        {
            var r = CR(1, 12);
           
            var x = r + 1;
            x = r - 12;
            x = r * r;
            x = r * 0;
            x = r / 1;
            x = r / CR(10,10);
            r.Inverse();
            var c = -r;

            var b = r < 1;
            b = r <= CR(2, 24);
            b =r > 2;
            b =r >= 15;
            b = r == 12;
            b = r != 4;
            
            Assert.AreEqual(CR(1,12),r,"Rational should not be mutable");
        }

        [TestMethod]
        public void _006Rational2Equals()
        {
            var r = CR(3, 12);
            Assert.AreEqual(r, CR(1, 4));
            Assert.AreEqual(r, CR(2, 8));
            Assert.AreNotEqual(r, CR(-2, 8));
            Assert.AreNotEqual(r, CR(4, 12));
            Assert.IsTrue(r==CR(2,8));
            Assert.IsFalse(r!=CR(1,4));
        }

        [TestMethod]
        public void _006Rational3Comparision()
        {
            var d = CR(-1, 4);
            var c = CR(1, 4);
            var a = CR(3, 12);
            var b = CR(1, 3);

            Assert.IsTrue(a.CompareTo(b) < 0);
            Assert.IsTrue(c<=a);
            Assert.IsFalse(c > b);
            Assert.IsTrue(d < c);
            Assert.IsFalse(d > c);
        }

        [TestMethod]
        public void _006Rational4Operations()
        {
            var r = CR(24, 12);
            Assert.AreEqual(2,r);
            var ir = r.Inverse();
            Assert.AreEqual(CR(1,2),ir);
            
            Assert.AreEqual(1,r*ir);

            var x = (r + ir);
            Assert.AreEqual(CR(5,2), x);
            Assert.AreEqual(5, 2*x);

            r -= ir;
            Assert.AreEqual(CR(6,4),r);

            r *= ir.Inverse();
            Assert.AreEqual(CR(36,12),r);

            r = r.Normalize();
            Assert.AreEqual(CR(18,6),r);

            r = +r;
            Assert.AreEqual(CR(3, 1), r);
        }

        [TestMethod]
        public void _006Rational5OverFlow()
        {
            Assert.IsTrue(CR(2000000000, 4) == CR(1000000000, 2));
            Assert.IsTrue(CR(2000000001, 4) > CR(1000000000, 2));

            Assert.AreEqual(1, CR(2000000001, 2000000000) - CR(1, 2000000000));
            Assert.AreEqual(2, CR(2000000001, 2000000000) + CR(1999999999, 2000000000));

            Assert.AreEqual(1, CR(2000000000, 2147483647) * CR(2147483647, 2000000000));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void _006Rational6DivideByZero()
        {
            var r = CR(0, 1);
            var r2 = CR(1, 1);
            r2 = r2/r;
        }
    }
}
