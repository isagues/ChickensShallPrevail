using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class EnumUtil {
        // https://stackoverflow.com/a/972323
        public static IEnumerable<T> GetValues<T>() {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }

}