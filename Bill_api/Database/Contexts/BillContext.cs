using Bill_api.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_api.Database.Contexts
{
    public class BillContext:DbContext
    {
        public DbSet<Bill>? Bills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = localhost:5432; Database = my_db; Username = postgres; Password = pass");
        }
    }
}
