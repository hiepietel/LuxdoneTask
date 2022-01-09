using LineDrawer.Services.Interfaces;
using System.Drawing;
using System.Windows.Forms;

namespace LineDrawer
{
    public partial class MainForm : Form
    {
        Graphics g;

        private readonly ILineDrawerService _lineDrawerService;
        private readonly IPointDrawerService _pointDrawerService;

        public MainForm(ILineDrawerService lineDrawerService, IPointDrawerService pointDrawerService)
        {
            _lineDrawerService = lineDrawerService;
            _pointDrawerService = pointDrawerService;
            InitializeComponent();

            g = mainPanel.CreateGraphics();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (label1.Visible == true)
                label1.Visible = false;
            button1.Enabled = false;
            _pointDrawerService.DrawPoint(g, e.X, e.Y);
            _lineDrawerService.DrawLine(g, e.X, e.Y, checkBox1.Checked);
            button1.Enabled = true;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _lineDrawerService.CleanLinesFromBoard(g);
            if (label1.Visible == false)
                label1.Visible = true;
        }
    }
}