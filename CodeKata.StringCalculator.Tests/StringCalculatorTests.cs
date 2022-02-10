using System;
using Xunit;

namespace CodeKata.StringCalculator.Tests
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator calc;

        public StringCalculatorTests()
        {
            calc = new StringCalculator();
        }

        [Fact]
        public void StringCalculator_Can_Construct()
        {    
            Assert.NotNull(calc);
        }

        [Fact]
        public void StringCalculator_Add_EmptyString_ReturnsZero()
        {
            Assert.Equal(0, calc.Add(""));
        }

        [Fact]
        public void StringCalculator_Add_One_ReturnsOne()
        {
            Assert.Equal(1m, calc.Add("1"));
        }

        [Fact]
        public void StringCalculator_Add_OneAndTwo_ReturnsThree()
        {
            Assert.Equal(3m, calc.Add("1,2"));
        }

        [Fact]
        public void StringCalculator_Add_Many_ReturnsSum()
        {
            Assert.Equal(54m, calc.Add("1,2,44,7"));
        }

        [Fact]
        public void StringCalculator_Add_OneTwoThree_WithNewLine_AndCommas_ReturnsSum()
        {
            Assert.Equal(6m, calc.Add("1,2\n3"));
        }

        [Fact]
        public void StringCalculator_Add_One_WithEmptyEntries_ReturnsOne()
        {
            Assert.Equal(1m, calc.Add("1,\n"));
        }

        [Fact]
        public void StringCalculator_SpecifyDelimiter_Add_OneAndTwo_ReturnsThree()
        {
            Assert.Equal(3m, calc.Add("//;\n1;2"));
        }


        [Fact]
        public void StringCalculator_WithNegative_ThrowsException()
        {
            Action act = () => calc.Add("1,2,-7");
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Negatives not allowed", exception.Message);
        }
    }
}
