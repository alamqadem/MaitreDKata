using MaitreDKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKataTest
{
    [TestClass]
    public class AlternativeTableConfigurationsTest
    {
        [TestMethod]
        public void Test1()
        {
            var seatingDuration = TimeSpan.FromHours(2.5);

            var tables = new ITable[]{
                          new CircularTable(4),
                          new RectangularTable(2), new RectangularTable(2),
                          new RectangularTable(2),
                          new RectangularTable(1), new RectangularTable(2)
                         };

            var reservations = new IReservation[0];

            var candidate = new Reservation(4, new DateTime(2028, 12, 12, 20, 00, 00));

            var actual = new AlternativeTableConfigurationsMaitreD()
                            .Accept(reservations, candidate, tables,
                                    seatingDuration);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test2()
        {
            var seatingDuration = TimeSpan.FromHours(2.5);

            var tables = new ITable[]{
                          new CircularTable(4),
                          new RectangularTable(2), new RectangularTable(2),
                          new RectangularTable(2),
                          new RectangularTable(1), new RectangularTable(2)
                         };

            var reservations = new[]{
                                    new Reservation(
                                        4, 
                                        new DateTime(2028, 12, 12, 19, 00, 00))
                                };

            var candidate = new Reservation(4, 
                                            new DateTime(2028, 12, 12, 20, 00, 00));

            var actual = new AlternativeTableConfigurationsMaitreD()
                            .Accept(reservations, candidate, tables,
                                    seatingDuration);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test3()
        {
            var seatingDuration = TimeSpan.FromHours(2.5);

            var tables = new ITable[]{
                          new CircularTable(4),
                          new RectangularTable(2), new RectangularTable(2),
                          new RectangularTable(2),
                          new RectangularTable(1), new RectangularTable(2)
                         };

            var reservations = new[]{
                                    new Reservation(
                                        4,
                                        new DateTime(2028, 12, 12, 19, 00, 00)),
                                    new Reservation(
                                        2,
                                        new DateTime(2028, 12, 12, 19, 00, 00)),
                                    new Reservation(
                                        2,
                                        new DateTime(2028, 12, 12, 19, 00, 00)),
                                     new Reservation(
                                        2,
                                        new DateTime(2028, 12, 12, 19, 00, 00))
                                };

            var candidate = new Reservation(4,
                                            new DateTime(2028, 12, 12, 20, 00, 00));

            var actual = new AlternativeTableConfigurationsMaitreD()
                            .Accept(reservations, candidate, tables,
                                    seatingDuration);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Test4()
        {
            var seatingDuration = TimeSpan.FromHours(2.5);

            var tables = new ITable[]{
                          new CircularTable(4),
                          new RectangularTable(2), new RectangularTable(2),
                          new RectangularTable(2),
                          new RectangularTable(1), new RectangularTable(2)
                         };

            var reservations = new[]{
                                    new Reservation(
                                        4,
                                        new DateTime(2027, 05, 25, 19, 00, 00)),
                                    new Reservation(
                                        2,
                                        new DateTime(2027, 05, 25, 19, 00, 00)),
                                    new Reservation(
                                        2,
                                        new DateTime(2027, 05, 25, 19, 30, 00)),
                                     new Reservation(
                                        2,
                                        new DateTime(2027, 05, 25, 19, 45, 00))
                                };

            var candidate = new Reservation(3,
                                            new DateTime(2027, 05, 25, 20, 00, 00));

            var actual = new AlternativeTableConfigurationsMaitreD()
                            .Accept(reservations, candidate, tables,
                                    seatingDuration);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test5()
        {
            var seatingDuration = TimeSpan.FromHours(2.5);

            var tables = new ITable[]{
                          new CircularTable(4),
                          new RectangularTable(2), new RectangularTable(2),
                          new RectangularTable(2),
                          new RectangularTable(1), new RectangularTable(2)
                         };

            var reservations = new[]{
                                    new Reservation(
                                        4,
                                        new DateTime(2027, 05, 25, 19, 00, 00)),
                                    new Reservation(
                                        2,
                                        new DateTime(2027, 05, 25, 19, 00, 00)),
                                    new Reservation(
                                        1,
                                        new DateTime(2027, 05, 25, 19, 30, 00))
                                };

            var candidate = new Reservation(6,
                                            new DateTime(2027, 05, 25, 20, 00, 00));

            var actual = new AlternativeTableConfigurationsMaitreD()
                            .Accept(reservations, candidate, tables,
                                    seatingDuration);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test6()
        {
            var seatingDuration = TimeSpan.FromHours(2.5);

            var tables = new ITable[]{
                          new CircularTable(4),
                          new RectangularTable(2), new RectangularTable(2),
                          new RectangularTable(2),
                          new RectangularTable(1), new RectangularTable(2)
                         };

            var reservations = new[]{
                                    new Reservation(
                                        6,
                                        new DateTime(2027, 05, 25, 20, 00, 00)),
                                    new Reservation(
                                        1,
                                        new DateTime(2027, 05, 25, 19, 30, 00))
                                };

            var candidate = new Reservation(6,
                                            new DateTime(2027, 05, 25, 20, 00, 00));

            var actual = new AlternativeTableConfigurationsMaitreD()
                            .Accept(reservations, candidate, tables,
                                    seatingDuration);

            Assert.IsFalse(actual);
        }
    }
}
