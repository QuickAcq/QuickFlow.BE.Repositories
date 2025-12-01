//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;

//namespace QuickFlow.BE.Repositories
//{
//	public class DesignTimeQuickFlowDbContextFactory
//		: IDesignTimeDbContextFactory<QuickFlowDbContext>
//	{
//		public QuickFlowDbContext CreateDbContext(string[] args)
//		{
//			var basePath = Directory.GetCurrentDirectory();

//			var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

//			var configuration = new ConfigurationBuilder()
//				.SetBasePath(basePath)
//				.AddJsonFile("appsettings.json", optional: false)
//				.AddJsonFile($"appsettings.{env}.json", optional: true)
//				.AddEnvironmentVariables()
//				.Build();

//			var connectionString = configuration.GetConnectionString("QuickFlowDb");

//			var optionsBuilder = new DbContextOptionsBuilder<QuickFlowDbContext>();
//			optionsBuilder.UseNpgsql(connectionString);

//			return new QuickFlowDbContext(optionsBuilder.Options);
//		}
//	}
//}
