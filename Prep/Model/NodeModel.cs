using System;
using System.Collections.Generic;
using System.Text;

namespace Prep.Model
{
    public class BinaryNode
    {
        public BinaryNode(object data, BinaryNode left, BinaryNode right)
        {
            Data = (int)data;
            Left = left;
            Right = right;
        }

        public BinaryNode Left;
        public BinaryNode Right;
        public int Data;
        public int Height;
    }

    public class Node
    {
        public List<Node> Children;
        public object Data;
    }

    public class LinkedListNode
    {
        public LinkedListNode Next;
        public int Data;
    }

    public class LinkedList
    {
        public LinkedListNode Head;
    }

    public class DoubleListNode
    {
        public DoubleListNode Next;
        public DoubleListNode Prev;
        public int Data;
    }

    public class GraphNode
    {
        public GraphNode(int V, int? W, int? Src)
        {
            this.Vertex = V;
            this.Weight = W;
            this.srcVertex = Src.HasValue ? Src.Value : 0;
        }

        public int Vertex { get; set; }
        public int? Weight { get; set; }
        public int srcVertex { get; set; }
    }

}
