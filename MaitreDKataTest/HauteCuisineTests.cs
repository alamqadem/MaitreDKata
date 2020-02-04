using MaitreDKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKataTest
{
    [TestClass]
    public class HauteCuisineTests
    {
        [TestMethod]
        public void Test1()
        {
            var tables = new[] { new RectangularTable(2), new RectangularTable(2), 
                                 new RectangularTable(4), new RectangularTable(4) };

            var reservations = new IReservation[0];

            var candidate = new Reservation(4, new DateTime(2024, 06, 07));

            var actual = new HauteCuisineMaitreD()
                            .Accept(reservations, candidate, 
                                    tables, TimeSpan.MaxValue);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test2()
        {
            var tables = new[] { new RectangularTable(2), new RectangularTable(2),
                                 new RectangularTable(4), new RectangularTable(4) };

            var reservations = new IReservation[0];

            var candidate = new Reservation(5, new DateTime(2024, 06, 07));

            var actual = new HauteCuisineMaitreD()
                            .Accept(reservations, candidate, 
                                    tables, TimeSpan.MaxValue);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Test3()
        {
            var tables = new[] { new RectangularTable(2), new RectangularTable(2),
                                 new RectangularTable(4) };

            var reservations = new IReservation[] { 
                                new Reservation(2, new DateTime(2024, 06, 07))
                               };

            var candidate = new Reservation(4, new DateTime(2024, 06, 07));

            var actual = new HauteCuisineMaitreD()
                            .Accept(reservations, candidate, 
                                    tables, TimeSpan.MaxValue);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test4()
        {
            var tables = new[] { new RectangularTable(2), new RectangularTable(2),
                                 new RectangularTable(4) };

            var reservations = new IReservation[] {
                                new Reservation(3, new DateTime(2024, 06, 07))
                               };

            var candidate = new Reservation(4, new DateTime(2024, 06, 07));

            var actual = new HauteCuisineMaitreD()
                            .Accept(reservations, candidate, 
                                    tables, TimeSpan.MaxValue);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Test5() // best fitting configuration
        {
            var tables = new[] { new RectangularTable(3), new RectangularTable(2),
                                 new RectangularTable(4) };

            var reservations = new IReservation[] {
                                new Reservation(4, new DateTime(2022, 10, 11)),
                                new Reservation(2, new DateTime(2022, 10, 11))
                               };

            var candidate = new Reservation(3, new DateTime(2022, 10, 11));

            var actual = new HauteCuisineMaitreD()
                            .Accept(reservations, candidate, 
                                    tables, TimeSpan.MaxValue);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test6() // you should not consider the time
        {
            var tables = new[] { new RectangularTable(3), new RectangularTable(2),
                                 new RectangularTable(4) };

            var reservations = new IReservation[] {
                                new Reservation(4, new DateTime(2022, 10, 11)),
                                new Reservation(2, new DateTime(2022, 10, 11)),
                                new Reservation(3, new DateTime(2022, 10, 11, 17, 00, 00))
                               };

            var candidate = new Reservation(3, new DateTime(2022, 10, 11));

            var actual = new HauteCuisineMaitreD()
                            .Accept(reservations, candidate,
                                    tables, TimeSpan.MaxValue);

            Assert.IsFalse(actual);
        }


    }
}
