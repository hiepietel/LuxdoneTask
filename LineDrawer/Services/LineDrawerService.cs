using LineDrawer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineDrawer.Services
{
    public class LineDrawerService : ILineDrawerService
    {

        List<Point> points;
        Pen pen;
        public LineDrawerService()
        {
            points = new List<Point>();
            pen = new Pen(Color.Black, 5);
        }

        public void DrawLine(Graphics g,int x, int y)
        {
            points.Add(new Point(x, y));

            if (points.Count <= 1)
            {
                return;
            }


            g.DrawLine(pen, points[points.Count - 2], points[points.Count - 1]);

        }


    }
}
