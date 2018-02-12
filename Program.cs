using System;

namespace ConvertNumbers
{
  class Program
  {

    const int BIRNARY = 2;
    const int OCTAL = 8;

    enum eConvertNumber
    {
      binary = 2,
      octal = 8
    }
    static void Main(string[] args)
    {
      string sReceiveNumber = string.Empty;
      double dNumber = 0;


      Console.WriteLine("Convert Decimal to Binary and Octal!!!");

      while (!double.TryParse(sReceiveNumber,out dNumber))
      {
        Console.WriteLine("Press number:");
        sReceiveNumber = Console.ReadLine();
      }
      dNumber = double.Parse(sReceiveNumber);

      Console.WriteLine("Decimal-->Binary: {0}", ConvertDecimalTo(dNumber, eConvertNumber.binary));
      Console.WriteLine("Decimal-->Octal.: {0}", ConvertDecimalTo(dNumber, eConvertNumber.octal));

      Console.ReadLine();

    }

    static string InvertString(string sText)
    {
      string sResult = string.Empty;
      for (int i = sText.Length; 0 < i; i--)
      {
        sResult += sText.Substring(i - 1, 1);
      }
      return sResult;
    }

    static string ConvertDecimalTo(double dNumber, eConvertNumber eType)
    {
      string sResult = string.Empty;
      double dResultRest = 0;
      double dDivide = 0;

      switch (eType)
      {
        case eConvertNumber.binary:
          dDivide = BIRNARY;
          break;
        case eConvertNumber.octal:
          dDivide = OCTAL;
          break;
        default:
          dDivide = 0;
          break;
      }

      while (dNumber > 0.1)
      {
        dResultRest = dNumber % dDivide;
        dNumber = Math.Truncate(dNumber / dDivide);
        sResult += dResultRest.ToString("0");
      }
      return InvertString(sResult);
    }

    

  }
}
