using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace RemoveExtraBlanks.Tests
{
    public class CheckCorrectFilesTests
    {
        [Fact]
        public void CheckCorrectFiles_BothFilesAreNotExist_ShouldShowErrorMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { };
                RemoveExtraBlanks.CheckCorrectFiles(args);
                Assert.Equal(RemoveExtraBlanks.USAGE_METHOD + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void CheckCorrectFiles_InputIsNotExist_ShouldShowErrorMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = {"", "output.txt" };
                int expected = 0;
                int result = RemoveExtraBlanks.CheckCorrectFiles(args);
                Assert.Equal(expected, result);
                Assert.Equal(RemoveExtraBlanks.INPUT_FILE_IS_NOT_EXIST + "\r\n" + RemoveExtraBlanks.USAGE_METHOD + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void CheckCorrectFiles_OutputIsNotExist_ShouldShowErrorMessage()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "input.txt", "" };
                int expected = 0;
                int result = RemoveExtraBlanks.CheckCorrectFiles(args);
                Assert.Equal(expected, result);
                Assert.Equal(RemoveExtraBlanks.OUTPUT_FILE_IS_NOT_EXIST + "\r\n" + RemoveExtraBlanks.USAGE_METHOD + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void CheckCorrectFiles_InputAndOutputAreExist_ShouldReturn1()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "input.txt", "output.txt" };
                int expected = 1;
                int result = RemoveExtraBlanks.CheckCorrectFiles(args);
                Assert.Equal(expected, result);
            }
        }
    }

    public class RemoveExtraBlanksInString
    {
        [Fact]
        public void RemoveExtraBlanksInString_WithTabulationInStart()
        {
            Assert.Equal("gg", RemoveExtraBlanks.RemoveExtraBlanksInString("        gg"));
        }

        [Fact]
        public void RemoveExtraBlanksInString_WithTabulationInEnd()
        {
            Assert.Equal("gg", RemoveExtraBlanks.RemoveExtraBlanksInString("gg      "));
        }

        [Fact]
        public void RemoveExtraBlanksInString_WithTabulationInStartAndEnd()
        {
            Assert.Equal("gg", RemoveExtraBlanks.RemoveExtraBlanksInString("        gg      "));
        }

        [Fact]
        public void RemoveExtraBlanksInString_WithTabulationInStartWithSpaces()
        {
            Assert.Equal("gg", RemoveExtraBlanks.RemoveExtraBlanksInString("          gg"));
        }

        [Fact]
        public void RemoveExtraBlanksInString_WithTabulationInStartAndEndWithSpaces()
        {
            Assert.Equal("gg", RemoveExtraBlanks.RemoveExtraBlanksInString("            gg              "));
        }

        [Fact]
        public void RemoveExtraBlanksInSomeWord_WithTabulationInStartAndEndWithSpaces()
        {
            Assert.Equal("gg wp", RemoveExtraBlanks.RemoveExtraBlanksInString("            gg                wp     "));
        }
    }

    public class WriteRemoveExtraBlanksStringInFile
    {
        [Fact]
        public void WriteRemoveExtraBlanksStringInFile_VoidFile()
        {
            string[] args = { "emptyInput.txt", "emptyOutput.txt" };
            RemoveExtraBlanks.WriteRemoveExtraBlanksStringInFile(args);
            string expected = null;
            using (StreamReader reader = new StreamReader(args[1]))
            {
                Assert.Equal(expected, reader.ReadLine());
            }
        }

        [Fact]
        public void WriteRemoveExtraBlanksStringInFile_HasLine()
        {
            string[] args = { "hasLineInput.txt", "hasLineOutput.txt" };
            RemoveExtraBlanks.WriteRemoveExtraBlanksStringInFile(args);
            string expected = "asfsda dsf sdf fds ds d ds";
            using (StreamReader reader = new StreamReader(args[1]))
            {
                Assert.Equal(expected, reader.ReadLine());
            }
        }
    }

    public class Main
    {
        [Fact]
        public void Main_GiveIncorrect2Arguments_ShouldShowMistakeText()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "3", "2" };
                RemoveExtraBlanks.Main(args);
                Assert.Equal(RemoveExtraBlanks.INPUT_FILE_IS_NOT_EXIST + "\r\n" + RemoveExtraBlanks.OUTPUT_FILE_IS_NOT_EXIST + "\r\n" + RemoveExtraBlanks.USAGE_METHOD + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void Main_GiveIncorrectArguments_ShouldShowMistakeText()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { "input.txt", "2" };
                RemoveExtraBlanks.Main(args);
                Assert.Equal(RemoveExtraBlanks.OUTPUT_FILE_IS_NOT_EXIST + "\r\n" + RemoveExtraBlanks.USAGE_METHOD + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void Main_GiveIncorrectNumberOfArguments_ShouldShowMistakeText()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                string[] args = { };
                RemoveExtraBlanks.Main(args);
                Assert.Equal(RemoveExtraBlanks.USAGE_METHOD + "\r\n", writer.ToString());
            }
        }

        [Fact]
        public void Main_GiveVoidInput_ShouldGiveVoidOutput()
        {
            string[] args = { "emptyInput.txt", "emptyOutput.txt" };
            RemoveExtraBlanks.Main(args);
            string expected = null;
            using (StreamReader reader = new StreamReader(args[1]))
            {
                Assert.Equal(expected, reader.ReadLine());
            }
        }

        [Fact]
        public void Main_GiveInput_ShouldGiveCorrectOutput()
        {
            string[] args = { "hasLineInput.txt", "hasLineOutput.txt" };
            RemoveExtraBlanks.Main(args);
            string expected = "asfsda dsf sdf fds ds d ds";
            using (StreamReader reader = new StreamReader(args[1]))
            {
                Assert.Equal(expected, reader.ReadLine());
            }
        }
    }
}

