using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend_final_proj.Models;

public partial class TaskmanagementDbContext : DbContext
{
    public TaskmanagementDbContext()
    {
    }

    public TaskmanagementDbContext(DbContextOptions<TaskmanagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllTask> AllTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:AZURE_SQL_CONNECTIONSTRING");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllTask>(entity =>
        {
            entity
                .HasKey(e => e.Id);
                entity.ToTable("all_tasks");

            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("due_date");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Manager).HasColumnName("manager");
            entity.Property(e => e.ManagerEmail).HasColumnName("manager_email");
            entity.Property(e => e.TaskDescription).HasColumnName("task_description");
            entity.Property(e => e.TaskTitle).HasColumnName("task_title");
            entity.Property(e => e.TaskUser).HasColumnName("task_user");
            entity.Property(e => e.TimeCreated)
                .HasColumnType("datetime")
                .HasColumnName("time_created");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
