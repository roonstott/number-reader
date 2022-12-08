using System;
using System.Collections.Generic;


namespace NumberReader.Models
{

  public class Number
  {
    public string UserNumber { get; set; }

    private Dictionary<int, string> SingleDigit = new Dictionary<int, string> () {{1, "one"}, {2, "two"}, {3, "three"}, {4, "four"}, {5, "five"}, {6, "six"}, {7, "seven"}, {8, "eight"}, {9, "nine"}};

    private Dictionary<int, string> Teens = new Dictionary<int, string> () {{10, "ten"}, {11, "eleven"}, {12, "twelve"}, {13, "thirteen"}, {14, "fourteen"}, {15, "fifteen"}, {16, "sixteen"}, {17, "seventeen"}, {18, "eighteen"}, {19, "nineteen"}};

    private Dictionary<int, string> DoubleDigits = new Dictionary<int, string> () {{2, "twenty"}, {3, "thirty"}, {4, "forty"}, {5, "fifty"}, {6, "sixty"}, {7, "seventy"}, {8, "eighty"}, {9, "ninety"}};

    private Dictionary<long, string> Tens = new Dictionary<long, string> () {{100, "hundred"}, {1000, "thousand"}, {1000000, "million"}, {1000000000, "billion"}, {1000000000000, "trillion"}};



    

    public Number(string stringUserNumber)
    {
      UserNumber = stringUserNumber;
    }

    public string ReadSingleDigit()
    {
      int number = int.Parse(UserNumber);
      return SingleDigit[number];
    }

    public int[] IntegerArray() // ex. input: int 321 
    {
      char[] charArray = UserNumber.ToCharArray();
      
      List<int> charList = new List<int> { };
      foreach (char character in charArray)
      {
        charList.Add(Int32.Parse(character.ToString()));
      }
      return charList.ToArray();
    }
  }
}
