using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GET_RESULT_FROM_PARALLEL_LOOP
{
    class Program
    {
        static IEnumerable<int> lista = Enumerable.Range(0, 300);

        static void Main(string[] args)
        {
            ParallelLoopResult result = Parallel.For(0, 300, (int i, ParallelLoopState state) =>
            {
                if (i == 99)
                {
                    Console.WriteLine($"Loop parado na posição {i}");
                    state.Stop();
                }
            });

            Console.WriteLine($"O loop foi completado? {result.IsCompleted}"); // Espera um false porque paramos o loop
            Console.WriteLine($"O maior valor executado? {result.LowestBreakIteration}");
            Console.WriteLine();

            ParallelLoopResult result2 = Parallel.ForEach(lista, (int i, ParallelLoopState state) =>
            {
                if (i == 99)
                {
                    Console.WriteLine($"Loop parado na posição {i}");
                    state.Break();
                }
            });

            Console.WriteLine($"O loop foi completado? {result2.IsCompleted}"); // Espera um false porque paramos o loop
            Console.WriteLine($"O maior valor executado? {result2.LowestBreakIteration}");
        }
    }
}
