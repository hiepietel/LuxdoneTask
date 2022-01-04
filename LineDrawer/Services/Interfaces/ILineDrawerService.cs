using System.Drawing;

namespace LineDrawer.Services.Interfaces
{
    public interface ILineDrawerService
    {
        void DrawLine(Graphics g, int x, int y);
    }
}
