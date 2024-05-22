using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circularMT_console
{
    internal class Program
    {

        static void Main(string[] args)
        {
            if (args.Length != 5)
            {
                Console.WriteLine("Usage: File to process <space> Name to save image too <space> -l(inear) or -c(ircular) <space> list of feature typess to ignore seperated by a ',' character <space> sequence length");
                Console.WriteLine("For example:");
                Console.WriteLine("sequence.gb sequence.png -c gene,source 16789");
                Console.WriteLine("Will create a circular image saved as sequence.png using data in the sequence.gb file of a genome 16,789 bp long, ignoring any features of type 'gene' and/or 'source'");

                Console.WriteLine("Arguments list:");
                foreach (string line in args)
                { Console.WriteLine(line); }
                return;
            }

            List<string> featuresToIgnore = new List<string>();
            bool linear = false;

            if (System.IO.File.Exists(args[0].Trim()) == false)
            { Console.WriteLine(args[0] + "is not args file"); return; }
            else if (args[2].Trim().ToLower() != "-c" && args[2].Trim().ToLower() != "-l")
            { Console.WriteLine(args[2] + "Argument 3 must be either '-c' or '-l', was " + args[3]); return; }
            
            int length = 0;
            try { length = Convert.ToInt32(args[4]); }
            catch { Console.WriteLine(args[4] + " must be a whole number"); return; }

            if (args[2].Trim().ToLower() == "-l") { linear = true; }
            string[] items = args[3].Split(',');
            featuresToIgnore.AddRange(items);
            engine eng = new engine(args[0], args[1], linear, featuresToIgnore, length);

        }
    }
}
