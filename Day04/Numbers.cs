namespace Day04
{
    internal static class Numbers
    {
        public static int[] Split(int value, int maxSize)
        {
            var result = new int[maxSize];
            for (var i = maxSize - 1; i >= 0; i--)
            {
                var x = value % 10;
                result[i] = x;
                value /= 10;
            }

            return result;
        }

        public static void Normalize(int[] value)
        {
            bool updated;
            do
            {
                updated = false;

                for (var i = value.Length - 1; i > 0; i--)
                {
                    var current = value[i];
                    var prev = value[i - 1];

                    if (prev > current)
                    {
                        for (var j = i; j < value.Length; j++)
                        {
                            value[j] = prev;
                        }

                        updated = true;
                        break;
                    }
                }
            }
            while (updated);
        }

        public static bool LessOrEqual(int[] x, int[] y)
        {
            for (var i = 0; i < x.Length; i++)
            {
                var c = x[i] - y[i];
                if (c > 0)
                {
                    return false;
                }

                if (c < 0)
                {
                    return true;
                }
            }

            return true;
        }

        public static void FindNext(int[] value)
        {
            for (var i = value.Length - 1; i >= 0; i--)
            {
                var newValue = value[i] + 1;
                if (newValue <= 9)
                {
                    for (var j = i; j < value.Length; j++)
                    {
                        value[j] = newValue;
                    }

                    return;
                }
            }

            value[0]++;
        }
    }
}
