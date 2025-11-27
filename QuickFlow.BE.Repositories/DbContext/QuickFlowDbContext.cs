using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QuickFlow.BE.Entities;

namespace QuickFlow.BE.Repositories;

public partial class QuickFlowDbContext : DbContext
{
    public QuickFlowDbContext()
    {
    }

    public QuickFlowDbContext(DbContextOptions<QuickFlowDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MstUser> MstUsers { get; set; }

    public virtual DbSet<WfInstance> WfInstances { get; set; }

    public virtual DbSet<WfInstanceTask> WfInstanceTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("User ID=quickflowdb_dev_admin;Password=P@ssw0rd;Server=103.82.240.95;Port=5432;Database=quickflowdb_dev;Pooling=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MstUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("mst_user_pkey");

            entity.ToTable("mst_user");

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("user_id");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(100)
                .HasColumnName("display_name");
            entity.Property(e => e.HashedPassword).HasColumnName("hashed_password");
            entity.Property(e => e.UserLogin)
                .HasMaxLength(100)
                .HasColumnName("user_login");
        });

        modelBuilder.Entity<WfInstance>(entity =>
        {
            entity.HasKey(e => e.WfInstanceId).HasName("wf_instance_pkey");

            entity.ToTable("wf_instance");

            entity.Property(e => e.WfInstanceId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("wf_instance_id");
            entity.Property(e => e.CurrentWfStateId).HasColumnName("current_wf_state_id");
            entity.Property(e => e.DocId)
                .HasMaxLength(100)
                .HasColumnName("doc_id");
            entity.Property(e => e.Subject)
                .HasMaxLength(500)
                .HasColumnName("subject");
            entity.Property(e => e.WfTemplateId).HasColumnName("wf_template_id");
        });

        modelBuilder.Entity<WfInstanceTask>(entity =>
        {
            entity.HasKey(e => e.WfInstanceTaskId).HasName("wf_instance_task_pkey");

            entity.ToTable("wf_instance_task");

            entity.Property(e => e.WfInstanceTaskId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("wf_instance_task_id");
            entity.Property(e => e.IsValid).HasColumnName("is_valid");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WfInstanceId).HasColumnName("wf_instance_id");

            entity.HasOne(d => d.WfInstance).WithMany(p => p.WfInstanceTasks)
                .HasForeignKey(d => d.WfInstanceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("wf_instance_task_wf_instance_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
