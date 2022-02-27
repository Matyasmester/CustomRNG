using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterCustomRandom
{
    internal class RNG
    {
        // Proportionality factor
        private const int k = 1589;

        private int index = 0;
        private List<int> Sequence = new();

        private int[] GetDigits(long n)
        {
            List<int> digits = new();

            while (n > 0)
            {
                digits.Add(Convert.ToInt32(n % 10));
                n /= 10;
            }
            digits.Reverse();

            return digits.ToArray();
        }

        private long GetTimeStamp()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        private long LongFromDigits(long input)
        {
            long result = 0;

            int[] digits = GetDigits(input);

            List<int> odd = new();
            List<int> even = new();

            foreach (int i in digits) {
                if(i % 2 == 0) even.Add(i);
                else
                {
                    odd.Add(i);
                }
            }

            foreach(int n in even)
            {
                foreach(int j in odd)
                {
                    if (n == 0 || j == 0) continue;
                    result += n * j;
                }
            }

            result *= k;
            return result;
        }

        private void MakeNewSequence()
        {
            long timestamp = GetTimeStamp();
            long seq = LongFromDigits(timestamp);

            Sequence = GetDigits(seq).ToList();
        }

        public RNG()
        {
            MakeNewSequence();
        }

        public int Next()
        {
            if (index >= Sequence.Count)
            {
                MakeNewSequence();
                index = 0;
            }
            int retval = Sequence[index];
            index++;

            return retval;
        }
    }
}
