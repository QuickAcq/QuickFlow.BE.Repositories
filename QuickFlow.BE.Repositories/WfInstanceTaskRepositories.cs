using Microsoft.EntityFrameworkCore;

using QuickFlow.BE.Entities;
using QuickFlow.BE.Shared.Interfaces;
using QuickFlow.BE.Shared.Interfaces.Repositories;

namespace QuickFlow.BE.Repositories
{
	internal class WfInstanceTaskRepositories : BaseRepositories<WfInstanceTask,Guid>, IWfInstanceTaskRepositories
	{
		public WfInstanceTaskRepositories(IDICollection dICollection, QuickFlowDbContext dbContext)
			: base(dICollection, dbContext)
		{
		}
	}
}
