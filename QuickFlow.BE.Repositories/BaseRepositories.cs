using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

using QuickFlow.BE.Shared.Interfaces;
using QuickFlow.BE.Shared.Interfaces.Repositories;

namespace QuickFlow.BE.Repositories
{
	internal class BaseRepositories<EntityType, IdType> : BaseRepositories, IBaseRepositories<EntityType, IdType>
		where EntityType : class
		where IdType : struct
	{
		public BaseRepositories(IDICollection dICollection, QuickFlowDbContext dbContext)
			: base(dICollection, dbContext)
		{
		}

		public async Task AddAsync(EntityType entity)
		{
			await this.DbContext.AddAsync<EntityType>(entity);			
		}

		public void Remove(EntityType entity)
		{
			EntityEntry<EntityType> entry = DbContext.Entry(entity);

			if (entry.State == EntityState.Detached)
			{
				DbContext.Attach(entity);
			}

			DbContext.Remove(entity);
		}

		public async Task<EntityType?> TryGetByIdAsync(IdType id)
		{
			IEntityType? entityType = DbContext.Model.FindEntityType(typeof(EntityType));
			if (entityType == null)
				throw new InvalidOperationException($"Entity type '{typeof(EntityType).Name}' not found in DbContext.");

			IProperty? keyProperty = entityType.FindPrimaryKey()?
				.Properties
				.FirstOrDefault();

			if (keyProperty == null)
				throw new InvalidOperationException($"Entity '{entityType.Name}' does not have a primary key defined.");

			string keyName = keyProperty.Name;

			return await DbContext.Set<EntityType>()
				.SingleOrDefaultAsync(e =>
					EF.Property<object>(e, keyName).Equals(id));
		}

		public async Task<EntityType> MustGetByIdAsync(IdType id)
		{
			EntityType? result = await this.TryGetByIdAsync(id);
			if (result == null)
			{
				throw new Exception("Cannot find '" + typeof(EntityType).Name + "' with id = '" + id.ToString() + "'");
			}
			return result;
		}

		public IQueryable<EntityType> SelectQuery()
		{
			return this.DbContext.Set<EntityType>();
		}
	}

	internal class BaseRepositories : IBaseRepositories
	{
		public IDICollection DICollection { get; private set; }		
		protected QuickFlowDbContext DbContext { get; private set; }

		public BaseRepositories(IDICollection dICollection, QuickFlowDbContext dbContext)
		{
			this.DICollection = dICollection;
			this.DbContext = dbContext;
		}
	}
}
