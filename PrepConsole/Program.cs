using System;
using System.Collections.Generic;
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

            Trees();

            Console.ReadLine();
        }

        private static void Trees()
        {
            try
            {
                int[] a = new int[] { 15, 14, 2, 13, 12, 11, 10, 10, 9, 8, 5, 7, 6, 5, 16, 4, 12, 3, 2, 1, 0, -1, -2, -6 };

                TreeTopics tree = new TreeTopics();
                var node = tree.InsertData(a[0], null);
                for (int i = 1; i < a.Length; i++)
                {
                    tree.InsertData(a[i], node);
                }

                //Console.WriteLine("LvTraversal");
                //tree.LevelOrderTraversal(new List<BinaryNode>() { node });

                Console.WriteLine("lvtraversal WO mem");
                tree.LevelOrderNodeWOMem(node);

                //Console.WriteLine($"Height:{tree.FindHeight(node)}");

                Console.WriteLine("inorderTraversal:");
                var result = tree.PreOrderTraversal(node);

                foreach (var item in result){ Console.Write($"{item} | "); }

                Console.WriteLine("serilaize");
                var serData = tree.Serialize(node);
                Console.WriteLine(serData);

                Console.WriteLine("Deserilaize");
                var root = tree.DeSerialize(serData);

                Console.WriteLine("lvtraversal WO mem");
                tree.LevelOrderNodeWOMem(root);


                
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
                int[] a = new int[] { 15, 14, 2, 13, 12, 11, 10, 10, 9, 8, 5, 7, 6, 5, 16, 4, 12, 3, 2, 1, 0, -1, -2, -6 };
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
