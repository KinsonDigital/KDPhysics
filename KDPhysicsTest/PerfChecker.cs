using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDPhysicsTest
{
    /// <summary>
    /// Runs code and measures its performance.
    /// </summary>
    public static class PerfRunner
    {
        public delegate void CodeToBenchmarkDelegate();
        private static List<double> _perfTimes = new List<double>();
        private static Stopwatch _timer = new Stopwatch();

        /// <summary>
        /// Benchmarks the performance of the code in the given <paramref name="codeToCheck"/> delegate.
        /// </summary>
        /// <param name="codeToCheck">The delegate to the method that contains the code to performance check.</param>
        /// <returns></returns>
        public static double BenchmarkCode(CodeToBenchmarkDelegate codeToCheck)
        {
            _timer.Start();

            //Invoke the method that contains the code to measure
            codeToCheck?.Invoke();

            _timer.Stop();

            var result = _timer.Elapsed.TotalMilliseconds;

            _timer.Reset();

            return result;
        }

        /// <summary>
        /// Benchmarks the performance of the code in the given <paramref name="codeToCheck"/> delegate.
        /// </summary>
        /// <param name="codeToCheck">The delegate to the method that contains the code to performance check.</param>
        /// <param name="iterationsPerBatch">The total times to perform the benchmark test.</param>
        /// <returns>The average result of all the tests.</returns>
        public static double BenchmarkCode(CodeToBenchmarkDelegate codeToCheck, int totalIterations)
        {
            //Clear the collected performance times
            _perfTimes.Clear();

            for (int i = 0; i < totalIterations; i++)
            {
                _perfTimes.Add(BenchmarkCode(codeToCheck));
            }

            return _perfTimes.Count > 0 ? _perfTimes.Average() : 0.0;
        }

        /// <summary>
        /// Benchmarks the performance of the code in the given <paramref name="codeToCheck"/> delegate.
        /// </summary>
        /// <param name="codeToCheck">The delegate to the method that contains the code to performance check.</param>
        /// <param name="iterationsPerBatch">The total times to perform the benchmark test.</param>
        /// <param name="totalBatches">The total number of batches to run.  Each batch will run the test as many times as <paramref name="iterationsPerBatch"/> is set to.</param>
        /// <returns>The average result of all the tests.</returns>
        public static double[] BenchmarkCode(CodeToBenchmarkDelegate codeToCheck, int iterationsPerBatch, int totalBatches)
        {
            var batchResults = new List<double>();

            //Clear the collected performance times
            _perfTimes.Clear();

            for (int i = 0; i < totalBatches; i++)
            {
                batchResults.Add(BenchmarkCode(codeToCheck, iterationsPerBatch));
            }

            return batchResults.ToArray();
        }
    }
}
