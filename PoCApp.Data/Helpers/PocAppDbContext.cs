using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PoCApp.Business.Entities;
using PoCApp.Data.Mapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCApp.Data.Helpers
{
   public class PocAppDbContext:DbContext
    {

        private string DbConnStr { get; set; }
        public PocAppDbContext()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            DbConnStr = root.GetConnectionString("PocDBConn");
        }

        public PocAppDbContext(DbContextOptions<PocAppDbContext> options)
         : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DbConnStr);

        }


        public DbSet<Individual> IndividualSet { get; set; }
        public DbSet<IndividualVW> IndividualVWSet { get; set; }
        public DbSet<Education> EducationSet { get; set; }
        public DbSet<Country> CountrySet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new IndividualConfiguration());
            modelBuilder.ApplyConfiguration(new IndividualVWConfiguration());

            modelBuilder.ApplyConfiguration(new EducationConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());

        }


    }
}
