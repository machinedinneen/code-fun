using NUnit.Framework;
using System;

namespace StringCalculator
{
    public class StringCalculatorTest
    {

        private StringCalculator _target;

        [SetUp]
        public void SetUp()
        {
            _target = new StringCalculator();
        }
        [Test]
        public void StringCalculator_Add_NullOrEmptyReturnsZero()
        {
            var result = _target.Add(string.Empty);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void StringCalculator_Add_HandleOneNumber()
        {
            string oneNum = "2";

            var oneResult = _target.Add(oneNum);
            Assert.AreEqual(2, oneResult);
        }

        [Test]
        public void StringCalculator_Add_HandleMulitpleNumbers()
        {
            string twoNums = "4,2";
            string threeNums = "3,1,6";

            var twoResult = _target.Add(twoNums);
            Assert.AreEqual(6, twoResult);

            var threeResult = _target.Add(threeNums);
            Assert.AreEqual(10, threeResult);
        }

        [Test]
        public void StringCalculator_Add_HandleLineBreakAndComma()
        {
            string number = "1\n2,3,412";

            var result = _target.Add(number);
            Assert.AreEqual(418, result);
        }

        [Test]
        public void StringCalculator_Add_HandleSingleDelimiter()
        {
            string number = "//;\n1;2";

            var result = _target.Add(number);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void StringCalculator_Add_NegativeNumberThrowsException()
        {
            string numbers = "1,5,2,-2";
            string errorMessage = "negatives not allowed -2";

            string multNegNums = "1,-5,2,-2";
            string errorMessage2 = "negatives not allowed -5 -2";

            var e = Assert.Throws<ArgumentException>(
                () => _target.Add(numbers));

            Assert.AreEqual(errorMessage, e.Message);

            var e2 = Assert.Throws<ArgumentException>(
                () => _target.Add(multNegNums));

            Assert.AreEqual(errorMessage, e.Message);
            Assert.AreEqual(errorMessage2, e2.Message);
        }

        [Test]
        public void StringCalculator_Add_IgnoreLargeNumbers()
        {
            string number = "4,22,4221,12";

            var result = _target.Add(number);
            Assert.AreEqual(38, result);
        }

        [Test]
        public void StringCalculator_Add_AnyLengthDelimiter()
        {
            string number = "//[***]\n1***2***3";

            var result = _target.Add(number);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void StringCalculator_Add_MultipleDelimiters()
        {
            string number = "//[*][%]\n1*2%3";

            var result = _target.Add(number);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void StringCalculator_Add_MultipleDelimitersAnyLength()
        {
            string number = "//[***][%%%]\n1***2%%%3";

            var result = _target.Add(number);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void StringCalculator_Add_HandleIdenticalDefaultDelimiter()
        {
            string number = "//[\n1[2";

            var result = _target.Add(number);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void StringCalculator_Add_HandleSpaceDelimiter()
        {
            string number = "//[ ]\n1 2 3";

            var result = _target.Add(number);
            Assert.AreEqual(6, result);
        }
    }
}
