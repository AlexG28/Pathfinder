using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinder
{
    internal class Algorithm
    {
        static int V = 10;

        int[,] graph;
        int dimension;
        Queue<int[]> cellQueue = new Queue<int[]>();
        List<int[]> visited = new List<int[]>();

        public Algorithm(int [,] graph)
        {
            this.graph = (int[,])graph.Clone();
            this.dimension = graph.GetLength(0);
        }
        
        public void BFS (int startX, int startY)
        {
            int dimension = graph.GetLength(0);
            int[,] newGraph = (int[,])graph.Clone(); // makes a clone


            //List<int>[,] paths = new List<int>[dimension,dimension];

            this.cellQueue.Enqueue(new int[] { startX, startY});

            int currX, currY;
            int[] temp = new int[2];
            
            while (cellQueue.Count > 0)
            {

                temp = cellQueue.Dequeue();
                currX = temp[0];
                currY = temp[1];
                
                if (contains1(currX, currX))
                {
                    continue;
                }

                if (!checkCell(currX, currY))
                {
                    break;
                }
            }

            Console.WriteLine("finished");
        }

        bool checkCell(int x, int y)
        {    

            if (graph[x, y] == 3) // break
            {
                return false;
            }



            if (x == 0)
            {
                if (!contains1(x + 1, y))
                {
                    this.cellQueue.Enqueue(new [] { x + 1, y });
                }
            } else if (x == dimension - 1)
            {
                if (!contains1(x - 1, y))
                {

                    this.cellQueue.Enqueue(new[] { x - 1, y });
                }
            } else
            {

                if (!contains1(x + 1, y))
                {
                    this.cellQueue.Enqueue(new[] { x + 1, y });
                }
                if (!contains1(x - 1, y))
                {
                    this.cellQueue.Enqueue(new[] { x - 1, y });
                }
            }


            if (y == 0)
            {
                if (!contains1(x, y + 1))
                {

                    this.cellQueue.Enqueue(new[] { x, y + 1 });
                }
            } else if (y == dimension - 1)
            {
                if (!contains1(x, y - 1))
                {

                    this.cellQueue.Enqueue(new[] { x, y - 1 });
                }
            } else
            {
                if (!contains1(x, y + 1))
                {

                    this.cellQueue.Enqueue(new[] { x, y + 1 });
                }
                if (!contains1(x, y - 1))
                {

                    this.cellQueue.Enqueue(new[] { x, y - 1 });
                }
            }
            
            // also need to add previous element to the list 
            visited.Add(new int[] { x, y });

            return true;
        }

        bool contains1(int x, int y)
        {
            foreach (int[] element in visited)
            {
                if (element[0] == x && element[1] == y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
