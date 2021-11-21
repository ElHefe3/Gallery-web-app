using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface ICRUD
    {
        Task<T> Create<T>(T dbObject) where T : class;
        Task<T> Read<T>(Int64 entityId) where T : class;
        Task<List<T>> ReadAll<T>() where T : class;
        Task<T> Update<T>(T objectToUpdate, Int64 entityId) where T : class;
        Task<bool> Delete<T>(Int64 entityId) where T : class;

        Task<List<T>> LoginUser<T>(String user_nickname, String password_hash) where T : class;

        Task<List<T>> IPermissionByUserID<T>(Int64 userID) where T : class;

        Task<List<T>> APermissionByUserID<T>(Int64 userID) where T : class;
    }
}
