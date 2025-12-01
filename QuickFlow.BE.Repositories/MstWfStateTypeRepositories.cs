using QuickFlow.BE.Entities;
using QuickFlow.BE.Shared.Interfaces;
using QuickFlow.BE.Shared.Interfaces.Repositories;

namespace QuickFlow.BE.Repositories
{
	internal class MstWfStateTypeRepositories : BaseEnumTableRepositories<MstWfStateType>, IMstWfStateTypeRepositories
	{
		public MstWfStateTypeRepositories(IDICollection dICollection, QuickFlowDbContext dbContext)
			: base(dICollection, dbContext)
		{
		}
	}
}
