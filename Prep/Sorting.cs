using System;

namespace Prep
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Sorting_algorithm
    /// https://en.wikipedia.org/wiki/Sorting_algorithm#Merge_sort
    /// Sorting comparision
    /// </summary>
    public static class Sorting
    {
        //********************************************************************** Quick Sort ******************************************************************************************

        /// <summary>
        /// nlogn, n2 worst case perf
        /// logn space, worst case is n in call stack
        /// choosing the right pivot is the key. either random or 3 median(high,low, mid) or true median covers sorted,reversed 
        /// duplicate values still create worst case scenario, so group array into three partitions - less, equal and great then sort only less and great.
        /// Parallel  - Yes but extra space
        /// Assuming an ideal choice of pivots, parallel quicksort sorts an array of size n in O(n log n) work in O(log² n) time using O(n) additional space.
        /// Not stable
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[] QuickSort(int[] a)
        {
            if (a == null)
                return null;

            if (a.Length < 2)
                return a;

            qSort(ref a, 0, a.Length - 1);

            return a;
        }

        private static void qSort(ref int[] a, int low, int high)
        {
            if(low < high && low >= 0 && high < a.Length)
            {
                int pindex = chosePivotIndex(ref a, low, high);
                //key
                if (high - low > 2)// 3 elements are already sorted in median pivot.
                {
                    Tuple<int, int, int, int> result = DoPartitionOnPivot(ref a, low, high, pindex);
                    qSort(ref a, result.Item1, result.Item2);
                    qSort(ref a, result.Item3, result.Item4);
                }
            }
        }

        private static int chosePivotIndex(ref int[] a, int low, int high)
        {
            int mid = (low + high) / 2;
            if (a[mid] < a[low])
                swapEle(ref a, mid, low);
            if (a[high] < a[mid])
                swapEle(ref a, high, mid);
            if (a[mid] < a[low])
                swapEle(ref a, high, low);

            return mid;
        }

        private static Tuple<int, int, int, int> DoPartitionOnPivot(ref int[] a, int low, int high, int pivotIndex)
        {
            int value = a[pivotIndex];
            swapEle(ref a, pivotIndex, high);
            int left = low;
            int right = high - 1;

            while (left <= right)
            {
                if (a[left] > value)
                {
                    swapEle(ref a, left, right);
                    swapEle(ref a, right, right + 1);
                    right--;
                }
                else if (a[left] <= value)
                {
                    left++;
                }
            }

            return new Tuple<int, int, int, int>(low, right, right + 2, high);
        }


        //********************************************************************** Merge Sort ******************************************************************************************

        /// <summary>
        /// nlogn for all cases
        /// n - space. can be done in O(1) for some variations - block sort.
        /// paralelilazation
        /// Stable sort
        /// no online.
        /// efficient quicksort implementations generally outperform mergesort for sorting RAM-based arrays.
        /// On the other hand, merge sort is a stable sort and is more efficient at handling slow-to-access sequential media. 
        /// Merge sort is often the best choice for sorting a linked list: in this situation it is relatively easy to implement a merge sort 
        /// in such a way that it requires only Θ(1) extra space, and the slow random-access performance of a linked list makes some 
        /// other algorithms (such as quicksort) perform poorly, and others (such as heapsort) completely impossible.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[] MergeSort(int[] a)
        {
            if (a == null)
                return null;

            if (a.Length < 2)
                return a;

            MergeSortImplementation(0, a.Length -1, ref a);
            return a;
        }

        private static void MergeSortImplementation(int left, int right, ref int[] a)
        {
            int mid = (left + right) / 2;
            if (left < right)
            {
                MergeSortImplementation(left, mid, ref a);
                MergeSortImplementation(mid + 1, right, ref a);
                MergeSortedList(left, mid, right, ref a);
            }
        }

        private static void MergeSortedList(int left, int mid, int right, ref int[] a)
        {
            int[] b = new int[(right - left) + 1];
            int bIndex = 0;
            int leftmax = mid;
            int rightmin = mid + 1;
            int min = left;
            int max = right;

            while (left <= leftmax || rightmin <= right)
            {
                if (left <= leftmax && rightmin <= right)
                {
                    if (a[left] <= a[rightmin])
                    {
                        b[bIndex] = a[left];
                        bIndex++;
                        left++;
                    }
                    if (a[left] > a[rightmin])
                    {
                        b[bIndex++] = a[rightmin++];
                    }
                }
                else if (left <= leftmax)
                {
                    b[bIndex++] = a[left++];
                }
                else
                {
                    b[bIndex++] = a[rightmin++];
                }
            }

            bIndex = 0;
            //key
            while (min <= max)
            {
                a[min++] = b[bIndex++];
            }
        }

        //********************************************************************** Heap Sort ******************************************************************************************
        /// <summary>
        /// nlogn all cases
        /// i space
        /// not stable
        /// cannot be parallelized or distributed.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[] HeapSort(int[] a)
        {
            if (a == null)
                return null;
            if (a.Length <= 1)
                return a;

            buildMaxheap(ref a);
            hSort(ref a);
            return a;
        }

        private static void buildMaxheap(ref int[] a)
        {
            int counter = a.Length/2;
            for (int i = a.Length - 1; i >= counter; i--)
            {
                BubbleUpEle(ref a, i);
            }
        }

        private static void BubbleUpEle(ref int[] a, int index)
        {
            int parentIndex = 0;
            do
            {
                parentIndex = (int)Math.Floor(Convert.ToDouble((index - 1) / 2));
                if (a[index] > a[parentIndex] && parentIndex >= 0)
                {
                    swapEle(ref a, index, parentIndex);
                    //key
                    checkChildAndSwap(ref a, index);
                }
                index = parentIndex;

            } while (parentIndex > 0);
        }

        private static void checkChildAndSwap(ref int[] a, int parentIndex)
        {
            int lc = 2 * parentIndex + 1;
            int rc = 2 * parentIndex + 2;

            if(lc <= a.Length -1 && a[lc] > a[parentIndex])
            {
                swapEle(ref a, lc, parentIndex);
            }
            if (rc <= a.Length - 1 && a[rc] > a[parentIndex])
            {
                swapEle(ref a, rc, parentIndex);
            }
        }

        private static void hSort(ref int[] a)
        {
            int index = a.Length - 1;

            while (index > 0)
            {
                swapEle(ref a, 0, index--);
                BubbleDownEle(ref a, index);
            }
        }

        private static void BubbleDownEle(ref int[] a, int lastIndex)
        {
            int currentParent = 0;
            while (currentParent <= lastIndex)
            {
                int tempindex = 0;
                int lci = 2 * currentParent + 1;
                int rci = 2 * currentParent + 2;

                if (lci <= lastIndex && a[currentParent] < a[lci])
                {
                    //key
                    tempindex = rci <= lastIndex && a[lci] < a[rci] ? rci : lci;
                    swapEle(ref a, currentParent, tempindex);
                }
                else if (rci <= lastIndex && a[currentParent] < a[rci])
                {
                    swapEle(ref a, currentParent, rci);
                    tempindex = rci;
                }
                else
                    return;

                currentParent = tempindex;
            }
        }

        //********************************************************************** Selection Sort ******************************************************************************************
        /// <summary>
        /// n^2 all
        /// not stable
        /// Selection sort can also be used on list structures that make add and remove efficient, such as a linked list. In this case 
        /// it is more common to remove the minimum element
        /// from the remainder of the list, and then insert it at the end of the values sorted 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[] SlectionSort(int[] a)
        {

            for (int i = 0; i < a.Length; i++)
            {
                int min = a[i];
                int minIndex = i;
                for (int j = i; j < a.Length; j++)
                {
                    if (a[j] < min)
                    {
                        min = a[j];
                        minIndex = j;
                    }
                }
                swapEle(ref a, i, minIndex);
            }

            return a;
        }

        //********************************************************************** Insertion Sort ******************************************************************************************
        /// <summary>
        /// O(n^2), best case o(n).
        /// Stable ******************************
        /// O(1) space
        /// Good when nearly sorted.
        /// Online sort - sorting can be done when new elements are added.
        /// Efficient when length is small like less than 10, This can be used in combination to quick sort and others for sorting smaller items
        /// Shell sort is a variant of insertion sort for larger lists.
        /// Con: We have move lot of elements when they are reversed or random.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[] InsertionSort(int[] a)
        {
            // return InsertionSortQuick(a);

            if (a == null)
                return null;
            if (a.Length <= 1)
                return a;


            for (int i = 1; i < a.Length; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    if (a[j] < a[j - 1])
                        swapEle(ref a, j, j - 1);
                    else
                        break;
                }
            }

            return a;
        }

        /// <summary>
        /// Remove one swap, slightly better.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[] InsertionSortQuick(int[] a)
        {
            if (a == null)
                return null;
            if (a.Length <= 1)
                return a;

            for (int i = 1; i < a.Length; i++)
            {
                int x = a[i];
                int j = i - 1;
                for (j = i-1; j >= 0; j--)
                {
                    if (x < a[j])
                        a[j + 1] = a[j];
                    else
                        break;                     
                }
                a[j + 1] = x;
            }
            return a;
        }

        //********************************************************************** Bubble Sort ******************************************************************************************


        public static int[] BubbleSort(int[] a)
        {
            return null;
        }

        private static void swapEle(ref int[] a, int leftIndex, int rightIndex)
        {
            if (a[leftIndex] != a[rightIndex])
            {
                a[leftIndex] = a[leftIndex] ^ a[rightIndex];
                a[rightIndex] = a[leftIndex] ^ a[rightIndex];
                a[leftIndex] = a[leftIndex] ^ a[rightIndex];
                return;
            }

            return;

            int temp = a[leftIndex];
            a[leftIndex] = a[rightIndex];
            a[rightIndex] = temp;
        }

    }
}
