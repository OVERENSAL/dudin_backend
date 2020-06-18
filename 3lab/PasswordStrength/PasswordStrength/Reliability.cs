using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStrength
{
    public class Reliability
    {
        public int StrenghtByNumberOfAllSymbols(string password)
        {
            return 4 * password.Length;
        }

        public int StrenghtByNumberOfAllDigits(string password)
        {
            return 4 * Counter(char.IsDigit, password);
        }

        public int StrenghtByAllSymbolsInUpperCase(string password)
        {
            int numberInUpperCase = Counter(char.IsUpper, password);
            if (numberInUpperCase != 0)
            {
                numberInUpperCase = (password.Length - numberInUpperCase) * 2;
            }

            return numberInUpperCase;
        }

        public int StrenghtByAllSymbolsInLowerCase(string password)
        {
            int numberInLowerCase = Counter(char.IsLower, password);
            if (numberInLowerCase != 0)
            {
                numberInLowerCase = (password.Length - numberInLowerCase) * 2;
            }

            return numberInLowerCase;
        }

        public int StrenghtByOnlyLetters(string password)
        {
            if (Counter(char.IsLetter, password) == password.Length)
                return -password.Length;
            return 0;
        }

        public int StrenghtByOnlyDigits(string password)
        {
            if (Counter(char.IsDigit, password) == password.Length)
                return -password.Length;
            return 0;
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
            return (StrenghtByNumberOfAllSymbols(password) + StrenghtByNumberOfAllDigits(password) +
                    StrenghtByAllSymbolsInLowerCase(password) + StrenghtByAllSymbolsInUpperCase(password) 
                    + StrenghtByOnlyDigits(password) + StrenghtByOnlyLetters(password) - RepeatSymbol(password));
        }
    }
}
