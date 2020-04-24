using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class ListExtensions
    {
        public static void AddMany<T>(this List<T> list, params T[] elements)
        {
            list.AddRange(elements);
        }
    }
}
