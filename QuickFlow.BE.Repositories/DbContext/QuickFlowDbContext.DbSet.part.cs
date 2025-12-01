using Microsoft.EntityFrameworkCore;

using QuickFlow.BE.Entities;
using QuickFlow.BE.Repositories.Extensions;
using QuickFlow.BE.Shared.Extensions;

namespace QuickFlow.BE.Repositories
{
	internal partial class QuickFlowDbContext : DbContext
	{
		partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
		{
			this.OnModelCreatingPartial_MstWfStateType(modelBuilder);
			this.OnModelCreatingPartial_MstUser(modelBuilder);

			this.OnModelCreatingPartial_WfTemplate(modelBuilder);
			this.OnModelCreatingPartial_WfTemplateState(modelBuilder);

			this.OnModelCreatingPartial_WfInstance(modelBuilder);
			this.OnModelCreatingPartial_WfInstanceTask(modelBuilder);
		}

		#region MstUser
		public DbSet<MstUser> MstUser { get; set; }

		private void OnModelCreatingPartial_MstUser(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MstUser>()
				.SetApplicationTableDefault()
				.SetSeedData(this.GetSeed_MstUser());
		}

		/// <summary>
		/// Provides seed data for the <see cref="QuickFlow.BE.Entities.MstUser"/> entity.
		/// </summary>
		/// <returns>An array of <see cref="QuickFlow.BE.Entities.MstUser"/> pre-populated with default values.</returns>
		private MstUser[] GetSeed_MstUser()
			=> [
				new MstUser() {
					RowId = new Guid("00000000-0000-0000-0000-000000000001"),
					CreatedBy = new Guid("00000000-0000-0000-0000-000000000001"),
					CreatedAt = new DateTime(2025, 1, 1),
					LastModifiedBy = new Guid("00000000-0000-0000-0000-000000000001"),
					LastModifiedAt = new DateTime(2025, 1, 1),
					IsDeleted = false,
					DisplayName = "Administrator",
					LoginName = "admin"
				}
			];
		#endregion


		#region MstWfStateType
		public DbSet<MstWfStateType> MstWfStateType { get; set; }

		private void OnModelCreatingPartial_MstWfStateType(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MstWfStateType>()
				.SetSeedData(this.GetSeed_Enum<MstWfStateType, WfStateTypeConstants>());
		}
		#endregion

		#region WfTemplate
		public DbSet<WfTemplate> WfTemplate { get; set; }

		private void OnModelCreatingPartial_WfTemplate(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<WfTemplate>()
				.SetApplicationTableDefault()
				.SetSeedData(this.GetSeed_WfTemplate());
		}

		/// <summary>
		/// Provides seed data for the <see cref="QuickFlow.BE.Entities.MstUser"/> entity.
		/// </summary>
		/// <returns>An array of <see cref="QuickFlow.BE.Entities.MstUser"/> pre-populated with default values.</returns>
		private WfTemplate[] GetSeed_WfTemplate()
			=> [
				new WfTemplate() {
					RowId = new Guid("00000000-0000-0000-0000-000000000002"),
					CreatedBy = new Guid("00000000-0000-0000-0000-000000000001"),
					CreatedAt = new DateTime(2025, 1, 1),
					LastModifiedBy = new Guid("00000000-0000-0000-0000-000000000001"),
					LastModifiedAt = new DateTime(2025, 1, 1),
					IsDeleted = false,
					Name = "DummyTemplate",
					Version = 1
				}
			];
		#endregion

		#region WfTemplateState
		public DbSet<WfTemplateState> WfTemplateState { get; set; }

		private void OnModelCreatingPartial_WfTemplateState(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<WfTemplateState>()
				.SetApplicationTableDefault()
				.SetSeedData(this.GetSeed_WfTemplateState());
		}

		/// <summary>
		/// Provides seed data for the <see cref="QuickFlow.BE.Entities.MstUser"/> entity.
		/// </summary>
		/// <returns>An array of <see cref="QuickFlow.BE.Entities.MstUser"/> pre-populated with default values.</returns>
		private WfTemplateState[] GetSeed_WfTemplateState()
			=> [
				new WfTemplateState() {
					RowId = new Guid("00000000-0000-0000-0000-000000000003"),
					CreatedBy = new Guid("00000000-0000-0000-0000-000000000001"),
					CreatedAt = new DateTime(2025, 1, 1),
					LastModifiedBy = new Guid("00000000-0000-0000-0000-000000000001"),
					LastModifiedAt = new DateTime(2025, 1, 1),
					IsDeleted = false,
					WfTemplateId = new Guid("00000000-0000-0000-0000-000000000002"),
					MstWfStateTypeId = 1
				}
			];
		#endregion

		#region WfInstance
		public DbSet<WfInstance> WfInstance { get; set; }

		private void OnModelCreatingPartial_WfInstance(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<WfInstance>()
				.SetApplicationTableDefault();
		}
		#endregion

		#region WfInstanceTask
		public DbSet<WfInstanceTask> WfInstanceTask { get; set; }

		private void OnModelCreatingPartial_WfInstanceTask(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<WfInstanceTask>()
				.SetApplicationTableDefault();
		}
		#endregion


		/// <summary>
		/// Generates an array of enum entity records from a given enum type, used for seeding reference data into a database.
		/// </summary>
		/// <typeparam name="EnumEntityType">The type of the enum entity, must inherit from <see cref="BaseEnumTable"/> and have a parameterless constructor.</typeparam>
		/// <typeparam name="EnumConstants">The enum type containing constant values.</typeparam>
		/// <returns>An array of <typeparamref name="EnumEntityType"/> populated from the enum values.</returns>
		public EnumEntityType[] GetSeed_Enum<EnumEntityType, EnumConstants>()
			where EnumEntityType : BaseEnumTable, new()
			where EnumConstants : struct, Enum
		{
			List<EnumEntityType> lstResult = new List<EnumEntityType>();
			foreach (EnumConstants enumKeyValue in Enum.GetValues(typeof(EnumConstants)))
			{
				EnumEntityType enumEntity = new EnumEntityType()
				{
					RowId = enumKeyValue.ToInt32(),
					Name = enumKeyValue.ToString().Replace("_", " ")
				};
				lstResult.Add(enumEntity);
			}
			return lstResult.ToArray();
		}
	}
}