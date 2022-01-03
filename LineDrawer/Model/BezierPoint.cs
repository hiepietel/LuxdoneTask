using System.Drawing;

namespace LineDrawer.Model
{
    public class BezierPoint
    {
        public Point FirstPoint { get; set; }
        public Point C0 { get; set; }
        public Point C1 { get; set; }
        public Point SecondPoint { get; set; }
    }
}