using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backup.Models
{
    public partial class Scada_InoueContext : DbContext
    {
        public Scada_InoueContext()
        {
        }

        public Scada_InoueContext(DbContextOptions<Scada_InoueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountRight> AccountRights { get; set; } = null!;
        public virtual DbSet<Audit> Audits { get; set; } = null!;
        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<Calib> Calibs { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CustomModule> CustomModules { get; set; } = null!;
        public virtual DbSet<CustomStringStorage> CustomStringStorages { get; set; } = null!;
        public virtual DbSet<DatabaseVar> DatabaseVars { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Function> Functions { get; set; } = null!;
        public virtual DbSet<Jschema> Jschemas { get; set; } = null!;
        public virtual DbSet<Messenger> Messengers { get; set; } = null!;
        public virtual DbSet<Mold> Molds { get; set; } = null!;
        public virtual DbSet<Ovens> Ovens { get; set; } = null!;
        public virtual DbSet<OvenSetting> OvenSettings { get; set; } = null!;
        public virtual DbSet<ProductDef> ProductDefs { get; set; } = null!;
        public virtual DbSet<SdataHistory> SdataHistories { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<Shiftwork> Shiftworks { get; set; } = null!;
        public virtual DbSet<Sjschema> Sjschemas { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TaskHistory> TaskHistories { get; set; } = null!;
        public virtual DbSet<Thistory> Thistories { get; set; } = null!;
        public virtual DbSet<Trigger> Triggers { get; set; } = null!;
        public virtual DbSet<Ttrend> Ttrends { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<ViewAccount> ViewAccounts { get; set; } = null!;
        public virtual DbSet<ViewAccountRight> ViewAccountRights { get; set; } = null!;
        public virtual DbSet<ViewBranch> ViewBranches { get; set; } = null!;
        public virtual DbSet<ViewCategory> ViewCategories { get; set; } = null!;
        public virtual DbSet<ViewDepartment> ViewDepartments { get; set; } = null!;
        public virtual DbSet<ViewSection> ViewSections { get; set; } = null!;
        public virtual DbSet<ViewUser> ViewUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=14.248.94.171\\SQL2022DEV,59322;Database=Scada_Inoue;User Id=inoue;Password=Daco@2016;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Accounts_User");
            });

            modelBuilder.Entity<AccountRight>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.FunctionId });

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountRights)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountRights_Account");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.AccountRights)
                    .HasForeignKey(d => d.FunctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountRights_Function");
            });

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.Property(e => e.AckBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Message).HasMaxLength(2000);

                entity.Property(e => e.Property).HasMaxLength(50);

                entity.Property(e => e.SchemaNo).HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UnitNo).HasMaxLength(50);
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Calib>(entity =>
            {
                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Oven)
                    .WithMany(p => p.Calibs)
                    .HasForeignKey(d => d.OvenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calibs_Oven");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Categories_Category");
            });

            modelBuilder.Entity<CustomModule>(entity =>
            {
                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DllName).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.ProgId).HasMaxLength(256);
            });

            modelBuilder.Entity<CustomStringStorage>(entity =>
            {
                entity.Property(e => e.Key).HasMaxLength(256);

                entity.Property(e => e.Value).HasMaxLength(2000);
            });

            modelBuilder.Entity<DatabaseVar>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Part).HasDefaultValueSql("((20))");

                entity.Property(e => e.Planning).HasDefaultValueSql("((100))");

                entity.Property(e => e.SchemaVer).HasDefaultValueSql("((100))");

                entity.Property(e => e.SwDuration)
                    .HasColumnName("SW_Duration")
                    .HasDefaultValueSql("((8))");

                entity.Property(e => e.SwLength)
                    .HasColumnName("SW_Length")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.SwStartTime)
                    .HasColumnName("SW_StartTime")
                    .HasDefaultValueSql("('06:00:00')");

                entity.Property(e => e.TimeZone).HasDefaultValueSql("((7))");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fvalue).HasColumnName("FValue");

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jschema>(entity =>
            {
                entity.ToTable("JSchemas");

                entity.Property(e => e.Alarm).HasMaxLength(4000);

                entity.Property(e => e.Data).HasMaxLength(4000);

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.SchemaNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Messenger>(entity =>
            {
                entity.Property(e => e.AccessToken).HasMaxLength(500);

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Jdata)
                    .HasMaxLength(4000)
                    .HasColumnName("JData");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.ReservedTagNames).HasMaxLength(256);

                entity.Property(e => e.TagNames).HasMaxLength(256);
            });

            modelBuilder.Entity<Mold>(entity =>
            {
                entity.HasIndex(e => e.MoldNo, "IX_Molds")
                    .IsUnique();

                entity.Property(e => e.Cavity).HasDefaultValueSql("((1))");

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MoldNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.VersionId).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Ovens>(entity =>
            {
                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.SortId).HasColumnName("SortID");

                entity.Property(e => e.UnitNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Ovens)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_Ovens_Section");
            });

            modelBuilder.Entity<OvenSetting>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ProductDef>(entity =>
            {
                entity.HasIndex(e => e.Code, "IX_ProductDefs")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductDefs)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ProductDefs_Category");
            });

            modelBuilder.Entity<SdataHistory>(entity =>
            {
                entity.ToTable("SDataHistory");

                entity.Property(e => e.Data)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Oven)
                    .WithMany(p => p.SdataHistories)
                    .HasForeignKey(d => d.OvenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SDataHistory_Oven");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SectionNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.AccessToken)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RefreshToken)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sessions_Account");
            });

            modelBuilder.Entity<Shiftwork>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateAdded)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<Sjschema>(entity =>
            {
                entity.ToTable("SJSchemas");

                entity.Property(e => e.Alarm).HasMaxLength(4000);

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.JschemaId).HasColumnName("JSchemaId");

                entity.HasOne(d => d.Jschema)
                    .WithMany(p => p.Sjschemas)
                    .HasForeignKey(d => d.JschemaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SJSchemas_JSchema");

                entity.HasOne(d => d.Oven)
                    .WithMany(p => p.Sjschemas)
                    .HasForeignKey(d => d.OvenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SJSchemas_Oven");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.Author).HasMaxLength(256);

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Status).HasDefaultValueSql("((2))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Tasks_User");
            });

            modelBuilder.Entity<TaskHistory>(entity =>
            {
                entity.ToTable("TaskHistory");

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Key).HasMaxLength(450);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskHistories)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_TaskHistory_Task");
            });

            modelBuilder.Entity<Thistory>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("THistory");

                entity.HasIndex(e => e.Time, "IX_THistory_Time");

                entity.HasOne(d => d.Oven)
                    .WithMany(p => p.Thistories)
                    .HasForeignKey(d => d.OvenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THistory_Oven");
            });

            modelBuilder.Entity<Trigger>(entity =>
            {
                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Triggers)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_Triggers_Task");
            });

            modelBuilder.Entity<Ttrend>(entity =>
            {
                entity.ToTable("TTrends");

                entity.HasIndex(e => e.OvenId, "IX_Trends_Oven");

                entity.HasOne(d => d.Oven)
                    .WithMany(p => p.Ttrends)
                    .HasForeignKey(d => d.OvenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTrends_Oven");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Users_Department");
            });

            modelBuilder.Entity<ViewAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Accounts");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewAccountRight>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_AccountRights");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fvalue).HasColumnName("FValue");

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewBranch>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Branches");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Categories");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewDepartment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Departments");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewSection>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Sections");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SectionNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Users");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
