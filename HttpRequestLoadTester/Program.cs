using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LoadTestSpike
{
    class Program
    {
        static async Task Main(string[] args)
        {
            UserInputArgs inputArgs;

            if (args.Any())
            {
                inputArgs = CommandLineParser.Parse(args);
            }
            else
            {
                inputArgs = UserInputParser.Parse();
            }

            var stpwatch = Stopwatch.StartNew();
            TestResult[] results = await RequestMaker.Run(inputArgs);
            stpwatch.Stop();
            ResultsProducer.CalculateResults(stpwatch, results);
            Console.ReadLine();
        }
    }
}

    
