using BankOCR.Exceptions;

namespace BankOCR
{
    public interface IBankAccountOcrParser
    {
        /// <summary>
        /// Parse OCR lines
        /// </summary>
        /// <exception cref="BankAccountOcrException"></exception>
        /// <param name="lines"></param>
        /// <returns> account No. if lines are valid</returns>
        int[] Parse(string[] lines);
    }
}