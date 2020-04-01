using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveExtraBlanks
{ 
    public class RemoveExtraBlanks
    {
        public const string INPUT_FILE_IS_NOT_EXIST = "Input file is not exist";
        public const string OUTPUT_FILE_IS_NOT_EXIST = "Output file is not exist";
        public const string USAGE_METHOD = "Usage: RemoveExtraBlanks.exe <input file> <output file>";
        public static void Main(string[] args)
        {
            if (CheckCorrectFiles(args) == 1)
            {
                WriteRemoveExtraBlanksStringInFile(args);
            }

        }

        public static void WriteRemoveExtraBlanksStringInFile(string[] args)
        {
            string str;
            using (StreamReader reader = new StreamReader(args[0]))
            {
                using (StreamWriter writer = new StreamWriter(args[1]))
                {
                    while ((str = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(RemoveExtraBlanksInString(str));
                    }
                }
            }
        }

        public static string RemoveExtraBlanksInString(string str)
        {
            return System.Text.RegularExpressions.Regex.Replace(str, "\\s+|\\t+", " ").Trim();
        }

        public static int CheckCorrectFiles(string[] args)
        {
            if (args.Length == 2)
            {
                bool input = File.Exists(args[0]);
                bool output = File.Exists(args[1]);
                if (input && output)
                {
                    return 1;
                }
                else
                {
                    if (!input)
                    {
                        Console.WriteLine(INPUT_FILE_IS_NOT_EXIST);
                    }
                    if (!output)
                    {
                        Console.WriteLine(OUTPUT_FILE_IS_NOT_EXIST);
                    }
                    Console.WriteLine(USAGE_METHOD);
                    return 0;
                }
            }
            Console.WriteLine(USAGE_METHOD);
            return 0;
        }
    }
}
