using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using fans;
namespace NET
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            String s = "0000010111";
            FA fa = new FA();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void FA1_Valid_OneZero_OneOne()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("01"));
        }

        [TestMethod]
        public void FA1_Valid_OneZero_ManyOnes()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("0111"));
        }

        [TestMethod]
        public void FA1_Valid_OneZero_OneOne_TrailingZeros()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("10"));
        }

        [TestMethod]
        public void FA1_Valid_OneZero_Complex()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("1010111"));
        }

        [TestMethod]
        public void FA1_Invalid_NoZero()
        {
            var fa = new FA1();
            Assert.IsFalse(fa.Run("111"));
        }

        [TestMethod]
        public void FA1_Invalid_TwoZeros_NoOne()
        {
            var fa = new FA1();
            Assert.IsFalse(fa.Run("00"));
        }

        [TestMethod]
        public void FA1_Invalid_TwoZeros_WithOnes()
        {
            var fa = new FA1();
            Assert.IsFalse(fa.Run("010"));
        }

        [TestMethod]
        public void FA1_Invalid_OnlyZero()
        {
            var fa = new FA1();
            Assert.IsFalse(fa.Run("0"));
        }

        [TestMethod]
        public void FA2_Valid_OneZero_OneOne()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("01"));
        }

        [TestMethod]
        public void FA2_Valid_ThreeZeros_OneOne()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("0001"));
        }

        [TestMethod]
        public void FA2_Valid_OneZero_ThreeOnes()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("0111"));
        }

        [TestMethod]
        public void FA2_Valid_Mixed()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("001011"));
        }

        [TestMethod]
        public void FA2_Invalid_EvenZeros_EvenOnes()
        {
            var fa = new FA2();
            Assert.IsFalse(fa.Run("0011"));
        }

        [TestMethod]
        public void FA2_Invalid_OddZeros_EvenOnes()
        {
            var fa = new FA2();
            Assert.IsFalse(fa.Run("0010"));
        }

        [TestMethod]
        public void FA2_Invalid_EvenZeros_OddOnes()
        {
            var fa = new FA2();
            Assert.IsFalse(fa.Run("001"));
        }

        [TestMethod]
        public void FA2_Invalid_Empty()
        {
            var fa = new FA2();
            Assert.IsFalse(fa.Run(""));
        }

        [TestMethod]
        public void FA3_Valid_Simple11()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("11"));
        }

        [TestMethod]
        public void FA3_Valid_WithZeros()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("0110"));
        }

        [TestMethod]
        public void FA3_Valid_Multiple11()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("11011"));
        }

        [TestMethod]
        public void FA3_Valid_EndsWith11()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("1011"));
        }

        [TestMethod]
        public void FA3_Invalid_No11()
        {
            var fa = new FA3();
            Assert.IsFalse(fa.Run("10101"));
        }

        [TestMethod]
        public void FA3_Invalid_OnlyOne1()
        {
            var fa = new FA3();
            Assert.IsFalse(fa.Run("1"));
        }

        [TestMethod]
        public void FA3_Invalid_OnlyZeros()
        {
            var fa = new FA3();
            Assert.IsFalse(fa.Run("000"));
        }
    }
}