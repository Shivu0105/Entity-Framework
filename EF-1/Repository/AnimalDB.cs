using Microsoft.EntityFrameworkCore;
using EF_1.Models;

namespace EF_1.Repository
{
    public class AnimalDB : DbContext
    {
        public AnimalDB(DbContextOptions<AnimalDB> options) : base(options)
        {

        }

        public DbSet<Animals> AnimalsTable { get; set; }      // all of the data from the table will be stored in this property
    }
}
