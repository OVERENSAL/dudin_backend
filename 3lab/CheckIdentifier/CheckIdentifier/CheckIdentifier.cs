using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIdentifier
{
    public class CheckIdentifier
    {
        private const string ERROR_MSG = "Pass one argument to the program for verification.";
        private const string VALID_SUCCESS = "Yes! Identificator validation was successful!";
        private const string VALID_FAIL = "No! Identificator validation failed. Unexpected symbol '";

        public static void Main(string[] args)
        {
            if (args.Length == 1 && args[0].Length != 0)
            {
                string verificationString = args[0];
                int verificationResult = ArgumentVerification(verificationString);
                if (verificationResult == -1)
                {
                    Console.WriteLine(VALID_SUCCESS);
                }
                else
                {
                    Console.WriteLine(VALID_FAIL + verificationString[verificationResult] + "' in the position " + verificationResult + ".");
                }
            }
            else
            {
                Console.WriteLine(ERROR_MSG);
            }
        }

        public static int ArgumentVerification(string verificationString)
        {
            int resultIndex = -1;
            bool valid = true;
            if (!char.IsLetter(verificationString[0]))
            {
                valid = false;
                resultIndex = 0;
            }
            for (int i = 1; i < verificationString.Length && valid; i++)
            {
                if (!(char.IsLetter(verificationString[i]) || char.IsDigit(verificationString[i])))
                {
                    resultIndex = i;
                    valid = false;
                }
            }

            return resultIndex;
        }
    }
}
