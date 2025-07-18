using System;
using System.Collections.Generic;
using System.Linq;

namespace RS {
    public static class ListExtensions {
        public static void RefreshWith<T>(this List<T> list, IEnumerable<T> items) {
            list.Clear();
            list.AddRange(items);
        }
        public static T GetRandom<T>(this IEnumerable<T> list, Random random = null)
        {
            random ??= new Random();
            var enumerable = list as T[] ?? list.ToArray();
            if (!enumerable.Any()) return default(T);
            return enumerable.ElementAt(random.Next(enumerable.Count()));
        }

        public static T GetRandom<T>(this IEnumerable<T> list,Func<T, bool> predicate, Random random = null) {
            random ??= new Random();
            var filteredList = list.Where(predicate).ToArray();
            if (!filteredList.Any()) return default(T);
            return filteredList.ElementAt(random.Next(filteredList.Length));
        }
    }
}