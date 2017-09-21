using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Chris.Framework.Data
{
    public class DbTransactionScope : IDisposable
    {
        private readonly IDatabaseTransaction _databaseTransaction;
        private bool _disposed;

        private bool _completed;

        //public DbTransactionScope(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, string connectionName = null):this()
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
