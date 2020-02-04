using MaitreDKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKataTest
{
    [TestClass]
    public class SecondSeatingsTests
    {
        [TestMethod]
        public void Test1()
        {
            var seatingDuration = TimeSpan.FromHours(2);

            var tables = new[] { new RectangularTable(2), new RectangularTable(2), 
                                 new RectangularTable(4) };

            var reservations = new[] {
                    new Reservation(4, new DateTime(2023, 10, 22, 18, 00, 00))
            };

            var candidate = new Reservation(
                                3, new DateTime(2023, 10, 22, 20, 00, 00));

            var actual = new SecondSeatingsMaitreD()
                                .Accept(reservations, candidate,
                                        tables, seatingDuration);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test2()
        {
            var seatingDuration = TimeSpan.FromHours(2.5);

            var tables = new[] { new RectangularTable(2), new RectangularTable(4), 
                                 new RectangularTable(4) };

            var reservations = new[] {
                    new Reservation(2, new DateTime(2023, 10, 22, 18, 00, 00)),
                    new Reservation(1, new DateTime(2023, 10, 22, 18, 15, 00)),
                    new Reservation(2, new DateTime(2023, 10, 22, 17, 45, 00))
            };

            var candidate = new Reservation(
                                3, new DateTime(2023, 10, 22, 20, 00, 00));

            var actual = new SecondSeatingsMaitreD()
                                .Accept(reservations, candidate,
                                        tables, seatingDuration);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Test3()
        {
            var seatingDuration = TimeSpan.FromHours(2.5);

            var tables = new[] { new RectangularTable(2), new RectangularTable(4), 
                                 new RectangularTable(4) };

            var reservations = new[] {
                    new Reservation(2, new DateTime(2023, 10, 22, 18, 00, 00)),
                    new Reservation(2, new DateTime(2023, 10, 22, 17, 45, 00))
            };

            var candidate = new Reservation(
                                3, new DateTime(2023, 10, 22, 20, 00, 00));

            var actual = new SecondSeatingsMaitreD()
                                .Accept(reservations, candidate,
                                        tables, seatingDuration);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test4()
        {
            var seatingDuration = TimeSpan.FromHours(2.5);

            var tables = new[] { new RectangularTable(2), new RectangularTable(4), 
                                 new RectangularTable(4) };

            var reservations = new[] {
                    new Reservation(2, new DateTime(2023, 10, 22, 18, 00, 00)),
                    new Reservation(1, new DateTime(2023, 10, 22, 18, 15, 00)),
                    new Reservation(2, new DateTime(2023, 10, 22, 17, 45, 00))
            };

            var candidate = new Reservation(
                                3, new DateTime(2023, 10, 22, 20, 15, 00));

            var actual = new SecondSeatingsMaitreD()
                                .Accept(reservations, candidate,
                                        tables, seatingDuration);

            Assert.IsTrue(actual);
        }
    }
}
