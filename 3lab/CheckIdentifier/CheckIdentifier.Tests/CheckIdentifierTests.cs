using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIdentifier.Tests
{
    public class CheckIdentifierTests
    {
        [Fact]
        public void CheckIdentifier_NotArguments_ShouldShowErrorMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { };
                CheckIdentifier.Main(args);
                Assert.Equal(CheckIdentifier.ERROR_MSG + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void CheckIdentifier_VoidArgument_ShouldShowErrorMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = {""};
                CheckIdentifier.Main(args);
                Assert.Equal(CheckIdentifier.ERROR_MSG + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void CheckIdentifier_SomeArguments_ShouldShowErrorMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "dsf", "dsfg" };
                CheckIdentifier.Main(args);
                Assert.Equal(CheckIdentifier.ERROR_MSG + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void CheckIdentifier_ArgumentIsNotValidateFromDigit_ShouldShowNoMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "1sadg" };
                CheckIdentifier.Main(args);
                Assert.Equal(CheckIdentifier.VALID_FAIL + "1' in the position 0.\r\n", writer.ToString());
            }
        }

        [Fact]
        public void CheckIdentifier_ArgumentIsNotValidateFromNotSymbol_ShouldShowNoMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "!sadg" };
                CheckIdentifier.Main(args);
                Assert.Equal(CheckIdentifier.VALID_FAIL + "!' in the position 0.\r\n", writer.ToString());
            }
        }

        [Fact]
        public void CheckIdentifier_ArgumentIsNotValidateFromNotSymbolInTheMiddle_ShouldShowNoMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "sa$dg" };
                CheckIdentifier.Main(args);
                Assert.Equal(CheckIdentifier.VALID_FAIL + "$' in the position 2.\r\n", writer.ToString());
            }
        }

        [Fact]
        public void CheckIdentifier_ArgumentIsNotValidateFromNotSymbolInTheEnd_ShouldShowNoMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "sadg$" };
                CheckIdentifier.Main(args);
                Assert.Equal(CheckIdentifier.VALID_FAIL + "$' in the position 4.\r\n", writer.ToString());
            }
        }

        [Fact]
        public void CheckIdentifier_ArgumentValidate_ShouldShowYesMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "sadg" };
                CheckIdentifier.Main(args);
                Assert.Equal(CheckIdentifier.VALID_SUCCESS + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void CheckIdentifier_ArgumentValidateWithSomeDigit_ShouldShowYesMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "s1adg1" };
                CheckIdentifier.Main(args);
                Assert.Equal(CheckIdentifier.VALID_SUCCESS + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void CheckIdentifier_ArgumentValidateWithSomeDigitAndCapitalLetters_ShouldShowYesMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "s113GE4228adDg14G64T" };
                CheckIdentifier.Main(args);
                Assert.Equal(CheckIdentifier.VALID_SUCCESS + "\r\n", writer.ToString());
            }
        }
    }
}
