using System;
using System.Threading;
using System.Globalization;

namespace ConvertNumbers
{
    class Program
    {

        const int BIRNARY = 2;
        const int OCTAL = 8;
        const int DECI = 10;
        const int HEXA = 16;

        enum eConvertNumber
        {
            binary = 2,
            octal = 8,
            deci = 10,
            hexa = 16
        }

        public static string sReceiveNumber = string.Empty;

        static void Main(string[] args)
        {

            string sAnswerYesNo = "Y";
            string sAnswerOption = "0";
            int iAnswerOption = 0;
            bool bAnswerOption = false;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");



            while (sAnswerYesNo.ToUpper() == "Y")
            {
                sReceiveNumber = string.Empty;
                bAnswerOption = false;
                iAnswerOption = 0;

                Console.Clear();
                Console.SetCursorPosition(0, 0);
                while (!bAnswerOption)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Convert Numbers!!!");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Select option to convert................: [ ]");//line 2, column = 43
                    Console.WriteLine("[1] - DECIMAL to others (binary, octal, hexa)");
                    Console.WriteLine("[2] - BINARY to others (decimal, octal, hexa)");
                    Console.WriteLine("[3] - OCTAL to others (binary, decimal, hexa)");
                    Console.WriteLine("[4] - HEXA to others (binary, octal, decimal)");
                    Console.WriteLine("---------------------------------------------");
                    Console.SetCursorPosition(43, 2);
                    sAnswerOption = Console.ReadLine();
                    if (int.TryParse(sAnswerOption, out iAnswerOption))
                    {
                        iAnswerOption = int.Parse(sAnswerOption);
                        if (iAnswerOption > 0 && iAnswerOption < 5)
                            bAnswerOption = true;
                    }
                }

                Console.SetCursorPosition(0, 8);
                switch (iAnswerOption)
                {
                    case 1:
                        {
                            DecimalToOthers();
                            break;
                        }
                    case 2:
                        BinaryToOthes();
                        break;
                    case 3:
                        Console.WriteLine("Not implements yet!!!");
                        break;
                    case 4:
                        Console.WriteLine("Not implements yet!!!");
                        break;
                }

                Console.WriteLine("For calculate another number press [Y]es OR press ANY thing to finish!!!");
                sAnswerYesNo = Console.ReadLine();
            }
        }

        static void BinaryToOthes()
        {
            //bool bValidateLoop = false;
            //byte byNumber;
            //while (!bValidateLoop)
            //{
            //  Console.WriteLine("Input binary:");
            //  sReceiveNumber = Console.ReadLine();
            //  if (byte.TryParse(sReceiveNumber, out byNumber))
            //    bValidateLoop = true;
            //}

            Console.WriteLine("Input binary:");
            sReceiveNumber = Console.ReadLine();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Binary-->Decimal: {0}", ConvertBinaryTo(sReceiveNumber, eConvertNumber.deci));


        }

        static void DecimalToOthers()
        {
            double dNumber = 0;

            while (!double.TryParse(sReceiveNumber, out dNumber))
            {
                Console.WriteLine("Input decimal:");
                sReceiveNumber = Console.ReadLine();
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Decimal-->Binary: {0}.{1}",
              ConvertDecimalTo(dNumber, eConvertNumber.binary),
              ConvertDecimalPartTo(dNumber, eConvertNumber.binary));
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Decimal-->Octal.: {0}.{1}",
              ConvertDecimalTo(dNumber, eConvertNumber.octal),
              ConvertDecimalPartTo(dNumber, eConvertNumber.octal));
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Decimal-->Octal.: {0}.{1}",
              ConvertDecimalTo(dNumber, eConvertNumber.hexa),
              ConvertDecimalPartTo(dNumber, eConvertNumber.hexa));
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


        static string ConvertDecimalPartTo(double dNumber, eConvertNumber eType)
        {
            string sResult = string.Empty;
            double dMultiple = 0;

            dNumber = dNumber - (int)dNumber;

            switch (eType)
            {
                case eConvertNumber.binary:
                    dMultiple = BIRNARY;
                    break;
                case eConvertNumber.octal:
                    dMultiple = OCTAL;
                    break;
                case eConvertNumber.hexa:
                    dMultiple = HEXA;
                    break;
                default:
                    dMultiple = 0;
                    break;
            }

            while (dNumber != 0.0)
            {
                dNumber *= dMultiple;
                int iRest = (int)dNumber;
                dNumber -= iRest;
                if (eType == eConvertNumber.hexa)
                {
                    switch (iRest)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            sResult += iRest.ToString("0");
                            break;
                        case 10:
                            sResult += "a";
                            break;
                        case 11:
                            sResult += "b";
                            break;
                        case 12:
                            sResult += "c";
                            break;
                        case 13:
                            sResult += "d";
                            break;
                        case 14:
                            sResult += "e";
                            break;
                        case 15:
                            sResult += "f";
                            break;
                    }
                }
                else
                    sResult += iRest.ToString("0");
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
                case eConvertNumber.hexa:
                    dDivide = HEXA;
                    break;
                default:
                    dDivide = 0;
                    break;
            }

            while (dNumber > 0.1)
            {
                dResultRest = dNumber % dDivide;
                dNumber = Math.Truncate(dNumber / dDivide);
                if (eType == eConvertNumber.hexa)
                {
                    switch (dResultRest)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            sResult += dResultRest.ToString("0");
                            break;
                        case 10:
                            sResult += "a";
                            break;
                        case 11:
                            sResult += "b";
                            break;
                        case 12:
                            sResult += "c";
                            break;
                        case 13:
                            sResult += "d";
                            break;
                        case 14:
                            sResult += "e";
                            break;
                        case 15:
                            sResult += "f";
                            break;
                    }
                }
                else
                    sResult += dResultRest.ToString("0");

            }
            return InvertString(sResult);
        }

        static string ConvertBinaryTo(string sNumber, eConvertNumber eType)
        {
            string sResult = string.Empty;
            double dType = 0;
            double dResultRest = 0;

            //byNumber = byte.Parse(sNumber);
            sNumber = InvertString(sNumber);

            switch (eType)
            {
                case eConvertNumber.deci:
                    dType = BIRNARY;
                    for (int i = 0; i <= sNumber.Length - 1; i++)
                    {
                        dResultRest += int.Parse(sNumber.Substring(i, 1)) * Math.Pow(dType, i);
                    }
                    break;
                case eConvertNumber.octal:
                    dType = OCTAL;
                    break;
                case eConvertNumber.hexa:
                    dType = HEXA;
                    break;
                default:
                    dType = 0;
                    break;
            }
            sResult = dResultRest.ToString();

            return sResult;
        }



    }
}
