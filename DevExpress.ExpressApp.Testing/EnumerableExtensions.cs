namespace DevExpress.ExpressApp.Testing{
    public static class EnumerableExtensions{
        public static IEnumerable<TSource> Do<TSource>(
            this IEnumerable<TSource> source, Action<TSource> action)
            => source.Select(item => {
                action(item);
                return item;
            });
        public static IEnumerable<TValue> To<TSource,TValue>(this IEnumerable<TSource> source,TValue value) 
            => source.Select(_ => value);
        public static IEnumerable<T> SelectManyRecursive<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector){
            foreach (var i in source){
                yield return i;
                var children = childrenSelector(i);
                if (children == null) continue;
                foreach (var child in SelectManyRecursive(children, childrenSelector))
                    yield return child;
            }
        }
        internal static TimeSpan Seconds(this int seconds) => TimeSpan.FromSeconds(seconds);
        internal static object DefaultValue(this Type t) => t.IsValueType ? Activator.CreateInstance(t) : null;
        internal static bool IsNullOrEmpty(this string strString)
            => string.IsNullOrEmpty(strString);
    }
}