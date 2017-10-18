using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LoadTestSpike
{
    internal static class RequestMaker
    {
        internal static Task<TestResult[]> Run(UserInputArgs inputArgs)
        {

            var tasks = new List<Task<TestResult>>();

            for (int i = 0; i < inputArgs.Concurrency; i++)
            {
                tasks.Add(Task<TestResult>.Run(() => RunRequestLoop(inputArgs.Iterations, inputArgs.Url)));
            }

            Console.WriteLine("Running...");
            var results = Task.WhenAll(tasks);
            return results;
        }

        private static async Task<TestResult> RunRequestLoop(int iterations, string url)
        {
            long totalRequests = 0;
            long successfulRequets = 0;
            long failedRequests = 0;
            long longestTimems = 0;
            var totalStopWatch = Stopwatch.StartNew();
            var requestsTimeTaken = new List<double>();
            for (int i = 0; i < iterations; i++)
            {
                long timeTakenms = 0;
                var perRequestStopwatch = Stopwatch.StartNew();
                var httpClient = new HttpClient();
                var responseMessage = await httpClient.GetAsync(url);
                perRequestStopwatch.Stop();
                totalRequests++;

                timeTakenms = perRequestStopwatch.ElapsedMilliseconds;
                requestsTimeTaken.Add(timeTakenms);
                if (longestTimems < timeTakenms)
                {
                    longestTimems = timeTakenms;
                }
                if (responseMessage.IsSuccessStatusCode)
                {
                    successfulRequets++;
                }
                else
                {
                    failedRequests++;
                }
            }

            totalStopWatch.Stop();

            return new TestResult(successfulRequets, failedRequests, (int)(totalStopWatch.ElapsedMilliseconds / totalRequests), longestTimems, requestsTimeTaken);
        }
    }
}
