using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.I_Permission;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class I_PermissionController : ControllerBase
    {
        private II_Permission_Service _i_permission_Service;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public I_PermissionController(II_Permission_Service i_permission_Service)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _i_permission_Service = i_permission_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddI_Permission(I_Permission_Pass_Object i_permission)
        {
            var result = await _i_permission_Service.AddSingleI_Permission(i_permission.image_id, i_permission.user_id, i_permission.i_permission_type);
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
        public async Task<IActionResult> GetAllI_Permissions()
        {
            var result = await _i_permission_Service.GetAllI_Permissions();
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
        public async Task<IActionResult> UpdateI_Permission(I_PermissionUpdate_Pass_Object i_permission)
        {
            var result = await _i_permission_Service.UpdateI_Permission(i_permission.i_permission_id, i_permission.image_id, i_permission.user_id, i_permission.i_permission_type);
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
        public async Task<IActionResult> NewIPermissionByUserID(int user_id)
        {
            var result = await _i_permission_Service.IPermissionByUserID(user_id);
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
