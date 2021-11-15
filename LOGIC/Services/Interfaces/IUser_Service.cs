using System;
using LOGIC.Services.Models;
using LOGIC.Services.Models.User;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities; ///////////// manually added

namespace LOGIC.Services.Interfaces
{
    public interface IUser_Service
    {
        Task<Generic_ResultSet<User_ResultSet>> AddSingleUser(int user_id, string user_name, string user_surname, string user_email, string user_nickname, string password_hash, ICollection<I_Permission> i_permissions, ICollection<A_Permission> a_permissions); //double check i collection type

        Task<Generic_ResultSet<List<User_ResultSet>>> GetAllUsers();

        Task<Generic_ResultSet<User_ResultSet>> UpdateUser(int user_id, string user_name, string user_surname, string user_email, string user_nickname, string password_hash, ICollection<I_Permission> i_permissions, ICollection<A_Permission> a_permissions); //double check i collection type;

    }
}
