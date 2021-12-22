using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinder
{
    internal class Algorithm
    {
        //static int V = 10;

        int[,] graph;
        int dimension;
        Queue<int[]> cellQueue = new Queue<int[]>();
        
        List<int[]> visited = new List<int[]>();
        
        Dictionary<int[], int[]> previousElements = new Dictionary<int[], int[]>(new SequenceEqualityComparer<int>());

        public Algorithm(int [,] graph)
        {
            this.graph = (int[,])graph.Clone();
            this.dimension = graph.GetLength(0);
            // this.previousElements.Add(new int[] {10, 20}, new int[] { 40, 50 });
        }
        
        public List<int[]> BFS (int startX, int startY, int destX, int destY)
        {
            
            int dimension = graph.GetLength(0);
            
            int[,] newGraph = (int[,])graph.Clone(); // makes a clone            

            this.cellQueue.Enqueue(new int[] { startX, startY});

            int currX, currY;
            int[] temp = new int[2];
            
            while (cellQueue.Count > 0)
            {

                temp = cellQueue.Dequeue();
                currX = temp[0];
                currY = temp[1];
                
                if (contains1(currX, currY) == true)
                {
                    continue;
                }

                if (!checkCell(currX, currY))
                {
                    continue;
                }
            }
            
            Console.Write("hello hahahhahahahah");

            List<int[]> output = this.printPath(destX, destY);

            return output;

           
        }

        bool checkCell(int x, int y)
        {    

            if (graph[x, y] == 3) 
            {
                return false;
            }

            if (x == 0)
            {
                if (!contains1(x + 1, y))
                {
                    this.cellQueue.Enqueue(new [] { x + 1, y });
                    this.previousElements.Add(new int[] { x + 1, y }, new int[] { x, y });
                }
            } else if (x == dimension - 1)
            {
                if (!contains1(x - 1, y))
                {
                    this.cellQueue.Enqueue(new[] { x - 1, y });
                    this.previousElements.Add(new int[] { x - 1, y }, new int[] { x, y });
                }
            } else
            {

                if (!contains1(x + 1, y))
                {
                    this.cellQueue.Enqueue(new[] { x + 1, y });
                    this.previousElements.Add(new int[] { x + 1, y }, new int[] { x, y });
                }
                if (!contains1(x - 1, y))
                {
                    this.cellQueue.Enqueue(new[] { x - 1, y });
                    this.previousElements.Add(new int[] { x - 1, y }, new int[] { x, y });
                }
            }


            if (y == 0)
            {
                if (!contains1(x, y + 1))
                {
                    this.cellQueue.Enqueue(new[] { x, y + 1 });
                    this.previousElements.Add(new int[] { x, y + 1}, new int[] { x, y });
                }
            } else if (y == dimension - 1)
            {
                if (!contains1(x, y - 1))
                {
                    this.cellQueue.Enqueue(new[] { x, y - 1 });
                    this.previousElements.Add(new int[] { x, y - 1 }, new int[] { x, y });
                }
            } else
            {
                if (!contains1(x, y + 1))
                {
                    this.cellQueue.Enqueue(new[] { x, y + 1 });
                    this.previousElements.Add(new int[] { x, y + 1 }, new int[] { x, y });
                }
                if (!contains1(x, y - 1))
                {
                    this.cellQueue.Enqueue(new[] { x, y - 1 });
                    this.previousElements.Add(new int[] { x, y - 1 }, new int[] { x, y });
                }
            }                     
 
            visited.Add(new int[] { x, y });        

            return true;
        }

        bool contains1(int x, int y)
        {
            
            bool inVisited = false;
            bool inQueue = false;

            if (visited.Any(p => p.SequenceEqual(new[] { x, y })))
            {
                inVisited = true;
            }

            if (cellQueue.Any(p => p.SequenceEqual(new[] {x, y })))
            {
                inQueue = true;
            }

            if ((inVisited || inQueue) || graph[x, y] == 3) // maybe change this to and ??????
            {
                return true;
            } else
            {
                return false;
            }


            /*
            if (visited.Any(p => p.SequenceEqual(new[] { x, y })))
            {
                return true;
            }

            return false;
            */

        }


        public List<int[]> printPath(int x, int y)
        {
            bool previousExists = true;

            List<int[]> path = new List<int[]>();

            path.Add(new int[] { x, y });

            int[] temp;
            int[] temp2;
            
            foreach (var pair in previousElements)
            {
                Console.WriteLine("The previous of [ {0}, {1} ] is [ {2}, {3} ]", pair.Key[0], pair.Key[1], pair.Value[0], pair.Value[1]);
            }

            while (previousExists)
            {
                temp2 = path[path.Count - 1];

                if (temp2[0] == 0 && temp2[1] == 0)
                {
                    Console.WriteLine("Done????????");
                    path.Reverse();
                    return path;
                }

                if (!previousElements.TryGetValue(temp2, out temp))
                {
                    Console.WriteLine("Not good");

                }
                path.Add(temp);
               
            }

            return path;  
        }
    }

    public class SequenceEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (ReferenceEquals(x, y))
                return true;
            else if (null == x || null == y)
                return false;

            return Enumerable.SequenceEqual(x, y, EqualityComparer<T>.Default);
        }

        public int GetHashCode(IEnumerable<T> obj) =>
          obj == null ? 0 : obj.FirstOrDefault()?.GetHashCode() ?? 0;
    }
}
