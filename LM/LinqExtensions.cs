using System.Collections.Generic;
using System.Linq;

namespace LM
{
    public static class LinqExtensions
    {
        public static bool SafeAny<T>(this IList<T> items)
        {
            if (items == null)
            {
                return false;
            }

            return items.Any();
        }

        public static IEnumerable<IList<T>> Batches<T>(this IList<T> records, int batchSize)
        {
            var result = new List<T>(batchSize);

            foreach (var record in records)
            {
                result.Add(record);

                if (result.Count >= batchSize)
                {
                    yield return result;

                    result = new List<T>(batchSize);
                }
            }

            if (result.Count != 0)
            {
                yield return result;
            }
        }
    }
}
