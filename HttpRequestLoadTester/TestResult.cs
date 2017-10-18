using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadTestSpike
{
    internal struct TestResult
    {
        internal long SuccessfulRequests { get; private set; }
        internal long FailedRequests { get; private set; }
        internal long AverageRequestTimems { get; private set; }
        internal long MaxRequestTimems { get; private set; }

        internal List<double> RequestTimes { get; private set; }
        public TestResult(long successfulRequests, long failedRequests, long averageRequestTimems, long maxRequestTimems, List<double> requestTimes)
        {
            SuccessfulRequests = successfulRequests;
            FailedRequests = failedRequests;
            AverageRequestTimems = averageRequestTimems;
            MaxRequestTimems = maxRequestTimems;
            RequestTimes = requestTimes;
        }
    }
}
