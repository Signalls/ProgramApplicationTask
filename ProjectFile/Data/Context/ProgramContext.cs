using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{


    public class ProgramContext : DbContext
    {
        public DbSet<ProgramDetails> ProgramDetails { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public ProgramContext(DbContextOptions<ProgramContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProgramDetails>()
               .ToContainer("ProgramDetails")
               .HasPartitionKey(e => e.Id)
               .HasKey(e => e.Id);


            modelBuilder.Entity<PersonalInfo>()
                .ToContainer("PersonalInfo")
                .HasPartitionKey(e => e.Id)
                .HasKey(e => e.Id);
        }

    }
}
