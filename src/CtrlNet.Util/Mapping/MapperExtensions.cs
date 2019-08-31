using AgileObjects.AgileMapper;
using System.Linq;

namespace CtrlNet.Util.Mapping
{
    /// <summary>
    ///		对象映射扩展
    /// </summary>
    public static class MapperExtensions
    {
        /// <summary>
        ///		深度克隆
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TSource Clone<TSource>(this TSource source)
        {
            return Mapper.DeepClone(source);
        }
        /// <summary>
        ///		对象创建
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination Map<TSource, TDestination>(this TSource source)
        {
            return Mapper.Map(source).ToANew<TDestination>();
        }
        /// <summary>
        ///		对象创建
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination Map<TDestination>(this object source)
        {
            return Mapper.Map(source).ToANew<TDestination>();
        }
        /// <summary>
        ///		合并
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static TDestination Map<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map(source).OnTo(destination);
        }
        /// <summary>
        ///		查询
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="queryable"></param>
        /// <returns></returns>
        public static IQueryable<TDestination> Project<TSource, TDestination>(this IQueryable<TSource> queryable)
        {
            return queryable.Project().To<TDestination>();
        }
    }
}
