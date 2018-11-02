using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BankOCR.Tests")]
namespace BankOCR
{
    internal static class OcrUtilities
    {
        /*
         _     _  _     _  _  _  _  _
        | |  | _| _||_||_ |_   ||_||_|
        |_|  ||_  _|  | _||_|  ||_| _|
         */
        private const string ConstLine1 = " _     _  _     _  _  _  _  _ ";
        private const string ConstLine2 = "| |  | _| _||_||_ |_   ||_||_|";
        private const string ConstLine3 = "|_|  ||_  _|  | _||_|  ||_| _|";

        private static readonly Dictionary<string, int> DigiteSignatures = new Dictionary<string, int>();

        static OcrUtilities()
        {
            var lines = new[] { ConstLine1, ConstLine2, ConstLine3 };

            for (var i = 0; i <= 9; i++)
            {
                DigiteSignatures[InternalGetDigiteSignature(lines, i)] = i;
            }
        }

        private static string[] InternalGetDigiteChars(IEnumerable<string> lines, int digitNo)
        {
            return lines
                .Select(x => x.Substring(digitNo * Constants.ChrsPerDigit, Constants.ChrsPerDigit))
                .ToArray();
        }

        private static string InternalGetDigiteSignature(IEnumerable<string> lines, int digitNo)
        {
            return InternalGetDigiteChars(lines, digitNo)
                .Aggregate(string.Empty, (c, n) => c + n);
        }

        private static string InternalGetDigiteSignature1(IEnumerable<string> lines, int digitNo)
        {
            return lines
                .Aggregate(string.Empty, (c, n) => c + n.Substring(digitNo * 3, 3));
        }

        public static string GetDigiteSignature(string[] lines, int digitNo)
        {
            //TODO: validate 4 lines and 27 chrs && >9 digit No.
            lines = lines.Take(3).ToArray();
            return InternalGetDigiteSignature(lines, digitNo);
        }

        public static int GetDigitFromSignature(string signature)
        {
            if (DigiteSignatures.ContainsKey(signature))
                return DigiteSignatures[signature];
            return -1;
        }

        public static string[] GenerateOcr(int[] accountNoDigits)
        {
            var lines = new[] { ConstLine1, ConstLine2, ConstLine3 };

            var ocrLines = new string[lines.Length + 1];

            foreach (var digit in accountNoDigits)
            {
                var charsLines = InternalGetDigiteChars(lines, digit);

                for (var i = 0; i < lines.Length; i++)
                {
                    ocrLines[i] += charsLines[i];
                }
            }

            return ocrLines.ToArray();
        }
    }
}
