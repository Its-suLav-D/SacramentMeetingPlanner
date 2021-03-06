using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SacramentMeetingPlanner.Models;
using Microsoft.EntityFrameworkCore;


namespace SacramentMeetingPlanner.Data
{
    public class SacramentContext:DbContext
    {
        public SacramentContext(DbContextOptions<SacramentContext> options) : base(options)
        {
        }

        public DbSet<Sacrament> Sacrament { get; set; }
        public DbSet<Speaker> Speakers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sacrament>().ToTable("Sacrament");
            modelBuilder.Entity<Speaker>().ToTable("Speaker");
      
        }

    }
}
