using Microsoft.EntityFrameworkCore;

using QuickFlow.BE.Entities;
using QuickFlow.BE.Shared.Interfaces;
using QuickFlow.BE.Shared.Interfaces.Repositories;

namespace QuickFlow.BE.Repositories
{
	internal class WfInstanceRepositories : BaseRepositories<WfInstance,Guid>, IWfInstanceRepositories
	{
		public WfInstanceRepositories(IDICollection dICollection, QuickFlowDbContext dbContext)
			: base(dICollection, dbContext)
		{
		}
	}
}
