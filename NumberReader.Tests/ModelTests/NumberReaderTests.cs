using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberReader.Models;
using System;
using System.Collections.Generic;

namespace NumberReader.Tests
{
  [TestClass]
  public class NumberReaderTests
  {
    [TestMethod]
    public void Number_CreateInstanceOfNumber_Number()
    {
      Number newNumber = new Number("7");
      Assert.AreEqual(typeof(Number), newNumber.GetType());
    }

    [TestMethod]
    public void GatherUserInput_ReturnsNumber_Int()
    {
      Number newNumber = new Number("7");
      string stringUserNumber = "7";
      string expected = stringUserNumber;
      string result = newNumber.UserNumber;
      Assert.AreEqual(expected, result);
    }

    [TestMethod]

    public void ReadSingleDigit_ReturnsSingleDigitAsStringWord_String()
    {
      Number newNumber = new Number("7");
      string expected = "seven";
      string result = newNumber.ReadSingleDigit();
      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void IntegerToCharArray_ReturnsInputAsCharArray_CharArray()
    {
      Number newNumber = new Number("17897");
      int[] expected = {1, 7, 8, 9, 7};
      int[] result = newNumber.IntegerArray();
      CollectionAssert.AreEqual(expected, result);

    }

    [TestMethod]

    public void ChunkThrees_ReturnsDictionaryOfThreeDigitChunks_Dictionary()
    {
      Number newNumber = new Number("17323897");
      Dictionary<int, int[]> expected = new Dictionary<int, int[]> () {{1, new [] {8, 9, 7}}, {2, new [] {3, 2, 3}}, {3, new [] {1, 7}}};
      Dictionary<int, int[]> result = newNumber.ChunkThrees();
      CollectionAssert.AreEqual(expected, result);
    }
  }
}
