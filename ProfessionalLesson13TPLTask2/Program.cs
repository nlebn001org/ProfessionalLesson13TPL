using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProfessionalLesson13TPLTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = 2;

            Task t1 = new Task(() => Parallel.Invoke(parallelOptions, Plus, Minus));
            t1.Start();
            Console.WriteLine("Main");
            t1.Wait();

        }

        static void Plus()
        {
            for (int i = 0; i < 40; i++)
            {
                Thread.Sleep(20);
                Console.Write("+ ");
            }

        }
        static void Minus()
        {
            for (int i = 0; i < 40; i++)
            {
                Thread.Sleep(20);
                Console.Write("- ");
            }
        }
    }
}
