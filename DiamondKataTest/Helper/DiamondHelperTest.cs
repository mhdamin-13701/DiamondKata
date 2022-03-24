using DiamondKata.Classes;
using DiamondKata.Helper;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DiamondKataTest.Helper
{
    public class DiamondHelperTest
    {
        [Test]
        public void RETURN_ARGUMENTEXCEPTION_ERROR_IF_THE_CHARACTER_NOT_BETWEEN_A_TO_Z() 
        {
            char chr = '4';
            Assert.Throws<ArgumentException>(() => { chr.CalculateResult(); });
        }

        [Test]
        public void PRINT_ONLY_THE_FIRST_CHARACTER_IF_THE_FIRST_CHARACTER_IS_A()
        {
            char chr = 'A';
            List<Diamond> result = chr.CalculateResult();
            List<DiamondResult> diamondResult = result.PreparationResultToPrint();
            var diamondListToPrint = diamondResult.PrintDiamondResult();
            Assert.AreEqual(diamondListToPrint[0], chr);
        }
        [Test]
        public void B_SHOULD_HAVE_SEPARATE_LINES()
        {
            char chr = 'B';
            List<Diamond> result = chr.CalculateResult();
            List<DiamondResult> diamondResult = result.PreparationResultToPrint();
            var diamondListToPrint = diamondResult.PrintDiamondResult();
            var expected = "-A-\r\nB-B\r\n-A-\r\n";
            Assert.AreEqual(diamondListToPrint.ToString(), expected);
        }

        [Test]
        public void B_SHOULD_REPEAT_CHARACTERS()
        {
            char chr = 'B';
            List<Diamond> result = chr.CalculateResult();
            List<DiamondResult> diamondResult = result.PreparationResultToPrint();
            var diamondListToPrint = diamondResult.PrintDiamondResult();
            Assert.AreEqual(diamondListToPrint.ToString().ToCharArray().Count(repeat => repeat == chr), 2);
        }
    }
}
