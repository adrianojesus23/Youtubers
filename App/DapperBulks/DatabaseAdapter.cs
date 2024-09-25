using Z.Dapper.Plus;
using System.Collections.Generic;
using Dapper;

namespace App.DapperBulks
{
    public class DatabaseAdapter
    {
        private readonly IDbConnectionManager _connectionManager;

        public DatabaseAdapter(IDbConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public void BulkInsert(IEnumerable<Customer> customers)
        {
            using (var conntion = _connectionManager.BeginTransaction())
            {
                try
                {
                    conntion.BulkInsert(customers);
                    _connectionManager.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _connectionManager.Rollback();
                    throw;
                }
            }
        }
        public void BulkUpdate(IEnumerable<Customer> customers)
        {
            using (var conntion = _connectionManager.BeginTransaction())
            {
                try
                {
                    conntion.BulkUpdate(customers);
                    _connectionManager.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _connectionManager.Rollback();
                    throw;
                }
            }
        }
        public void BulkDelete(IEnumerable<Customer> customers)
        {
            using (var conntion = _connectionManager.BeginTransaction())
            {
                try
                {
                    conntion.BulkDelete(customers);
                    _connectionManager.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _connectionManager.Rollback();
                    throw;
                }
            }
        }
        public void BulkMarge(IEnumerable<Customer> customers)
        {
            using (var conntion = _connectionManager.BeginTransaction())
            {
                try
                {
                    conntion.BulkMerge(customers);
                    _connectionManager.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _connectionManager.Rollback();
                    throw;
                }
            }
        }
        
        public IEnumerable<Customer> GetCustomers()
        {
            using (var conntion = _connectionManager.GetConnection())
            {
                try
                {
                    var customers = conntion.Query<Customer>( "SELECT Id ,Name ,Email FROM Customers");

                    return customers;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
