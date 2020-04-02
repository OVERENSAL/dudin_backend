using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStrength
{
    public class Verification
    {
        public const string INVALID_NUMBER_OF_ARGUMENTS = "Invalid number of arguments.";
        public const string METHOD_USAGE = "Usage: PasswordStrength.exe <password>.";
        public const string NON_VALID_PASSWORD = "The password is not valid in position ";

        public int ArgumentNumberVerification(string[] args)
        {
            if (args.Length == 1 && args[0].Length != 0)//отсекаются пустые строки
                return 1;
            Console.WriteLine(INVALID_NUMBER_OF_ARGUMENTS);
            Console.WriteLine(METHOD_USAGE);
            return 0;
        }

        public int PasswordVerification(string password)
        {
            int resultIndex = -1;
            bool valid = true;
            for (int i = 0; i < password.Length && valid; i++)
            {
                if (!(char.IsLetter(password[i]) || char.IsDigit(password[i])))
                {
                    resultIndex = i;
                    valid = false;
                }
            }
            if (resultIndex != -1)
                Console.WriteLine(NON_VALID_PASSWORD + resultIndex + " unexpected symbol '" + password[resultIndex] + "'.");

            return resultIndex;
        }
    }
}
