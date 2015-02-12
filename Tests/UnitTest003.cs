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
    public class UnitTest003
    {
        public T CreateRower<T>() where T: class 
        {
            var rower = Type.GetType(TypeStrings.Rower).
                GetConstructor(Type.EmptyTypes).Invoke(null) as T;

            return rower;
        }

        public T CreateAutobus<T>() where T : class
        {
            var autobus = Type.GetType(TypeStrings.Autobus).
                GetConstructor(Type.EmptyTypes).Invoke(null) as T;

            return autobus;
        }

        public T CreateOsobowka<T>(decimal spalanie, decimal pojemnosc) where T : class
        {
            var osobowka = Type.GetType(TypeStrings.Osobowka).
                GetConstructor(new []{typeof(decimal), typeof(decimal)}).Invoke(new []{(object)spalanie,(object)pojemnosc}) as T;

            return osobowka;
        }

        public T CreateBenzyna<T>()
        {
            var type = Type.GetType(TypeStrings.Paliwo);
            var field = type.GetField("Benzyna", (BindingFlags.Static | BindingFlags.Public));
            var x = field.GetValue(null);

            return (T) x;
        }

        public T CreateOlej<T>()
        {
            var x = Type.GetType(TypeStrings.Paliwo).
                GetField("Olej", BindingFlags.Static | BindingFlags.Public).GetValue(null);

            return (T)x;
        }

        public T CreateNieDotyczy<T>()
        {
            var x = Type.GetType(TypeStrings.Paliwo).
                GetField("NieDotyczy", BindingFlags.Static | BindingFlags.Public).GetValue(null);

            return (T)x;
        }

        public void TestTankuj(dynamic pojazd, dynamic paliwo)
        {
            pojazd.Tankuj(20, paliwo);
        }

        public void TestJedz(dynamic pojazd)
        {
            pojazd.Jedz(250);
        }

        public void TestBig(dynamic pojazd, dynamic paliwo)
        {
            pojazd.Jedz(10);
            try
            {
                pojazd.Tankuj(20, paliwo);
            }
            catch (NotSupportedException) { }
            pojazd.Jedz(500);
            try
            {
                pojazd.Tankuj(100, paliwo);
            }catch (NotSupportedException) { }
            pojazd.Jedz(10);
            pojazd.Jedz(20);
            try
            {
                pojazd.Tankuj(10, paliwo);
            }catch (NotSupportedException) { }
            pojazd.Jedz(1000);
        }

        public void TestBigKlima(dynamic pojazd, dynamic paliwo)
        {
            pojazd.Jedz(10);
            try
            {
                pojazd.Tankuj(20, paliwo);
            }
            catch (NotSupportedException) { }
            pojazd.Klimatyzacja = true;
            pojazd.Jedz(500);
            try
            {
                pojazd.Tankuj(100, paliwo);
            }
            catch (NotSupportedException) { }
            pojazd.Jedz(10);
            pojazd.Klimatyzacja = false;
            pojazd.Jedz(20);
            try
            {
                pojazd.Tankuj(10, paliwo);
            }
            catch (NotSupportedException) { }
            pojazd.Klimatyzacja = true;
            pojazd.Jedz(1000);
        }

        [TestMethod]
        public void _003IPojazd1Rower()
        {
            var rower = CreateRower<dynamic>();
            Assert.IsNotNull(rower);
            try
            {
                rower.Tankuj(10, CreateBenzyna<dynamic>());
                Assert.Fail("Should throw NotSupportedException");
            }
            catch (NotSupportedException)
            {
            }
            catch (Exception ex)
            {
                Assert.Fail("Wrong exception "+ex.GetType().Name);
            }
            try
            {
                rower.Tankuj(20, CreateOlej<dynamic>());
                Assert.Fail("Should throw NotSupportedException");
            }
            catch (NotSupportedException)
            {
            }
            catch (Exception ex)
            {
                Assert.Fail("Wrong exception " + ex.GetType().Name);
            }
            TestBig(rower, CreateBenzyna<dynamic>());
            Assert.AreEqual(1540, rower.Przejechane);
            Assert.AreEqual(0, rower.Paliwo);
        }

        [TestMethod]
        public void _003IPojazd2Autobus()
        {
            var pojazd = CreateAutobus<dynamic>();
            Assert.IsNotNull(pojazd);
            try
            {
                pojazd.Tankuj(10, CreateBenzyna<dynamic>());
                Assert.Fail("Should throw ArgumentException");
            }
            catch (ArgumentException)
            {
            }
            catch (Exception ex)
            {
                Assert.Fail("Wrong exception " + ex.GetType().Name);
            }


                pojazd.Tankuj(20, CreateOlej<dynamic>());
                

            TestBig(pojazd, CreateOlej<dynamic>());
            Assert.AreEqual(750, pojazd.Przejechane);
            Assert.AreEqual(0, pojazd.Paliwo);
        }

        [TestMethod]
        public void _003IPojazd3Osobowka()
        {
            var pojazd = CreateOsobowka<dynamic>(4,40);
            Assert.IsNotNull(pojazd);
            

                pojazd.Tankuj(10, CreateBenzyna<dynamic>());
               
            try
            {
                pojazd.Tankuj(20, CreateOlej<dynamic>());
                Assert.Fail("Should throw ArgumentException");
            }
            catch (ArgumentException)
            {
            }
            catch (Exception ex)
            {
                Assert.Fail("Wrong exception " + ex.GetType().Name);
            }

            TestBig(pojazd, CreateBenzyna<dynamic>());
            Assert.AreEqual(1540, pojazd.Przejechane);
            Assert.AreEqual(0, pojazd.Paliwo);

            TestBigKlima(pojazd, CreateBenzyna<dynamic>());
            Assert.AreEqual(2770, pojazd.Przejechane);
            Assert.AreEqual(0, pojazd.Paliwo);
        }

        [TestMethod]
        public void _003IPojazd4TestInterfejsu()
        {
            var type = Type.GetType(TypeStrings.IPojazd);
            Assert.IsNotNull(type,"There is no App.IPojazd interface");

            var jedz = type.GetMethod("Jedz");
            var tankuj = type.GetMethod("Tankuj");
            var paliwo = type.GetProperty("Paliwo");
            var przejechane = type.GetProperty("Przejechane");

            var pojazdy = new[]
            {
                new Tuple<dynamic,dynamic>(CreateBenzyna<dynamic>(),CreateRower<dynamic>()),
                new Tuple<dynamic,dynamic>(CreateOlej<dynamic>(),CreateAutobus<dynamic>()),
                new Tuple<dynamic,dynamic>(CreateBenzyna<dynamic>(),CreateOsobowka<dynamic>(4,80))
            };

            foreach (var tuple in pojazdy)
            {
                try
                {
                    tankuj.Invoke(tuple.Item2, new[] {20M, tuple.Item1});
                }
                catch (TargetInvocationException)
                {
                }
                jedz.Invoke(tuple.Item2, new[] {100M as object});
                try
                {
                    tankuj.Invoke(tuple.Item2, new[] { 80M, tuple.Item1 });
                }
                catch (TargetInvocationException)
                {
                }
                jedz.Invoke(tuple.Item2, new[] { 450M as object });
            }

            Assert.AreEqual(0m, paliwo.GetValue(pojazdy[0].Item2));
            Assert.AreEqual(550m, przejechane.GetValue(pojazdy[0].Item2));

            Assert.AreEqual(0m, paliwo.GetValue(pojazdy[1].Item2));
            Assert.AreEqual(500m, przejechane.GetValue(pojazdy[1].Item2));

            Assert.AreEqual(0m, paliwo.GetValue(pojazdy[1].Item2));
            Assert.AreEqual(500m, przejechane.GetValue(pojazdy[1].Item2));
        }


    }
}
