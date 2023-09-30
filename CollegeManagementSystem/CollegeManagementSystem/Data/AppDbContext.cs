using College_Management_System.Data;
using College_Management_System.Models;
using CollegeManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace College_Management_System.Data
{
    public class AppDbContext : IdentityDbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
		
		}
        
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Schedules> schedules { get; set; }
        public DbSet<Student> students { get; set; }
		public DbSet<StudentCourses> StudentCourses { get; set; }
		public DbSet<ApplicaionUser> ApplicaionUsers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<StudentCourses>()
				.HasKey(sc => new { sc.studentId, sc.courseId });

			modelBuilder.Entity<StudentCourses>()
				.HasOne(sc => sc.student)
				.WithMany(s => s.studentCourses)
				.HasForeignKey(sc => sc.studentId);

			modelBuilder.Entity<StudentCourses>()
				.HasOne(sc => sc.course)
				.WithMany(c => c.studentCourses)
				.HasForeignKey(sc => sc.courseId);
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
			{
				entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
			});

		}

	}
}
