using System;
using System.Collections.Generic;
using System.Text;

namespace Chris.Framework.Data
{
    public interface IDatabaseTransaction
    {
        /// <summary>
        /// 提交事务
        /// </summary>
        void Commit();
        /// <summary>
        /// 回滚事务
        /// </summary>
        void Rollback();
    }
}
