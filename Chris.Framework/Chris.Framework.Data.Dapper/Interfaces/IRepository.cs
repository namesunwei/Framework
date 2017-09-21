using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chris.Framework.Data.Dapper.Query;

namespace Chris.Framework.Data.Dapper.Interfaces
{
    public interface IRepository<T> where T : class
    {
        int Count();
        Task<int> CountAsync();
        int Count(QueryFilter filter);
        Task<int> CountAsync(QueryFilter filter);

        int Insert(T entity);
        Task<int> InsertAsync(T entity);
        int Insert(IEnumerable<T> entities);
        Task<int> InsertAsync(IEnumerable<T> entities);

        int Delete(T entity);
        Task<int> DeleteAsync(T entity);
        int Delete(QueryFilter filter);
        Task<int> DeleteAsync(QueryFilter filter);

        int Update(T entity);
        Task<int> UpdateAsync(T entity);
        int Update(T entity, IEnumerable<KeyValuePair<string, object>> fieldsToUpdate);
        Task<int> UpdateAsync(T entity, IEnumerable<KeyValuePair<string, object>> fieldsToUpdate);
        int Update(QueryFilter filter, IEnumerable<KeyValuePair<string, object>> fieldsToUpdate);
        Task<int> UpdateAsync(QueryFilter filter, IEnumerable<KeyValuePair<string, object>> fieldsToUpdate);

        IEnumerable<T> Query(QueryFilter filter);
        Task<IEnumerable<T>> QueryAsync(QueryFilter filter);
        IEnumerable<T> Query<TField>(string fieldName, IEnumerable<TField> fieldValues);
        Task<IEnumerable<T>> QueryAsync<TField>(string fieldName, IEnumerable<TField> fieldValues);
        IEnumerable<T> QueryAll();
        Task<IEnumerable<T>> QueryAllAsync();
        IEnumerable<T> QueryPaginated(int pageIndex, int pageSize, QueryFilter filter = null, SortOptions options = null);
        Task<IEnumerable<T>> QueryPaginatedAsync(int pageIndex, int pageSize, QueryFilter filter = null, SortOptions options = null);
    }
}
