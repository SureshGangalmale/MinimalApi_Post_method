using System.Data;
using Microsoft.EntityFrameworkCore;
using MinimalApiDemo.Models;
using MySql.Data.MySqlClient;

namespace MinimalApiDemo.Data
{
    public class MySqlDbContext:DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options):base (options)
        {
            
        }
        public DbSet<Student> students { get; set; }
    }
}
