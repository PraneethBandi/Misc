using System;
using System.Collections.Generic;
using System.Text;

namespace Prep
{
    public class DynnamicP
    {
        public long findFibonacci(int n)
        {
            if (n <= 0)
                return 0;

            if (n <= 2)
                return 1;

            int result = 1;
            int prev = 1;

            for (int i = 3; i <= n; i++)
            {
                int temp = result;
                result = result + prev;
                Console.Write($"{result},");
                prev = temp;
            }
            Console.WriteLine();
            return result;
        }

        //public int LongestCommonSubSequence(string a, string b)
        //{
        //    if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
        //        return 0;

        //    int ans = lca(a,b,)
        //}

        

        public bool FindSubset(int[] a, int sum)
        {
            try
            {
                Dictionary<string, bool> mem = new Dictionary<string, bool>();

                return isSubset(a, a.Length - 2, sum, mem) || isSubset(a, a.Length - 2, sum - a[a.Length - 1], mem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        private bool isSubsetItr(int[] a, int n, int sum)
        {
            if (a == null)
                return false;

            if (a.Length == 0)
                return false;

            bool[,] mem = new bool[sum + 1, n + 1];
            mem[0, 0] = true;

            for (int i = 1; i <= sum; i++)
            {
                mem[i, 0] = false;
            }

            for (int i = 1; i <= n; i++)
            {
                mem[0, i] = true;
            }

            for (int i = 1; i<=sum; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    mem[i, j] = mem[i, j - 1];
                    if (i >= a[j-1])
                    {
                        mem[i, j] = mem[i, j] || mem[i - a[j - 1], j - 1];
                    }
                }
            }

            return false;
        }

            private bool isSubset(int[] a, int n, int sum, Dictionary<string, bool> mem)
        {
            string key = $"s-{sum}|i-{n}";

            if (sum == 0)
            {
                addKeys(mem, key, true);
                return true;
            }
                
            //if (sum < 0)
            //    return false;

            if (n == 0)
            {
                addKeys(mem, key, false);
                return false;
            }

            //if (a[n - 1] > sum)
            //    return isSubset(a, n - 1, sum);

            bool prev = false, cur = false;

            if (mem.ContainsKey($"s-{sum}|i-{n - 1}"))
                prev = mem[$"s-{sum}|i-{n - 1}"];
            else
                prev = isSubset(a, n - 1, sum, mem);

            if (mem.ContainsKey($"s-{sum - a[n - 1]}|i-{n - 1}"))
                cur = mem[$"s-{sum - a[n - 1]}|i-{n - 1}"];
            else
                cur = isSubset(a, n - 1, sum - a[n - 1], mem);

            return prev || cur;
        }

        private void addKeys(Dictionary<string, bool> mem, string key, bool value)
        {
            if (mem.ContainsKey(key))
                mem[key] = value;
            else
                mem.Add(key, value);
        }
    }
}
