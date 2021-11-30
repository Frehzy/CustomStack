using CustomStack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace StackTestsLib.StringTests
{
    [TestClass]
    public class StringException
    {
        private CustomStack<string> IntStack;

        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("Test Initialize");
            IntStack = new CustomStack<string>(5);
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
                IntStack.Push($"{i}");
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
            IntStack.Push("Первое");
            var result = IntStack.Count;
            Assert.AreEqual(1, result);
            IntStack.Dispose();
            var result2 = IntStack.IsEmpty();
            Assert.AreEqual(true, result2);
            IntStack.Push("Второе");
            var result3 = IntStack.Count;
            Assert.AreEqual(1, result3);
            var result4 = IntStack.IsEmpty();
            Assert.AreEqual(false, result4);
        }
    }
}
