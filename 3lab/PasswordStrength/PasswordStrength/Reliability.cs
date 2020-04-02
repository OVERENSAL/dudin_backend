using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStrength
{
    public class Reliability
    {
        public int NumberOfAllSymbols(string password)
        {
            return password.Length;
        }

        public int NumberOfAllDigits(string password)
        {
            return Counter(char.IsDigit, password);
        }

        public int NumberOfAllSymbolsInUpperCase(string password)
        {
            return Counter(char.IsUpper, password);
        }

        public int NumberOfAllSymbolsInLowerCase(string password)
        {
            return Counter(char.IsLower, password);
        }

        public bool OnlyLetters(string password)
        {
            if (Counter(char.IsLetter, password) == password.Length)
                return true;
            return false;
        }

        public bool OnlyDigits(string password)
        {
            if (Counter(char.IsDigit, password) == password.Length)
                return true;
            return false;
        }

        public int RepeatSymbol(string password)
        {
            int counter = 0;
            int temporaryCount = 0;
            List<char> SymbolsList = new List<char>(password);
            List<char> UnigueSymbolsList = new List<char>(password.Distinct());
            for (int i = 0; i < UnigueSymbolsList.Count; i++)
            {
                for (int j = 0; j < SymbolsList.Count; j++)
                {
                    if (UnigueSymbolsList[i] == SymbolsList[j])
                    {
                        temporaryCount++;
                    }
                }
                if (temporaryCount > 1)
                {
                    counter += temporaryCount;
                }
                temporaryCount = 0;
            }
            return counter;
        }

        public int Counter(Func<char, bool> func, string password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (func(password[i]))
                {
                    counter++;
                }
            }
            return counter;
        }

        public int ReliabilityAnalysis(string password)
        {
            int numberInLowerCase = NumberOfAllSymbolsInLowerCase(password);
            if (numberInLowerCase != 0)
            {
                numberInLowerCase = (password.Length - numberInLowerCase) * 2;
            }
            int numberInUpperCase = NumberOfAllSymbolsInUpperCase(password);
            if (numberInUpperCase != 0)
            {
                numberInUpperCase = (password.Length - numberInUpperCase) * 2;
            }
            int onlyDigits = 0;
            if (OnlyDigits(password))
            {
                onlyDigits -= password.Length;
            }
            int onlyLetters = 0;
            if (OnlyLetters(password))
            {
                onlyLetters -= password.Length;
            }

            return (4 * NumberOfAllSymbols(password) + 4 * NumberOfAllDigits(password) +
                numberInLowerCase + numberInUpperCase + onlyLetters + onlyDigits - RepeatSymbol(password));
        }
    }
}
