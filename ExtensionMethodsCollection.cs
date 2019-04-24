using System;
using System.Collections.Generic;

namespace AdbUtils
{
    public static class ExtensionMethodsCollection
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach(var elem in collection)
            {
                action.Invoke(elem);
            }
        }
    }
}
