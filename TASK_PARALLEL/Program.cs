using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TASK_PARALLEL
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            WithNoParallel();
            stopWatch.Stop();

            Console.WriteLine("\nA tarefa sequencial foi finalizada em {0}.\n", stopWatch.ElapsedMilliseconds / 1000.0);

            stopWatch.Reset();

            stopWatch.Start();
            WithParallel();
            stopWatch.Stop();

            Console.WriteLine("\nA tarefa paralela foi finalizada em {0}.\n", stopWatch.ElapsedMilliseconds / 1000.0);
        }

        private static void WithNoParallel()
        {
            ImprimirZero();
            ImprimirUm();
            ImprimirPonto();
        }

        private static void WithParallel()
        {
            // Não é possível garantir a ordem de processamento quando está usando este tipo de paralelismo
            // Fazendo a execução paralela conseguimos uma enorme redução de tempo de execução 
            Parallel.Invoke(
                () => ImprimirZero(),
                () => ImprimirUm(),
                () => ImprimirPonto());
        }

        private static void ImprimirPonto()
        {
            for (int i = 0; i < 300; i++)
            {
                ExecutarTarefaDemorada();
                Console.Write(".");
            }
        }

        private static void ImprimirUm()
        {
            for (int i = 0; i < 300; i++)
            {
                ExecutarTarefaDemorada();
                Console.Write("1");
            }
        }

        private static void ImprimirZero()
        {
            for (int i = 0; i < 300; i++)
            {
                ExecutarTarefaDemorada();
                Console.Write("0");
            }
        }

        private static void ExecutarTarefaDemorada()
        {
            Thread.Sleep(10);
        }
    }
}
