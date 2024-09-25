using Microsoft.Data.SqlClient;

namespace App.DapperBulks;

using System;
using System.Data;
using System.Data.SqlClient;

public class DbConnectionManager : IDbConnectionManager
{
    private readonly string _connectionString;
    private SqlConnection _sqlConnection;
    private SqlTransaction _sqlTransaction;

    public DbConnectionManager(string connectionString)
    {
        _connectionString = connectionString;
        _sqlConnection = new SqlConnection(_connectionString);
    }
    
    public void Dispose()
    {
        if (_sqlTransaction is not null)
        {
            Rollback();
        }

        if (_sqlConnection is not null &&
            _sqlConnection.State == ConnectionState.Open)
        {
            _sqlConnection.Close();
            _sqlConnection.Dispose();
        }
    }

    public IDbConnection GetConnection()
    {
        if(_sqlConnection.State == ConnectionState.Closed)
            _sqlConnection.Open();

        return _sqlConnection;
    }

    public IDbTransaction BeginTransaction()
    {
        if(_sqlConnection.State == ConnectionState.Closed)
            _sqlConnection.Open();

        _sqlTransaction = _sqlConnection.BeginTransaction();
        return _sqlTransaction;
    }

    public void Commit()
    {
        _sqlTransaction?.Commit();
        _sqlTransaction = null;
    }

    public void Rollback()
    {
        _sqlTransaction?.Rollback();
        _sqlTransaction = null;
    }
}
