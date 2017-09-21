using System;
using System.Collections.Generic;
using System.Text;
using Chris.Framework.Data.Dapper.Enums;

namespace Chris.Framework.Data.Dapper.Query
{
    public class QueryFilter
    {
        /// <summary>
        /// 通过 and 语义合并两个查询过滤器。
        /// </summary>
        /// <param name="filter1"></param>
        /// <param name="filter2"></param>
        /// <returns></returns>
        public static QueryFilter CombineAnd(QueryFilter filter1, QueryFilter filter2)
        {
            return new CombinedQueryFilter(filter1, filter1, BooleanClause.And);
        }
        /// <summary>
        /// 通过 or 语义合并两个查询过滤器。
        /// </summary>
        /// <param name="filter1"></param>
        /// <param name="filter2"></param>
        /// <returns></returns>
        public static QueryFilter CombineOr(QueryFilter filter1, QueryFilter filter2)
        {
            return new CombinedQueryFilter(filter1, filter2, BooleanClause.Or);
        }
    }
}
