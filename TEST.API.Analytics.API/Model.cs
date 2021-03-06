﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using TEST.API.Analytics.API.DO;

namespace TEST.API.Analytics.API
{
    public class Model : DbContext
    {
        public Model(DbContextOptions<Model> options) : base(options)
        {
        }

        public DbSet<EnrollmentDO> Enrollments { get; set; }
        public DbSet<StudentDO> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnrollmentDO>().ToTable("Enrollment");
            modelBuilder.Entity<StudentDO>().ToTable("Student");

            modelBuilder.Entity<EnrollmentDO>()
                .HasOne(s => s.Student)
                .WithMany(e => e.Enrollments)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
