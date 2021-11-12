using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Album;

namespace LOGIC.Services.Interfaces
{
    public interface IAlbum_Service
    {
        Task<Generic_ResultSet<Album_ResultSet>> AddSingleAlbum(int i_permission_id, int image_id, int user_id, string i_permission_type);

        Task<Generic_ResultSet<List<Album_ResultSet>>> GetAllAlbums();

        Task<Generic_ResultSet<Album_ResultSet>> UpdateAlbum(int i_permission_id, int image_id, int user_id, string i_permission_type);
    }
}
