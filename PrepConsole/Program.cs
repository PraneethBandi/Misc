using System;
using System.Collections.Generic;
using System.Linq;
using Prep;
using Prep.Model;

namespace PrepConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Sorting();

            //Trees();

            //AVLTree();

            //Graph();

            //MatrixShortestPath();

            //BitwiseTopics();

            //LinkedListTopics();

            //ArrayTopics();

            Dynnamic();

            Console.ReadLine();
        }

        private static void Dynnamic()
        {
            DynnamicP p = new DynnamicP();
            //p.findFibonacci(10);
            //p.findFibonacci(15);
            //p.findFibonacci(1);

            var exists = p.FindSubset(new int[] { 4, 34, -3, 4, 12, 5, 2, -2 }, 7);
            Console.WriteLine(exists);
        }

        private static void ArrayTopics()
        {
            int[] a = new int[] { -6, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] b = new int[] { -6, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 13 };
            int[] c = new int[] { 1 };
            int[] d = new int[] { 14, 15};
            

            
            ArrayTopics arr = new ArrayTopics();
            Console.WriteLine(arr.FindOrInsert(a, 26));
            Console.WriteLine(arr.FindOrInsert(a, -7));
            Console.WriteLine(arr.FindOrInsert(b, 12));
            Console.WriteLine(arr.FindOrInsert(b, 2));


        }

        private static void LinkedListTopics()
        {
            try
            {
                int[] a = new int[] { 15, 14, 2, 13, 12, 11, 10, 10, 9, 8, 5, 7, 6, 5, 20, 4, 12, 3, 2, 1, 0, -1, -2, -6, 18, 19, 21, 23, 24, 25 };

                LinkedListTopics ls = new LinkedListTopics();
                //var node = ls.CreateLinkedList(a);
                //ls.printLinkedList(node);

                //var node20 = ls.FindNode(node, 20);
                //var node25 = ls.FindNode(node, 25);

                //node25.Next = node20;

                //var exists = ls.isCycleExists(node);

                //var loopNode = ls.FindLoopNode(node.Head);


                int[] b = new int[] { 24115, -75629, -46517, 30105, 19451, -82188, 99505, 6752, -36716, 54438, -51501, 83871, 11137, -53177,
                    22294, -21609, -59745, 53635, -98142, 27968, -260, 41594, 16395, 19113, 71006, -97942, 42082, -30767, 85695, -73671 };
                var c = b.ToList();

                var r = ls.maxset(c);



                //var sorted = ls.SortLinkedList(node);
                //var sortedList = new LinkedList() { Head = sorted };
                //ls.printLinkedList(sortedList);

                //ls.DeleteNode(sortedList, 20);
                //ls.printLinkedList(sortedList);

                //ls.DeleteNode(sortedList, -6);
                //ls.printLinkedList(sortedList);

                //ls.DeleteNode(sortedList, -1);
                //ls.printLinkedList(sortedList);

                //ls.DeleteNode(sortedList, 25);
                //ls.printLinkedList(sortedList);

                //var reverse = ls.ReverseLinkedList(sortedList);
                //ls.printLinkedList(new LinkedList() { Head = reverse });

                //var node1 = ls.CreateLinkedList(a);
                //ls.printLinkedList(node);

                //var dupes = ls.RemoveDupes(node1);
                //ls.printLinkedList(new LinkedList() { Head = dupes });

                //ls.printLinkedList(node1);
                //var ithNode = ls.returnIth(node, 10);
                //Console.WriteLine(ithNode == null ? "null" : ithNode.Data.ToString());


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private static void BitwiseTopics()
        {
            try
            {
                BitwiseTopics bit = new BitwiseTopics();

                Console.WriteLine("10 -> 2 :" + bit.ConvertIntValue(2, 10));
                Console.WriteLine("15 -> 2 :" + bit.ConvertIntValue(2, 15));
                Console.WriteLine("1 -> 2 :" + bit.ConvertIntValue(2, 1));
                Console.WriteLine("0 -> 2 :" + bit.ConvertIntValue(2, 0));
                Console.WriteLine("13 -> 2 :" + bit.ConvertIntValue(2, 13));

                Console.WriteLine("17 -> 16 :" + bit.ConvertIntValue(16, 17));
                Console.WriteLine("253 -> 16 :" + bit.ConvertIntValue(16, 253));
                Console.WriteLine("31 -> 16 :" + bit.ConvertIntValue(16, 31));
                Console.WriteLine("32 -> 16 :" + bit.ConvertIntValue(16, 32));
                Console.WriteLine("13 -> 16 :" + bit.ConvertIntValue(16, 13));
                Console.WriteLine("1 -> 16 :" + bit.ConvertIntValue(16, 1));
                Console.WriteLine("15 -> 16 :" + bit.ConvertIntValue(16, 15));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void MatrixShortestPath()
        {
            try
            {
                int[,] mat = new int[,]
                {
                    {2,1,5,1 },
                    {3,4,2,2 },
                    { 1,2,3,3},
                    {1,3,2,4 }
                };

                GraphTopics gt = new GraphTopics();

                //gt.MatrixUniquePaths(mat, 4, 4);

                gt.MatrixUniquePathsIterative(mat, 4, 4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void Graph()
        {
            Graph graph = new Graph(9);

            graph.AddEdge(0, 1, 4);
            graph.AddEdge(1, 2, 8);
            graph.AddEdge(2, 3, 7);
            graph.AddEdge(3, 4, 9);
            graph.AddEdge(4, 5, 10);
            graph.AddEdge(5, 6, 2);
            graph.AddEdge(6, 7, 1);
            graph.AddEdge(7, 0, 8);
            graph.AddEdge(1, 7, 11);
            graph.AddEdge(7, 8, 7);
            graph.AddEdge(6, 8, 6);
            graph.AddEdge(5, 2, 4);
            graph.AddEdge(5, 3, 14);
            graph.AddEdge(8, 2, 2);

            graph.PrintGraph();

            GraphTopics gt = new GraphTopics();

            gt.FindShortestPath(graph, 0, 4);
            gt.FindShortestPath(graph, 0, 8);
            gt.FindShortestPath(graph, 3, 4);
            gt.FindShortestPath(graph, 8, 5);
        }

        private static void AVLTree()
        {
            try
            {
                int[] a = new int[] { 15, 14, 2, 13, 12, 11, 10, 10, 9, 8, 5, 7, 6, 5, 20, 4, 12, 3, 2, 1, 0, -1, -2, -6, 18, 19, 21, 23, 24, 25 };

                AVLTree tree = new AVLTree();
                BinaryNode root = null;
                for (int i = 0; i < a.Length; i++)
                {
                    root = tree.InsertNode(root, a[i]);
                }

                Console.WriteLine("LevelOrder");
                TreeTopics nTree = new TreeTopics();
                nTree.LevelOrderNodeWOMem(root);

                Console.WriteLine("normal tree");

                var node = nTree.InsertData(a[0], null);
                for (int i = 1; i < a.Length; i++)
                {
                    nTree.InsertData(a[i], node);
                }

                var balanced = nTree.BalanceTreeRecursive(node);
                Console.WriteLine("level order");
                nTree.LevelOrderNodeWOMem(balanced);

                Console.WriteLine("Inorder");
                var result = nTree.InOrderTraversal(root);
                foreach (var item in result) { Console.Write($"{item} | "); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        private static void Trees()
        {
            try
            {
                int[] a = new int[] { 15, 14, 2, 13, 12, 11, 10, 10, 9, 8, 5, 7, 6, 5, 20, 4, 12, 3, 2, 1, 0, -1, -2, -6 , 18, 19, 21, 23, 24, 25 };

                TreeTopics tree = new TreeTopics();
                var node = tree.InsertData(a[0], null);
                for (int i = 1; i < a.Length; i++)
                {
                    tree.InsertData(a[i], node);
                }

                var result = tree.InOrderTraversal(node);
                foreach (var item in result) { Console.Write($"{item} | "); }

                Console.WriteLine();

                var invert = tree.InvertTree(node);
                var result2 = tree.InOrderTraversal(invert);
                foreach (var item in result2) { Console.Write($"{item} | "); }

                //Console.WriteLine("LvTraversal");
                //tree.LevelOrderTraversal(new List<BinaryNode>() { node });

                //Console.WriteLine("lvtraversal WO mem");
                //tree.LevelOrderNodeWOMem(node);

                ////Console.WriteLine($"Height:{tree.FindHeight(node)}");

                //Console.WriteLine("preOrderTraversal:");
                //var result = tree.PreOrderTraversal(node);

                //foreach (var item in result){ Console.Write($"{item} | "); }

                //Console.WriteLine();
                //Console.WriteLine("serilaize");
                //var serData = tree.Serialize(node);
                //Console.WriteLine(serData);

                //Console.WriteLine("Deserilaize");
                //var root = tree.DeSerialize(serData);

                //Console.WriteLine("lvtraversal WO mem");
                //tree.LevelOrderNodeWOMem(root);

                //var result = tree.InOrderTraversal(node);
                //foreach (var item in result){ Console.Write($"{item} | "); }
                //Console.WriteLine();

                //BinaryNode root = tree.DeleteData(12, node);

                //result = tree.InOrderTraversal(node);
                //foreach (var item in result) { Console.Write($"{item} | "); }
                //Console.WriteLine();

                //Console.WriteLine(tree.SearchDataInBST(8, node));
                //Console.WriteLine(tree.SearchDataInBST(3, node));
                //Console.WriteLine(tree.SearchDataInBST(-6, node));
                //Console.WriteLine(tree.SearchDataInBST(19, node));
                //Console.WriteLine(tree.SearchDataInBST(22, node));
                //Console.WriteLine(tree.SearchDataInBST(15, node));
                //Console.WriteLine(tree.SearchDataInBST(20, node));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }



        private static void Sorting()
        {
            try
            {
                int[] a = new int[] { 15, 14, 2, 13, 12, 11, 10, 10, 9, 8, 5, 7, 6, 5, 16, 4, 12, 3, 2, 1, 0, -1, -2, -6, 20, 18, 19, 21, 23, 24, 25 };
                int[] b = new int[] { 1, 2, 3, 5, 7 };
                int[] c = new int[] { 0, -1 };
                int[] d = new int[] { -4, -5, -10, -2 };
                int[] e = new int[] { 2, 2, 2,3,1, 2, 2, 2 };
                int[] f = new int[] { 5 };

                //inseriton
                //InsertionSort(a, b, c, d, e, f);

                //merge sort
                //MergeSort(a, b, c, d, e, f);

                //quickSort
                //QuickSort(a, b, c, d, e, f);

                //heap sort
                //HeapSort(a, b, c, d, e, f);

                //heap sort
                SelectionSort(a, b, c, d, e, f);


                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        private static void SelectionSort(int[] a, int[] b, int[] c, int[] d, int[] e, int[] f)
        {
            Console.WriteLine("before");
            printArray(a);
            var result = Prep.Sorting.SlectionSort(a);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(b);
            result = Prep.Sorting.SlectionSort(b);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(c);
            result = Prep.Sorting.SlectionSort(c);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(d);
            result = Prep.Sorting.SlectionSort(d);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(f);
            result = Prep.Sorting.SlectionSort(f);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(e);
            result = Prep.Sorting.SlectionSort(e);
            Console.WriteLine("after");
            printArray(result);
        }

        private static void HeapSort(int[] a, int[] b, int[] c, int[] d, int[] e, int[] f)
        {
            Console.WriteLine("before");
            printArray(a);
            var result = Prep.Sorting.HeapSort(a);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(b);
            result = Prep.Sorting.HeapSort(b);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(c);
            result = Prep.Sorting.HeapSort(c);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(d);
            result = Prep.Sorting.HeapSort(d);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(f);
            result = Prep.Sorting.HeapSort(f);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(e);
            result = Prep.Sorting.HeapSort(e);
            Console.WriteLine("after");
            printArray(result);
        }

        private static void QuickSort(int[] a, int[] b, int[] c, int[] d, int[] e, int[] f)
        {
            Console.WriteLine("before");
            printArray(a);
            var result = Prep.Sorting.QuickSort(a);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(b);
            result = Prep.Sorting.QuickSort(b);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(c);
            result = Prep.Sorting.QuickSort(c);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(d);
            result = Prep.Sorting.QuickSort(d);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(f);
            result = Prep.Sorting.QuickSort(f);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(e);
            result = Prep.Sorting.QuickSort(e);
            Console.WriteLine("after");
            printArray(result);
        }

        private static void MergeSort(int[] a, int[] b, int[] c, int[] d, int[] e, int[] f)
        {
            Console.WriteLine("before");
            printArray(a);
            var result = Prep.Sorting.MergeSort(a);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(b);
            result = Prep.Sorting.MergeSort(b);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(c);
            result = Prep.Sorting.MergeSort(c);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(d);
            result = Prep.Sorting.MergeSort(d);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(f);
            result = Prep.Sorting.MergeSort(f);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(e);
            result = Prep.Sorting.MergeSort(e);
            Console.WriteLine("after");
            printArray(result);
        }

        private static void InsertionSort(int[] a, int[] b, int[] c, int[] d, int[] e, int[] f)
        {
            Console.WriteLine("before");
            printArray(a);
            var result = Prep.Sorting.InsertionSort(a);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(b);
            result = Prep.Sorting.InsertionSort(b);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(c);
            result = Prep.Sorting.InsertionSort(c);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(d);
            result = Prep.Sorting.InsertionSort(d);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(f);
            result = Prep.Sorting.InsertionSort(f);
            Console.WriteLine("after");
            printArray(result);

            Console.WriteLine("before");
            printArray(e);
            result = Prep.Sorting.InsertionSort(e);
            Console.WriteLine("after");
            printArray(result);
        }

        private static void printArray(int[] a)
        {
            if(a == null)
            {
                Console.WriteLine("null");
                return;
            }

            foreach (var item in a)
            {
                Console.Write(item);Console.Write(",");
            }
            Console.WriteLine("");
        }
    }
}
