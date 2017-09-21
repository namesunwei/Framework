using System;
using System.Collections.Generic;
using System.Linq;
using Chris.Framework.Extensions;


namespace Chris.Framework.Data
{
    /// <summary>
    /// 数据库选项
    /// </summary>
    public class DatabaseOptions
    {
        private string _defaultConnectionName;
        private Dictionary<string, string> _connectionStrings;

        public virtual Dictionary<string, string> ConnectionStrings
        {
            get => _connectionStrings ?? (_connectionStrings = new Dictionary<string, string>(StringComparer.Ordinal));
            set => _connectionStrings = value;
        }
        public virtual string DefaultConnectionNmae
        {
            get => _defaultConnectionName.IfNullOrWhiteSpace(ConnectionStrings.Keys.FirstOrDefault());
            set => _defaultConnectionName = value;
        }
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <param name="connectionName">连接名</param>
        /// <param name="throwIfNotExisted">true:连接字符串不存在时抛异常，false:连接字符串不存在时返回bull</param>
        /// <returns></returns>
        public virtual string GetConnectionString(string connectionName = null, bool throwIfNotExisted = true)
        {
            connectionName = connectionName.IfNullOrWhiteSpace(_defaultConnectionName);
            if (!connectionName.IsNullOrWhiteSpace())
            {
                var conn = ConnectionStrings.GetOrDefault(connectionName);
                if (conn.IsNullOrWhiteSpace() && throwIfNotExisted)
                {
                    throw new Exception($"在配置文件中找不到名为 '{connectionName}' 的数据库连接字符串。");
                }
                return conn;
            }
            else
            {
                var conn = ConnectionStrings.FirstOrDefault().Value;
                if (conn.IsNullOrWhiteSpace() && throwIfNotExisted)
                {
                    throw new Exception($"没有配置任何可用的数据库连接字符串，或连接字符串为空。");
                }
                return conn;
            }
        }
    }
}
