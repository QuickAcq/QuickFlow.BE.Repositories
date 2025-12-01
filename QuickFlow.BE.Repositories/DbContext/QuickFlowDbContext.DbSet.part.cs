using Microsoft.EntityFrameworkCore;

using QuickFlow.BE.Entities;
using QuickFlow.BE.Repositories.Extensions;

namespace QuickFlow.BE.Repositories
{
	internal partial class QuickFlowDbContext : DbContext
	{
		partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
		{
			this.OnModelCreatingPartial_MstUsers(modelBuilder);

			this.OnModelCreatingPartial_WfTemplates(modelBuilder);
			this.OnModelCreatingPartial_WfTemplateStates(modelBuilder);

			this.OnModelCreatingPartial_WfInstances(modelBuilder);
			this.OnModelCreatingPartial_WfInstanceTasks(modelBuilder);
		}

		#region MstUsers
		public DbSet<MstUser> MstUsers { get; set; }

		private void OnModelCreatingPartial_MstUsers(ModelBuilder modelBuilder)
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

		#region WfTemplates
		public DbSet<WfTemplate> WfTemplates { get; set; }

		private void OnModelCreatingPartial_WfTemplates(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<WfTemplate>()
				.SetApplicationTableDefault();
		}
		#endregion

		#region WfTemplateStates
		public DbSet<WfTemplateState> WfTemplateStates { get; set; }

		private void OnModelCreatingPartial_WfTemplateStates(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<WfTemplateState>()
				.SetApplicationTableDefault();
		}
		#endregion

		#region WfInstances
		public DbSet<WfInstance> WfInstances { get; set; }

		private void OnModelCreatingPartial_WfInstances(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<WfInstance>()
				.SetApplicationTableDefault();
		}
		#endregion

		#region WfInstanceTasks
		public DbSet<WfInstanceTask> WfInstanceTasks { get; set; }

		private void OnModelCreatingPartial_WfInstanceTasks(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<WfInstanceTask>()
				.SetApplicationTableDefault();
		}
		#endregion

	}
}