using Microsoft.EntityFrameworkCore;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Data
{
    public class DBContext : DbContext
    {
        public DbSet<City> city { get; set; }
        public DbSet<Client> client { get; set; }
        public DbSet<User> user { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "Server=db4free.net; User ID=serempre_admin; Password=admin123456**!; Database=serempre_test_db";

            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version("8.1")));
        }
    }
}
