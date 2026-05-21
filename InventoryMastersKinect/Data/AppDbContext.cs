using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryMastersKinect.Model;

namespace InventoryMastersKinect.Data
{  
    public class AppDbContext : DbContext
    {
        public DbSet<MedicaoVolume> MedicoesVolume { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=medicoes.db");
        }
    }
}