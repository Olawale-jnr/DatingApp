using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataContext : DbContext
    {
        //ctrl + . on Datacontext to generate constructor
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        //Generates a table called Users, Can be anything of choice
        public DbSet<AppUser> Users { get; set; }
    }
}
