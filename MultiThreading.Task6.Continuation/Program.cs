/*
*  Create a Task and attach continuations to it according to the following criteria:
   a.    Continuation task should be executed regardless of the result of the parent task.
   b.    Continuation task should be executed when the parent task finished without success.
   c.    Continuation task should be executed when the parent task would be finished with fail and parent task thread should be reused for continuation
   d.    Continuation task should be executed outside of the thread pool when the parent task would be cancelled
   Demonstrate the work of the each case with console utility.
*/
using System;
using System.Threading.Tasks;

namespace MultiThreading.Task6.Continuation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create a Task and attach continuations to it according to the following criteria:");
            Console.WriteLine("a.    Continuation task should be executed regardless of the result of the parent task.");
            Console.WriteLine("b.    Continuation task should be executed when the parent task finished without success.");
            Console.WriteLine("c.    Continuation task should be executed when the parent task would be finished with fail and parent task thread should be reused for continuation.");
            Console.WriteLine("d.    Continuation task should be executed outside of the thread pool when the parent task would be cancelled.");
            Console.WriteLine("Demonstrate the work of the each case with console utility.");
            Console.WriteLine();

            // feel free to add your code

            Random r = new Random();
            int[] CreateArray()
            {
                throw null;
            }           
          


            Task<int[]> createArrayOfRandomIntegers = Task.Run(() => CreateArray());
            Task continuation = createArrayOfRandomIntegers.ContinueWith(x =>
            {
                Console.WriteLine("The second task executed regardless of the result of the parent task."); 
            });
            Task anotherContinuation = createArrayOfRandomIntegers.ContinueWith(x =>
            {
                Console.WriteLine("The third task executed when the parent task finished without success.");

            }, TaskContinuationOptions.OnlyOnFaulted);
            Task theLastContinuation = createArrayOfRandomIntegers.ContinueWith(x =>
            {
                Console.WriteLine("The fourth task executed when the parent task would be finished with fail and parent task thread should be reused for continuation.");

            }, TaskContinuationOptions.OnlyOnFaulted);
            Console.ReadLine();
        }
    }
}
