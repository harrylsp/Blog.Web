using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common
{
    public static class CollectionExtensions
    {
        public static void Each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    }
}
