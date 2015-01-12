using System;

namespace QuickSearch
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static int DoQuickSearch(string pattern, string text)
        {
            if (String.IsNullOrEmpty(pattern) || String.IsNullOrEmpty(text))
            {
                return -1;
            }

            // pattern = abac
            var p = pattern.ToCharArray();
            // text = werjewjabaczwzer
            var a = text.ToCharArray();

            var pi = 0;
            var ai = 0;
            var pl = p.Length;

            // shift = .... abcdefg...
            var shift = new int[Char.MaxValue];
            var initShiftValue = pl + 1;

            // shift = 5,5,5,5,5,5
            for (var i = 0; i < shift.Length; i++)
            {
                shift[i] = initShiftValue;
            }

            for (var i = 0; i < pl; i++)
            {
                shift[p[i]] = pl - i;
            }
            
            while(a.Length - ai >= pl - pi)
            {
                if (a[ai] == p[pi])
                {
                    if (pl == pi + 1)
                    {
                        return ai -(pl-1);
                    }

                    pi++;
                    ai++;
                }
                else
                {
                    ai += shift[a[ai + pl - pi]];
                    pi = 0;
                }
            }

            return -1;
        }
    }
}
