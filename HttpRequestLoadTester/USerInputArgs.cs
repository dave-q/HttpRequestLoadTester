using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadTestSpike
{
    internal class UserInputArgs
    {
        internal string Url { get; private set; }
        internal int Iterations { get; private set; }
        internal int Concurrency { get; private set; }
        internal UserInputArgs(string url, int iterations, int concurrency)
        {
            Url = url;
            Iterations = iterations;
            Concurrency = concurrency;
        }
    }
}
