using System;
using System.Linq;

namespace remove_duplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            if (checkArguments(args) == 1)
            {
                Console.WriteLine(args[0].Distinct().ToArray());
            }
        }

        static int checkArguments(string[] args)
        {
            if (args.Length == 1)
            {
                return 1;
            }
            else
            {
                Console.WriteLine("Incorrect number of arguments! ");
                return 0;
            }
        }
    }
}