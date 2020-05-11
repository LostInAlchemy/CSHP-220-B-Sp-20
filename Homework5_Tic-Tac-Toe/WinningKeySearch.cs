using System.Collections.Generic;

namespace Homework5_Tic_Tac_Toe
{
    static class WinningKeySearch
    {
        public static bool ContainsSequence<T>(this List<T> outer, List<T> inner)
        {
            bool isMatch = true;
            int outerCount = outer.Count;
            int innerCount = inner.Count;
            int Match3 = 0;

            for (int i = 0; i < outerCount; i++)
            {
                for (int j = 0; j < innerCount; j++)
                {
                    if (!outer[i].Equals(inner[j]))
                    {
                        isMatch = false;
                    }
                    else
                    {
                        Match3++;
                        break;
                    }
                }
            }

            if (Match3 == 3)
            {
                return true;
            }

            return isMatch;
        }
    }
}