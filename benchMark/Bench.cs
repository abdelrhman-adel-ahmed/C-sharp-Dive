using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace benchMark
{
    [MemoryDiagnoser]
    public class Bench
    {
        private static readonly Sample samples = new Sample();

        [Benchmark]
        public string GetNameDynamic()
        {
            return samples.GetNameDynamic();
        }
        [Benchmark]
        public string GetName()
        {
            return samples.GetName();
        }
        [Benchmark]
        public List<string> GetNameInListDynamic()
        {
            return samples.GetNameInListDynamic();
        }
        [Benchmark]
        public List<string> GetNameInList()
        {
            return samples.GetNameInList();
        }
    }
}
