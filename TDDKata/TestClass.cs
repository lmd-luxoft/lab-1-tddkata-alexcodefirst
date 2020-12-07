// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;

namespace TDDKata
{
    [TestFixture]
    public class TestClass
    {
        private StringCalc _stringCalc;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            _stringCalc = new StringCalc();
        }

        [Test]
        public void Should_ReturnSum_When_ArgumentsHaveTwoPositiveNumbers()
        {
            string arguments = "1,1";
            int expected = 2;
            int actual = _stringCalc.Sum(arguments);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_ReturnNumber_When_ArgumentsHaveOnlyOnePositiveNumber()
        {
            string arguments = "1";
            int expected = 1;
            int actual = _stringCalc.Sum(arguments);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase("0")]
        public void Should_ReturnZero_When_ArgumementsAreWhiteSpaceOrZero(string arguments)
        {
            int expected = 0;
            int actual = _stringCalc.Sum(arguments);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_ThrowException_When_ArgumementsAreNull()
        {
            string arguments = null;
            int expected = -1;
            int actual = _stringCalc.Sum(arguments);
            Assert.AreEqual(expected, actual);
        }


        [TestCase("1,1,2", 4)]
        [TestCase("1,1,2,3", 7)]
        public void Should_ReturnSum_When_ArgumentsHaveMoreThanTwoNumbers(string arguments, int expected)
        {
            int actual = _stringCalc.Sum(arguments);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,-1")]
        [TestCase("-1,1")]
        [TestCase("-1,-1")]
        public void Should_ThrowException_When_ArgumentsHaveNegativeNumbers(string arguments)
        {
            int expected = -1;
            int actual = _stringCalc.Sum(arguments);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("qwerty")]
        [TestCase("1,qw")]
        [TestCase("az,1")]
        public void Should_ThrowException_When_ArgumentsHaveNoNumbers(string arguments)
        {
            int expected = -1;
            int actual = _stringCalc.Sum(arguments);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,1", 2)]
        [TestCase("1/n1", 2)]
        public void Should_ReturnSum_When_ArgumentsSeparatotIsCorrect(string arguments, int expected)
        {
            int actual = _stringCalc.Sum(arguments);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//1;1.3", 4)]
        [TestCase("//1.1", 2)]
        public void Should_ReturnSum_When_ArgumentsContainSpecialSeparator(string arguments, int expected)
        {
            int actual = _stringCalc.Sum(arguments);
            Assert.AreEqual(expected, actual);
        }

    }
}
