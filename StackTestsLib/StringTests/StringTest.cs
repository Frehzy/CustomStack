using CustomStack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace StackTestsLib.StringTests
{
    [TestClass]
    public class StringTest
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

        [TestMethod]
        public void PushStack()
        {
            for (int i = 0; i < IntStack.MaxCount; i++)
                IntStack.Push($"{i}");
        }

        [TestMethod]
        public void PopStack()
        {
            IntStack.Push("������");
            IntStack.Push("������");
            IntStack.Pop();
        }

        [TestMethod]
        public void PeekStack()
        {
            IntStack.Push("������");
            IntStack.Push("������");
            IntStack.Peek();
        }

        [TestMethod]
        public void ContainsStack()
        {
            IntStack.Push("������");
            IntStack.Push("������");
            bool result = IntStack.Contains("������");
            bool result2 = IntStack.Contains("������");

            Assert.AreEqual(true, result);
            Assert.AreNotEqual(false, result);
            Assert.AreEqual(false, result2);
            Assert.AreNotEqual(true, result2);
        }

        [TestMethod]
        public void IsEmptyStack()
        {
            IntStack.Push("������");
            IntStack.Push("������");
            bool result = IntStack.IsEmpty();
            Assert.AreEqual(false, result, "��� ��������");
            IntStack.Pop();
            bool result2 = IntStack.IsEmpty();
            Assert.AreEqual(false, result2, "������ ��������");
            IntStack.Pop();
            bool result3 = IntStack.IsEmpty();
            Assert.AreEqual(true, result3, "������ ��������");
        }

        [TestMethod]
        public void ClearAndCheckEmpty()
        {
            IntStack.Push("������");
            IntStack.Push("������");
            bool result = IntStack.IsEmpty();
            Assert.AreEqual(false, result, "��� �������� ��������");
            IntStack.Clear();
            bool result2 = IntStack.IsEmpty();
            Assert.AreEqual(true, result2, "����� �������");
            IntStack.Push("������");
            bool result3 = IntStack.IsEmpty();
            Assert.AreEqual(false, result3, "���������� item ����� �������");
        }

        [TestMethod]
        public void CopyTo()
        {
            IntStack.Push("������");
            IntStack.Push("������");
            var result = IntStack.CopyTo(2);
            var result2 = IntStack.CopyTo(5);
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(5, result2.Length);
        }
    }
}
