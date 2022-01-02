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
        int startLength = 30;

        bool startAvailable = true;
        bool targetAvailable = true;

        int destinationX, destinationY;
        int startX, startY;

        SolidBrush startSquare = new SolidBrush(Color.Red);
        SolidBrush targetSquare = new SolidBrush(Color.Blue);
        SolidBrush wallSquare = new SolidBrush(Color.Gray);
        SolidBrush pathSquare = new SolidBrush(Color.Yellow);

        List<int[]> path;

        // 1 means start (red)
        // 2 means target (blue)
        // 0 means wall (gray)
        // 4 means path

        /*
        static int[,] graph = new int[,]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        */

        int[,] graph = new int[30, 30];
        



        
        public Grid(int x, int y, int width)
        {         
            this.gridStart.X = x;
            this.gridStart.Y = y;
            this.cellWidth = width;

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    graph[i, j] = 0;
                }
            }        
        }

        public Bitmap testDraw(Bitmap surface, Graphics g)
        {
            for (int i = 0; i <= 20; i++)
            {
                // horizontal
                g.DrawLine(myPen, 0, (i * 20), 400, (i * 20));
                
                //vertical
                g.DrawLine(myPen, (i * 20), 0, (i * 20), 400);
            }

            return surface;
        }

        public Bitmap addSquare1(Bitmap surface, Graphics g, int x, int y, int type)
        {
            int a, b;
            a = (int)(x / 20);
            b = (int)(y / 20);

            if (type == 1)
            {
                destinationX = a;
                destinationY = b;

                g.FillRectangle(startSquare, (a * 20) + 1, (b * 20) + 1, 19, 19);
            }
            else if (type == 2)
            {
                startX = a;
                startY = b;

                g.FillRectangle(targetSquare, (a * 20) + 1, (b * 20) + 1, 19, 19);
            } else if (type == 3)
            {
                g.FillRectangle(wallSquare, (a * 20) + 1, (b * 20) + 1, 19, 19);
            }

            //potentially add if type == 4 for path 

            graph[b, a] = type;

            return surface;
        }

        // work on this later

        public bool checkIfAvailable(int type)
        {
            if (type == 1)
            {
                return startAvailable;
            } else if (type == 2)
            {
                return targetAvailable;
            } 

            return true;
        }


        public void Draw(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            
            for (int i = 0; i <= startLength; i++)
            {
                //vertical    
                g.DrawLine(myPen, gridStart.X + (i * cellWidth), gridStart.Y, gridStart.X + (i * cellWidth), gridStart.Y + 600);

                //horizontal                               
                g.DrawLine(myPen, gridStart.X, gridStart.Y + (i * cellWidth), gridStart.X + 600, gridStart.Y + (i * cellWidth));
            }            
            
            for(int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] == 1)
                    {
                        // start square                      
                        e.Graphics.FillRectangle(startSquare, gridStart.X + (j * 20) + 1, gridStart.Y + (i * 20) + 1, 19, 19);                     
                    } else if (graph[i, j] == 2)
                    {
                        // target square 
                        e.Graphics.FillRectangle(targetSquare, gridStart.X + (j * 20) + 1, gridStart.Y + (i * 20) + 1, 19, 19);
                    } else if (graph[i, j] == 3)
                    {
                        // wall square 
                        e.Graphics.FillRectangle(wallSquare, gridStart.X + (j * 20) + 1, gridStart.Y + (i * 20) + 1, 19, 19);
                    } else if (graph[i, j] == 4)
                    {
                        // path square
                        e.Graphics.FillRectangle(pathSquare, gridStart.X + (j * 20) + 1, gridStart.Y + (i * 20) + 1, 19, 19);
                    }
                }
            }
        }


        public void addSquare(int x, int y, int type)
        {         
            int a, b;
            a = (int)((x - gridStart.X) / 20);
            b = (int)((y - gridStart.Y) / 20);

            if (type == 1)
            {
                destinationX = a;
                destinationY = b;

                startAvailable = false;

            } else if (type == 2)
            {
                startX = a;
                startY = b;

                targetAvailable = false;
            }

            graph[b, a] = type;
        }


        public void findPath()
        {
            Algorithm pathfinder = new Algorithm(graph);

            path = pathfinder.BFS(startY, startX, destinationY, destinationX);

            path.RemoveAt(0);
            path.RemoveAt(path.Count - 1);

            foreach (int[] pathitem in path)
            {
                graph[pathitem[0], pathitem[1]] = 4;
            } 
        }

        public void clear2()
        {

        }

        public void clear()
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    graph[i, j] = 0;
                }
            }
        }
    }
}
