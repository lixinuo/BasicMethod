using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础算法实现
{
    class Program
    {
        static void Main(string[] args)
        {
            BubbleSortDome();
        }


        public static void BubbleSortDome()
        {
            int maxSize = 10000;
            int[] array = new int[maxSize];
            Random random = new Random();
            for (int i = 0; i < maxSize; i++)
            {
                array[i] = random.Next(1, 11);
            }
            Console.WriteLine("Before Bubble Sort:");
            BasicClass.PrintArray(array);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            BasicClass.QuickSort(array, 0, maxSize - 1);
            watch.Stop();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("After Bubble Sort");
            BasicClass.PrintArray(array);
            Console.WriteLine("Total Elapsed Milliseconds:{0}ms", watch.ElapsedMilliseconds);
            Console.ReadLine();

        }
    }
}
