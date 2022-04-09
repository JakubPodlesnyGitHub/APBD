using System;

namespace LinqTutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task1");
            LinqTasks.Task1().DisplayResultFromTask();
            Console.WriteLine("Task2");
            LinqTasks.Task2().DisplayResultFromTask();
            Console.WriteLine("Task3");
            Console.WriteLine(LinqTasks.Task3());
            Console.WriteLine("Task4");
            LinqTasks.Task4().DisplayResultFromTask();
            Console.WriteLine("Task5");
            LinqTasks.Task5().DisplayResultFromTask();
            Console.WriteLine("Task6");
            LinqTasks.Task6().DisplayResultFromTask();
            Console.WriteLine("Task7");
            LinqTasks.Task7().DisplayResultFromTask();
            Console.WriteLine("Task8");
            Console.WriteLine(LinqTasks.Task8());
            Console.WriteLine("Task9");
            Console.WriteLine(LinqTasks.Task9());
            Console.WriteLine("Task10");
            LinqTasks.Task10().DisplayResultFromTask();
            Console.WriteLine("Task11");
            LinqTasks.Task11().DisplayResultFromTask();
            Console.WriteLine("Task12"); 
            LinqTasks.Task12().DisplayResultFromTask();
            Console.WriteLine("Task13");
            Console.WriteLine(LinqTasks.Task13(new []{1,1,1,1,1,1,10,1,1,1,1}));
            Console.WriteLine("Task14");
            foreach (var t in LinqTasks.Task14())
            {
                Console.WriteLine(t.Dname);
            }
            
        }
    }
}
