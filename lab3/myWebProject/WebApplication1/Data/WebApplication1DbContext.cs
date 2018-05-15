using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1DbContext: DbContext
    {
        public WebApplication1DbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
