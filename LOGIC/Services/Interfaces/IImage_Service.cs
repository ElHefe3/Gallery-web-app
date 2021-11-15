using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Image;

namespace LOGIC.Services.Interfaces
{
    public interface IImage_Service
    {

        Task<Generic_ResultSet<Image_ResultSet>> AddSingleImage(int image_id, int album_id, string image_captured_date, string image_captured_by, string image_tags, string geolocation); 

        Task<Generic_ResultSet<List<Image_ResultSet>>> GetAllImages();

        Task<Generic_ResultSet<Image_ResultSet>> UpdateImage(int image_id, int album_id, string image_captured_date, string image_captured_by, string image_tags, string geolocation);
    }
}
