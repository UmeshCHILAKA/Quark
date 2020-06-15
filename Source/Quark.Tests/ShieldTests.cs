using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Quark.Tests
{
    [TestFixture()]
    internal class ShieldTests
    {
        const string DummyParameter = "DummyParam";
        [Test()]
        public void IsNullTest()
        {
            Shield.IsNull(DummyParameter, new object());
            Assert.Throws<ArgumentNullException>(() => Shield.IsNull(DummyParameter, null));
        }

        [Test()]
        public void IsOutOfRangeTests()
        {
            //Positive Numbers
            Shield.IsOutofRange(DummyParameter, 5.0, 4.6, 5.5);
            Shield.IsOutofRange(DummyParameter, 5.0, 5.0, 5.5);
            Shield.IsOutofRange(DummyParameter, 5.0, 4.6, 5.0);

            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.IsOutofRange(DummyParameter, 4.0, 4.6, 5.5));
            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.IsOutofRange(DummyParameter, 4.599, 4.6, 5.5));
            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.IsOutofRange(DummyParameter, 5.50001, 4.6, 5.5));

            //Negative Numbers
            Shield.IsOutofRange(DummyParameter, -5.0, -5.5, -4.6);
            Shield.IsOutofRange(DummyParameter, -5.0, -5.5, -5.0);
            Shield.IsOutofRange(DummyParameter, -5.0, -5.0, -4.6);

            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.IsOutofRange(DummyParameter, -4.0, -5.5, -4.6));
            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.IsOutofRange(DummyParameter, -4.599, -5.5, -4.6));
            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.IsOutofRange(DummyParameter, -5.50001, -5.5, -4.6));

        }

        [Test()]
        public void IsNanTests()
        {
            Shield.IsNan(DummyParameter, 88.28);
            Shield.IsNan(DummyParameter, double.NegativeInfinity);
            Shield.IsNan(DummyParameter, double.PositiveInfinity);

            Assert.Throws<ArgumentException>(() => Shield.IsNan(DummyParameter, double.NaN));

        }

        [Test()]
        public void IsValidNumberTestes()
        {
            Shield.IsInvalidNumber(DummyParameter, 11.57);

            Assert.Throws<ArgumentException>(() => Shield.IsInvalidNumber(DummyParameter, double.NegativeInfinity));
            Assert.Throws<ArgumentException>(() => Shield.IsInvalidNumber(DummyParameter, double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => Shield.IsNan(DummyParameter, double.NaN));
        }

        [Test()]
        public void IsCollectionEmptyTests()
        {
            Shield.IsCollectionEmpty(DummyParameter, new List<int> { 6 });

            Assert.Throws<ArgumentNullException>(() => Shield.IsCollectionEmpty(DummyParameter, null));
            Assert.Throws<ArgumentException>(() => Shield.IsCollectionEmpty(DummyParameter, new List<int>()));
        }
    }
}