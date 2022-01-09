using System.Drawing;

namespace LineDrawer.Services.Interfaces
{
    public interface IPointDrawerService
    {
        void DrawPoint(Graphics g, int x, int y);
    }
}