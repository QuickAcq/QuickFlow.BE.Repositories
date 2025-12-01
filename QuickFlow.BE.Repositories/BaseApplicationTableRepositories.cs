using Microsoft.EntityFrameworkCore;

using QuickFlow.BE.Entities;
using QuickFlow.BE.Shared.Interfaces;

namespace QuickFlow.BE.Repositories
{
	internal class BaseApplicationTableRepositories<EntityType> : BaseRepositories<EntityType, Guid>
		where EntityType : BaseApplicationTable
	{
		public BaseApplicationTableRepositories(IDICollection dICollection, QuickFlowDbContext dbContext)
			: base(dICollection, dbContext)
		{
		}

		public override async Task<EntityType?> TryGetByIdAsync(Guid id)
		{
			return await DbContext.Set<EntityType>().Where(row => row.RowId == id)
				.SingleOrDefaultAsync();
		}
	}
}
