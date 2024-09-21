using System.Data;

namespace App.DapperBulks;

public interface IDbConnectionManager : IDisposable
{
   IDbConnection GetConnection();
   IDbTransaction BeginTransaction();
   void Commit();
   void Rollback();
}