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

        public MainForm()
        {
            InitializeComponent();
            g = mainPanel.CreateGraphics();
            pen = new Pen(Color.Black, 5);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if( x == -1 || y == -1)
            {
                x = e.X;
                y = e.Y;
                return;
            }

            var p = new Point()
            {
                X = x,
                Y = y
            };
            var pNew = new Point()
            {
                X = e.X,
                Y = e.Y
            };
            g.DrawLine(pen, p, pNew);
            x = e.X;
            y = e.Y;    
        }
    }
}
