using Microsoft.EntityFrameworkCore.Storage;

using QuickFlow.BE.Shared.Interfaces.Repositories;

namespace QuickFlow.BE.Repositories
{
	internal class ApplicationDbTransaction : IApplicationDbTransaction
	{
		protected IDbContextTransaction DbContextTransaction { get; set; }

		public ApplicationDbTransaction(IDbContextTransaction dbContextTransaction)
		{
			this.DbContextTransaction = dbContextTransaction;
		}

		public void Commit() => this.DbContextTransaction.Commit();
		public Task CommitAsync() => this.DbContextTransaction.CommitAsync();
		public void Rollback() => this.DbContextTransaction?.Rollback();
		public Task RollbackAsync() => this.DbContextTransaction.RollbackAsync();
		public ValueTask DisposeAsync() => this.DbContextTransaction.DisposeAsync();
		public void Dispose() => this.DbContextTransaction.Dispose();
	}
}