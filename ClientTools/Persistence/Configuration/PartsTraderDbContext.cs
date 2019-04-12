using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.ValueObjects;

namespace Persistence.Configuration
{
    public class PartsTraderDBContext : DbContext
    {
        public PartsTraderDBContext(DbContextOptions<PartsTraderDBContext> options)
            : base(options)
        {

        }

        public DbSet<PartSummary> PartSummaries { get; set; }
        //Fake Database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartSummary>().HasData(new PartSummary
            {
                Description = "Description 1",
                PartNumber = PartNumber.For("1234-1234abcd")
            }, new PartSummary
            {
                Description = "Description 2",
                PartNumber = PartNumber.For("1235-abcd")
            }, new PartSummary
            {
                Description = "Description 3",
                PartNumber = PartNumber.For("1236-efgh")
            }
            , new PartSummary
            {
                Description = "Description 4",
                PartNumber = PartNumber.For("1237-1233")
            });
        }
    }
}
