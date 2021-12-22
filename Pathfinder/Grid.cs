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
        Pen myPen = new Pen(Color.Black);      
        int cellWidth;
        int startLength = 10;


        SolidBrush startSquare = new SolidBrush(Color.Red);
        SolidBrush targetSquare = new SolidBrush(Color.Blue);
        SolidBrush wallSquare = new SolidBrush(Color.Gray);
        SolidBrush pathSquare = new SolidBrush(Color.Yellow);

        List<int[]> path;

        // 1 means start (red)
        // 2 means target (blue)
        // 0 means wall (gray)
        // 4 means path

        static int[,] graph = new int[,]
        {
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };


        

        
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
            
            for(int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] == 1)
                    {
                        // start square 
                        e.Graphics.FillRectangle(startSquare, gridStart.Y + (j * 20) + 1, gridStart.X + (i * 20) + 1, 19, 19);

                    } else if (graph[i, j] == 2)
                    {
                        // target square 
                        e.Graphics.FillRectangle(targetSquare, gridStart.Y + (j * 20) + 1, gridStart.X + (i * 20) + 1, 19, 19);
                    } else if (graph[i, j] == 3)
                    {
                        // wall square 
                        e.Graphics.FillRectangle(wallSquare, gridStart.Y + (j * 20) + 1, gridStart.X + (i * 20) + 1, 19, 19);
                    } else if (graph[i, j] == 4)
                    {
                        e.Graphics.FillRectangle(pathSquare, gridStart.Y + (j * 20) + 1, gridStart.X + (i * 20) + 1, 19, 19);
                    }
                }
            }
        }

        public void active()
        {
            Algorithm pathfinder = new Algorithm(graph);
            
            path = pathfinder.BFS(0, 0, 4, 9);

            path.RemoveAt(0);
            path.RemoveAt(path.Count - 1);

            foreach (int[] pathitem in path)
            {
                graph[pathitem[0], pathitem[1]] = 4;
                
                //Console.WriteLine("-> [{0},{1}]", pathitem[0], pathitem[1]);
            }

            //Console.WriteLine("done");
        }
    }
}
