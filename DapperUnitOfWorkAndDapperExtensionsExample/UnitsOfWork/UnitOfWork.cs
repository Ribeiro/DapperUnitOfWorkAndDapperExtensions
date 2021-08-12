using Serilog;
using System;
using System.Data;
using System.Data.SqlClient;


namespace DapperUnitOfWorkAndDapperExtensionsExample.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        IDbConnection _connection = null;
        IDbTransaction _transaction = null;
        private Guid _id = Guid.Empty;

        public UnitOfWork()
        {
            _id = Guid.NewGuid();
            _connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DapperUoW;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        IDbConnection IUnitOfWork.Connection
        {
            get { return _connection; }
        }

        IDbTransaction IUnitOfWork.Transaction
        {
            get { return _transaction; }
        }

        Guid IUnitOfWork.Id
        {
            get { return _id; }
        }

        public void Begin()
        {
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                Rollback();
                Log.Error(ex, ex.Message);
                throw new Exception($"Commit failed: {ex.Message}", ex);

            }finally
            {
                Dispose();
            }
        }

        private void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose() => _transaction?.Dispose();

    }

}