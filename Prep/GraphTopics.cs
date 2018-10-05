using Prep.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Prep
{
    //BFS DFS - O(V+E)
    //Space = O(V)
    public class GraphTopics
    {
        //should use priority queue - min heap with  values values as weights
        public void FindShortestPath(GraphM graph, int src, int dest)
        {
            MinHeap heap = new MinHeap(graph.Vertices.GetLength(0));

            int[] dist = new int[graph.Vertices.GetLength(0)];
            for (int i = 0; i < dist.Length; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[src] = 0;
            heap.Add(src, 0);

            bool[] spt = new bool[graph.Vertices.GetLength(0)];
            int[] parent = new int[graph.Vertices.GetLength(0)];
            parent[src] = src;
            
            while(heap.Count > 0)
            {
                var vertex = heap.ExtractMin();
                spt[vertex] = true;

                var edges = graph.GetAllEdges(vertex);
                for (int i = 0; i < edges.Length; i++)
                {
                    var newDist = dist[vertex] + graph.GetWeight(vertex, edges[i]);
                    if (!spt[edges[i]] && dist[edges[i]] > newDist)
                    {
                        dist[edges[i]] = newDist;
                        heap.update(edges[i], newDist);
                        parent[edges[i]] = vertex;
                    }
                }
            }

            //for (int i = 0; i < dist.Length; i++)
            //{
            //    Console.WriteLine($"{i} --> {dist[i]}");
            //}

            //for (int i = 0; i < parent.Length; i++)
            //{
            //    Console.WriteLine($"{i} --> {parent[i]}");
            //}

            Console.WriteLine($"path - {src} --> {dest}");

            if(dist[dest] < int.MaxValue)
            {
                int temp = dest;
                Console.Write(dest + "<--");
                do
                {
                    Console.Write(parent[temp] + "<--");
                    temp = parent[temp];

                } while (temp != parent[temp]);

                Console.WriteLine();
            }
            
        }

        public void FindShortestPath(Graph graph, int src, int dest)
        {
            MinHeap heap = new MinHeap(graph.Vertices.GetLength(0));

            int[] dist = new int[graph.Vertices.GetLength(0)];
            for (int i = 0; i < dist.Length; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[src] = 0;
            heap.Add(src, 0);

            bool[] spt = new bool[graph.Vertices.GetLength(0)];
            int[] parent = new int[graph.Vertices.GetLength(0)];
            parent[src] = src;

            while (heap.Count > 0)
            {
                var vertex = heap.ExtractMin();
                spt[vertex] = true;

                var edges = graph.GetAllEdges(vertex);
                for (int i = 0; i < edges.Length; i++)
                {
                    var newDist = dist[vertex] + graph.GetWeight(vertex, edges[i]);
                    if (!spt[edges[i]] && dist[edges[i]] > newDist)
                    {
                        dist[edges[i]] = newDist;
                        heap.update(edges[i], newDist);
                        parent[edges[i]] = vertex;
                    }
                }
            }

            //for (int i = 0; i < dist.Length; i++)
            //{
            //    Console.WriteLine($"{i} --> {dist[i]}");
            //}

            //for (int i = 0; i < parent.Length; i++)
            //{
            //    Console.WriteLine($"{i} --> {parent[i]}");
            //}

            Console.WriteLine($"path - {src} --> {dest}");

            if (dist[dest] < int.MaxValue)
            {
                int temp = dest;
                Console.Write(dest + "<--");
                do
                {
                    Console.Write(parent[temp] + "<--");
                    temp = parent[temp];

                } while (temp != parent[temp]);

                Console.WriteLine();
            }
        }

        public void MatrixUniquePaths(int[,] matrix, int m, int n)
        {
            var spt = findShortesPath(m - 1, n - 1, ref matrix, 2, 1);
        }

        public void MatrixUniquePathsIterative(int[,] matrix, int m, int n)
        {
            int si = 2;
            int sj = 1;

            matrix[si, sj] = 0;

            for (int i = si+1; i < m; i++)
            {
                matrix[i, sj] = matrix[i - 1, sj] + matrix[i, sj];  
            }

            for (int j = sj+1; j < n; j++)
            {
                matrix[si, j] = matrix[si, j - 1] + matrix[si, j];
            }

            for (int i = si+1; i < m; i++)
            {
                for (int j = sj+1; j < n; j++)
                {
                    var p1 = matrix[i - 1, j];
                    var p2 = matrix[i, j-1];

                    var sp = p1 > p2 ? p2 : p1;

                    matrix[i, j] = sp + matrix[i, j];
                }
            }

            var result = matrix[m - 1, n - 1];
        }

        private int findShortesPath(int i, int j, ref int[,] matrix, int srci, int srcj)
        {
            if (i < srci || j < srcj)
                return int.MaxValue;

            int p1, p2;

            if (i == 0)
                p1 = int.MaxValue;
            else
                p1 = findShortesPath(i - 1, j, ref matrix, srci, srcj);

            if (j == 0)
                p2 = int.MaxValue;
            else
                p2 = findShortesPath(i, j - 1, ref matrix, srci, srcj);

            var sp = p1 > p2 ? p2 : p1;

            return i == srci && j == srcj ? 0 : sp + matrix[i, j];
        }
    }

    //undirected non weighted graph
    public class Graph
    {
        public LinkedList<GraphNode>[] Vertices;

        public Graph(int V)
        {
            Vertices = new LinkedList<GraphNode>[V];
        }

        public bool EdgeExists(int src, int dest)
        {
            if (src >= Vertices.GetLength(0) || src < 0)
                return false;

            if (dest >= Vertices.GetLength(0) || dest < 0)
                return false;

            var node = Vertices[src].First;
            while(node != null)
            {
                if (node.Value.Vertex == dest)
                    return true;

                node = node.Next;
            }
            return false;
        }

        public void AddEdge(int src, int dest, int? weight)
        {
            if (src >= Vertices.GetLength(0) || src < 0)
                return;

            if (dest >= Vertices.GetLength(0) || dest < 0)
                return;

            if(Vertices[src] == null)
            {
                Vertices[src] = new LinkedList<GraphNode>();
            }
            if (Vertices[dest] == null)
            {
                Vertices[dest] = new LinkedList<GraphNode>();
            }

            Vertices[src].AddFirst(new GraphNode(dest, weight, src));
            Vertices[dest].AddFirst(new GraphNode(src, weight, dest));
        }

        public int GetWeight(int src, int dest)
        {
            if (src >= Vertices.GetLength(0) || src < 0)
                return int.MaxValue;

            if (dest >= Vertices.GetLength(0) || dest < 0)
                return int.MaxValue;

            var node = Vertices[src].First;

            while (node != null)
            {
                if (node.Value.Vertex == dest)
                    return node.Value.Weight.Value;
                node = node.Next;
            }
            return int.MaxValue;
        }

        public int[] GetAllEdges(int src)
        {
            if (src >= Vertices.GetLength(0) || src < 0)
                return null;

            List<int> edges = new List<int>();

            var node = Vertices[src].First;

            while(node != null)
            {
                edges.Add(node.Value.Vertex);
                node = node.Next;
            }
            return edges.ToArray();
        }

        public void DFSRecursive(int src, int dest)
        {
            if (src >= Vertices.GetLength(0) || src < 0)
                return;

            bool[] visited = new bool[Vertices.GetLength(0)];
            DFSUtil(src, ref visited, dest);
        }

        private void DFSUtil(int v, ref bool[] visited, int dest)
        {
            visited[v] = true;
            Console.Write($"--> {v}");

            if(dest > 0 && v == dest)
                Console.WriteLine("found");

            int[] edges = GetAllEdges(v);
            for (int i = 0; i < edges.Length; i++)
            {
                if(!visited[edges[i]])
                {
                    DFSUtil(edges[i], ref visited, dest);
                }
            }
        }

        public bool DFS(int src, int dest)
        {
            if (src >= Vertices.GetLength(0) || src < 0)
                return false;

            bool[] visited = new bool[Vertices.GetLength(0)];
            Stack<int> stack = new Stack<int>();

            stack.Push(src);
            visited[src] = true;

            while(stack.Count > 0)
            {
                var edge = stack.Pop();
                Console.WriteLine($"{src} --> {edge}");

                if (dest > 0 && edge == dest)
                    return true;

                int[] edges = GetAllEdges(edge);
                for (int i = 0; i < edges.Length; i++)
                {
                    if (!visited[edges[i]])
                    {
                        visited[edges[i]] = true;
                        stack.Push(edges[i]);
                    }
                }
            }

            return false;
        }

        public bool BFS(int src, int dest)
        {
            if (src >= Vertices.GetLength(0) || src < 0)
                return false;

            //if (dest >= Vertices.GetLength(0) || dest < 0)
            //    return false;

            bool[] visited = new bool[Vertices.GetLength(0)];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(src);
            visited[src] = true;

            while (queue.Count > 0)
            {
                int[] edges = GetAllEdges(queue.Dequeue());
                for (int i = 0; i < edges.Length; i++)
                {
                    Console.WriteLine($"{src} --> {edges[i]}");
                    
                    if (dest > 0 && dest == i)
                        return true;

                    if(!visited[edges[i]])
                    {
                        queue.Enqueue(edges[i]);
                        visited[edges[i]] = true;
                    }
                }
            }

            return false;
        }

        public void PrintGraph()
        {
            Console.WriteLine("Adjacency List");
            for (int i = 0; i < Vertices.GetLength(0); i++)
            {
                var list = Vertices[i];
                Console.WriteLine($"vertex - {i}");
                var node = list.First;
                while(node != null)
                {
                    Console.Write($"-->{node.Value}");
                    node = node.Next;
                }
                Console.WriteLine();
            }
        }
    }

    //Matrix
    public class GraphM
    {
        public int[,] Vertices;
        public GraphM(int V)
        {
            Vertices = new int[V, V];
        }

        

        public bool EdgeExists(int src, int dest)
        {
            if (src >= Vertices.GetLength(0) || src < 0)
                return false;

            if (dest >= Vertices.GetLength(0) || dest < 0)
                return false;

            return Vertices[src, dest] > 0;
        }

        public int[] GetAllEdges(int src)
        {
            if (src >= Vertices.GetLength(0) || src < 0)
                return null;

            List<int> edges = new List<int>();
            for (int i = 0; i < Vertices.GetLength(0); i++)
            {
                if (Vertices[src, i] > 0)
                    edges.Add(i);
            }

            return edges.ToArray();
        }

        public void DFSRecursive(int src, int dest)
        {
            if (src >= Vertices.GetLength(0) || src < 0)
                return;

            bool[] visited = new bool[Vertices.GetLength(0)];

            for (int i = 0; i < Vertices.GetLength(0); i++)
            {
                if (!visited[i])
                    DFSUtil(src, ref visited, dest);
            }
        }

        private void DFSUtil(int v, ref bool[] visited, int dest)
        {
            visited[v] = true;
            Console.Write($"--> {v}");

            if (dest > 0 && v == dest)
                Console.WriteLine("found");

            int[] edges = GetAllEdges(v);
            for (int i = 0; i < edges.Length; i++)
            {
                if (!visited[edges[i]])
                {
                    DFSUtil(edges[i], ref visited, dest);
                }
            }
        }

        public bool DFS(int src, int dest)
        {
            if (src >= Vertices.GetLength(0) || src < 0)
                return false;

            bool[] visited = new bool[Vertices.GetLength(0)];
            Stack<int> stack = new Stack<int>();

            stack.Push(src);
            visited[src] = true;

            while (stack.Count > 0)
            {
                var edge = stack.Pop();
                Console.WriteLine($"{src} --> {edge}");

                if (dest > 0 && edge == dest)
                    return true;

                int[] edges = GetAllEdges(edge);
                for (int i = 0; i < edges.Length; i++)
                {
                    if (!visited[edges[i]])
                    {
                        visited[edges[i]] = true;
                        stack.Push(edges[i]);
                    }
                }
            }

            return false;
        }

        public bool BFS(int src, int dest)
        {

            if (src >= Vertices.GetLength(0) || src < 0)
                return false;

            //if (dest >= Vertices.GetLength(0) || dest < 0)
            //    return false;

            bool[] visited = new bool[Vertices.GetLength(0)];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(src);
            visited[src] = true;

            while (queue.Count > 0)
            {
                int[] edges = GetAllEdges(queue.Dequeue());
                for (int i = 0; i < edges.Length; i++)
                {
                    Console.WriteLine($"{src} --> {edges[i]}");


                    if (dest > 0 && dest == i)
                        return true;

                    if (!visited[edges[i]])
                    {
                        queue.Enqueue(edges[i]);
                        visited[edges[i]] = true;
                    }

                }
            }

            return false;
        }

        public void AddEdge(int src, int dest, int? weight)
        {
            if (src >= Vertices.GetLength(0) || src < 0)
                return;

            if (dest >= Vertices.GetLength(0) || dest < 0)
                return;

            Vertices[src, dest] = weight.HasValue ? weight.Value : 1;
            Vertices[dest, src] = weight.HasValue ? weight.Value : 1;
        }

        public int GetWeight(int src, int dest)
        {
            if (src >= Vertices.GetLength(0) || src < 0)
                return int.MaxValue;

            if (dest >= Vertices.GetLength(0) || dest < 0)
                return int.MaxValue;

            return Vertices[src, dest];
        }

        public void PrintGraph()
        {
            Console.WriteLine("Matrix");
            for (int i = 0; i < Vertices.GetLength(0); i++)
            {
                Console.Write($"Vertex - {i}");
                for (int j = 0; j < Vertices.GetLength(0); j++)
                {
                    if (Vertices[i, j] > 0)
                        Console.Write($"--{GetWeight(i,j)}-->{j}");
                }
                Console.WriteLine();
            }
        }
    }
}
