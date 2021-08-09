using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StaffManagement.Models
{

    public class StaffContext : DbContext
    {
        private readonly IConfiguration _config;
        public StaffContext(DbContextOptions<StaffContext> options, IConfiguration config) : base(options)
        {
            this._config = config;

        }
        public DbSet<Staff> customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }

    }
}