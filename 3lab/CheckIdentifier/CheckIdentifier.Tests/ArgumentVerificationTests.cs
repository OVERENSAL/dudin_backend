using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckIdentifier.Tests
{
    public class ArgumentVerificationTests
    {
        [Fact]
        public void ArgumentVerification_ShouldVerificationALittleString()
        {
            Assert.Equal(-1, CheckIdentifier.ArgumentVerification("g"));
        }

        [Fact]
        public void ArgumentVerification_ShouldVerificationString()
        {
            Assert.Equal(-1, CheckIdentifier.ArgumentVerification("great"));
        }

        [Fact]
        public void ArgumentVerification_ShouldVerificatiotStringWithNumberInEnd()
        {
            Assert.Equal(-1, CheckIdentifier.ArgumentVerification("great4"));
        }

        [Fact]
        public void ArgumentVerification_ShouldVerificatiotStringWithSomeNumberInEnd()
        {
            Assert.Equal(-1, CheckIdentifier.ArgumentVerification("great44"));
        }

        [Fact]
        public void ArgumentVerification_NotShouldVerificatiotStringWithNumberInStart()
        {
            Assert.Equal(0, CheckIdentifier.ArgumentVerification("4great44"));
        }

        [Fact]
        public void ArgumentVerification_NotShouldVerificatiotStringOnlyWithNumberInStart()
        {
            Assert.Equal(0, CheckIdentifier.ArgumentVerification("4"));
        }

        [Fact]
        public void ArgumentVerification_NotShouldVerificatiotStringWithSpace()
        {
            Assert.Equal(2, CheckIdentifier.ArgumentVerification("gr eat"));
        }

        [Fact]
        public void ArgumentVerification_NotShouldVerificatiotStringWithSpaceInStart()
        {
            Assert.Equal(0, CheckIdentifier.ArgumentVerification(" gr eat"));
        }
    }
}
