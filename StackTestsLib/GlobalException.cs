using CustomStack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace StackTestsLib
{
    [TestClass]
    public class GlobalException
    {
        [ExpectedException(typeof(Exception), "Exception!")]
        [TestMethod]
        public void CreateStack_Exception() //Ошибка при создании слишком маленького stack
        {
            CustomStack<int> IntStack = new CustomStack<int>(-1);
            CustomStack<string> StringStack = new CustomStack<string>(-1);
            CustomStack<long> LongStack = new CustomStack<long>(-1);
        }
        [TestMethod]
        public void CreateStack()
        {
            CustomStack<int> IntStack = new CustomStack<int>(0);
            Assert.AreEqual(0, IntStack.MaxCount);
            CustomStack<string> StringStack = new CustomStack<string>(0);
            Assert.AreEqual(0, StringStack.MaxCount);
            CustomStack<long> LongStack = new CustomStack<long>(0);
            Assert.AreEqual(0, LongStack.MaxCount);
        }
        [ExpectedException(typeof(Exception), "Exception!")]
        [TestMethod]
        public void CreateStack_Exception2() //Ошибка при создании слишком большого stack
        {
            CustomStack<int> IntStack = new CustomStack<int>(32768);
            CustomStack<string> StringStack = new CustomStack<string>(32768);
            CustomStack<long> LongStack = new CustomStack<long>(32768);
        }
        [TestMethod]
        public void CreateStack2()
        {
            CustomStack<int> IntStack = new CustomStack<int>(32767);
            Assert.AreEqual(32767, IntStack.MaxCount);
            CustomStack<string> StringStack = new CustomStack<string>(32767);
            Assert.AreEqual(32767, StringStack.MaxCount);
            CustomStack<long> LongStack = new CustomStack<long>(32767);
            Assert.AreEqual(32767, LongStack.MaxCount);
        }
    }
}
