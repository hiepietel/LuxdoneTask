using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LineDrawer.Extensions
{
    public static class PointExtensions
    {
        public static Point RescalePoint(this Point point)
        {
            int xe = point.X % 10;
            point.X -= xe;

            int ye = point.Y % 10;
            point.Y -= ye;

            return point;
        }

        public static Point CreateRescaledPoint(int x, int y)
        {
            var point = new Point(x, y);
            return RescalePoint(point);
        }
    }
}
