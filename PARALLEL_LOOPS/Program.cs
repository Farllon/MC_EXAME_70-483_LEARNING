using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace PARALLEL_FOREACH
{
    class Program
    {
        static IEnumerable<int> lista = Enumerable.Range(0, 300);

        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            WithNoParallel();
            stopWatch.Stop();

            Console.WriteLine("\nA tarefa sequencial foi finalizada em {0}.\n", stopWatch.ElapsedMilliseconds / 1000.0);

            stopWatch.Reset();

            stopWatch.Start();
            WithParallelForeach();
            stopWatch.Stop();

            Console.WriteLine("\nA tarefa com foreach paralelo foi finalizada em {0}.\n", stopWatch.ElapsedMilliseconds / 1000.0);

            stopWatch.Reset();

            stopWatch.Start();
            WithParallelFor();
            stopWatch.Stop();

            Console.WriteLine("\nA tarefa com for paralelo foi finalizada em {0}.\n", stopWatch.ElapsedMilliseconds / 1000.0);
        }

        private static void WithNoParallel()
        {
            ImprimirZero();
            ImprimirUm();
            ImprimirPonto();
        }

        private static void WithParallelFor()
        {
            Parallel.Invoke(
                () => ImprimirPontoForParalelo(),
                () => ImprimirUmForParalelo(),
                () => ImprimirZeroForParalelo());
        }

        private static void WithParallelForeach()
        {
            Parallel.Invoke(
                () => ImprimirPontoForeachParalelo(),
                () => ImprimirUmForeachParalelo(),
                () => ImprimirZeroForeachParalelo());
        }

        private static void ImprimirPonto()
        {
            for (int i = 0; i < 300; i++)
            {
                ExecutarTarefaDemorada();
                Console.Write(".");
            }
        }

        private static void ImprimirPontoForParalelo()
        {
            Parallel.For(0, 300, (i) =>
            {
                ExecutarTarefaDemorada();
                Console.Write(".");
            });
        }

        private static void ImprimirPontoForeachParalelo()
        {
            Parallel.ForEach(lista, (i) =>
            {
                ExecutarTarefaDemorada();
                Console.Write(".");
            });
        }

        private static void ImprimirUm()
        {
            for (int i = 0; i < 300; i++)
            {
                ExecutarTarefaDemorada();
                Console.Write("1");
            }
        }

        private static void ImprimirUmForParalelo()
        {
            Parallel.For(0, 300, (i) =>
            {
                ExecutarTarefaDemorada();
                Console.Write("1");
            });
        }

        private static void ImprimirUmForeachParalelo()
        {
            Parallel.ForEach(lista, (i) =>
            {
                ExecutarTarefaDemorada();
                Console.Write("1");
            });
        }

        private static void ImprimirZero()
        {
            for (int i = 0; i < 300; i++)
            {
                ExecutarTarefaDemorada();
                Console.Write("0");
            }
        }

        private static void ImprimirZeroForParalelo()
        {
            Parallel.For(0, 300, (i) =>
            {
                ExecutarTarefaDemorada();
                Console.Write("0");
            });
        }

        private static void ImprimirZeroForeachParalelo()
        {
            Parallel.ForEach(lista, (i) =>
            {
                ExecutarTarefaDemorada();
                Console.Write("0");
            });
        }

        private static void ExecutarTarefaDemorada()
        {
            Thread.Sleep(10);
        }
    }
}
