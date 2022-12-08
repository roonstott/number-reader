using System;
using System.Collections.Generic;


namespace NumberReader.Models
{

  public class Number
  {
    public int UserNumber { get; set; }

    private Dictionary<int, string> SingleDigit = new Dictionary<int, string> () {{1, "one"}, {2, "two"}, {3, "three"}, {4, "four"}, {5, "five"}, {6, "six"}, {7, "seven"}, {8, "eight"}, {9, "nine"}};

    public Number(string stringUserNumber)
    {
      UserNumber = Int32.Parse(stringUserNumber);
    }

    public string ReadSingleDigit()
    {
      return "test";
    }

  }
}
