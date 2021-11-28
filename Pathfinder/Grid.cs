using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Pathfinder
{
    internal class Grid
    {
        PointF gridStart;
        int cellWidth;

        Pen myPen = new Pen(Color.Black);      
        
        int startLength = 10;
        public Grid(int x, int y, int width)
        {
            this.gridStart.X = x;
            this.gridStart.Y = y;
            this.cellWidth = width;
        }

        public void Draw(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i <= startLength; i++)
            {
                //vertical    
                g.DrawLine(myPen, gridStart.X + (i * cellWidth), gridStart.Y, gridStart.X + (i * cellWidth), gridStart.Y + 200);

                //horizontal                               
                g.DrawLine(myPen, gridStart.X, gridStart.Y + (i * cellWidth), gridStart.X + 200, gridStart.Y + (i * cellWidth));
            }        
        }
    }
}
