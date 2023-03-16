using System.Linq.Expressions;

namespace EatZ.Infra.CrossCutting.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, bool condition)
        {
            if (condition)
            {
                return source.Where(predicate);
            }

            return source;
        }
    }
}
