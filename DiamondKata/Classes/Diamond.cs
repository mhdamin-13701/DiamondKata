using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondKata.Classes
{
    public class Diamond
    {
        public char Char { get; set; }
        public List<int> Lines { get; set; }
        public List<int> Positions { get; set; }
        public Diamond()
        {
            Lines = new List<int>();
            Positions = new List<int>();
        }
    }
}
