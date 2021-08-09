using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FloraTransAPI.Models;

namespace FloraTransAPI.Data
{
    public class FloraTransAPIContext : DbContext
    {
        public FloraTransAPIContext (DbContextOptions<FloraTransAPIContext> options)
            : base(options)
        {
        }

        public DbSet<FloraTransAPI.Models.Container> Container { get; set; }

        public DbSet<FloraTransAPI.Models.Contact> Contact { get; set; }

        public DbSet<FloraTransAPI.Models.Client> Client { get; set; }

        public DbSet<FloraTransAPI.Models.Warehouse> Warehouse { get; set; }

    }
}
