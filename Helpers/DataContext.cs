using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        
        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            //options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase")); //localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
            var conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=vodovod;Integrated Security=False;Trusted_Connection=True;");
            options.UseSqlServer(conn);
            //options.UseSqlServer("server=SQLEXPRESS;database=vodovod;Trusted_Connection=True;");
        }
    }
}