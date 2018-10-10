using System;
using System.Collections.Generic;
using System.Text;

namespace Prep
{
    public class StringTopics
    {
        public int[] findSubstringKMP(string text, string p)
        {
            // KMP
            // preprocess the pattern to create a longest prefex and suffix word dor substring of p ends at i;
            //create an array of length p and fill that with lps values a[0] = 0
            //run the substring match algo

            List<int> result = new List<int>();

            if (string.IsNullOrWhiteSpace(p) || string.IsNullOrWhiteSpace(text))
                return result.ToArray();

            int[] pre = preProcessPattern(p);

            int j = 0;
            int i = 0;
            while(i < text.Length)
            {
                if (j == p.Length)
                {
                    result.Add(i - (p.Length - 1));
                    j = pre[j - 1];
                }

                if (text[i] == p[j])
                {
                    i++;
                    j++;
                }
                else if (j > 0)
                {
                    j = pre[j - 1];
                }
                else
                {
                    j = 0;
                    i++;
                }
            }

            return result.ToArray();
        }

        private int[] preProcessPattern(string p)
        {
            int[] pre = new int[p.Length];
            pre[0] = 0;
            int len = 0;
            int i = 0;
            while(i < p.Length)
            {
                if (p[i] == p[len])
                {
                    pre[i] = len;
                    len++;
                    i++;
                }
                else
                {
                    if(len > 0)
                    {
                        len = pre[len - 1];
                    }
                    else
                    {
                        pre[i] = len;
                        i++;
                    }
                }
            }

            return pre;
        }
    }
}
