using FitFalMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FitFalMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {

     


        public DbSet<Product> Products  { get; set; }
        public DbSet<DayOfEating> DayOfEatings { get; set; }
        public DbSet<Meal> Meals { get; set; }




        public Context(DbContextOptions<Context> options) : base(options)
        {            
        }

  

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }

    }
}
