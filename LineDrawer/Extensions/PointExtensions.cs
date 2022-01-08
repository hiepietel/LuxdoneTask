using System;
using System.Drawing;

namespace LineDrawer.Extensions
{
    public static class PointExtensions
    {
        public static Point RescalePoint(this Point point)
        {
            int xe = point.X % 5;
            point.X -= xe;

            int ye = point.Y % 5;
            point.Y -= ye;

            return point;
        }

        public static Point CreateRescaledPoint(int x, int y)
        {
            var point = new Point(x, y);
            return RescalePoint(point);
        }

        public static Point MoveRescaledPoint(this Point point, int xDir, int yDir)
        {
            point.X += xDir;
            point.Y += yDir;

            return point;
        }

        public static Rectangle MakeRectangleFromPoint(this Point point, int width = 5)
            => new Rectangle(point.X - width / 2, point.Y - width / 2, width, width);
    }
}