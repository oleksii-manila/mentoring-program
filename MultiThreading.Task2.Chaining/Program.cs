/*
 * 2.	Write a program, which creates a chain of four Tasks.
 * First Task – creates an array of 10 random integer.
 * Second Task – multiplies this array with another random integer.
 * Third Task – sorts this array by ascending.
 * Fourth Task – calculates the average value. All this tasks should print the values to console.
 */
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiThreading.Task2.Chaining
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".Net Mentoring Program. MultiThreading V1 ");
            Console.WriteLine("2.	Write a program, which creates a chain of four Tasks.");
            Console.WriteLine("First Task – creates an array of 10 random integer.");
            Console.WriteLine("Second Task – multiplies this array with another random integer.");
            Console.WriteLine("Third Task – sorts this array by ascending.");
            Console.WriteLine("Fourth Task – calculates the average value. All this tasks should print the values to console");
            Console.WriteLine();

            // feel free to add your code
            Random r = new Random();
            int[] CreateArray()
            {
                int[] array = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    array[i] = r.Next(0, 100);

                    Console.WriteLine(array[i]);
                }

                Console.WriteLine("The end of creating array");               

                return array;
            }

            int[] MultiplyArray(int[] array)
            {
                for(int i = 0; i<array.Length; i++)
                {
                    array[i] = array[i] * r.Next(0, 100);

                    Console.WriteLine(array[i]);

                }
                Console.WriteLine("The end of multiplying array");

                return array;
            }

            int[] SortArray(int[]array)
            {
                Array.Sort(array);

                foreach (var item in array)
                    Console.WriteLine(item);
                Console.WriteLine("The end of sorted array");

                return array;
            }

            double Average(int[] array)
            {
                var sum = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }
                var avrg = sum / array.Length;

                Console.WriteLine($"Average is: {avrg}");
                return avrg;
            }

            Task<int[]> createArrayOfRandomIntegers = Task.Run(() => CreateArray());
            Task<int[]> continuation = createArrayOfRandomIntegers.ContinueWith(x =>
            {
                return MultiplyArray(createArrayOfRandomIntegers.Result);
            });
            Task<int[]> anotherContinuation = continuation.ContinueWith(x =>
            {
                return SortArray(continuation.Result);
            });
            Task<double> theLastContinuation = anotherContinuation.ContinueWith(x =>
            {
                return Average(anotherContinuation.Result);
            });

            Console.ReadLine();
        }
    }
}
