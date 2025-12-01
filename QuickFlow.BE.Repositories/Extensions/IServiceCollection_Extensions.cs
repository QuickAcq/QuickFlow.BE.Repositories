using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using QuickFlow.BE.Shared.Interfaces.Repositories;

namespace QuickFlow.BE.Repositories.Extensions
{
	public static class IServiceCollection_Extensions
	{
		internal static IServiceCollection RegisterRepositoriesImplementation(this IServiceCollection services)
		{
			services.AddScoped<IWfInstanceRepositories, WfInstanceRepositories>();
			services.AddScoped<IWfInstanceTaskRepositories, WfInstanceTaskRepositories>();

			services.AddScoped<IRepositoriesCollection, RepositoriesCollection>();
			return services;
		}

		internal static IServiceCollection RegisterDbContextImplementation(this IServiceCollection services)
		{
			services.AddDbContext<QuickFlowDbContext>(opts => opts.UseDefaultBuild());
			return services;
		}
	}
}
