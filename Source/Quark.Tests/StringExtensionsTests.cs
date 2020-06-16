using NUnit.Framework;
using System;

namespace Quark.Tests
{
    internal class StringExtensionsTests
    {
        [Test()]
        public void LimitCharsTest()
        {
            const string OrgString = "12345678901234567890";
            const string stringAll = OrgString;
            const string string15 = "123456789012...";
            const string string5 = "12...";

            string longString = OrgString;

            Assert.AreEqual(stringAll, longString.LimitChars(50));
            Assert.AreEqual(OrgString, longString);

            Assert.AreEqual(string15, longString.LimitChars(15));
            Assert.AreEqual(OrgString, longString);

            Assert.AreEqual(string5, longString.LimitChars(5));
            Assert.AreEqual(OrgString, longString);

            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(() => longString.LimitChars(-23)));
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(() => longString.LimitChars(2)));
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(() => longString.LimitChars(3)));
        }

        [Test()]
        public void GetDoubleTest()
        {
            Assert.AreEqual(5.45, "5.45".GetDouble());
            Assert.AreEqual(-5.45, "-5.45".GetDouble());

            Assert.AreEqual(5.45, "5.450000".GetDouble());
            Assert.AreEqual(-5.45, "-5.4500000000".GetDouble());
        }

        [Test()]
        public void RemoveEmptyLineAtEndTest()
        {
            var data = "Hello with end lines\r\n\r\n\r\n";
            Assert.AreEqual("Hello with end lines\r\n\r\n", data.RemoveEmptyLineAtEnd());

            data = "Hello without end line";
            Assert.AreEqual(data, data.RemoveEmptyLineAtEnd());

            data = null;
            Assert.Throws<ArgumentNullException>(() => data.RemoveEmptyLineAtEnd());
        }

        [Test()]
        public void RemoveEmptyLinesAtEndTest()
        {
            var data = "Hello with end lines\r\n\r\n\r\n";
            Assert.AreEqual("Hello with end lines", data.RemoveEmptyLinesAtEnd());

            data = "Hello without end line";
            Assert.AreEqual(data, data.RemoveEmptyLinesAtEnd());

            data = null;
            Assert.Throws<ArgumentNullException>(() => data.RemoveEmptyLinesAtEnd());
        }
    }
}