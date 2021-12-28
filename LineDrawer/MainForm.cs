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
        int x =-1;
        int y = -1;
        Pen pen;

        private readonly ILineDrawerService _lineDrawService;

        public MainForm(ILineDrawerService lineDrawerService)
        {
            _lineDrawService = lineDrawerService;
            InitializeComponent();

            g = mainPanel.CreateGraphics();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _lineDrawService.DrawLine(g, e.X, e.Y);
        }
    }
}
