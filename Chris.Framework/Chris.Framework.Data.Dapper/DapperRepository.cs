using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chris.Framework.Data.Dapper.Interfaces;
using Chris.Framework.Data.Dapper.Query;
using Microsoft.Extensions.Logging;

namespace Chris.Framework.Data.Dapper
{
    public class DapperRepository<T> : IRepository<T> where T : class
    {
        private readonly DapperMetadata _dapperMetadata;
        private readonly Lazy<ILogger> _loggerLazy;

       

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(QueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(QueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(QueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(QueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public int Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public int Insert(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query(QueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query<TField>(string fieldName, IEnumerable<TField> fieldValues)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> QueryAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> QueryAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> QueryAsync(QueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> QueryAsync<TField>(string fieldName, IEnumerable<TField> fieldValues)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> QueryPaginated(int pageIndex, int pageSize, QueryFilter filter = null, SortOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> QueryPaginatedAsync(int pageIndex, int pageSize, QueryFilter filter = null, SortOptions options = null)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity, IEnumerable<KeyValuePair<string, object>> fieldsToUpdate)
        {
            throw new NotImplementedException();
        }

        public int Update(QueryFilter filter, IEnumerable<KeyValuePair<string, object>> fieldsToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity, IEnumerable<KeyValuePair<string, object>> fieldsToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(QueryFilter filter, IEnumerable<KeyValuePair<string, object>> fieldsToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
