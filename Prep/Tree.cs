using Prep.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prep
{

    public class TreeTopics
    {
        /*
         * Delete Node
         *      different levels of nodes
         * Height
         * Traversals
         * BFS
         * DFS
         * Seriliazation / deserialization
         * Balance
         * check balanced
         * 
         */

        /*
         * The maximum number of nodes at level ‘l’ of a binary tree is 2^(l-1). level of root is 1.
         * Maximum number of nodes in a binary tree of height ‘h’ is 2h – 1.Height of a tree with single node is considered as 1
         * In a Binary Tree with N nodes, minimum possible height or minimum number of levels is  Log2(N+1)
         *          If we consider the convention where height of a leaf node is considered as 0, then above formula for minimum possible height becomes Log2(N+1) – 1
         *   A Binary Tree with L leaves has at least   ⌈ Log2L ⌉ + 1   levels
         *   Full Binary tree - all nodes has 0 or 2 nodes
         *   Complete B tree - all levels are filled except last . filled from left to right
         *   Perfect B tree -  full + complete
         *   Balance tree - when height - logN. i.e diff of left height and right height not greater than 1.
         *   
         */

        public BinaryNode InsertData(int data, BinaryNode node)
        {
            if (node == null)
            {
                return new BinaryNode(data, null, null);
            }

            if (data <= (int)node.Data)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryNode(data, null, null);
                }
                else
                    InsertData(data, node.Left);
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryNode(data, null, null);
                }
                else
                    InsertData(data, node.Right);
            }

            return node;
        }

        public bool DeleteData(int data, BinaryNode node)
        {
            return false;
        }

        public bool SearchDataInBST(int data, BinaryNode node)
        {
            return false;
        }

        public int SearchData(int data, BinaryNode node)
        {
            return 0;
        }

        public bool BFS(int data, BinaryNode node)
        {
            return false;
        }

        public bool DFS(int data, BinaryNode node)
        {
            return false;
        }

        public void LevelOrderTraversal(List<BinaryNode> nodes)
        {
            if (nodes != null && nodes.Count > 0)
            {
                List<BinaryNode> childNodes = new List<BinaryNode>();
                foreach (BinaryNode node in nodes)
                {
                    Console.Write($"{node.Data} | ");
                    if (node.Left != null)
                        childNodes.Add(node.Left);
                    if (node.Right != null)
                        childNodes.Add(node.Right);
                }
                Console.WriteLine();
                LevelOrderTraversal(childNodes);
            }
        }

        public void LevelOrderNodeWOMem(BinaryNode node)
        {
            if (node == null)
                return;

            int height = FindHeight(node);

            for (int i = 1; i <= height; i++)
            {
                PrintLevel(i, node);
                Console.WriteLine();
            }
        }

        private void PrintLevel(int level, BinaryNode node)
        {
            if (node == null)
                return;

            if(level == 1)
                Console.Write($"{node.Data} | ");
            else
            {
                PrintLevel(level - 1, node.Left);
                PrintLevel(level - 1, node.Right);
            }
        }

        public int[] InOrderTraversal(BinaryNode node)
        {
            List<int> nodeList = new List<int>();
            TraverseNodes(node, nodeList, 1);
            return nodeList.ToArray();
        }

        public int[] PostOrderTraversal(BinaryNode node)
        {
            List<int> nodeList = new List<int>();
            TraverseNodes(node, nodeList, 2);
            return nodeList.ToArray();
        }

        public int[] PreOrderTraversal(BinaryNode node)
        {
            List<int> nodeList = new List<int>();
            TraverseNodes(node, nodeList, 0);
            return nodeList.ToArray();
        }

        private void TraverseNodes(BinaryNode node, List<int> nodeList, int traverseType)
        {
            if (node == null)
                return;
            switch (traverseType)
            {
                case 0:
                    nodeList.Add((int)node.Data);
                    TraverseNodes(node.Left, nodeList, 0);
                    TraverseNodes(node.Right, nodeList, 0);
                    break;
                case 1:
                    TraverseNodes(node.Left, nodeList, 1);
                    nodeList.Add((int)node.Data);
                    TraverseNodes(node.Right, nodeList, 1);
                    break;
                case 2:
                    TraverseNodes(node.Left, nodeList, 2);
                    TraverseNodes(node.Right, nodeList, 2);
                    nodeList.Add((int)node.Data);
                    break;
            }
        }

        public void BalanceTree(BinaryNode node)
        {

        }

        public int FindHeight(BinaryNode node)
        {
            if (node == null)
                return 0;

            int left = FindHeight(node.Left);
            int right = FindHeight(node.Right);

            if (left > right)
                return left + 1;
            return right + 1;
        }


        public string Serialize(BinaryNode node)
        {
            if (node == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            serlializeNode(node, sb, node);
            return sb.ToString();
        }

        public string SerializeWLevelOrder(BinaryNode node)
        {
            if (node == null)
                return string.Empty;

        }

        private void serlializeNode(BinaryNode node, StringBuilder sb, BinaryNode parentNode)
        {
            if (node == null)
                return;
            sb.Append($"{node.Data}|{parentNode.Data},");
            serlializeNode(node.Left, sb, node);
            serlializeNode(node.Right, sb, node);
        }

        public BinaryNode DeSerialize(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;

            char nSep = ',';

            string[] nodes = input.Split(new char[] { nSep }, StringSplitOptions.RemoveEmptyEntries);

            var rootItem = GetNodeAndParent(nodes[0]);
            BinaryNode root = new BinaryNode(rootItem.Item1, null, null);

            BuildTree(nodes, 1, root);
            return root;
        }

        private Tuple<int,int> GetNodeAndParent(string item)
        {
            if (string.IsNullOrEmpty(item))
                return null;

            var items = item.Split('|', StringSplitOptions.RemoveEmptyEntries);
            return new Tuple<int, int>(int.Parse(items[0]), int.Parse(items[1]));
        }

        private int BuildTree(string[] items, int index, BinaryNode node)
        {
            if (index >= items.Length)
                return int.MaxValue;

            int parent = (int)node.Data;
            var values = GetNodeAndParent(items[index]);

            if (values == null)
                throw new Exception("invalid serilizarion data");

            int nextIndex = 0;

            if(values.Item2 == parent)
            {
                var newNode = new BinaryNode(values.Item1, null, null);
                if (node.Left == null)
                    node.Left = newNode;
                else
                    node.Right = newNode;

                nextIndex = BuildTree(items, ++index, newNode);
                if(nextIndex <= items.Length)
                {
                    var newValues = GetNodeAndParent(items[nextIndex]);
                    if(newValues.Item2 == parent)
                    {
                        node.Right = new BinaryNode(newValues.Item1, null, null);
                        return BuildTree(items, ++nextIndex, newNode);
                    }
                    return nextIndex;
                }
                return int.MaxValue;
            }
            else
            {
                return index;
            }
        }

    }


}
