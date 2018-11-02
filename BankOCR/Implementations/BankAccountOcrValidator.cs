using BankOCR.Exceptions;

namespace BankOCR.Implementations
{
    public class BankAccountOcrValidator : IBankAccountOcrValidator
    {
        public bool Validate(int[] accountNoDigits)
        {
            if (accountNoDigits == null || accountNoDigits.Length != Constants.AccountNpLength)
                throw new BankAccountOcrException(Constants.InvalidAccountNo);

            var checksum = 0;

            for (var i = 1; i <= Constants.AccountNpLength; i++)
            {
                checksum += (accountNoDigits[(Constants.AccountNpLength - i)] * i);
            }

            return checksum % 11 == 0;
        }
    }
}