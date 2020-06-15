using NUnit.Framework;

namespace Quark.Tests
{
    [TestFixture]
    internal class DoubleExtensionsTests
    {
        [Test()]
        public void LimitToTest()
        {
            double num = 4.999;
            Assert.AreEqual(5, num.LimitTo(5, 25));
            num = 5;
            Assert.AreEqual(5, num.LimitTo(5, 25));
            num = 15;
            Assert.AreEqual(15, num.LimitTo(5, 25));

            num = 25;
            Assert.AreEqual(25, num.LimitTo(5, 25));
            num = 25.0000000001;
            Assert.AreEqual(25, num.LimitTo(5, 25));

            num = 4.9999;
            Assert.AreEqual(45, num.LimitTo(45, 75));
            num = 45;
            Assert.AreEqual(45, num.LimitTo(45, 75));
            num = 65;
            Assert.AreEqual(65, num.LimitTo(45, 75));

            num = 75;
            Assert.AreEqual(75, num.LimitTo(45, 75));
            num = 125;
            Assert.AreEqual(75, num.LimitTo(45, 75));
        }

        [Test()]
        public void HasValueTest()
        {
            double number = 11.57;
            Assert.IsTrue(number.HasValue());

            number = -11.57;
            Assert.IsTrue(number.HasValue());

            number = double.NegativeInfinity;
            Assert.IsFalse(number.HasValue());

            number = double.PositiveInfinity;
            Assert.IsFalse(number.HasValue());

            number = double.NaN;
            Assert.IsFalse(number.HasValue());
        }
    }
}
