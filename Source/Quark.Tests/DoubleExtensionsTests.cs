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


        [Test]
        public void ToStringTest()
        {
            double number = 9.986730539;

            Assert.AreEqual("10", number.ToString(DecimalPlaces.None));
            Assert.AreEqual("10.0", number.ToString(DecimalPlaces.One));
            Assert.AreEqual("9.99", number.ToString(DecimalPlaces.Two));
            Assert.AreEqual("9.987", number.ToString(DecimalPlaces.Three));
            Assert.AreEqual("9.9867", number.ToString(DecimalPlaces.Four));
            Assert.AreEqual("9.98673", number.ToString(DecimalPlaces.Five));
            Assert.AreEqual("9.986731", number.ToString(DecimalPlaces.Six));
            Assert.AreEqual("9.9867305", number.ToString(DecimalPlaces.Seven));
            Assert.AreEqual("9.98673054", number.ToString(DecimalPlaces.Eight));
            Assert.AreEqual("9.986730539", number.ToString(DecimalPlaces.Nine));
            Assert.AreEqual("9.9867305390", number.ToString(DecimalPlaces.Ten));
            Assert.AreEqual("9.986730539", number.ToString(DecimalPlaces.All));

            number = double.NegativeInfinity;
            Assert.AreEqual("∞", number.ToString(DecimalPlaces.All));
            number = double.PositiveInfinity;
            Assert.AreEqual("∞", number.ToString(DecimalPlaces.All));

            DoubleExtensions.Infinity_Representation = "INF";
            number = double.NegativeInfinity;
            Assert.AreEqual("INF", number.ToString(DecimalPlaces.All));
            number = double.PositiveInfinity;
            Assert.AreEqual("INF", number.ToString(DecimalPlaces.All));


            number = double.NaN;
            Assert.AreEqual("<>", number.ToString(DecimalPlaces.All));

            DoubleExtensions.Infinity_Representation = "NaN";
            number = double.NegativeInfinity;
            Assert.AreEqual("NaN", number.ToString(DecimalPlaces.All));
        }
    }
}
