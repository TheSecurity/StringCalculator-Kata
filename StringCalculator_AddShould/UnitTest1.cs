using System;
using Xunit;
using kata1_StringCalculator;

namespace UnitTests
{
    public class StringCalculator_AddShould
    {
        [Theory]
        [InlineData(0,"0")]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        public void ReturnNumber_AddedNumber(int expected, string input)
        {
            var result = Calculator.Add(input);

            Assert.Equal(expected,result);
        }

        [Fact]
        public void ReturnZero_StringIsEmpty()
        {
            var result = Calculator.Add("");

            Assert.Equal(0,result);
        }

        [Theory]
        [InlineData(3, ",1,2")]
        [InlineData(4, "1,,3")]
        [InlineData(3, "1,2,,,")]
        public void ReturnSum_NumbersString(int expected, string input)
        {
            var result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, "1\n2\n3")]
        [InlineData(5, "1,3\n1")]
        [InlineData(7, "2,2,3")]
        public void ReturnSum_NumbersSplittedViaCommasOrNewLine(int expected, string input)
        {
            var result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        //[delimiter]\n[numbers]
        [Theory]
        [InlineData(6, "//[a]\n1a2a3")]
        [InlineData(11, "//[.]\n5.2,3\n1")]
        public void ReturnSum_NumbersSplittedViaCustomDelimiter(int expected, string input)
        {
            var result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, "-1,2")]
        public void ThrowsException_NegativeNumbersEntered(int expected, string input)
        {
            void TestCode() => Calculator.Add(input);
            var exception = Assert.Throws<NegativeNumberException>((Action) TestCode);
            Assert.Contains("-1", exception.Message);
        }

        [Theory]
        [InlineData(3, "2,1001,1")]
        [InlineData(1001, "1,1000")]
        [InlineData(1000, "1111,1000,1002")]
        public void ReturnNumbersLower1000(int expected, string input)
        {
            var result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, "//[|||]\n1|||2|||3")]
        public void ReturnsNumber_NumbersWithMultipleDelimiterString(int expected, string input)
        {
            var result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, "//[|][%]\n1|2%3")]
        public void ReturnsNumber_NumbersWithMultipleDifferentDelimiters(int expected, string input)
        {
            var result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, "//[||][%]\n1||2%3")]
        public void ReturnsNumber_NumbersWithMultipleDifferentLengthDelimiters(int expected, string input)
        {
            var result = Calculator.Add(input);

            Assert.Equal(expected, result);
        }
    }
}
