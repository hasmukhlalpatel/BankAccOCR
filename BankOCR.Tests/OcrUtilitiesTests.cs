using BankOCR.Implementations;
using Xunit;

namespace BankOCR.Tests
{
    public class OcrUtilitiesTests
    {
        private const string ConstLine1 = " _     _  _     _  _  _  _  _ ";
        private const string ConstLine2 = "| |  | _| _||_||_ |_   ||_||_|";
        private const string ConstLine3 = "|_|  ||_  _|  | _||_|  ||_| _|";
        private const string ConstLine4 = "";

        [Theory]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(9)]
        [InlineData(0)]
        public void VerifyDigit(int digit)
        {
            var lines = new string[] { ConstLine1, ConstLine2, ConstLine3, ConstLine4 };

            var signature = OcrUtilities.GetDigiteSignature(lines, digit);
            var result = OcrUtilities.GetDigitFromSignature(signature);

            Assert.Equal(digit, result);
        }

        [Fact]
        public void Test1()
        {
            var lines = new string[] {ConstLine1, ConstLine2, ConstLine3, ConstLine4};
            var result = OcrUtilities.GetDigiteSignature(lines, 0);
            var result5 = OcrUtilities.GetDigiteSignature(lines, 5);
            var sig = OcrUtilities.GetDigitFromSignature(result5);

            var accountDigits = new BankAccountOcrParser().Parse(lines);

            var result1= new BankAccountOcrValidator().Validate(accountDigits);


        }


    }
}