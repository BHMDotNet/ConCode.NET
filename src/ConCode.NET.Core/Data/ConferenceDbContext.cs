using ConCode.NET.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeConf.NET.Core.Data
{
    public class ConferenceDbContext : DbContext
    {
        public ConferenceDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=localConCodeNET;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FacebookProfile).HasColumnName("FacebookUri");
                entity.Property(e => e.LinkedInProfile).HasColumnName("LinkedInUri");
                entity.Property(e => e.Photo).HasColumnName("PhotoUri");
                entity.HasOne(e => e.SpeakerInfo).WithOne(e => e.User).HasForeignKey<SpeakerInfo>(e => e.UserId);
                entity.HasOne(e => e.AttendeeInfo).WithOne(e => e.User).HasForeignKey<AttendeeInfo>(e => e.UserId);
            });
            modelBuilder.Entity<SpeakerInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Ignore(e => e.Talks);
                entity.Property(e => e.Tagline).HasColumnName("Tagline");
            });
            modelBuilder.Entity<AttendeeInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<User>())
            {
                var entity = entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.ModifiedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
        
        public DbSet<User> Users { get; set; }
    }
}
