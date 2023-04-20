using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Domain.Model;
using Azure.Core;
using Azure.Identity;

namespace School_Ifrastructure.Data
{
    public class SchooldbContext : DbContext
    {
        public SchooldbContext(DbContextOptions<SchooldbContext> options): base(options)
        {
            var tokenRequestContext = new TokenRequestContext(new[] { "https://database.windows.net/" });
            var accessToken = (new DefaultAzureCredential()).GetToken(tokenRequestContext);
            var conn = (Microsoft.Data.SqlClient.SqlConnection)this.Database.GetDbConnection();
            conn.AccessToken = accessToken.Token;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.School)
                .WithMany(s => s.Teacher)
                .HasForeignKey(t => t.School_id)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Department)
                .WithMany(s => s.Teacher)
                .HasForeignKey(t => t.Dep_id)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Student>()
                .HasOne(t => t.School)
                .WithMany(s => s.Student)
                .HasForeignKey(t => t.School_id)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Student>()
                .HasOne(t => t.Department)
                .WithMany(s => s.Student)
                .HasForeignKey(t => t.Dep_id)
                .OnDelete(DeleteBehavior.SetNull);

        }
        public DbSet<Schools> schools { get; set; }  
        public DbSet<Department> department { get; set; }   
        public DbSet<Student> student { get; set; } 
        public DbSet<Teacher> teacher { get; set; }

    }
}
