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
    public class UnitTest004
    {
        private UnitTest003 ut3 = new UnitTest003();

        public T CreatePies<T>() where T: class 
        {
            var pies = Type.GetType(TypeStrings.Pies).
                GetConstructor(Type.EmptyTypes).Invoke(null) as T;

            return pies;
        }

        public T CreateKon<T>() where T : class
        {
            var kon = Type.GetType(TypeStrings.Kon).
                GetConstructor(Type.EmptyTypes).Invoke(null) as T;

            return kon;
        }

        [TestMethod]
        public void _004IZwierze1KarmieniePsa()
        {
            var pies = CreatePies<IZwierze>();

            Assert.IsTrue(pies.Glodny);
            
            pies.Jedz(10);
            Assert.IsFalse(pies.Glodny);
            pies.Traw(5);
            Assert.IsFalse(pies.Glodny);
            pies.Jedz(20);
            Assert.IsFalse(pies.Glodny);
            pies.Traw(20);
            Assert.IsFalse(pies.Glodny);
            pies.Traw(10);
            Assert.IsTrue(pies.Glodny);
            pies.Jedz(5);
            Assert.IsTrue(pies.Glodny);
            pies.Jedz(1);
            Assert.IsFalse(pies.Glodny);
            
        }

        [TestMethod]
        public void _004IZwierze2UzywanieKonia()
        {
            var type = Type.GetType(TypeStrings.IPojazd);
            Assert.IsNotNull(type, "There is no App.IPojazd interface");

            var jedz = type.GetMethod("Jedz");
            var tankuj = type.GetMethod("Tankuj");
            var paliwo = type.GetProperty("Paliwo");
            var przejechane = type.GetProperty("Przejechane");

            var kon = CreateKon<IZwierze>();

            Assert.IsTrue(kon.Glodny);

            kon.Jedz(10);
            Assert.IsFalse(kon.Glodny);
            kon.Traw(5);
            Assert.IsFalse(kon.Glodny);
            kon.Jedz(20);
            Assert.IsFalse(kon.Glodny);
            jedz.Invoke(kon, new[] {2000M as object});
            Assert.IsFalse(kon.Glodny);
            kon.Traw(10);
            Assert.IsTrue(kon.Glodny);
            kon.Jedz(5);
            Assert.IsTrue(kon.Glodny);
            kon.Jedz(1);
            Assert.IsFalse(kon.Glodny);
            jedz.Invoke(kon, new[] { 2000M as object });
            
            Assert.AreEqual(2100M, przejechane.GetValue(kon));
            Assert.IsTrue(kon.Glodny);
            kon.Jedz(1);
            Assert.IsFalse(kon.Glodny);

            
        }
    }
}
