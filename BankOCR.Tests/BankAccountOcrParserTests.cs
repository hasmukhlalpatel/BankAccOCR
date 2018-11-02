using BankOCR.Exceptions;
using BankOCR.Implementations;
using Xunit;

namespace BankOCR.Tests
{
    public class BankAccountOcrParserTests
    {
        private IBankAccountOcrParser _parserService;

        public BankAccountOcrParserTests()
        {
            _parserService = new BankAccountOcrParser();
        }

        [Fact]
        public void Valid_Parse()
        {
            var accNo = new int[] { 4, 5, 7, 5, 0, 8, 0, 0, 0 };
            var generatedOcr = OcrUtilities.GenerateOcr(accNo);
            var parsedAccountNo = _parserService.Parse(generatedOcr);

            Assert.Equal(accNo, parsedAccountNo);
        }


        [Fact]
        public void Invalid_Parse()
        {
            var ex = Assert.Throws<BankAccountOcrException>(() => _parserService.Parse(null));
            Assert.NotNull(ex);
        }

    }
}