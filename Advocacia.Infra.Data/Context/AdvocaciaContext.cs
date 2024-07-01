using Microsoft.EntityFrameworkCore;
using Advocacia.Domain.Entities;
using Advocacia.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Advocacia.Infra.Data.Context
{
    public class AdvocaciaContext : DbContext
    {
        public AdvocaciaContext()
        {

        }

        public AdvocaciaContext(DbContextOptions<AdvocaciaContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=DbAdvocacia;Integrated Security=true;encrypt=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>(new ClienteConfig().Configure);
            
        }
    }
}
