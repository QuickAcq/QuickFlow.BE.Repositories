using Microsoft.EntityFrameworkCore;

using QuickFlow.BE.Entities;
using QuickFlow.BE.Repositories.Extensions;

namespace QuickFlow.BE.Repositories
{
	internal partial class QuickFlowDbContext : DbContext
	{
		partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
		{
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

		#region WfTemplate
		public DbSet<WfTemplate> WfTemplate { get; set; }

		private void OnModelCreatingPartial_WfTemplate(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<WfTemplate>()
				.SetApplicationTableDefault();
		}
		#endregion

		#region WfTemplateState
		public DbSet<WfTemplateState> WfTemplateState { get; set; }

		private void OnModelCreatingPartial_WfTemplateState(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<WfTemplateState>()
				.SetApplicationTableDefault();
		}
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

	}
}