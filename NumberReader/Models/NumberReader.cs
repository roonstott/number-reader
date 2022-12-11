using System;
using System.Collections.Generic;


namespace NumberReader.Models
{

  public class Number
  {
    public string UserNumber { get; set; }

    private Dictionary<int, string> SingleDigit = new Dictionary<int, string> () {{0, ""}, {1, "one"}, {2, "two"}, {3, "three"}, {4, "four"}, {5, "five"}, {6, "six"}, {7, "seven"}, {8, "eight"}, {9, "nine"}};

    private Dictionary<int, string> Teens = new Dictionary<int, string> () {{0, "ten"}, {1, "eleven"}, {2, "twelve"}, {3, "thirteen"}, {4, "fourteen"}, {5, "fifteen"}, {6, "sixteen"}, {7, "seventeen"}, {8, "eighteen"}, {9, "nineteen"}};

    private Dictionary<int, string> DoubleDigits = new Dictionary<int, string> () {{2, "twenty"}, {3, "thirty"}, {4, "forty"}, {5, "fifty"}, {6, "sixty"}, {7, "seventy"}, {8, "eighty"}, {9, "ninety"}};

    private Dictionary<long, string> Tens = new Dictionary<long, string> () {{1, " "}, {2, "thousand"}, {3, "million"}, {4, "billion"}, {5, "trillion"}, {6, "quadrillion"}, {7, "quintrillion"}, {8, "sextillion"}, {9, "septillion"}, {10, "octillion"}, {11, "nonillion"}, {12, "decillion"}};
  
    public Number(string stringUserNumber)
    {
      UserNumber = stringUserNumber;
    }

    public string ReadAChunk(List<int> chunk)
    {
      int length = chunk.Count;
      if (length == 1)
      {
        return SingleDigit[chunk[0]];
      }
      else if (length == 2 || (length == 3 && chunk[0] == 0))
      {
        return ReadTwo(chunk);
      }
      else
      {
        return SingleDigit[chunk[0]] + " hundred " + ReadTwo(chunk);
      }      
    }

    public string ReadTwo(List<int>chunk)
    {
      int length = chunk.Count;
      if (chunk[length-2] == 1)
        {
          return Teens[chunk[length-1]];
        }
      else if (chunk[length-2] == 0)
      {
        return SingleDigit[chunk[length-1]];
      }
      else 
      {
        return DoubleDigits[chunk[length-2]] + " " + SingleDigit[chunk[length-1]];
      }
    }

    public string ReadItAll()
    {
      Dictionary <int, List<int>> chunkDictionary = ChunkThrees();
      string output = " ";

      for (int index = 12; index > 0; index--)
      {
        if (chunkDictionary.ContainsKey(index))
        {
        output += ReadAChunk(chunkDictionary[index]) + " " + Tens[index] + " ";
        }
      }
      return output; 
    }

    public List<int> IntegerList() // ex. input: int 321 
    {
      char[] charArray = UserNumber.ToCharArray();
      
      List<int> intList = new List<int> { };
      foreach (char character in charArray)
      {
        intList.Add(Int32.Parse(character.ToString()));
      }
      return intList;
    }

    public Dictionary<int, List<int> > ChunkThrees()
    {
      List<int> intList = IntegerList(); //ex. {3, 2, 4, 5, 1, 9, 3, 1}
      int length = intList.Count;  // ex. 8
      int remainder = length % 3; // ex. 2
      int wholeChunks = (length-remainder)/3; //ex. 2
      Dictionary<int, List<int>> chunkDictionary = new Dictionary<int, List<int>>() { };
      
      // Whole Chunks of Three

      for (int index = 1; index<=wholeChunks; index++)
      {
        List<int> chunkList = new List<int> { };

          for (int innerIndex = 0; innerIndex <= 2; innerIndex++)
          {     
            int spotsBack = 3*index - innerIndex;
            int exactSpot = length - spotsBack;
            chunkList.Add(intList[exactSpot]);
          }
        if(chunkList[0] + chunkList[1] + chunkList[2] != 0)
        {
        chunkDictionary[index] = chunkList;
        }
      }

      //Partial Chunk
      if(remainder>0)
      {
        List<int> chunkList = new List<int> { };
        if(remainder == 1 && intList[0] != 0)
        {
          chunkList.Add(intList[0]);
        }
        else if(remainder == 2 && (intList[0] + intList[1] != 0))
        {
          chunkList.Add(intList[0]);
          chunkList.Add(intList[1]);
        }
        if(chunkList.Count > 0)
        {
        chunkDictionary[wholeChunks + 1] = chunkList;
        }
      } 
      return chunkDictionary;    
    }   
  }
}
