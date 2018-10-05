using System;
using System.Collections.Generic;
using System.Text;

namespace Prep
{
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

        public int ConvertToInt(string s, int baseFrom)
        {
            if (string.IsNullOrWhiteSpace(s) || baseFrom < 0)
                return 0;

            char[] c = s.ToCharArray();
        }
    }
}
