using LineDrawer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _pointDrawerService.DrawPoint(g, e.X, e.Y);
            _lineDrawerService.DrawLine(g, e.X, e.Y);
                           
        }
    }
}
