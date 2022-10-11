using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        //from core.security
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaIoCampDbConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(pl =>
            {
                pl.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                pl.Property(p => p.Id).HasColumnName("Id");
                pl.Property(p => p.Name).HasColumnName("Name");
                pl.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<Technology>(t =>
            {
                t.ToTable("Technologies").HasKey(k => k.Id);
                t.Property(p => p.Id).HasColumnName("Id");
                t.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                t.Property(p => p.Name).HasColumnName("Name");
                t.HasOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<SocialMedia>(sm =>
            {
                sm.ToTable("SocialMedias").HasKey(k => k.Id);
                sm.Property(p => p.Id).HasColumnName("Id");
                sm.Property(p => p.UserId).HasColumnName("UserId");
                sm.Property(p => p.Name).HasColumnName("Name");
                sm.Property(p => p.UrlAddress).HasColumnName("UrlAddress");
                sm.HasOne(p => p.User);
            });

            //data migration
            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java"), new(3, "Python") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            Technology[] technologyEntitySeeds = { new(1, 1, "WPF"), new(2, 1, "ASP.NET"), new(3, 2, "Spring"), new(4, 3, "Pandas") };
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);

            SocialMedia[] socialMediaEntitySeeds = { new (1,"github","www.github.com/user1",1), new(2, "twitter", "www.twitter.com/user1", 1) };
            modelBuilder.Entity<SocialMedia>().HasData(socialMediaEntitySeeds);
        }
    }
}
