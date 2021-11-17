using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.User;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser_Service _user_Service;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UserController(IUser_Service user_Service)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _user_Service = user_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddUser(User_Pass_Object user)
        {
            var result = await _user_Service.AddSingleUser(user.user_name, user.user_surname, user.user_email, user.user_nickname, user.password_hash);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        //   [HttpGet]
        //    [Route("[action]")]
        //   public async Task<IActionResult> GetUserById(int id)
        //   {
        //       var result = await _user_Service.GetserById(id);
        //       switch (result.success)
        //       {
        //           case true:
        //               return Ok(result);
        //
        //           case false:
        //              return StatusCode(500, result);
        //       }
        //   }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _user_Service.GetAllUsers();
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
        public async Task<IActionResult> UpdateUser(UserUpdate_Pass_Object user)
        {
            var result = await _user_Service.UpdateUser(user.user_id, user.user_name, user.user_surname, user.user_email, user.user_nickname, user.password_hash);
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
