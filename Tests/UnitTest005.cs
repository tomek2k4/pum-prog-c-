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
    public class UnitTest005
    {
        [TestMethod]
        public void _005GcdLcm1GCD()
        {
            var rh =
                Type.GetType(TypeStrings.RationalHelper).
                    GetConstructor(Type.EmptyTypes).Invoke(null) as IRationalHelper;

            Assert.AreEqual(1, rh.Gcd(1, 5));
            Assert.AreEqual(5, rh.Gcd(5, 10));
            Assert.AreEqual(4, rh.Gcd(16, 12));
            Assert.AreEqual(60,rh.Gcd(60,60));
            Assert.AreEqual(0 ,rh.Gcd(0,0));
            Assert.AreEqual(5 ,rh.Gcd(5,0));
            Assert.AreEqual(5, rh.Gcd(0, 5));
            Assert.AreEqual(4, rh.Gcd(-16, 12));
            Assert.AreEqual(4, rh.Gcd(16, -12));
            Assert.AreEqual(4, rh.Gcd(-16, -12));

        }


        [TestMethod]
        public void _005GcdLcm2LCM()
        {
            var rh =
                Type.GetType(TypeStrings.RationalHelper).
                    GetConstructor(Type.EmptyTypes).Invoke(null) as IRationalHelper;

            Assert.AreEqual(5, rh.Lcm(1, 5));
            Assert.AreEqual(10, rh.Lcm(5, 10));
            Assert.AreEqual(48, rh.Lcm(16, 12));
            Assert.AreEqual(60, rh.Lcm(60, 60));
            Assert.AreEqual(48, rh.Lcm(-16, 12));
            Assert.AreEqual(48, rh.Lcm(16, -12));
            Assert.AreEqual(48, rh.Lcm(-16, -12));
            Assert.AreEqual(0, rh.Lcm(0, 5));
            Assert.AreEqual(0, rh.Lcm(5, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void _005GcdLcm2DivideByZero()
        {
            var rh =
                Type.GetType(TypeStrings.RationalHelper).
                    GetConstructor(Type.EmptyTypes).Invoke(null) as IRationalHelper;

            rh.Lcm(0, 0);
        }


        [TestMethod]
        public void _005GcdLcm2OverFlow()
        {
            var rh =
                Type.GetType(TypeStrings.RationalHelper).
                    GetConstructor(Type.EmptyTypes).Invoke(null) as IRationalHelper;

            Assert.AreEqual(2000000000, rh.Lcm(2000000000, 1000000000));
            Assert.AreEqual(2000000000, rh.Lcm(-2000000000, 1000000000));

            Assert.AreEqual(60, rh.Lcm(60, 60));
        }
    }
}
