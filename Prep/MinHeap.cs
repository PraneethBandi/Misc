using System;
using System.Collections.Generic;
using System.Text;

namespace Prep
{
    public class MinHeap
    {
        int[] vertices;
        int counter;
        public MinHeap(int capacity)
        {
            vertices = new int[capacity];

            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = int.MaxValue;
            }

            counter = capacity;
        }

        public void Add(int vertex, int dist)
        {
            vertices[vertex] = dist;
        }

        public void update(int vertex, int dist)
        {
            vertices[vertex] = dist;
        }

        public int ExtractMin()
        {
            int min = int.MaxValue;
            int minIndex = -1;
            for (int i = 0; i < vertices.Length; i++)
            {
                if(vertices[i] < min)
                {
                    minIndex = i;
                    min = vertices[i];
                }
            }

            vertices[minIndex] = int.MaxValue;
            counter--;
            return minIndex;
        }

        public int Count { get { return counter;  }}
    }
}
