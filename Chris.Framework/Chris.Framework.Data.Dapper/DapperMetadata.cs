using System;
using System.Collections.Generic;
using System.Text;
using Chris.Framework.Infrastructure;

namespace Chris.Framework.Data.Dapper
{
    /// <summary>
    /// Dapper元数据
    /// </summary>
    public class DapperMetadata
    {
        public Type EntityType { get; }
        public string TableName { get; internal set; }
       // public  IEnumerable<Dappfe>
        public DapperMetadata(Type entityType)
        {
            Guard.ArgumentNotNull(entityType, nameof(entityType));

        }
    }
}
