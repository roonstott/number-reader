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
    public void IntegerToIntList_ReturnsInputAsIntArray_IntArray()
    {
      Number newNumber = new Number("17897");
      List<int> expected = new List<int> {1, 7, 8, 9, 7};
      List<int> result = newNumber.IntegerList();
      CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]

    public void ChunkThrees_ReturnsDictionaryOfThreeDigitChunks_Dictionary()
    {
      Number newNumber = new Number("17323897");
      Dictionary<int, List<int>> expected = new Dictionary<int, List<int>> () {{1, new List<int> {8,9,7}}, {2, new List<int> {3,2,3}}, {3, new List<int> {1,7}}};
      Dictionary<int, List<int>> result = newNumber.ChunkThrees();
      for (int index = 1; index<=3; index++)
      {
        CollectionAssert.AreEqual(expected[index], result[index]);
      }
    }

    [TestMethod]

    public void ReadTwo_ReadsTwoDigits_String()
    {
      Number newNumber = new Number("17323897");
      Dictionary<int, List<int>> dictionary = newNumber.ChunkThrees();
      List<int> list1 = dictionary[1];
      List<int> list3 = dictionary[3];
      string result1 = newNumber.ReadTwo(list1);
      string expected1 = "ninety seven";
      string result3 = newNumber.ReadTwo(list3);
      string expected3 = "seventeen";
      Assert.AreEqual(result1, expected1);
      Assert.AreEqual(result3, expected3);
    }

    [TestMethod]

    public void ReadAChunk_ReadsThreeDigits_String()
    {
      Number newNumber = new Number("17323897");
      Dictionary<int, List<int>> dictionary = newNumber.ChunkThrees();
      List<int> list1 = dictionary[1];
      List<int> list3 = dictionary[3];
      string result1 = newNumber.ReadAChunk(list1);
      string expected1 = "eight hundred ninety seven";
      string result3 = newNumber.ReadAChunk(list3);
      string expected3 = "seventeen";
      Assert.AreEqual(result1, expected1);
      Assert.AreEqual(result3, expected3);
    }
  }
}
