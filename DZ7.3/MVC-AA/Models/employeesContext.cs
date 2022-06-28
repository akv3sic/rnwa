using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MVC_AA.Models
{
    public partial class employeesContext : DbContext
    {
        public employeesContext()
        {
        }

        public employeesContext(DbContextOptions<employeesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CurrentDeptEmp> CurrentDeptEmps { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DeptEmp> DeptEmps { get; set; }
        public virtual DbSet<DeptEmpLatestDate> DeptEmpLatestDates { get; set; }
        public virtual DbSet<DeptManager> DeptManagers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=employees;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CurrentDeptEmp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("current_dept_emp", "employees");

                entity.Property(e => e.DeptNo)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("dept_no")
                    .IsFixedLength(true);

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptNo)
                    .HasName("PK_departments_dept_no");

                entity.ToTable("departments", "employees");

                entity.HasIndex(e => e.DeptName, "departments$dept_name")
                    .IsUnique();

                entity.Property(e => e.DeptNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("dept_no")
                    .IsFixedLength(true);

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("dept_name");
            });

            modelBuilder.Entity<DeptEmp>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.DeptNo })
                    .HasName("PK_dept_emp_emp_no");

                entity.ToTable("dept_emp", "employees");

                entity.HasIndex(e => e.DeptNo, "dept_no");

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.DeptNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("dept_no")
                    .IsFixedLength(true);

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.DeptEmps)
                    .HasForeignKey(d => d.DeptNo)
                    .HasConstraintName("dept_emp$dept_emp_ibfk_2");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.DeptEmps)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("dept_emp$dept_emp_ibfk_1");
            });

            modelBuilder.Entity<DeptEmpLatestDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("dept_emp_latest_date", "employees");

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");
            });

            modelBuilder.Entity<DeptManager>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.DeptNo })
                    .HasName("PK_dept_manager_emp_no");

                entity.ToTable("dept_manager", "employees");

                entity.HasIndex(e => e.DeptNo, "dept_no");

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.DeptNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("dept_no")
                    .IsFixedLength(true);

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.DeptManagers)
                    .HasForeignKey(d => d.DeptNo)
                    .HasConstraintName("dept_manager$dept_manager_ibfk_2");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.DeptManagers)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("dept_manager$dept_manager_ibfk_1");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpNo)
                    .HasName("PK_employees_emp_no");

                entity.ToTable("employees", "employees");

                entity.Property(e => e.EmpNo)
                    .ValueGeneratedNever()
                    .HasColumnName("emp_no");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.FromDate })
                    .HasName("PK_salaries_emp_no");

                entity.ToTable("salaries", "employees");

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date");

                entity.Property(e => e.Salary1).HasColumnName("salary");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("salaries$salaries_ibfk_1");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.Title1, e.FromDate })
                    .HasName("PK_titles_emp_no");

                entity.ToTable("titles", "employees");

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.Title1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("titles$titles_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
