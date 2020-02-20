using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<IntroParamsSource>();
        }

        public class IntroParamsSource
        {
            // property with public setter
            [ParamsSource(nameof(ValuesForA))]
            public int A { get; set; }

            // public field
            [ParamsSource(nameof(ValuesForB))]
            public int B;

            // public property
            public IEnumerable<int> ValuesForA => new[] { 100, 200 };

            // public static method
            public static IEnumerable<int> ValuesForB() => new[] { 10, 20 };

            [Benchmark]
            public void Benchmark() => Thread.Sleep(A + B + 5);
        }
    }
}
