using CustomStack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace StackTestsLib.LongTests
{
    [TestClass]
    public class LongException
    {
        private CustomStack<long> IntStack;

        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("Test Initialize");
            IntStack = new CustomStack<long>(5);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("CleanUp");
            IntStack.Dispose();
        }

        [ExpectedException(typeof(Exception), "Exception!")]
        [TestMethod]
        public void OverStack_Exception() //Переполнение Stack
        {
            for (int i = 0; i < IntStack.MaxCount + 1; i++)
                IntStack.Push(i);
        }

        [ExpectedException(typeof(Exception), "Exception!")]
        [TestMethod]
        public void PopEmptyStack_Exception() //Пустой Stack
        {
            IntStack.Pop();
        }

        [ExpectedException(typeof(Exception), "Exception!")]
        [TestMethod]
        public void PeekEmptyStack_Exception() //Пустой Stack
        {
            IntStack.Peek();
        }

        [ExpectedException(typeof(Exception), "Exception!")]
        [TestMethod]
        public void AfterDispose_Exception() //Работа со Stack после Dispose
        {
            IntStack.Push(5);
            var result = IntStack.Count;
            Assert.AreEqual(1, result);
            IntStack.Dispose();
            var result2 = IntStack.IsEmpty();
            Assert.AreEqual(true, result2);
            IntStack.Push(5);
            var result3 = IntStack.Count;
            Assert.AreEqual(1, result3);
            var result4 = IntStack.IsEmpty();
            Assert.AreEqual(false, result4);
        }
    }
}
