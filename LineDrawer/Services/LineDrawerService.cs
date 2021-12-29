using LineDrawer.Model;
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

        Point firstPoint;
        Pen pen;
        public LineDrawerService()
        {
            firstPoint = new Point(-1, -1);
            pen = new Pen(Color.Black, 5);
        }

        public void DrawLine(Graphics g,int x, int y)
        {
            if (firstPoint.X < 0 && firstPoint.Y < 0)
            {
                firstPoint = new Point(x, y);
                return;
            }
            else
            {
                var secondPoint = new Point(x, y);

                var c0 = new Point()
                {
                    X = (firstPoint.X + x) / 3,
                    Y = (firstPoint.Y + y) / 3,
                };
                var c1 = new Point()
                {
                    X = (firstPoint.X + x) * 2 / 3,
                    Y = (firstPoint.Y + y) * 2 / 3,
                };

                g.DrawBezier(pen, firstPoint, c0, c1, secondPoint);


                firstPoint = new Point(-1, -1);
            }
        }
        private Coefficient GetEquationFromPoints(int p0, int p1, int p2, int p3)
        {
            return new Coefficient()
            {
                ThirdPower = -p0 + 3 * p1 + 3 * p2 + p3,
                SecondPower = 3 * p0 - 6 * p1 + 3 * p2,
                FirstPower = 3 * p0 + 3 * p1,
                NoPower = p0
            };

        }
        private void isIntersect()
        {

        }
    }
}
