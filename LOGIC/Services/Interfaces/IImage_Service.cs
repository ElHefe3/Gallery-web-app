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

        Task<Generic_ResultSet<Image_ResultSet>> AddSingleImage(Int64 album_id, DateTime image_captured_date, string image_captured_by, string image_tags, string geolocation); 

        Task<Generic_ResultSet<List<Image_ResultSet>>> GetAllImages();

        Task<Generic_ResultSet<Image_ResultSet>> UpdateImage(Int64 image_id, Int64 album_id, DateTime image_captured_date, string image_captured_by, string image_tags, string geolocation);

        Task<Generic_ResultSet<Image_ResultSet>> DeleteImage(Int64 image_id);

        Task<Generic_ResultSet<Image_ResultSet>> GetImageByID(Int64 image_id);
    }
}
