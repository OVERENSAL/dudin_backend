using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace PasswordStrength.Tests
{
    public class ArgumentsNumberVerificationTests
    {
        public Verification verification = new Verification();

        [Fact]
        public void ArgumentNumberVerification_EmptyListArguments_ShouldShowMistakeMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { };
                int expected = 0;
                Assert.Equal(expected, verification.ArgumentNumberVerification(args));
                Assert.Equal(Verification.INVALID_NUMBER_OF_ARGUMENTS + "\r\n" + Verification.METHOD_USAGE + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void ArgumentNumberVerification_EmptyArgument_ShouldShowMistakeMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "" };
                int expected = 0;
                Assert.Equal(expected, verification.ArgumentNumberVerification(args));
                Assert.Equal(Verification.INVALID_NUMBER_OF_ARGUMENTS + "\r\n" + Verification.METHOD_USAGE + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void ArgumentNumberVerification_SomeArguments_ShouldShowMistakeMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "1", "2" };
                int expected = 0;
                Assert.Equal(expected, verification.ArgumentNumberVerification(args));
                Assert.Equal(Verification.INVALID_NUMBER_OF_ARGUMENTS + "\r\n" + Verification.METHOD_USAGE + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void ArgumentNumberVerification_OneArguments_ShouldWorkCorrectly()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "1" };
                int expected = 1;
                Assert.Equal(expected, verification.ArgumentNumberVerification(args));
            }
        }
    }

    public class PasswordVerificationTests
    {
        public Verification verification = new Verification();

        [Fact]
        public void PasswordVerification_PasswordWithTab_ShouldReturnIndex()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string password = "  asgd ds ew 3";
                int expected = 0;
                Assert.Equal(expected, verification.PasswordVerification(password));
                Assert.Equal(Verification.NON_VALID_PASSWORD + expected + " unexpected symbol '" + password[expected] + "'.\r\n", writer.ToString());
            }
        }

        [Fact]
        public void PasswordVerification_PasswordWithSpace_ShouldReturnIndex()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string password = "asgd ds ew 3";
                int expected = 4;
                Assert.Equal(expected, verification.PasswordVerification(password));
                Assert.Equal(Verification.NON_VALID_PASSWORD + expected + " unexpected symbol '" + password[expected] + "'.\r\n", writer.ToString());
            }
        }

        [Fact]
        public void PasswordVerification_PasswordWithNotSymbol_ShouldReturnIndex()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string password = "a$sgd!";
                int expected = 1;
                Assert.Equal(expected, verification.PasswordVerification(password));
                Assert.Equal(Verification.NON_VALID_PASSWORD + expected + " unexpected symbol '" + password[expected] + "'.\r\n", writer.ToString());
            }
        }

        [Fact]
        public void PasswordVerification_RightPassword_ShouldReturnRight()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string password = "3dDsaw321fdsFDS";
                int expected = -1;
                Assert.Equal(expected, verification.PasswordVerification(password));
                Assert.True(writer.ToString() == "");
            }
        }
    }

    public class ReliabilityTests
    {
        public Reliability reliability = new Reliability();

        [Fact]
        public void Counter_GiveIsDigitFunc_ShouldReturnNumberOfDigit()
        {
            string password = "12345";
            int expected = 5;
            Assert.Equal(expected, reliability.Counter(char.IsDigit, password));
        }

        [Fact]
        public void Counter_GiveIsLetterFunc_ShouldReturnNumberOfLetter()
        {
            string password = "S12s3f45D";
            int expected = 4;
            Assert.Equal(expected, reliability.Counter(char.IsLetter, password));
        }

        [Fact]
        public void NumberOfAllSymbols_ShouldReturnRightNumberOfSymbols()
        {
            string password = "S12s3f45D";
            int expected = 36;
            Assert.Equal(expected, reliability.StrenghtByNumberOfAllSymbols(password));
        }

        [Fact]
        public void NumberOfAllDigits_ShouldReturnRightNumberOfDigits()
        {
            string password = "S12s3f45D5434";
            int expected = 36;
            Assert.Equal(expected, reliability.StrenghtByNumberOfAllDigits(password));
        }

        [Fact]
        public void NumberOfAllSymbolsInUpperCase_ShouldReturnRightNumberOfSymbols()
        {
            string password = "S12s3f45D5434";
            int expected = 22;
            Assert.Equal(expected, reliability.StrenghtByAllSymbolsInUpperCase(password));
        }

        [Fact]
        public void NumberOfAllSymbolsInLowerCase_ShouldReturnRightNumberOfSymbols()
        {
            string password = "S12s3f45D5434";
            int expected = 22;
            Assert.Equal(expected, reliability.StrenghtByAllSymbolsInLowerCase(password));
        }

        [Fact]
        public void BooleanOfLetters_ShouldReturnFalse()
        {
            string password = "S12s3f45D5434";
            int expected = 0;
            Assert.Equal(expected, reliability.StrenghtByOnlyLetters(password));
        }
        
        [Fact]
        public void BooleanOfDigits_ShouldReturnFalse()
        {
            string password = "6764d";
            int expected = 4;
            Assert.Equal(expected, reliability.StrenghtByOnlyDigits(password));
        }

        [Fact]
        public void RepeatSymbol_GiveAllRepeatSymbolString_ShouldReturnRightNumber()
        {
            string password = "aaaaaa";
            int expected = 6;
            Assert.Equal(expected, reliability.RepeatSymbol(password));
        }

        [Fact]
        public void RepeatSymbol_GiveRepeatSomeSymbolString_ShouldReturnRightNumber()
        {
            string password = "aaaaaabb";
            int expected = 8;
            Assert.Equal(expected, reliability.RepeatSymbol(password));
        }

        [Fact]
        public void RepeatSymbol_GiveRepeatThreeSymbolString_ShouldReturnRightNumber()
        {
            string password = "aaaaaabbcc";
            int expected = 10;
            Assert.Equal(expected, reliability.RepeatSymbol(password));
        }

        [Fact]
        public void RepeatSymbol_GiveRepeatMixSymbolString_ShouldReturnRightNumber()
        {
            string password = "adfbfsdcfssafddsdf";
            int expected = 16;
            Assert.Equal(expected, reliability.RepeatSymbol(password));
        }
    }

    public class ReliabilityAnalysis
    {
        Reliability reliability = new Reliability();

        [Fact]
        public void ReliabilityAnalysis_GiveSimplePassword()
        {
            string password = "aabb123";
            int result = reliability.ReliabilityAnalysis(password);
            int expected = 42;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReliabilityAnalysis_GiveMiddlePassword()
        {
            string password = "6Ut7LXG1";
            int result = reliability.ReliabilityAnalysis(password);
            int expected = 66;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReliabilityAnalysis_GiveHardPassword()
        {
            string password = "EmIsWrHErI3w";
            int result = reliability.ReliabilityAnalysis(password);
            int expected = 72;
            Assert.Equal(expected, result);
        }
    }

    public class PasswordStrength
    {
        [Fact]
        public void Main_GiveEmptyArgs_ShouldShowMistakeMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { };
                Program.Main(args);
                Assert.Equal(Verification.INVALID_NUMBER_OF_ARGUMENTS + "\r\n" + Verification.METHOD_USAGE + "\r\n", writer.ToString());

            }
        }

        [Fact]
        public void Main_GiveSomeArgs_ShouldShowMistakeMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "sdf", "s" };
                Program.Main(args);
                Assert.Equal(Verification.INVALID_NUMBER_OF_ARGUMENTS + "\r\n" + Verification.METHOD_USAGE + "\r\n", writer.ToString());

            }
        }

        [Fact]
        public void Main_GiveRightArgsButNotValid_ShouldShowMistakeMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "!ds" };
                Program.Main(args);
                Assert.Equal(Verification.NON_VALID_PASSWORD + "0 unexpected symbol '!'.\r\n", writer.ToString());

            }
        }

        [Fact]
        public void Main_GiveRightArgs_ShouldShowReliability()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "ds" };
                Program.Main(args);
                int expected = 6;
                Assert.Equal(expected.ToString() + "\r\n", writer.ToString());

            }
        }

        [Fact]
        public void Main_GiveRightArgs_ShouldShowNegativeReliability()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "sU1Khvci2nHBYK7y" };
                Program.Main(args);
                int expected = 112;
                Assert.Equal(expected.ToString() + "\r\n", writer.ToString());

            }
        }
    }

}
