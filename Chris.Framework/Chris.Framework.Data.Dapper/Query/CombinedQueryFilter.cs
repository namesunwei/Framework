using System;
using System.Collections.Generic;
using System.Text;
using Chris.Framework.Data.Dapper.Enums;
using Chris.Framework.Infrastructure;


namespace Chris.Framework.Data.Dapper.Query
{
    public class CombinedQueryFilter : QueryFilter
    {
        public QueryFilter Filter1 { get; }

        public QueryFilter Filter2 { get; }

        /// <summary>
        /// 表示查询过滤器中的字段逻辑组合方式。
        /// </summary>
        public BooleanClause Clause { get; }
        public CombinedQueryFilter(QueryFilter filter1, QueryFilter filter2, BooleanClause clause = BooleanClause.And)
        {
            Guard.ArgumentNotNull(filter1, nameof(filter1));
            Guard.ArgumentNotNull(filter2, nameof(filter2));

            Filter1 = filter1;
            Filter2 = filter2;
            Clause = clause;

        }
    }
}
