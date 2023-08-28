using BackUpOven.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpOven
{
    internal class SQLServerContext : DbContext
    {
        private readonly string _connectionString;

        public SQLServerContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        public DbSet<Ovens> Ovens { get; set; }
        public DbSet<Thistory> Thistory { get; set; }
    }
}
