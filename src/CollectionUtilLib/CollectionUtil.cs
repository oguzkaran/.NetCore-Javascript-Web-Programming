using System.Collections.Generic;

namespace CSD.Util.Collections
{
    public static class CollectionUtil
    {
        public static T[] ToArray<T>(this ICollection<T> coll)
        {
            var result = new T[coll.Count];

            coll.CopyTo(result, 0);

            return result;
        }

        public static bool AreAllDistinct<T>(this ICollection<T> coll)
        {
            return coll.Count == new HashSet<T>(coll).Count;
        }

        public static bool AreAllDistinct<T>(this IEnumerable<T> ie)
        {
            return new List<T>(ie).Count == new HashSet<T>(ie).Count;
        }
    }
}
