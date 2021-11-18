using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC.Services.Models;
using LOGIC.Services.Models.I_Permission;

namespace LOGIC.Services.Interfaces
{
    public interface II_Permission_Service
    {

        Task<Generic_ResultSet<I_Permission_ResultSet>> AddSingleI_Permission(Int64 image_id, Int64 user_id, string i_permission_type);

        Task<Generic_ResultSet<List<I_Permission_ResultSet>>> GetAllI_Permissions();

        Task<Generic_ResultSet<I_Permission_ResultSet>> UpdateI_Permission(Int64 i_permission_id, Int64 image_id, Int64 user_id, string i_permission_type);

        Task<Generic_ResultSet<List<I_Permission_ResultSet>>> IPermissionByUserID(Int64 user_id);

    }
}
