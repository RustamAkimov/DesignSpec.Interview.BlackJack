using System;
using System.Collections.Generic;

namespace BlackJack
{
    public static class ListExtensions
    {
        private static Random rng = new Random();  

        public static void Shuffle<T>(this IList<T> list)  
        {  
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }
        
        public static T RemoveAndReturnFirst<T>(this List<T> list)
        {
            if (list == null || list.Count == 0)
            {
                // Instead of returning the default,
                // an exception might be more compliant to the method signature.

                return default(T);
            }

            T currentFirst = list[0];
            list.RemoveAt(0);
            return currentFirst;
        }

    }
}