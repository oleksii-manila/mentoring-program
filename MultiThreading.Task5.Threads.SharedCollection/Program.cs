/*
 * 5. Write a program which creates two threads and a shared collection:
 * the first one should add 10 elements into the collection and the second should print all elements
 * in the collection after each adding.
 * Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading.Task5.Threads.SharedCollection
{
    class Program
    {
        static EventWaitHandle eventWaitHandle = new AutoResetEvent(false);
        static List<int> list = new List<int>();
        static Object first = new Object();
        static void Main(string[] args)
        {
            Console.WriteLine("5. Write a program which creates two threads and a shared collection:");
            Console.WriteLine("the first one should add 10 elements into the collection and the second should print all elements in the collection after each adding.");
            Console.WriteLine("Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.");
            Console.WriteLine();

            // feel free to add your code
            Task.Factory.StartNew(WorkerThread);
            Task.Factory.StartNew(PrintingThread);

            Console.ReadLine();
        }

        private static void PrintingThread()
        {
            lock (first)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void WorkerThread()
        {
            lock (first)
            {

                for (int i = 0; i < 10; i++)
                {
                    list.Add(i);
                    Console.WriteLine($"Added number: {i}");
                    Thread.Sleep(1000);
                }
            }



        }
    }
}
