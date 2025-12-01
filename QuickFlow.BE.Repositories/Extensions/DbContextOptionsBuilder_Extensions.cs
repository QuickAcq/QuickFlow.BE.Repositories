using Microsoft.EntityFrameworkCore;

namespace QuickFlow.BE.Repositories.Extensions
{
	internal static class DbContextOptionsBuilder_Extensions
	{
		public static DbContextOptionsBuilder UseDefaultBuild(this DbContextOptionsBuilder optionsBuilder)
		{
			return optionsBuilder
				.UseNpgsql("User ID=quickflowdb_dev_admin;Password=P@ssw0rd;Server=103.82.240.95;Port=5432;Database=quickflowdb_dev;Pooling=true;")
				.UseSnakeCaseNamingConvention();
		}

	}
}
