using Microsoft.EntityFrameworkCore;
using CookBook.Models;
using System.Reflection.Metadata;

namespace CookBook.Data
{
    public class CookBookContext : DbContext
    {
        public CookBookContext(DbContextOptions<CookBookContext> options) : base(options)
        {
           
        }

         public DbSet<User> Users {get; set;}
    }
}