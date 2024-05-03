using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Database;

public partial class Demo1Context : DbContext
{
    public Demo1Context()
    {
    }

    public Demo1Context(DbContextOptions<Demo1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Devicetype> Devicetypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;user=root;password=1234;database=demo1", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.37-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("application");

            entity.HasIndex(e => e.ClientId, "client_id");

            entity.HasIndex(e => e.DeviceType, "device_type");

            entity.HasIndex(e => e.EmployeeId, "employee_id");

            entity.HasIndex(e => e.Status, "status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DeviceType).HasColumnName("device_type");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EndedTime)
                .HasColumnType("datetime")
                .HasColumnName("ended_time");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Priority)
                .HasDefaultValueSql("'1'")
                .HasColumnName("priority");
            entity.Property(e => e.StartedTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("started_time");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Client).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("application_ibfk_3");

            entity.HasOne(d => d.DeviceTypeNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.DeviceType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("application_ibfk_1");

            entity.HasOne(d => d.Employee).WithMany(p => p.Applications)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("application_ibfk_4");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("application_ibfk_2");

            entity.HasMany(d => d.Comments).WithMany(p => p.Applications)
                .UsingEntity<Dictionary<string, object>>(
                    "Commentapplication",
                    r => r.HasOne<Comment>().WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("commentapplication_ibfk_2"),
                    l => l.HasOne<Application>().WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("commentapplication_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ApplicationId", "CommentId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("commentapplication");
                        j.HasIndex(new[] { "CommentId" }, "comment_id");
                        j.IndexerProperty<int>("ApplicationId").HasColumnName("application_id");
                        j.IndexerProperty<int>("CommentId").HasColumnName("comment_id");
                    });

            entity.HasMany(d => d.Materials).WithMany(p => p.Applications)
                .UsingEntity<Dictionary<string, object>>(
                    "Applicationmaterial",
                    r => r.HasOne<Material>().WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("applicationmaterial_ibfk_2"),
                    l => l.HasOne<Application>().WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("applicationmaterial_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ApplicationId", "MaterialId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("applicationmaterial");
                        j.HasIndex(new[] { "MaterialId" }, "material_id");
                        j.IndexerProperty<int>("ApplicationId").HasColumnName("application_id");
                        j.IndexerProperty<int>("MaterialId").HasColumnName("material_id");
                    });
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(80)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(80)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(80)
                .HasColumnName("phone");
            entity.Property(e => e.SecondName)
                .HasMaxLength(80)
                .HasColumnName("second_name");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("comments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommentText)
                .HasColumnType("text")
                .HasColumnName("comment_text");
        });

        modelBuilder.Entity<Devicetype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("devicetype");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.PositionId, "position_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(80)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(80)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(80)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(80)
                .HasColumnName("password");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.SecondName)
                .HasMaxLength(80)
                .HasColumnName("second_name");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_ibfk_1");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("material");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("positions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
