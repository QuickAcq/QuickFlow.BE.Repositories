using QuickFlow.BE.Entities;
using QuickFlow.BE.Shared.Interfaces;
using QuickFlow.BE.Shared.Interfaces.Repositories;

namespace QuickFlow.BE.Repositories
{
	internal class WfTemplateRepositories : BaseApplicationTableRepositories<WfTemplate>, IWfTemplateRepositories
	{
		public WfTemplateRepositories(IDICollection dICollection, QuickFlowDbContext dbContext)
			: base(dICollection, dbContext)
		{
		}
	}
}
