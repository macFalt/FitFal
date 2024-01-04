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
        public DbSet<BodyPart> BodyParts { get; set; }
        public DbSet<DayOfEating> DayOfEatings { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Meal_Product> Meal_Products { get; set; }
        public DbSet<NutritionalValues> NutritionalValues { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Training_Exercise> Training_Exercises { get; set; }

        public DbSet<Domain.Model.Type> Types { get; set; }


        public Context(DbContextOptions options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .HasOne(a => a.NutritionalValues).WithOne(b => b.Product)
                .HasForeignKey<NutritionalValues>(e => e.Id_Product);


            builder.Entity<Meal_Product>()
                .HasOne(mp=>mp.Meal)
                .WithMany(m=>m.Meal_Products)
                .HasForeignKey(mp=>mp.Id_Meal);

            builder.Entity<Meal_Product>()
                .HasOne(mp => mp.Product)
                .WithMany(m => m.Meal_Products)
                .HasForeignKey(mp => mp.Id_Product);

            builder.Entity<DayOfEating>()
                .HasMany(m => m.Meals)
                .WithOne(d => d.DayOfEating)
                .HasForeignKey(m => m.Id_DayOfEating);




    








            //Jeden do jeden
            //builder.Entity<Customer>()
            //    .HasOne(a=> a.CustomerContactInformation).WithOne(b=>b.Customer) // jeden CustomerContactInformation bedzie mial powiazanie z jednym Customerem
            //    .HasForeignKey<CustomerContactInformation>(e=?equals.CustomerRef) //CustomerContactInformation posiada klucz obcy w piostaci CutomerRef

            //Wiele do wielu
            //Musimy stworzyc tabele posredniczaca
            //builder.Entity<ItemTag>()
            //     .HasKey(it => new {it.ItemId, it.TagId});
            //
            //builder.Entity<ItemTag>()
            //      .HasOne<Item>(it =>it.Item)
            //      .WithMany(i=> i.ItemTags)
            //      .HasForeignKay(it =>it.ItemId);
            //builder.Entity<ItemTag>()
            //      .HasOne<Tag>(it =>it.Tag)
            //      .WithMany(i=> i.ItemTags)
            //      .HasForeignKay(it =>it.TagId);


        }

    }
}
