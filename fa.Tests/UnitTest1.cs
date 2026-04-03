using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using fans;
namespace NET
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            String s = "0111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            String s = "01011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }   
        [TestMethod]
        public void TestMethod3()
        {
            String s = "110101011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }  
        [TestMethod]
        public void TestMethod4()
        {
            String s = "1110111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }  
        [TestMethod]
        public void TestMethod5()
        {
            String s = "10";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        } 
        [TestMethod]
        public void TestMethod6()
        {
            String s = "0101";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }  
        [TestMethod]
        public void TestMethod7()
        {
            String s = "00110011";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }  
        [TestMethod]
        public void TestMethod8()
        {
            String s = "0001";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }  
        [TestMethod]
        public void TestMethod9()
        {
            String s = "111000";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        } 
        [TestMethod]
        public void TestMethod10()
        {
            String s = "00110011";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod11()
        {
            String s = "0101";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }     
    }
    [TestMethod]
public void FA1_Valid_OneZero_OneOne()
{
    FA1 fa = new FA1();
    Assert.IsTrue(fa.Run("01"));
}

[TestMethod]
public void FA1_Valid_OneZero_ManyOnes()
{
    FA1 fa = new FA1();
    Assert.IsTrue(fa.Run("0111"));
}

[TestMethod]
public void FA1_Valid_OneZero_OneOne_TrailingZeros()
{
    FA1 fa = new FA1();
    Assert.IsTrue(fa.Run("10"));
}

[TestMethod]
public void FA1_Valid_OneZero_Complex()
{
    FA1 fa = new FA1();
    Assert.IsTrue(fa.Run("1010111"));
}

[TestMethod]
public void FA1_Invalid_NoZero()
{
    FA1 fa = new FA1();
    Assert.IsFalse(fa.Run("111"));
}

[TestMethod]
public void FA1_Invalid_TwoZeros_NoOne()
{
    FA1 fa = new FA1();
    Assert.IsFalse(fa.Run("00"));
}

[TestMethod]
public void FA1_Invalid_TwoZeros_WithOnes()
{
    FA1 fa = new FA1();
    Assert.IsFalse(fa.Run("010"));
}

[TestMethod]
public void FA1_Invalid_OnlyZero()
{
    FA1 fa = new FA1();
    Assert.IsFalse(fa.Run("0"));
}

[TestMethod]
public void FA2_Valid_OneZero_OneOne()
{
    FA2 fa = new FA2();
    Assert.IsTrue(fa.Run("01"));
}

[TestMethod]
public void FA2_Valid_ThreeZeros_OneOne()
{
    FA2 fa = new FA2();
    Assert.IsTrue(fa.Run("0001"));
}

[TestMethod]
public void FA2_Valid_OneZero_ThreeOnes()
{
    FA2 fa = new FA2();
    Assert.IsTrue(fa.Run("0111"));
}

[TestMethod]
public void FA2_Valid_Mixed()
{
    FA2 fa = new FA2();
    Assert.IsTrue(fa.Run("001011"));
}

[TestMethod]
public void FA2_Invalid_EvenZeros_EvenOnes()
{
    FA2 fa = new FA2();
    Assert.IsFalse(fa.Run("0011"));
}

[TestMethod]
public void FA2_Valid_OddZeros_OddOnes()
{
    FA2 fa = new FA2();
    Assert.IsTrue(fa.Run("0010"));
}

[TestMethod]
public void FA2_Invalid_EvenZeros_OddOnes()
{
    FA2 fa = new FA2();
    Assert.IsFalse(fa.Run("001"));
}

[TestMethod]
public void FA2_Invalid_Empty()
{
    FA2 fa = new FA2();
    Assert.IsFalse(fa.Run(""));
}

[TestMethod]
public void FA3_Valid_Simple11()
{
    FA3 fa = new FA3();
    Assert.IsTrue(fa.Run("11"));
}

[TestMethod]
public void FA3_Valid_WithZeros()
{
    FA3 fa = new FA3();
    Assert.IsTrue(fa.Run("0110"));
}

[TestMethod]
public void FA3_Valid_Multiple11()
{
    FA3 fa = new FA3();
    Assert.IsTrue(fa.Run("11011"));
}

[TestMethod]
public void FA3_Valid_EndsWith11()
{
    FA3 fa = new FA3();
    Assert.IsTrue(fa.Run("1011"));
}

[TestMethod]
public void FA3_Invalid_No11()
{
    FA3 fa = new FA3();
    Assert.IsFalse(fa.Run("10101"));
}

[TestMethod]
public void FA3_Invalid_OnlyOne1()
{
    FA3 fa = new FA3();
    Assert.IsFalse(fa.Run("1"));
}

[TestMethod]
public void FA3_Invalid_OnlyZeros()
{
    FA3 fa = new FA3();
    Assert.IsFalse(fa.Run("000"));
}
}
