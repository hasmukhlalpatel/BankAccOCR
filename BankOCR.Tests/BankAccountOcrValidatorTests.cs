using BankOCR.Exceptions;
using BankOCR.Implementations;
using Xunit;

namespace BankOCR.Tests
{
    public class BankAccountOcrValidatorTests
    {
        private IBankAccountOcrParser _parserService;
        private IBankAccountOcrValidator _validatorService;

        public BankAccountOcrValidatorTests()
        {
            _parserService = new BankAccountOcrParser();
            _validatorService= new BankAccountOcrValidator();
        }

        [Fact]
        public void Invalid_Data_Validate()
        {
            var ex = Assert.Throws<BankAccountOcrException>(() => _validatorService.Validate(null));
            Assert.NotNull(ex);
        }

        [Fact]
        public void Validate()
        {
            var nos = new int[] { 4, 5, 7, 5, 0, 8, 0, 0, 0 };
            var generatedOcr = OcrUtilities.GenerateOcr(nos);
            var verifyAccountNo = _parserService.Parse(generatedOcr);
            var result = _validatorService.Validate(verifyAccountNo);

            Assert.True(result);
        }
    }
}
