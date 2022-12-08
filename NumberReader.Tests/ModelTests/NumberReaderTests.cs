using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberReader.Models;

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
  }
}
