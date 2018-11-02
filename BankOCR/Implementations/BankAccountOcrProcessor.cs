using System;
using System.Collections.Generic;
using System.Text;

namespace BankOCR.Implementations
{
    public class BankAccountOcrProcessor : IBankAccountOcrProcessor
    {
        private readonly IBankAccountOcrParser _parser;
        private readonly IBankAccountOcrValidator _validator;

        public BankAccountOcrProcessor(IBankAccountOcrParser parser, IBankAccountOcrValidator validator)
        {
            _parser = parser;
            _validator = validator;
        }
        public void Process()
        {
            throw new NotImplementedException();
        }
    }
}
