using System.Data;

namespace AcademicPublishing.DataAccess.Sql;

public interface IDbConnectionFactory
{
    IDbConnection GetConnection();
}
