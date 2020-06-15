using NUnit.Framework;

namespace Quark.Tests
{
    [TestFixture()]
    public class CharExtensionsTests
    {
        [Test]
        public void GetUnicodeValueTest()
        {
            Assert.AreEqual("U+0061", 'a'.ToUnicodeValue());
            Assert.AreEqual("U+0009", '\t'.ToUnicodeValue());
            Assert.AreEqual("U+0020", ' '.ToUnicodeValue());
            Assert.AreEqual("U+0041", 'A'.ToUnicodeValue());
            Assert.AreEqual("U+005C", '\\'.ToUnicodeValue());
        }

        [Test]
        public void ToUrlValueTest()
        {
            Assert.AreEqual("a", 'a'.ToUrlValue());
            Assert.AreEqual("A", 'A'.ToUrlValue());

            Assert.AreEqual("\\", '\\'.ToUrlValue());
            Assert.AreEqual("/", '/'.ToUrlValue());

            //Test for IsControl
            Assert.AreEqual("%09", '\t'.ToUrlValue());
            Assert.AreEqual("%07", '\a'.ToUrlValue());
            Assert.AreEqual("%00", '\0'.ToUrlValue());

            //Test for IsSeparator
            Assert.AreEqual("%20", ' '.ToUrlValue());
            Assert.AreEqual("%0D", '\r'.ToUrlValue());
            Assert.AreEqual("%0A", '\n'.ToUrlValue());

            //Test for IsSurrogate
            const string str = "\U00010F00";
            Assert.AreEqual("%D803", str[0].ToUrlValue());
        }

        [Test]
        public void DisplayValueTest()
        {
            Assert.AreEqual("a", 'a'.ToDisplayValue());
            Assert.AreEqual("A", 'A'.ToDisplayValue());
            Assert.AreEqual("\\", '\\'.ToDisplayValue());

            //Test for IsControl
            Assert.AreEqual("U+0009", '\t'.ToDisplayValue());
            Assert.AreEqual("U+0007", '\a'.ToDisplayValue());
            Assert.AreEqual("U+0000", '\0'.ToDisplayValue());

            //Test for IsSeparator
            Assert.AreEqual("U+0020", ' '.ToDisplayValue());
            Assert.AreEqual("U+000D", '\r'.ToDisplayValue());
            Assert.AreEqual("U+000A", '\n'.ToDisplayValue());

            //Test for IsSurrogate
            const string str = "\U00010F00";
            Assert.AreEqual("U+D803", str[0].ToDisplayValue());
        }
    }
}