using DiamondKata.Classes;
using DiamondKata.Helper;
using System;
using System.Collections.Generic;

namespace DiamondKata
{
    class Program
    {
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(args[0]))
            {
                throw new ArgumentException("you should add a char parameter between A to Z");
            }
            char.TryParse(args[0],out char chr);
            List<Diamond> result = chr.CalculateResult()   ;
            List<DiamondResult> diamondResult = result.PreparationResultToPrint();
            var diamondListToPrint = diamondResult.PrintDiamondResult();
            Console.WriteLine(diamondListToPrint.ToString());
        }
    }
}