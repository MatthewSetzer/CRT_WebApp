using CRT_WebApp.Server.Services.UserService;
using CRT_WebApp.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CRT_WebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //---------------------------------------------------------------------------------------------------------//
        private readonly IUserService _userService;

        public struct UserRole
        {
            public string UserID { get; set; }
            public string RoleID { get; set; }
            public UserRole(string userID, string roleID)
            {
                UserID = userID;
                RoleID = roleID;
            }
        }
        //---------------------------------------------------------------------------------------------------------//
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //---------------------------------------------------------------------------------------------------------//
        [Authorize(Roles= "Admin")]
        [HttpPost("AddRole")]
        public async Task<ActionResult<RegistrationResponseDto>> AddRoleToUser(UserRole userRole)
        {
            //Console.WriteLine("CONTROLLER ADD ROLE TO USER"+Environment.NewLine+"userID: "+userRole.UserID+Environment.NewLine+"roleID: "+userRole.RoleID);
            var result = await _userService.AddRoleToUser(userRole.UserID, userRole.RoleID);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }
            return Ok();
        }
        //---------------------------------------------------------------------------------------------------------//
        [Authorize(Roles="Admin")]
        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<IdentityUser>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            if(users != null)
            {
                return Ok(users);
            }
            else
            {
                return BadRequest();
            }
        }

        //---------------------------------------------------------------------------------------------------------------//

        [Authorize(Roles = "Admin")]
        [HttpPost("AddUser")]
        public async Task AddUser(UserModel user)
        {
            Console.WriteLine("//---------------------------------------------------------------------------------------------------------//");
            Console.WriteLine("Gets called to add a user");
            Console.WriteLine("//---------------------------------------------------------------------------------------------------------//");

            await _userService.RegisterUser(user);       
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("RemoveRole")]

        public async Task<ActionResult<List<IdentityUser>>> RemoveRoleFromUser(string userID, string roleID)
        {
            var result = await _userService.RemoveRoleFromUser(userID, roleID);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }
            return Ok();
        }

        //---------------------------------------------------------------------------------------------------------------//

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteUser")]
        public async Task DeleteUser(string userID)
        {
           //var result = await _userService.DeleteUser(userID);
        }
    }


}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
