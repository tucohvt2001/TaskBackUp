using backup.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backup
{
    internal class SQLServerContext : DbContext
    {
        private readonly string _connectionString2;

        public SQLServerContext(string connectionString2)
        {
            _connectionString2 = connectionString2;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString2);
        }
        public DbSet<Ovens> Ovens { get; set; }
        public DbSet<Thistory> Thistory { get; set; }
    }
}
