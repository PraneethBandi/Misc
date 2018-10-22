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

        public BinaryNode DeleteData(int data, BinaryNode node)
        {
            if (node == null)
                return null;

            if (data < (int)node.Data)
                node.Left = DeleteData(data, node.Left);
            else if (data > (int)node.Data)
                 node.Right = DeleteData(data, node.Right);
            else
            {
                if (node.Left == null)
                    return node.Right;
                if (node.Right == null)
                    return node.Left;

                int min = FinMin(node.Right);
                node.Right = DeleteData(min, node.Right);
                node.Data = min;
            }
            return node;
        }

        private int FindMax(BinaryNode node)
        {
            int max = (int)node.Data;
            BinaryNode temp = node.Right;

            while (temp != null)
            {
                max = (int)temp.Data;
                temp = temp.Right;
            }

            return max;
        }

        private int FinMin(BinaryNode node)
        {
            int min = (int)node.Data;
            BinaryNode temp = node.Left;

            while(temp != null)
            {
                min = (int)temp.Data;
                temp = temp.Left;
            }

            return min;
        }

        public bool SearchDataInBST(int data, BinaryNode node)
        {
            if (node == null)
                return false;

            if (data < (int)node.Data)
                return SearchDataInBST(data, node.Left);
            if (data > (int)node.Data)
                return SearchDataInBST(data, node.Right);
            else
                return true;
        }

        public int SearchData(int data, BinaryNode node)
        {
            //BFS or DFS
            return 0;
        }

        public bool BFS(int data, BinaryNode node)
        {
            //LevelOrderTraversal
            return false;
        }

        public bool DFS(int data, BinaryNode node)
        {
            //IN,pre,post order
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

        public BinaryNode BalanceTree(BinaryNode node)
        {
            if (node == null)
                return null;

            int[] a = this.InOrderTraversal(node);

            AVLTree tree = new AVLTree();
            BinaryNode root = null;

            for (int i = 0; i < a.Length; i++)
            {
                root = tree.InsertNode(root, a[i]);
            }

            return root;
        }

        public BinaryNode BalanceTreeRecursive(BinaryNode node)
        {
            if (node == null)
                return null;

            int[] a = this.InOrderTraversal(node);
            return buildSubTree(0, a.Length - 1, a);
        }

        private BinaryNode buildSubTree(int left, int right, int[] a)
        {
            if(left >= 0 && left <= right && right < a.Length)
            {
                int mid = (right + left) / 2;
                BinaryNode root = new BinaryNode(a[mid], null, null);

                if (left == right)
                    return root;

                root.Left = buildSubTree(left, mid - 1, a);
                root.Right = buildSubTree(mid + 1, right, a);

                return root;
            }
            return null;
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
            serlializeNode(node, sb);
            return sb.ToString();
        }

        private void serlializeNode(BinaryNode node, StringBuilder sb)
        {
            if (node == null)
                return;

            sb.Append($"{node.Data},");

            if (node.Left == null && node.Right == null)
            { }
            else if (node.Left == null)
                sb.Append("/,");

            serlializeNode(node.Left, sb);
            serlializeNode(node.Right, sb);

            sb.Append($"),");
        }

//        private int index = 0;
        public BinaryNode DeSerialize(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;

            string[] items = input.Split(',', StringSplitOptions.RemoveEmptyEntries);

            if (items.Length == 0)
                return null;
            int index = 0;
            return BuildNode(ref index, items);
        }

        private BinaryNode BuildNode(ref int index, string[] items)
        {
            string rootData = items[index];
            if (rootData == ")")
            {
                return null;
            }
            else if(rootData == "/")
            {
                index++;
                return null;
            }
            else
            {
                BinaryNode newNode = new BinaryNode(rootData, null, null);
                index++;
                newNode.Left = BuildNode(ref index, items);
                newNode.Right = BuildNode(ref index, items);
                index++;
                return newNode;
            }
        }


        public BinaryNode InvertTree(BinaryNode root)
        {
            if (root == null)
                return null;

            InvertSubTree(root);
            return root;
        }

        private void InvertSubTree(BinaryNode node)
        {
            if (node == null)
                return;

            if (node.Left != null)
                InvertSubTree(node.Left);
            if (node.Right != null)
                InvertSubTree(node.Right);

            var temp = node.Left;
            node.Left = node.Right;
            node.Right = temp;
        }

        public BinaryNode FindLowestCommonAncestor(BinaryNode root, BinaryNode a, BinaryNode b)
        {
            if (root == null)
                return null;

            if (a == null || b == null)
                return null;

            if (a == b)
                return a;

            return fLCA(root, a.Data, b.Data);
        }

        private BinaryNode fLCA(BinaryNode root, int left, int right)
        {
            if (root == null)
                return null;
    
            if (root.Data < left && root.Data < right)
                return fLCA(root.Left, left, right);
            else if(root.Data > left && root.Data > right)
                return fLCA(root.Right, left, right);

            return root;
        }

        public BinaryNode FindLowestCommonAncestorIterative(BinaryNode root, BinaryNode a, BinaryNode b)
        {
            if (root == null)
                return null;

            if (a == null || b == null)
                return null;

            if (a == b)
                return a;

            var temp = root;

            while(temp != null)
            {
                if (temp.Data < a.Data && temp.Data < b.Data)
                    temp = temp.Left;
                else if (temp.Data > a.Data && temp.Data > b.Data)
                    temp = temp.Right;

                return temp;
            }

            return null;
        }

    }


}
