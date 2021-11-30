using System;

namespace CustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> IntStack = new CustomStack<int>(3);
            IntStack.Push(1);
            IntStack.Push(5);
            IntStack.Push(7);
            foreach (var item in IntStack.GetStack())
                Console.WriteLine(item);
            IntStack.Pop();
            foreach (var item in IntStack.GetStack())
                Console.WriteLine(item);
            IntStack.Clear();
            foreach (var item in IntStack.GetStack())
                Console.WriteLine(item);
            IntStack.Push(1);
            IntStack.Push(5);
            foreach (var item in IntStack.GetStack())
                Console.WriteLine(item);
            Console.WriteLine(IntStack.Count);
            IntStack.Pop();
            Console.WriteLine(IntStack.Count);

            Console.WriteLine("____________________");
            IntStack.Dispose();
            foreach (var item in IntStack.GetStack())
                Console.WriteLine(item);

            CustomStack<int> IntStack2 = new CustomStack<int>();
            Console.WriteLine(IntStack2.Count);
            IntStack2.Push(1);
            IntStack2.Push(3);
            Console.WriteLine(IntStack2.Count);
            Console.WriteLine(IntStack2.MaxCount);
            Console.WriteLine("____________________");
            Console.WriteLine("____________________");
            foreach (var item in IntStack2.GetStack())
                Console.WriteLine(item);

            var int3 = IntStack2.CopyTo(4);
            Console.WriteLine("____________________");
            Console.WriteLine("____________________");
            foreach (var item in int3)
                Console.WriteLine(item);
            Console.WriteLine("____________________");
            Console.WriteLine("____________________");
        }
    }
}
