using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                Settings = new AppConfiguration();
                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
                DatabaseOptions = OptionsBuilder.Options;
            }

            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }
            private AppConfiguration Settings { get; set; }
        }

        public static OptionsBuild Options = new OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<I_Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }

        //todo:mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

    
}
