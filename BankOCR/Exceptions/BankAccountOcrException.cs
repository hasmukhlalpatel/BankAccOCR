using System;

namespace BankOCR.Exceptions
{
    [Serializable]
    public class BankAccountOcrException : Exception
    {
        public BankAccountOcrException()
        {
        }

        public BankAccountOcrException(string message) : base(message)
        {
        }
    }
}