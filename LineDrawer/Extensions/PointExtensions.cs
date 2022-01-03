using System;
using System.Drawing;

namespace LineDrawer.Extensions
{
    public static class PointExtensions
    {
        public static Point RescalePoint(this Point point)
        {
            int xe = point.X % 50;
            point.X -= xe;

            int ye = point.Y % 50;
            point.Y -= ye;

            return point;
        }

        public static Point CreateRescaledPoint(int x, int y)
        {
            var point = new Point(x, y);
            return RescalePoint(point);
        }

        public static Point RandomlyMovePoint(this Point point)
        {
            var random = new Random();

            var x_positive = random.Next(10) % 2 == 0 ? 1 : -1;
            var y_positive = random.Next(10, 20) % 2 == 0 ? 1 : -1;

            var x_amount = random.Next(2, 8) * 50;
            var y_amount = random.Next(2, 4) * 50;

            point.X += x_positive * x_amount;
            point.Y += y_positive * y_amount;

            return RescalePoint(point);
        }

        public static Rectangle MakeRectangleFromPoint(this Point point, int width = 20)
            => new Rectangle(point.X - width / 2, point.Y - width / 2, width, width);
    }
}