using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STOP_PARALLEL_LOOPS
{
    class Program
    {
        static IEnumerable<int> lista = Enumerable.Range(0, 300);

        static void Main(string[] args)
        {
            for (int i = 0; i < 300; i++)
            {
                if (i == 99)
                {
                    Console.WriteLine($"Loop parado na posição {i}");
                    break;
                }
            }

            Parallel.For(0, 300, (int i, ParallelLoopState state) =>
            {
                if (i == 99)
                {
                    Console.WriteLine($"Loop parado na posição {i}");
                    state.Stop();
                }
            });

            Parallel.ForEach(lista, (int i, ParallelLoopState state) =>
            {
                if (i == 99)
                {
                    Console.WriteLine($"Loop parado na posição {i}");
                    state.Stop();
                }
            });
        }
    }
}
