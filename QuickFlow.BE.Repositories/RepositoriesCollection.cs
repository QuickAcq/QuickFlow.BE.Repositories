using QuickFlow.BE.Shared.Interfaces.Repositories;

namespace QuickFlow.BE.Repositories
{
	internal class RepositoriesCollection : IRepositoriesCollection
	{
		protected QuickFlowDbContext DbContext { get; private set; }

		private readonly Lazy<IWfInstanceRepositories> _lzWfInstance;
		public IWfInstanceRepositories WfInstance => _lzWfInstance.Value;

		private readonly Lazy<IWfInstanceTaskRepositories> _lzWfInstanceTask;
		public IWfInstanceTaskRepositories WfInstanceTask => _lzWfInstanceTask.Value;

		public async Task<int> SaveChangesAsync() => await this.DbContext.SaveChangesAsync();

		public async Task<IApplicationDbTransaction> BeginTransactionAsync() => new ApplicationDbTransaction(await this.DbContext.Database.BeginTransactionAsync());

		public RepositoriesCollection(
			QuickFlowDbContext dbContext
			, Lazy<IWfInstanceRepositories> lzWfInstance
			, Lazy<IWfInstanceTaskRepositories> lzWfInstanceTask)
			
		{			
			this.DbContext = dbContext;
			this._lzWfInstance = lzWfInstance;
			this._lzWfInstanceTask = lzWfInstanceTask;
		}
	}
}
