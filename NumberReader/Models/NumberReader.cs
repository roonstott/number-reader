using System;
using System.Collections.Generic;


namespace NumberReader.Models
{

  public class Number
  {
    public int UserNumber { get; set; }
    public Number(string stringUserNumber)
    {
      UserNumber = Int32.Parse(stringUserNumber);
    }
  }
}
