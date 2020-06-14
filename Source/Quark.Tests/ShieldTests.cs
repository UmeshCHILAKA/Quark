using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Quark.Tests
{
    [TestFixture()]
    public class ShieldTests
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
            Shield.IsOutofRange(5.0, 4.6, 5.5, DummyParameter);
            Shield.IsOutofRange(5.0, 5.0, 5.5, DummyParameter);
            Shield.IsOutofRange(5.0, 4.6, 5.0, DummyParameter);

            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.IsOutofRange(4.0, 4.6, 5.5, DummyParameter));
            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.IsOutofRange(4.599, 4.6, 5.5, DummyParameter));
            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.IsOutofRange(5.50001, 4.6, 5.5, DummyParameter));

            //Negative Numbers
            Shield.IsOutofRange(-5.0, -5.5, -4.6, DummyParameter);
            Shield.IsOutofRange(-5.0, -5.5, -5.0, DummyParameter);
            Shield.IsOutofRange(-5.0, -5.0, -4.6, DummyParameter);

            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.IsOutofRange(-4.0, -5.5, -4.6, DummyParameter));
            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.IsOutofRange(-4.599, -5.5, -4.6, DummyParameter));
            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.IsOutofRange(-5.50001, -5.5, -4.6, DummyParameter));

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
            Shield.IsValidNumber(DummyParameter, 11.57);

            Assert.Throws<ArgumentException>(() => Shield.IsValidNumber(DummyParameter, double.NegativeInfinity));
            Assert.Throws<ArgumentException>(() => Shield.IsValidNumber(DummyParameter, double.PositiveInfinity));
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