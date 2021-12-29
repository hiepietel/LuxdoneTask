using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineDrawer.Model
{
    public class Coefficient
    {
        public int ThirdPower { get; set; } // x^3
        public int SecondPower{ get; set; } //x^2
        public int FirstPower { get; set; }
        public int NoPower { get; set; }
    }
}
