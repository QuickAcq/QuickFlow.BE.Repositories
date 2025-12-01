using Microsoft.EntityFrameworkCore;

using QuickFlow.BE.Entities;
using QuickFlow.BE.Shared.Interfaces;
using QuickFlow.BE.Shared.Interfaces.Repositories;

namespace QuickFlow.BE.Repositories
{
	internal class BaseEnumTableRepositories<EntityType> : BaseRepositories<EntityType, int>, IBaseEnumTableRepositories<EntityType>
		where EntityType : BaseEnumTable
	{
		public BaseEnumTableRepositories(IDICollection dICollection, QuickFlowDbContext dbContext)
			: base(dICollection, dbContext)
		{
		}

		public override async Task<EntityType?> TryGetByIdAsync(int id)
		{
			return await DbContext.Set<EntityType>().Where(row => row.RowId == id)
				.SingleOrDefaultAsync();
		}
	}
}
