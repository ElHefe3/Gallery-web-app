using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Image;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IImage_Service _image_Service;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ImageController(IImage_Service image_Service)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _image_Service = image_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddImage(Image_Pass_Object image)
        {                                                                                             //////////////note the date to string
            var result = await _image_Service.AddSingleImage(image.album_id, image.image_capture_date.ToString(), image.image_captured_by, image.image_tags, image.geolocation);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

           [HttpGet]
           [Route("[action]")]
           public async Task<IActionResult> GetAllImages()
           {
               var result = await _image_Service.GetAllImages();
               switch (result.success)
               {
                   case true:
                       return Ok(result);
        
                   case false:
                      return StatusCode(500, result);
               }
           }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateImage(ImageUpdate_Pass_Object image)
        {
            var result = await _image_Service.UpdateImage(image.image_id, image.album_id, image.image_capture_date.ToString(), image.image_captured_by, image.image_tags, image.geolocation);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
    }
}
