using AssessmentMaqta_DataAccess.Application;
using AssessmentMaqta_DataAccess.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssessmentMaqta_DataAccess.Context
{
    public class AssessmentContext:IdentityDbContext<ApplicationUser>
    {
        public AssessmentContext(DbContextOptions<AssessmentContext> options) : base(options)
        {

        }
        public DbSet<Country> countries { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<JobTitle> jobTitles { get; set; }
        public DbSet<Employee> employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(new Country { Id=1, Name = "United Arab Emirates" });
            builder.Entity<Department>().HasData(new Department { Id = 1, Name = "HR" });
            builder.Entity<JobTitle>().HasData(new JobTitle { Id = 1, Name = "Developer" });
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = "1", Name = "Administrator",UserName="Admin",PasswordHash= "AQAAAAEAACcQAAAAELcKoqMvhRmmRgPCezVpmR+4PtG5k60V7oc8hjq6EHIoLmJzNFmhbk7vHd8vW0j63g==",Email="admin@admin.com",AccessFailedCount=0,LockoutEnabled=false,PhoneNumberConfirmed=false,NormalizedUserName="ADMIN" });
            base.OnModelCreating(builder);
        }
    }
}
