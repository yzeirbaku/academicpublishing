using AcademicPublishing.DataAccess.Repositories;
using AcademicPublishing.DataAccess.Sql;
using Microsoft.Extensions.DependencyInjection;

namespace AcademicPublishing.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlDataAccess(this IServiceCollection services)
    {
        services.AddScoped<IDbConnectionFactory, SqlConnectionFactory>();
        services.AddScoped<IArticleRepository, ArticleRepository>();

        return services;
    }
}
