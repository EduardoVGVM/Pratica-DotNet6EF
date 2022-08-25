using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet6WebAPICrud.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet6WebAPICrud.Data
{
    public class MyWorldDbContext : DbContext
    {
        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
        {

        }

        public DbSet<Cake> Cake {get; set; }
    }
}