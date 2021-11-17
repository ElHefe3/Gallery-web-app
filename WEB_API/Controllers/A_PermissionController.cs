using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.A_Permission;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class A_PermissionController : ControllerBase
    {
        private IA_Permission_Service _a_permission_Service;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public A_PermissionController(IA_Permission_Service a_permission_Service)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _a_permission_Service = a_permission_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddA_Permission(A_Permission_Pass_Object a_permission)
        {
            var result = await _a_permission_Service.AddSingleA_Permission(a_permission.album_id, a_permission.user_id, a_permission.a_permission_type);
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
        public async Task<IActionResult> GetAllA_Permissions()
        {
            var result = await _a_permission_Service.GetAllA_Permissions();
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
        public async Task<IActionResult> UpdateA_Permission(A_PermissionUpdate_Pass_Object a_permission)
        {
            var result = await _a_permission_Service.UpdateA_Permission(a_permission.a_permission_id, a_permission.album_id, a_permission.user_id, a_permission.a_permission_type);
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
