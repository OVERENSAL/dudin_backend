using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStrength
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Verification verification = new Verification();
            if (verification.ArgumentNumberVerification(args) == 1 && verification.PasswordVerification(args[0]) == -1)
            {
                Reliability reliability = new Reliability();
                Console.WriteLine(reliability.ReliabilityAnalysis(args[0]));
            }
        }
    }
}
