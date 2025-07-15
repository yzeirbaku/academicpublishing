using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace AcademicPublishing.DataAccess.Sql;

public class SqlConnectionFactory(IConfiguration configuration) : IDbConnectionFactory
{
    private readonly string _connectionString = configuration.GetConnectionString("SqlConnectionString")
        ?? throw new InvalidOperationException("Missing SqlConnectionString.");

    public IDbConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
