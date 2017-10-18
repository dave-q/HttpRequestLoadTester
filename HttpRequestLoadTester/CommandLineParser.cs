using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadTestSpike
{
    internal static class CommandLineParser
    {
        internal static UserInputArgs Parse(string[] args)
        {
            string url = string.Empty;
            int concurrency = 0;
            int iterations = 0;
            foreach (var arg in args)
            {
                try
                {
                    var argKvpArray = arg.Split(new[] { ':' }, 2);
                    var argKey = argKvpArray[0];
                    var argValue = argKvpArray[1];

                    switch (argKey.ToLower())
                    {
                        case "-url":
                            url = argValue;
                            break;
                        case "-i":
                            iterations = int.Parse(argValue);
                            break;
                        case "-c":
                            concurrency = int.Parse(argValue);
                            break;
                        default:
                            throw new Exception();
                    }
                }
                catch
                {
                    throw new ArgumentException($"Failed to parse argument: { arg }");
                }

            }
            return new UserInputArgs(url, iterations, concurrency);
        }
    }
}
