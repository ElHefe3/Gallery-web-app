using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Image;

namespace LOGIC.Services.Interfaces
{
    public interface IIamge_Service
    {

        Task<Generic_ResultSet<Image_ResultSet>> AddSingleImage(int user_id, string user_name, string user_surname, string user_email, string user_nickname, string password_hash, ICollection<I_Permission> i_permissions, ICollection<A_Permission> a_permissions); //double check i collection type

        Task<Generic_ResultSet<List<Image_ResultSet>>> GetAllUsers();

        Task<Generic_ResultSet<Image_ResultSet>> UpdateImage(int user_id, string user_name, string user_surname, string user_email, string user_nickname, string password_hash, ICollection<I_Permission> i_permissions, ICollection<A_Permission> a_permissions) //double check i collection type;
    }
}
