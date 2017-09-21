using System;
using System.Collections.Generic;
using System.Text;
using Chris.Framework.Data.Dapper.Enums;
using Chris.Framework.Infrastructure;


namespace Chris.Framework.Data.Dapper.Query
{
    /// <summary>
    /// 排序选项
    /// </summary>
    public class SortOptions
    {

        private readonly List<string> _fieldNameCollection;
        /// <summary>
        /// 排序方式
        /// </summary>
        public SortOrder SortOrder { get; set; }
        /// <summary>
        /// 获取作为排序选项的字段集合
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetFieldNames()
        {
            return _fieldNameCollection;
        }
        /// <summary>
        /// 初始化排序规则
        /// </summary>
        /// <param name="fieldName">默认排序字段</param>
        /// <param name="sortOrder">排序方式</param>
        public SortOptions(string fieldName, SortOrder sortOrder = SortOrder.Descending)
        {
            Guard.ArgumentNullOrWhiteSpaceString(fieldName, nameof(fieldName));
            SortOrder = sortOrder;
            _fieldNameCollection = new List<string> { fieldName };
        }
        /// <summary>
        /// 为当前排序选项添加排序字段（字段排序优先规则按添加的顺序）。
        /// </summary>
        /// <param name="fieldNames"></param>
        /// <returns></returns>
        public SortOptions AddField(List<string> fieldNames)
        {
            Guard.ArgumentNullOrWhiteSpaceString(fieldNames, nameof(fieldNames));
            _fieldNameCollection.AddRange(fieldNames);
            return this;
        }

    }
}
