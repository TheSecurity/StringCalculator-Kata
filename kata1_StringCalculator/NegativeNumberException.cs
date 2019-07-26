using System;
using System.Collections.Generic;

namespace kata1_StringCalculator
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(IEnumerable<int> negativeNumbers) :
            base("Negatives not allowed: " + string.Join(',', negativeNumbers))
        {

        }
    }
}