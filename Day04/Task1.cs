namespace Day04
{
    internal static class Task1
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

        private static bool MeetsCriteria(int[] value)
        {
            for (var i = 1; i < value.Length; i++)
            {
                if (value[i - 1] == value[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
