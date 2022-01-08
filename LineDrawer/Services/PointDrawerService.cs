using LineDrawer.Extensions;
using LineDrawer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LineDrawer.Services
{
    public class PointDrawerService : IPointDrawerService
    {
        SolidBrush p = new SolidBrush(Color.DarkBlue);
        public PointDrawerService()
        {

        }
        public void DrawPoint(Graphics g,int x, int y)
        {
            var rectangle = PointExtensions.CreateRescaledPoint(x, y).MakeRectangleFromPoint();
            g.FillRectangle(p, rectangle);
        }
    }
}
