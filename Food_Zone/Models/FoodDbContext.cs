using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Zone.Models;

namespace Food_Zone.Models
{
    public class FoodDbContext : DbContext
    {
        string connectionString;
        public DbSet<famousdish> famousdish { get; set; }

        public FoodDbContext()
        {
            connectionString = "server=.;database=foodzone;integrated security=true;multipleactiveresultsets=true;trustservercertificate=true";
        }

        public FoodDbContext(string path) : base()
        {
            connectionString = path;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<gallery> gallery { get; set; }

        public DbSet<veg> veg { get; set; }

        public DbSet<nonveg> nonveg { get; set; }

        public DbSet<check> check { get; set; }

        public DbSet<Register> Register { get; set; }

        public DbSet<contact> contact { get; set; }

        
    }

}

