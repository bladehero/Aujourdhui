using System;
using System.Collections.Generic;

#nullable enable

namespace Aujourdhui.Extensions.EnumerableExtensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> EachApply<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (action is null)
            {
                throw new NullReferenceException($"Parameter `{nameof(action)}` cannot be null!");
            }

            foreach (var item in source)
            {
                action.Invoke(item);
            }

            return source;
        }
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (action is null)
            {
                throw new NullReferenceException($"Parameter `{nameof(action)}` cannot be null!");
            }

            foreach (var item in source)
            {
                action.Invoke(item);
            }
        }
    }
}
