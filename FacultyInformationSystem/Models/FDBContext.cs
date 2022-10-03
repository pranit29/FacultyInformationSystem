using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FacultyInformationSystem.Models
{
    public partial class FDBContext : DbContext
    {
        public FDBContext()
        {
        }

        public FDBContext(DbContextOptions<FDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseSubject> CourseSubjects { get; set; }
        public virtual DbSet<CoursesTaught> CoursesTaughts { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Grant> Grants { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkHistory> WorkHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PRANIT;Database=FDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("CourseID");

                entity.Property(e => e.CourseCredits)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.DeptId).HasColumnName("DeptID");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Courses_Courses");
            });

            modelBuilder.Entity<CourseSubject>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CourseSubject");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseSubject_Courses");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseSubject_Subjects");
            });

            modelBuilder.Entity<CoursesTaught>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CoursesTaught");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.FacultyId).HasColumnName("FacultyID");

                entity.Property(e => e.FirstDateTaught)
                    .HasColumnType("date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoursesTaught_Courses");

                entity.HasOne(d => d.Faculty)
                    .WithMany()
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoursesTaught_Faculty");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoursesTaught_Subjects");
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.Property(e => e.DegreeId)
                    .ValueGeneratedNever()
                    .HasColumnName("DegreeID");

                entity.Property(e => e.Degree1)
                    .HasMaxLength(20)
                    .HasColumnName("Degree");

                entity.Property(e => e.FacultyId).HasColumnName("FacultyID");

                entity.Property(e => e.Grade)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Specialiation).HasMaxLength(20);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Degrees)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Degrees_Degrees");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId);

                entity.ToTable("Department");

                entity.Property(e => e.DeptId)
                    .ValueGeneratedNever()
                    .HasColumnName("DeptID");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("Designation");

                entity.Property(e => e.DesignationId)
                    .ValueGeneratedNever()
                    .HasColumnName("DesignationID");

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("Faculty");

                entity.Property(e => e.FacultyId)
                    .ValueGeneratedNever()
                    .HasColumnName("FacultyID");

                entity.Property(e => e.Address)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeptId).HasColumnName("DeptID");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Faculty_Department");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.DesignationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Faculty_Designation");
            });

            modelBuilder.Entity<Grant>(entity =>
            {
                entity.Property(e => e.GrantId)
                    .ValueGeneratedNever()
                    .HasColumnName("GrantID");

                entity.Property(e => e.FacultyId).HasColumnName("FacultyID");

                entity.Property(e => e.GrantDescription).HasMaxLength(50);

                entity.Property(e => e.GrantTitle).HasMaxLength(50);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Grants)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grants_Faculty");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.Property(e => e.PublicationId)
                    .ValueGeneratedNever()
                    .HasColumnName("PublicationID");

                entity.Property(e => e.ArticleName).HasMaxLength(50);

                entity.Property(e => e.CitationDate)
                    .HasColumnType("date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.FacultyId).HasColumnName("FacultyID");

                entity.Property(e => e.PublicationLocation).HasMaxLength(50);

                entity.Property(e => e.PublicationTiltle).HasMaxLength(50);

                entity.Property(e => e.PublisherName).HasMaxLength(50);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publications_Publications");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("SubjectID");

                entity.Property(e => e.DeptId).HasColumnName("DeptID");

                entity.Property(e => e.SubjectName).HasMaxLength(50);

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subjects_Department");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<WorkHistory>(entity =>
            {
                entity.ToTable("WorkHistory");

                entity.Property(e => e.WorkHistoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("WorkHistoryID");

                entity.Property(e => e.FacultyId).HasColumnName("FacultyID");

                entity.Property(e => e.JobBeginDate)
                    .HasColumnType("date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.JobEndDate)
                    .HasColumnType("date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.JobResponsibilities).HasMaxLength(100);

                entity.Property(e => e.JobTitle).HasMaxLength(50);

                entity.Property(e => e.JobType).HasMaxLength(50);

                entity.Property(e => e.Organisation).HasMaxLength(50);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.WorkHistories)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkHistory_Faculty");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
