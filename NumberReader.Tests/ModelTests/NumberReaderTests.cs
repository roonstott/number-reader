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
      Number newNumber = new Number();
      Assert.AreEqual(typeof(Number), newNumber.GetType());
    }

    [TestMethod]
    public void GatherUserInput_ReturnsNumber_Int()
    {
      string stringUserNumber = "7";
      int userNumber = Int32.Parse(stringUserNumber);
      int result = newNumber.UserNumber;
      Assert.AreEqual(userNumber, result);
    }
  }
}
