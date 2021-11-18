using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC.Services.Models;
using LOGIC.Services.Models.A_Permission;

namespace LOGIC.Services.Interfaces
{
    public interface IA_Permission_Service
    {
        Task<Generic_ResultSet<A_Permission_ResultSet>> AddSingleA_Permission(Int64 album_id, Int64 user_id, string a_permission_type);

        Task<Generic_ResultSet<List<A_Permission_ResultSet>>> GetAllA_Permissions();

        Task<Generic_ResultSet<A_Permission_ResultSet>> UpdateA_Permission(Int64 a_permission_id, Int64 album_id, Int64 user_id, string a_permission_type);
    }
}
