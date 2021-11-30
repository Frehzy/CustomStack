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
        }
        [TestMethod]
        public void CreateStack() //Ошибка при создании слишком большого stack
        {
            CustomStack<int> IntStack = new CustomStack<int>(0);
            Assert.AreEqual(0, IntStack.MaxCount);
        }
        [ExpectedException(typeof(Exception), "Exception!")]
        [TestMethod]
        public void CreateStack_Exception2() //Ошибка при создании слишком большого stack
        {
            CustomStack<int> IntStack = new CustomStack<int>(32768);
        }
        [TestMethod]
        public void CreateStack2() //Ошибка при создании слишком большого stack
        {
            CustomStack<int> IntStack = new CustomStack<int>(32767);
            Assert.AreEqual(32767, IntStack.MaxCount);
        }
    }
}
