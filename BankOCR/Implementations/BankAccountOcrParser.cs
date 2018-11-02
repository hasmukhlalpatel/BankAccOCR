using BankOCR.Exceptions;

namespace BankOCR.Implementations
{
    public class BankAccountOcrParser : IBankAccountOcrParser
    {
        public int[] Parse(string[] lines)
        {
            if (lines == null || lines.Length != 4)
                throw new BankAccountOcrException(Constants.InvalidOCR);

            var accountNoDigits = new int[Constants.AccountNpLength];

            for (var i = 0; i < Constants.AccountNpLength; i++)
            {
                var digiteSignature = OcrUtilities.GetDigiteSignature(lines, i);
                accountNoDigits[i] = OcrUtilities.GetDigitFromSignature(digiteSignature);
            }

            return accountNoDigits;
        }
    }
}