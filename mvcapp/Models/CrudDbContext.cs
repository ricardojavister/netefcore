using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvcapp.Models;

namespace mvcapp.Models
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options)
        {

        }
        public DbSet<product> product {get; set;}
        public DbSet<mvcapp.Models.productExternal> productExternal { get; set; }
    }
}
