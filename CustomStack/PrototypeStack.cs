using System;
using System.Linq;

namespace CustomStack
{
    public interface IStack<T>
    {
        public abstract void Push(T item);
        public abstract T Pop();
        public abstract T Peek();
        public abstract bool Contains(T item);
        public abstract T[] CopyTo(int arrayIndex);
        public abstract bool IsEmpty();
        public abstract void Clear();
        public abstract int Count { get; }
        public abstract int MaxCount { get; }
    }

    public class CustomStack<T> : IStack<T>, IDisposable
    {
        private int Size; //размер стека на данный момент
        private T[] Stack; //обобщённый тип (дженерик) стека
        private int MaxStackSize; //максимальный размер стека
        public T this[int index] //индексатор для стека
        {
            get 
            {
                if (index >= Stack.Length)
                    throw new Exception("Выход за пределы стека");
                return Stack[index]; 
            }
            private set { Stack[index] = value; }
        }

        public int Count => Size;
        public int MaxCount => MaxStackSize;

        public CustomStack()
        {
            Stack = new T[Int32.MaxValue / 2];
            Size = 0;
            this.MaxStackSize = Int32.MaxValue / 2;
        }

        public CustomStack(int MaxStackSize)
        {
            Stack = new T[MaxStackSize];
            Size = 0;
            this.MaxStackSize = MaxStackSize;
        }

        public void Push(T item)
        {
            if (Size == MaxStackSize)
                throw new Exception("Переполнение стека");
            Stack[Size++] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new Exception("Стек пуст");
            var item = Stack[--Size];
            Stack[Size] = default;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("Стек пуст");
            return Stack[Size - 1];
        }

        public bool Contains(T item)
        {
            return Stack.Contains(item);
        }

        public bool IsEmpty()
        {
            if (Size == 0)
                return true;
            else
                return false;
        }
        public void Clear()
        {
            Array.Clear(Stack, 0, MaxStackSize);
            Size = 0;
        }

        public T[] GetStack()
        {
            T[] tempArray = new T[Size];
            Array.Copy(Stack, tempArray, Size);
            Array.Reverse(tempArray, 0, tempArray.Length);
            return tempArray;
        }

        public T[] CopyTo(int arrayIndex)
        {
            var oldStack = GetStack();
            CustomStack<T> ResultStack;
            if (Size >= arrayIndex)
                ResultStack = new CustomStack<T>(Size);
            else
                ResultStack = new CustomStack<T>(arrayIndex);

            for (int i = 0; i < arrayIndex; i++)
            {
                try
                { ResultStack.Push(oldStack[i]); }
                catch
                { ResultStack.Push(default); }
            }

            Array.Reverse(ResultStack.Stack, 0, ResultStack.Size);
            return ResultStack.GetStack();
        }

        public void Dispose()
        {
            Clear();
            MaxStackSize = 0;
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}
