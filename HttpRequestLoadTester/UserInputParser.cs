using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadTestSpike
{
    internal static class UserInputParser
    {
        internal static UserInputArgs Parse()
        {
            var url = GetUrlFromUser();
            var iterations = GetIterationsFromUser();
            var concurrency = GetConcurrencyFromUser();

            return new UserInputArgs(url, iterations, concurrency);
        }

        private static string GetUrlFromUser()
        {
            string url;
            Console.WriteLine("Enter the url to make requests to");
            while (true)
            {
                var enteredUrl = Console.ReadLine();
                if (enteredUrl.ToLower() == "exit") Environment.Exit(0);
                try
                {
                    new Uri(enteredUrl);
                    url = enteredUrl;
                    break;
                }
                catch
                {
                    Console.WriteLine("That isn't a valid Url, please try again or enter exit to give up");
                }
            }

            return url;
        }
        private static int GetIterationsFromUser()
        {
            int iterations;
            Console.WriteLine("Enter the number of iterations each conccurent loop should run");
            while (true)
            {
                var enteredIterations = Console.ReadLine();
                if (enteredIterations.ToLower() == "exit") Environment.Exit(0);
                if (int.TryParse(enteredIterations, out iterations))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That isn't a valid integer, please try again or enter exit to give up");
                }
            }

            return iterations;
        }
        private static int GetConcurrencyFromUser()
        {
            int concurrency;
            Console.WriteLine($"Enter the amount of concurency you'd like to have in this test(ie the number of concurrent threads to run up, fyi you have {Environment.ProcessorCount} cores, so keep that in mind)");
            while (true)
            {
                var enteredConcurrency = Console.ReadLine();
                if (enteredConcurrency.ToLower() == "exit") Environment.Exit(0);
                if (int.TryParse(enteredConcurrency, out concurrency))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That isn't a valid integer, please try again or enter exit to give up");
                }
            }

            return concurrency;
        }
    }
}
