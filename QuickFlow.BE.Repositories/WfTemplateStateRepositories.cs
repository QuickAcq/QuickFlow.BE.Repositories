using QuickFlow.BE.Entities;
using QuickFlow.BE.Shared.Interfaces;
using QuickFlow.BE.Shared.Interfaces.Repositories;

namespace QuickFlow.BE.Repositories
{
	internal class WfTemplateStateRepositories : BaseApplicationTableRepositories<WfTemplateState>, IWfTemplateStateRepositories
	{
		public WfTemplateStateRepositories(IDICollection dICollection, QuickFlowDbContext dbContext)
			: base(dICollection, dbContext)
		{
		}
	}
}
