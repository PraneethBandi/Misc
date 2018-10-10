using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prep
{
    public class ArrayTopics
    {
        public int FindOrInsert(int[] A, int target)
        {
            if (A == null)
                return -1;
            if (A.Length == 0)
                return 0;

            return binarySearch(0, A.Length - 1, target, A);
        }

        private int binarySearch(int leftIndex, int rightIndex, int target, int[] A)
        {
            if((rightIndex - leftIndex) <= 1)
            {
                if (target <= A[leftIndex])
                    return leftIndex;
                else 
                    return rightIndex;
            }
            else
            {
                var mid = (rightIndex + leftIndex) / 2;
                if (A[mid] == target)
                    return mid;
                else if (target < A[mid])
                    return binarySearch(leftIndex, mid, target, A);
                else
                    return binarySearch(mid, rightIndex, target, A);
            }
        }

        public int LongestIncreasingSubSequence(int[] a)
        {
            
            if (a == null)
                return 0;

            if (a.Length == 1)
                return 1;

            int[] mem = new int[a.Length];
            mem[0] = 1;

            //l(i) = l(i-1) + 1 if a[i-1] < a[i] or l(i-1)

            for (int i = 1; i < a.Length; i++)
            {
                mem[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (a[i] > a[j] && mem[i] < mem[j] + 1)
                        mem[i] = mem[j] + 1;
                }
                
            }

            return mem.ToList().Max();
        }
    }
}
