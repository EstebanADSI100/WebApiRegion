using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class WebApiRegionDbContext : DbContext
    {
        public WebApiRegionDbContext(DbContextOptions<WebApiRegionDbContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
    }
}
