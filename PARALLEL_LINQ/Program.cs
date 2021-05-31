using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PARALLEL_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            var lista = Enumerable.Range(0, 10);

            stopWatch.Start();
            var result1 = lista.Where(x => FazerConsulta(x));

            Parallel.ForEach(result1, (i) => Console.WriteLine(i));

            stopWatch.Stop();

            Console.WriteLine("Tempo para realizar linq sequencial {0}", stopWatch.ElapsedMilliseconds / 1000);

            stopWatch.Reset();

            stopWatch.Start();
            var result2 = lista.AsParallel().Where(x => FazerConsulta(x));
            Parallel.ForEach(result2, (i) => Console.WriteLine(i));
            stopWatch.Stop();

            Console.WriteLine("Tempo para realizar linq sequencial {0}", stopWatch.ElapsedMilliseconds / 1000);
        }

        private static bool FazerConsulta(int x)
        {
            Thread.Sleep(1000);
            return x % 2 == 0;
        }
    }
}
