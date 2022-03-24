using DiamondKata.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondKata.Helper
{
    public static  class DiamondHelper
    {
        private const char SEPARATION = '-';
        private static Dictionary<char, int> _dictionaryChar = new Dictionary<char, int> 
        { 
            { 'A', 1 } , { 'B', 2 } ,{ 'C', 3 } ,{ 'D', 4 } ,{ 'E', 5 } ,{ 'F', 6 } ,{ 'G', 7 } ,{ 'H', 8 } ,{ 'I', 9 } ,{ 'J', 10 } ,{ 'K', 11 } ,{ 'L', 12 } ,{ 'M', 13 } ,
            { 'N', 14 } ,{ 'O', 15 } ,{ 'P', 16 } ,{ 'Q', 17 } ,{ 'R', 18 } ,{ 'S', 19 } ,{ 'T', 20 } ,{ 'U', 21 } ,{ 'V', 22 } ,{ 'W', 23 } ,{ 'X', 24 } ,{ 'Y', 25 } ,{ 'Z', 26 } 
        };
        public static List<Diamond> CalculateResult(this char chr)
        {
            if (!_dictionaryChar.ContainsKey(Char.ToUpper(chr)) )
            {
                throw new ArgumentException("it is not a valid character");
            }

            List<Diamond> diamondList = new List<Diamond>();
            Diamond diamond;
            //  first character
            if (_dictionaryChar[Char.ToUpper(chr)] == 1)
            {
                diamond = new Diamond() { Char = chr, Lines = new List<int>() {1}, Positions = new List<int>() {1}};
                diamondList.Add(diamond);
                return diamondList;
            }


            //any character 
            //calculate the positions and linens for the current character
            var previousChar = _dictionaryChar.LastOrDefault(k=>k.Key < Char.ToUpper(chr)).Value;
            var currentChar = _dictionaryChar[Char.ToUpper(chr)];
            var lastCurrentPosition = previousChar + currentChar;
            diamond  = new Diamond(){ Char = char.ToUpper(chr), Lines = new List<int>() { _dictionaryChar[Char.ToUpper(chr)] }, Positions = new List<int>() { 1, lastCurrentPosition } };
            diamondList.Add(diamond);

            //calculate the positions and linens for  previous character 
            int count = 1;
            foreach (var item in _dictionaryChar.Where(k => k.Key < Char.ToUpper(chr)).OrderByDescending(order=>order.Key))
            {
                diamond = new Diamond() { Char = Char.ToUpper(item.Key), Lines = new List<int>() { item.Value,  _dictionaryChar[Char.ToUpper(chr)]+count } , Positions = new List<int>() { count+1, lastCurrentPosition-1} };
                count ++;
                lastCurrentPosition--;
                diamondList.Add(diamond);
            }
                return diamondList.OrderBy(o=>o.Char).ToList();
        }

        public static List<DiamondResult> PreparationResultToPrint(this List<Diamond> result) 
        {
            List<DiamondResult> diamondResult = new List<DiamondResult>();
            var maxPos = result.SelectMany(pos => pos.Positions).Max();
            string defaultline = new String(SEPARATION, maxPos);

            result.ForEach(diamond => {
                diamond.Lines.ForEach(line =>
                {
                    StringBuilder sb = new StringBuilder(defaultline);
                    diamond.Positions.Distinct().ToList().ForEach(pos => {
                        sb[pos - 1] = char.ToUpper(diamond.Char);
                    });
                    diamondResult.Add(new DiamondResult { Line = sb.ToString(), LineNbr = line });
                });
            });
            return diamondResult;
        }

        public static StringBuilder PrintDiamondResult(this List<DiamondResult> diamondResult) {

            StringBuilder diamondListResult = new StringBuilder();
            diamondResult.OrderBy(order => order.LineNbr).ToList().ForEach(result =>
            {
                diamondListResult.AppendLine(result.Line);
            });

            return diamondListResult;
        }
    }
}