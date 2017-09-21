using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Chris.Framework.Data.Dapper.Enums;
using Chris.Framework.Infrastructure;

namespace Chris.Framework.Data.Dapper.Conventions
{
    public class PropertyConvention
    {
        private readonly Func<PropertyInfo, bool> _filter;
        private readonly DbColumnRule _dbColumnRule;
        internal PropertyConvention(Func<PropertyInfo, bool> filter, DbColumnRule dbColumnRule = DbColumnRule.None)
        {
            Guard.ArgumentNotNull(filter, nameof(filter));
            _filter = filter;
            _dbColumnRule = dbColumnRule;
        }
    }
}
