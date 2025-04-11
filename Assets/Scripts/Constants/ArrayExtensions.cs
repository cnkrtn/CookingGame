using System;

namespace Constants
{
    public static class ArrayExtensions
    {
        private static Random _random = new Random();

        public static void Shuffle<T>(this T[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = _random.Next(0, i + 1); // Random index between 0 and i
                (array[i], array[j]) = (array[j], array[i]); // Swap elements
            }
        }
    }
}