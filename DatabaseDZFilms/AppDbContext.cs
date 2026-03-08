using DatabaseDZFilms.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;

namespace DatabaseDZFilms
{
    public class AppDbContext : DbContext
    {
        //private readonly string _connectionString = "Data Source=EfCore.db";
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EfCore;";

        // Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlite(_connectionString);
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<StudentGroup>().ToView("vw_StudentsGroups").HasNoKey();

            //modelBuilder.Entity<Student>().Property(s => s.Scholarship).HasColumnType("money");
            //modelBuilder.Entity<Teacher>(b =>
            //{
            //    b.Property(t => t.Salary)
            //        .HasColumnType("money")
            //        .HasDefaultValue(25_000);
            //    b.ToTable(t => t.HasCheckConstraint("CK_Salary_MoreThenZero", "[Salary] > 0"));
            //});

            modelBuilder.Entity<User>(b =>
            {
                b.HasIndex(s => s.email).IsUnique();
                b.ToTable(s => s.HasCheckConstraint("CK_email_Pattern", "[email] LIKE '%_@%_.%_'"));
                b.HasIndex(s => s.username).IsUnique();
                b.ToTable(s => s.HasCheckConstraint("CK_username_Pattern", "[username] <> ''"));
            });
            modelBuilder.Entity<Film>(b =>
            {
                b.ToTable(s => s.HasCheckConstraint("CK_username_Pattern", "[year] > 0 ''"));
            });

            modelBuilder.Entity<Film>(b =>
            {
                b.Property(f => f.Title).HasMaxLength(50);
                b.Property(f => f.Description).IsRequired(false);
                b.Property(f => f.DateAdded).HasDefaultValueSql("GETDATE()");
                b.HasCheckConstraint("CK_Film_name_NotEmpty", "[name] <> ''");
                b.HasCheckConstraint("CK_Film_year_Positive", "[year] > 0");
                b.HasOne(f => f.User).WithMany(u => u.Films).HasForeignKey(f => f.UserId);
            });

            //modelBuilder.Entity<Group>(g =>
            //{
            //    g.HasIndex(nameof(Group.Name)).IsUnique();
            //});
        }
    }
}