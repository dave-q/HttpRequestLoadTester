using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadTestSpike
{
    internal static class ResultsProducer
    {
        internal static void CalculateResults(Stopwatch stpwatch, TestResult[] results)
        {
            long totalTime = stpwatch.ElapsedMilliseconds;
            long totalSuccessRequests = 0;
            long totalFailedRequests = 0;
            long averageTimems = 0;
            long totalAverageTimems = 0;
            long maxTime = 0;
            var requestsTimeTaken = new List<double>();
            foreach (var result in results)
            {
                totalSuccessRequests += result.SuccessfulRequests;
                totalFailedRequests += result.FailedRequests;
                totalAverageTimems += result.AverageRequestTimems;
                requestsTimeTaken.AddRange(result.RequestTimes);
                if (result.MaxRequestTimems > maxTime)
                {
                    maxTime = result.MaxRequestTimems;
                }
            }

            averageTimems = (long)((decimal)totalAverageTimems / (decimal)results.Count());
            var std = StandardDeviation(requestsTimeTaken);
            var totalTimeSeconds = (decimal)totalTime / 1000;
            var rps = (decimal)(totalSuccessRequests + totalFailedRequests) / totalTimeSeconds;

            Console.WriteLine("------------RESULTS----------------");
            Console.WriteLine($"Succesful Requests: {totalSuccessRequests}");
            Console.WriteLine($"Failed Requests: {totalFailedRequests}");
            Console.WriteLine($"Average(mean) request time(ms): {averageTimems}");
            Console.WriteLine($"Longest request(ms): {maxTime}");
            Console.WriteLine($"Standard Deviation: {std:#.##}");
            Console.WriteLine($"Requests/sec: {rps:#.##}");
        }

        private static double StandardDeviation(IEnumerable<double> values)
        {
            double avg = values.Average();
            return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }
    }
}
