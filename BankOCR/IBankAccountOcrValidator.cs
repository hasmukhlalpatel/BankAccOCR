using BankOCR.Exceptions;

namespace BankOCR
{
    public interface IBankAccountOcrValidator
    {
        /// <summary>
        /// validate OCR lines
        /// </summary>
        /// <exception cref="BankAccountOcrException"></exception>
        /// <param name="accountNoDigits"></param>
        /// <returns> true if accountNoDigits are valid</returns>
        bool Validate(int[] accountNoDigits);
    }
}