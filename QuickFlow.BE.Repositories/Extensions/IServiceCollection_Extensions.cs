using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using QuickFlow.BE.Repositories;
using QuickFlow.BE.Shared.Interfaces.Repositories;

namespace QuickFlow.BE.Repositories.Extensions
{
	public static class IServiceCollection_Extensions
	{
		internal static IServiceCollection RegisterRepositoriesImplementation(this IServiceCollection services)
		{
			services.AddScoped<IWfInstanceRepositories, WfInstanceRepositories>();
			services.AddScoped<IWfInstanceTaskRepositories, WfInstanceTaskRepositories>();
			return services;
		}

		internal static IServiceCollection RegisterDbContextImplementation(this IServiceCollection services)
		{
			services.AddDbContext<QuickFlowDbContext>(opts => opts.UseNpgsql("User ID=quickflowdb_dev_admin;Password=P@ssw0rd;Server=103.82.240.95;Port=5432;Database=quickflowdb_dev;Pooling=true;"));
			return services;
		}
	}
}
