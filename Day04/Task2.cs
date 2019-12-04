namespace Day04
{
    internal static class Task2
    {
        public static int Solve(int min, int max)
        {
            var current = Numbers.Split(min, 6);
            var limit = Numbers.Split(max, 6);

            Numbers.Normalize(current);
            var result = 0;
            
            while (Numbers.LessOrEqual(current, limit))
            {
                if (MeetsCriteria(current))
                {
                    result++;
                }

                Numbers.FindNext(current);
            }

            return result;
        }

        internal static bool MeetsCriteria(int[] value)
        {
            const int GroupSize = 2;
            var groupSign = value[0];
            var groupLength = 1;

            for (var i = 1; i < value.Length; i++)
            {
                if (groupSign == value[i])
                {
                    groupLength++;
                }
                else if (groupLength == GroupSize)
                {
                    return true;
                }
                else
                {
                    groupSign = value[i];
                    groupLength = 1;
                }
            }

            return groupLength == GroupSize;
        }
    }
}
