using Blog.Common;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Blog.DataAccess
{
    public class BlogDatabase : IDbConnection, IDependencyRequestSingleton
    {
        private static readonly OrmLiteConnectionFactory Factory =
           new OrmLiteConnectionFactory(ConfigManager.Configuration["ProjectConfig:localhost"], MySqlDialect.Provider);

        private readonly IDbConnection _conn = Factory.OpenDbConnection();

        public BlogDatabase()
        {
        }

        public string ConnectionString
        {
            get => _conn.ConnectionString;
            set => _conn.ConnectionString = value;
        }

        public int ConnectionTimeout => _conn.ConnectionTimeout;

        public string Database => _conn.Database;

        public ConnectionState State => _conn.State;

        public IDbTransaction BeginTransaction() => _conn.BeginTransaction();

        public IDbTransaction BeginTransaction(IsolationLevel il) => _conn.BeginTransaction(il);

        public void ChangeDatabase(string databaseName) => _conn.ChangeDatabase(databaseName);

        public void Close() => _conn.Close();

        public IDbCommand CreateCommand() => _conn.CreateCommand();

        public void Dispose() => _conn.Dispose();

        public void Open() => _conn.Open();
    }
}
