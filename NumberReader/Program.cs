using System;
using System.Collections.Generic;
using NumberReader.Models;

namespace Interface
{
  public class Program
  {
    public static void Main()
    {
      Console.WriteLine("Enter A Number");
      string input = Console.ReadLine();
      Number number = new Number(input);
      string output = number.ReadItAll();
      Console.WriteLine(output);
    }
  }
}