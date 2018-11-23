using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class DataContext: DbContext
    {
        public DataContext (DbContextOptions<DataContext> options): base(options)
        {

        }

        public DataContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresExtension("postgis");
        }

        public DbSet<Mtc> Mtcs { get; set; }

        public DbSet<MtcActivity> MtcActivitys { get; set; }

        public DbSet<MtcHomezone> MtcHomezones { get; set; }

        public DbSet<Days> Dayss { get; set; }


    }
}
