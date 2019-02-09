using BBBWebApiCodeFirst.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var connectionString = configuration.GetConnectionString("BbbApiConnection");

                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresExtension("postgis");
        }


        public DbSet<Age> Ages { get; set; }

        public DbSet<Day> Days { get; set; }

        public DbSet<Gender> Genders {get; set;}

        public DbSet<Mtc> Mtcs { get; set; }

        public DbSet<MtcActivity> MtcActivitys { get; set; }

        public DbSet<MtcAge> MtcAges { get; set; }

        public DbSet<MtcGender> MtcGenders { get; set; }

        public DbSet<MtcHomezone> MtcHomezones { get; set; }       

    }
}
