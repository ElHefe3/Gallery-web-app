using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            AppConfiguration Settings = new AppConfiguration();
            DbContextOptionsBuilder<DatabaseContext> OptionsBUilder = new DbContextOptionsBuilder<DatabaseContext>();
            OptionsBUilder.UseSqlServer(Settings.SqlConnectionString);
            return new DatabaseContext(OptionsBUilder.Options);
        }
    }
}
