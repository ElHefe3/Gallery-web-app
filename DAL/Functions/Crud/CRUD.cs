using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Functions.Interfaces;

namespace DAL.Functions.Crud
{
    public class CRUD : ICRUD
    {
        public async Task<T> Create<T>(T dbObject) where T : class
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    await context.AddAsync<T>(dbObject);
                    await context.SaveChangesAsync();
                    return dbObject;
                }
            }
            catch
            {
                throw;
            }
        }

        public Task<bool> Delete<T>(long entityId) where T : class
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    T recordToDelete = await context.FindAsync<T>(entityId);
                    if (recordToDelete != null)
                    {
                        context.Remove(recordToDelete);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public Task<T> Read<T>(long entityId) where T : class
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    T result = await context.FindAsync<T>(entityId);
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public Task<List<T>> ReadAll<T>() where T : class
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.Set<T>().ToListAsync();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public Task<T> Update<T>(T objectToUpdate, long entityId) where T : class
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var objectFound = await context.FindAsync<T>(entityId);
                    if (objectFound != null)
                    {
                        context.Entry(objectFound).CurrentValues.SetValues(objectToUpdate);
                        await context.SaveChangesAsync();
                    }
                    return objectFound;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
