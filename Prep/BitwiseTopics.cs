using System;
using System.Collections.Generic;
using System.Text;

namespace Prep
{
    /// <summary>
    /// & operator - one only when both are one
    /// | operator - one only when either or both are one
    /// ~ operator - reverse/flip the bits
    /// ^ XOR - one only when either is one, not both.
    /// >> right shift = logical and arthematic. logical is represented as  >> , arthematic represented as >>>
    ///     logical - shift bits to right including signed bit and put 0 at most significant bit. ask is it signed or unsigned.
    ///     arthematic - shift bit to right , leave one as is at most significant bit for signed lese put 0.
    ///     right shift arthematic for unsigned/signed is divided by 2^n where n is shift by how many bits.
    ///     right shift logical is not divided by 2 for signed bits as it will shift the signed bit as well. check that
    /// left Shift is similar by multiplying by 2^n.
    /// for signed integers with negative sive is indicated by 1 as most significant bit and N-1 bits are calculated for negative no in way -k can be represented as concat(1, 2^N-1 - K)
    /// it is 2s complement. easy way to convert k to -k is flip k bits and add 1 and then prepend 1 as signed bit.
    /// eg - 3 as 011, flip - 100 , add 1 - 101, prepend signed bit - 1101 = -3;
    /// 
    /// tricks
    /// 
    /// X ^ 0s = X      x & 0s = 0          X | 0s = x
    /// X ^ 1s = ~x     x & 1s = x          X | 1s = 1
    /// X ^ X = 0       x & x = x           X | x = x
    /// X ^ (~X) = 1s
    /// 
    /// </summary>
    public class BitwiseTopics
    {
        public string ConvertIntValue(int BaseTo, int value)
        {
            if (value == 0)
                return "0";

            if (BaseTo == 0)
                return "0";

            StringBuilder sb = new StringBuilder();
            ConvertIntValueUtil(value, sb, BaseTo);
            return sb.ToString();
        }

        private void ConvertIntValueUtil(int value, StringBuilder sb, int baseTo)
        {
            if(value == 0)
            {
                sb.Append("0");
                    return;
            }

            int quotient = value / baseTo;
            int reminder = value % baseTo;
            ConvertIntValueUtil(quotient, sb, baseTo);
            sb.Append(getbaseString(baseTo, reminder));
        }

        private string getbaseString(int baseTo, int reminder)
        {
            if (reminder <= 9)
                return reminder.ToString();

            string[] array = new string[] { "A", "B", "C", "D", "E", "F", "G" };
            if(baseTo == 16)
            {
                return array[reminder - 10];
            }
            return reminder.ToString();
        }

        /// <summary>
        /// left shift 1 with i gives something like 000010000. and do AND with num so that 
        /// every thing will be zero if ith bit is 0 else not zero
        /// </summary>
        private bool getBitAtindex(int num, int i)
        {
            return ((num & (1 << i)) != 0);
        }

        /// <summary>
        /// left shift 1 by i give like 000010000. then OR the number so if it 0 then will turn to 1 else remain one.
        /// </summary>
        private int setBitAtI(int num, int i)
        {
            num = num | (1 << i);
            return num;
        }

        /// <summary>
        /// left shift 1 by i then negate that that will give 111101111. now AND this with num;
        /// </summary>
        private int clearBitAtI(int num, int i)
        {
            return (~(1 << i)) & num;
        }

        /// <summary>
        /// create a mask like 00000011111(i zeros) and use AND with num. left shift 1 with i and do - 1 this will give all 1111 after i to right most bit.
        /// </summary>
        private int ClearAllBitsFromLefttoI(int num, int i)
        {
            return ((1 << i) - 1) & num;
        }

        /// <summary>
        /// create a mask like 111111000000 (i -> last zeros) and use AND with num. left shift -1 with i + 1 give 11111100000(i -> last 0s), then AND num
        /// </summary>
        private int ClearAllBitsFromRighttoI(int num, int i)
        {
            return (-1 << (i+1)) & num;
        }


        //this is combination of clear bit and set bit.
        private int updateIthBit(int num, int i, bool isbit1)
        {
            var value = isbit1 ? 1 : 0;

            int mask = ~(1 << i);

            return (mask & num) | (1 << i);
        }

        private int insertMintoN(int num, int N, int i, int j)
        {
            // creat a mask like 0000011111 all zeros from i to j and do AND.

            int mask = ~0; // all ones
            mask = (mask << (j + 1)) | ((1 << i) - 1); // get 111110000011111
            num = num & mask; // clear bit between i and j;

            N = N << i;

            return num | N;
        }

        private string ConvertDoubleToBinary(double num)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(".");

            while(num > 0)
            {
                if (sb.Length > 32)
                    return sb.ToString();

                var temp = num * 2;
                if (temp >= 1)
                {
                    sb.Append("1");
                    num = temp - 1;
                }
                else
                {
                    sb.Append("0");
                    num = temp;
                }
            }

            return sb.ToString();
        }



    }
}
