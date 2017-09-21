using System;
using System.Collections.Generic;
using System.Text;

namespace Chris.Framework.Data.Dapper.Enums
{
    [Flags]
    public enum DbColumnRule : byte
    {
        None = 0x00,
        Ignore = 0x02,
        Key = 0x04,
        AutoGeneration = 0x08
    }
}
