using Prep.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prep
{
    public class AVLTree
    {
        BinaryNode root = null;
        public AVLTree(BinaryNode node)
        {
            root = node;
        }

        public AVLTree()
        { }

        private int height(BinaryNode node)
        {
            if (node == null)
                return 0;

            return node.Height;
        }

        private int max(int a, int b)
        {
            return a > b ? a : b;
        }

        private BinaryNode LeftRotate(BinaryNode node)
        {

            BinaryNode root = node.Right;
            if (root != null)
            {
                BinaryNode temp = root.Left;
                root.Left = node;
                node.Right = temp;

                root.Height = 1 + max(height(root.Left), height(root.Right));
                node.Height = 1 + max(height(node.Left), height(node.Right));

                return root;
            }
            else
                return node;
        }

        private BinaryNode RightRotate(BinaryNode node)
        {
            BinaryNode root = node.Left;
            if (root != null)
            {
                BinaryNode temp = root.Right;
                root.Right = node;
                node.Left = temp;

                node.Height = 1 + max(height(node.Left), height(node.Right));
                root.Height = 1 + max(height(root.Left), height(root.Right));

                return root;
            }
            else
                return node;
        }

        public BinaryNode InsertNode(BinaryNode node, int key)
        {
            if (node == null)
                return new BinaryNode(key, null, null);

            if (key > node.Data)
                node.Right = InsertNode(node.Right, key);
            if (key <= node.Data)//they say no duplicates
                node.Left = InsertNode(node.Left, key);

            node.Height = 1 + max(height(node.Left), height(node.Right));

            int balance = height(node.Left) - height(node.Right);

            if (balance > 1 && key <= node.Left.Data)
                return RightRotate(node);
            else if (balance > 1 && key > node.Left.Data)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }
            else if (balance < -1 && key > node.Right.Data)
                return LeftRotate(node);
            else if(balance < -1 && key <= node.Right.Data)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }



    }
}
