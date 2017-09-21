using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Chris.Framework.Data.Dapper.Conventions;

namespace Chris.Framework.Data.Dapper
{
    public class DapperFieldMetadata
    {
        public PropertyInfo Field { get; set; }
        public string Name { get; set; }
        public bool AutoGeneration { get; set; }
        public bool IsKey { get; set; }
        public bool Ignore { get; set; }
        internal DapperFieldMetadata(PropertyInfo field)
        {
            Field = field;
           // Name=
        }

        internal DapperFieldMetadata(PropertyInfo field, PropertyConvention convention)
        {

        }


    }
}
