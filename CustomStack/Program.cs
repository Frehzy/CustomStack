using System;

namespace CustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> IntStack = new CustomStack<string>(3);
            IntStack.Push("Первое");
            IntStack.Push("Второе");
            var result = IntStack.CopyTo(2);
            var result2 = IntStack.CopyTo(5);

        }
    }
}
