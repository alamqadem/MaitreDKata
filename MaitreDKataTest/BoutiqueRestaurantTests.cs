using MaitreDKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MaitreDKataTest
{
    [TestClass]
    public class BoutiqueRestaurantTests
    {
        [TestMethod]
        public void Test1()
        {
            var reservations = new Reservation[0];

            var candidate = new QuantityOnlyReservation(1);

            var tables = new[] { new RectangularTable(12) };

            var actual = new BoutiqueRestaurantMaitreD()
                            .Accept(reservations, candidate, 
                                    tables, TimeSpan.MaxValue);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test2()
        {
            var reservations = new Reservation[0];

            var candidate = new QuantityOnlyReservation(13);

            var tables = new[] { new RectangularTable(12) };

            var actual = new BoutiqueRestaurantMaitreD()
                            .Accept(reservations, candidate, 
                                    tables, TimeSpan.MaxValue);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Test3()
        {
            var reservations = new Reservation[0];

            var candidate = new QuantityOnlyReservation(12);

            var tables = new[] { new RectangularTable(12) };

            var actual = new BoutiqueRestaurantMaitreD()
                            .Accept(reservations, candidate, 
                                    tables, TimeSpan.MaxValue);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test4()
        {
            var reservations = new IReservation[] { 
                new Reservation(2, new DateTime(2023, 09, 14)) 
            };

            var candidate = new Reservation(3, new DateTime(2023, 09, 14));

            var tables = new[] { new RectangularTable(4) };

            var actual = new BoutiqueRestaurantMaitreD()
                            .Accept(reservations, candidate, 
                                    tables, TimeSpan.MaxValue);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Test5()
        {
            var reservations = new IReservation[] {
                new Reservation(2, new DateTime(2023, 09, 14))
            };

            var candidate = new Reservation(3, new DateTime(2023, 09, 14));

            var tables = new[] { new RectangularTable(10) };

            var actual = new BoutiqueRestaurantMaitreD()
                            .Accept(reservations, candidate, 
                                    tables, TimeSpan.MaxValue);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test6()
        {
            var reservations = new IReservation[] {
                new Reservation(3, new DateTime(2023, 09, 14)),
                new Reservation(2, new DateTime(2023, 09, 14)),
                new Reservation(3, new DateTime(2023, 09, 14))
            };

            var candidate = new Reservation(3, new DateTime(2023, 09, 14));

            var tables = new[] { new RectangularTable(10) };

            var actual = new BoutiqueRestaurantMaitreD()
                            .Accept(reservations, candidate, 
                                    tables, TimeSpan.MaxValue);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Test7()
        {
            var reservations = new IReservation[] {
                new Reservation(2, new DateTime(2023, 09, 15))
            };

            var candidate = new Reservation(3, new DateTime(2023, 09, 14));

            var tables = new[] { new RectangularTable(4) };

            var actual = new BoutiqueRestaurantMaitreD()
                            .Accept(reservations, candidate, 
                                    tables, TimeSpan.MaxValue);

            Assert.IsTrue(actual);
        }
    }
}
