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

        Task<Generic_ResultSet<I_Permission_ResultSet>> AddSingleI_Permission(int image_id, int user_id, string i_permission_type);

        Task<Generic_ResultSet<List<I_Permission_ResultSet>>> GetAllI_Permissions();

        Task<Generic_ResultSet<I_Permission_ResultSet>> UpdateI_Permission(int i_permission_id, int image_id, int user_id, string i_permission_type);
    }
}
