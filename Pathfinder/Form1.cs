using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pathfinder
{
    public partial class Form1 : Form
    {
        
        Grid newGrid = new Grid(50, 50, 20);
        
        public Form1()
        {
            InitializeComponent();
            this.Width = 500;
            this.Height = 500;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            newGrid.Draw(e);
            
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
            // replace 50 with an actual variable 
            if (e.X >= 50 && 
                e.X <= 50 + 200 &&
                e.Y >= 50 &&
                e.Y <= 50 + 200)
            {
                newGrid.click(e.X, e.Y);
            } else
            {
                newGrid.click(-1, -1);
            }

            Refresh();
        }
    }
}
