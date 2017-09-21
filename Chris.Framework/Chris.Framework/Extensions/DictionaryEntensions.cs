using System;
using System.Collections.Generic;
using Chris.Framework.Infrastructure;

namespace Chris.Framework.Extensions
{
    /// <summary>
    /// 字典扩展
    /// </summary>
    public static class DictionaryEntensions
    {
        /// <summary>
        /// 向字典中插入键值对
        /// </summary>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <param name="instance">源字典</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="replaceExisting">是否替换已存在的项</param>
        public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> instance, TKey key, TValue value, bool replaceExisting = true)
        {
            if (!instance.ContainsKey(key))
            {
                instance.Add(key, value);
            }

            else if (replaceExisting)
            {
                instance[key] = value;
            }
        }

        /// <summary>
        /// 合并字典
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="instance">源字典</param>
        /// <param name="toAdd">待合并的字典</param>
        /// <param name="replaceExisting">是否替换已存在项</param>
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> instance, IEnumerable<KeyValuePair<TKey, TValue>> toAdd, bool replaceExisting = true)
        {
            Guard.ArgumentNotNull(toAdd, nameof(toAdd));

            foreach (var pair in toAdd)
            {
                instance.Add(pair.Key, pair.Value, replaceExisting);
            }
        }
        /// <summary>
        /// 当该项不存在时，向字典中插入该项
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="instance">源字典</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static bool AddIfNotExisted<TKey, TValue>(this IDictionary<TKey, TValue> instance, TKey key, TValue value)
        {
            if (instance.ContainsKey(key))
            {
                return false;
            }

            instance.Add(key, value);

            return true;
        }

        /// <summary>
        /// 获取字典中的指定项
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="instance">源字典</param>
        /// <param name="key">键</param>
        /// <param name="defaultValue">指定项不存在时，所取的默认值</param>
        /// <returns></returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> instance, TKey key, TValue defaultValue = default(TValue))
        {
            return instance.TryGetValue(key, out var result) ? result : defaultValue;
        }
        /// <summary>
        /// 获取字典中指定键的值，如果该项不存在，则返回委托的返回值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="instance">源字典</param>
        /// <param name="key">键</param>
        /// <param name="valueFactory">当该项不存在时的，返回值的委托对象</param>
        /// <returns></returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> instance, TKey key, Func<TValue> valueFactory)
        {
            Guard.ArgumentNotNull(valueFactory, nameof(valueFactory));

            return !instance.TryGetValue(key, out var result) ? valueFactory.Invoke() : result;
        }

        /// <summary>
        /// 获取字典中的指定项，如果不存在，则添加委托结果到源字典中
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="instance">源字典</param>
        /// <param name="key">键</param>
        /// <param name="valueFunc">当指定项不存在时，插入字典项的委托</param>
        /// <returns></returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> instance, TKey key, Func<TKey, TValue> valueFunc)
        {
            Guard.ArgumentNotNull(valueFunc, nameof(valueFunc));

            if (instance.TryGetValue(key, out var result)) return result;

            result = valueFunc(key);
            instance.Add(key, result);

            return result;
        }
        /// <summary>
        /// 获取字典中某一项的值，并删除该项
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="instance">源字典</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static TValue GetAndRemove<TKey, TValue>(this IDictionary<TKey, TValue> instance, TKey key)
        {
            if (!instance.TryGetValue(key, out var result)) return default(TValue);

            return instance.Remove(key) ? result : default(TValue);
        }
    }
}
