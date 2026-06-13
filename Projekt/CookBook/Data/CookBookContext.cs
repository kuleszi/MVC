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
         public DbSet<Category> Categories {get; set;}
         public DbSet<Ingredient> Ingredients {get; set;}
         public DbSet<Recipe> Recipes {get; set;}
         public DbSet<Step> Steps {get; set;}
    }
}