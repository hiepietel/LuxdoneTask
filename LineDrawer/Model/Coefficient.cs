using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineDrawer.Model
{
    public class Coefficient
    {
        public double ThirdPower { get; set; } // x^3
        public double SecondPower{ get; set; } //x^2
        public double FirstPower { get; set; }
        public double NoPower { get; set; }
    }
}
