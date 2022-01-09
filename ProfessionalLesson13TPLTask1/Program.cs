using System;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProfessionalLesson13TPLTask1
{
    internal class Program
    {
        static int[] arr = new int[1000000];
        static Random rand = new Random();
        static void Main(string[] args)
        {
            ParralelArrInitialize(arr);
            ParallelQuery<int> collection = ParallelGetOddNumsFromArray(arr);
            ParallelConsoleOut(collection);
        }

        static void ParralelArrInitialize(int[] arr)
        {
            Parallel.For(0, arr.Length, (i) => arr[i] = rand.Next());
        }

        static ParallelQuery<int> ParallelGetOddNumsFromArray(int[] arr)
        {
            return from number in arr.AsParallel()
                   where number % 2 != 0
                   select number;

        }

        static void ParallelConsoleOut(ParallelQuery<int> collection)
        {
            Parallel.ForEach(collection, number => Console.WriteLine(number));
        }

    }
}
