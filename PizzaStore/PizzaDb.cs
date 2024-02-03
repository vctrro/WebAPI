using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Model;

namespace PizzaStore.DB
{
    public class PizzaDb : DbContext
    {
        public PizzaDb(DbContextOptions options) : base(options) {}
        public DbSet<Pizza>? Pizzas { get; set; } = null;
    }
}