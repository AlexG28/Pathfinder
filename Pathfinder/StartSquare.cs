using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Pathfinder
{
    internal class StartSquare
    {
        bool drawCurrent = true;
        int verticalCell;
        int horizontalCell;
        
        PointF gridStart;
        SolidBrush redBrush = new SolidBrush(Color.Red);

        public StartSquare(PointF gridStart)
        {
            this.gridStart = gridStart;
        }

        public void click(int x, int y)
        {
            if (x == -1 && y == -1)
            {
                drawCurrent = false;
            }
            else
            {
                drawCurrent = true;

                this.horizontalCell = (int)Math.Floor((x - gridStart.X) / 20);
                this.verticalCell = (int)Math.Floor((y - gridStart.Y) / 20);
            }
        }

        public void Draw(PaintEventArgs e)
        {
            if (drawCurrent)
            {

                e.Graphics.FillRectangle(redBrush, gridStart.X + (horizontalCell * 20) + 1, gridStart.Y + (verticalCell * 20) + 1, 19, 19);
            }
        }
    }
}
