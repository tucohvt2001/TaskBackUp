using DemoWithEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backup
{
    internal class SQLiteContext : DbContext
    {
        private readonly string _connectionString;

        public SQLiteContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }
        public DbSet<DataLogger1> DataLogger1 { get; set; }
    }
}
