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
            var tables = new[] { new Table(2), new Table(2), 
                                 new Table(4), new Table(4) };

            var reservations = new IReservation[0];

            var candidate = new Reservation(4, new DateTime(2024, 06, 07));

            var actual = new MaitreD().Accept(reservations, candidate, tables);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test2()
        {
            var tables = new[] { new Table(2), new Table(2),
                                 new Table(4), new Table(4) };

            var reservations = new IReservation[0];

            var candidate = new Reservation(5, new DateTime(2024, 06, 07));

            var actual = new MaitreD().Accept(reservations, candidate, tables);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Test3()
        {
            var tables = new[] { new Table(2), new Table(2),
                                 new Table(4) };

            var reservations = new IReservation[] { 
                                new Reservation(2, new DateTime(2024, 06, 07))
                               };

            var candidate = new Reservation(4, new DateTime(2024, 06, 07));

            var actual = new MaitreD().Accept(reservations, candidate, tables);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test4()
        {
            var tables = new[] { new Table(2), new Table(2),
                                 new Table(4) };

            var reservations = new IReservation[] {
                                new Reservation(3, new DateTime(2024, 06, 07))
                               };

            var candidate = new Reservation(4, new DateTime(2024, 06, 07));

            var actual = new MaitreD().Accept(reservations, candidate, tables);

            Assert.IsFalse(actual);
        }


    }
}
