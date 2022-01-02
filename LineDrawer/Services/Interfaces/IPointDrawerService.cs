using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LineDrawer.Services.Interfaces
{
    public interface IPointDrawerService
    {
        void DrawPoint(Graphics g, int x, int y);
    }
}
