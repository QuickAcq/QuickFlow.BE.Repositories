using Microsoft.EntityFrameworkCore;

using QuickFlow.BE.Entities;
using QuickFlow.BE.Repositories.Extensions;

namespace QuickFlow.BE.Repositories
{
	internal partial class QuickFlowDbContext : DbContext
	{
		public QuickFlowDbContext()
		{
		}

		public QuickFlowDbContext(DbContextOptions<QuickFlowDbContext> options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseDefaultBuild();
			}
			base.OnConfiguring(optionsBuilder);
		}			


		//public virtual DbSet<MstUser> MstUsers { get; set; }

		//public virtual DbSet<WfInstance> WfInstances { get; set; }

		//public virtual DbSet<WfInstanceTask> WfInstanceTasks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{			
			//modelBuilder.Entity<MstUser>(entity =>
			//{
			//	entity.HasKey(e => e.UserId).HasName("mst_user_pkey");

			//	entity.ToTable("mst_user");

			//	entity.Property(e => e.UserId)
			//		.HasDefaultValueSql("gen_random_uuid()")
			//		.HasColumnName("user_id");
			//	entity.Property(e => e.DisplayName)
			//		.HasMaxLength(100)
			//		.HasColumnName("display_name");
			//	entity.Property(e => e.HashedPassword).HasColumnName("hashed_password");
			//	entity.Property(e => e.UserLogin)
			//		.HasMaxLength(100)
			//		.HasColumnName("user_login");
			//});

			//modelBuilder.Entity<WfInstance>(entity =>
			//{
			//	entity.HasKey(e => e.WfInstanceId).HasName("wf_instance_pkey");

			//	entity.ToTable("wf_instance");

			//	entity.Property(e => e.WfInstanceId)
			//		.HasDefaultValueSql("gen_random_uuid()")
			//		.HasColumnName("wf_instance_id");
			//	entity.Property(e => e.CurrentWfStateId).HasColumnName("current_wf_state_id");
			//	entity.Property(e => e.DocId)
			//		.HasMaxLength(100)
			//		.HasColumnName("doc_id");
			//	entity.Property(e => e.Subject)
			//		.HasMaxLength(500)
			//		.HasColumnName("subject");
			//	entity.Property(e => e.WfTemplateId).HasColumnName("wf_template_id");
			//});

			//modelBuilder.Entity<WfInstanceTask>(entity =>
			//{
			//	entity.HasKey(e => e.WfInstanceTaskId).HasName("wf_instance_task_pkey");

			//	entity.ToTable("wf_instance_task");

			//	entity.Property(e => e.WfInstanceTaskId)
			//		.HasDefaultValueSql("gen_random_uuid()")
			//		.HasColumnName("wf_instance_task_id");
			//	entity.Property(e => e.IsValid).HasColumnName("is_valid");
			//	entity.Property(e => e.UserId).HasColumnName("user_id");
			//	entity.Property(e => e.WfInstanceId).HasColumnName("wf_instance_id");

			//	entity.HasOne(d => d.WfInstance).WithMany(p => p.WfInstanceTasks)
			//		.HasForeignKey(d => d.WfInstanceId)
			//		.OnDelete(DeleteBehavior.Restrict)
			//		.HasConstraintName("wf_instance_task_wf_instance_id_fkey");
			//});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


	}
}