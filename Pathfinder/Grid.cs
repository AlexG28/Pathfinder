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
        SolidBrush redBrush = new SolidBrush(Color.Red);

       
        bool drawCurrent = true;
        int verticalCell;
        int horizontalCell;
        
        int startLength = 10;
        public Grid(int x, int y, int width)
        {
            this.gridStart.X = x;
            this.gridStart.Y = y;
            this.cellWidth = width;
        }

        public void click(int x, int y)
        {
            if (x == -1 && y == -1)
            {
                drawCurrent = false;
            } else
            {
                drawCurrent = true; 


                this.horizontalCell = (int)Math.Floor((x - gridStart.X) / 20);
                this.verticalCell = (int)Math.Floor((y - gridStart.Y) / 20);
            }
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

            if (drawCurrent)
            {

                g.FillRectangle(redBrush, gridStart.X + (horizontalCell * 20) + 1, gridStart.Y + (verticalCell * 20) + 1, 19, 19);
            }
        }

    }
}
