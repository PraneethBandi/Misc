using System;
using System.Collections.Generic;
using System.Text;

namespace Prep.Model
{
    public class BinaryNode
    {
        public BinaryNode(object data, BinaryNode left, BinaryNode right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public BinaryNode Left;
        public BinaryNode Right;
        public object Data;
    }

    public class Node
    {
        public List<Node> Children;
        public object Data;
    }

    public class LinkedListNode
    {
        public LinkedListNode Next;
        public object Data;
    }

    public class DoubleListNode
    {
        public DoubleListNode Next;
        public DoubleListNode Prev;
        public object Data;
    }

}
