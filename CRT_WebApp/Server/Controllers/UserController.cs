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
        public struct DeleteID
        {
            public string UserID { get; set; }
            public DeleteID(string userID)
            {
                UserID = userID;
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
        [HttpDelete("RemoveRole/{UserID}")]

        public async Task<ActionResult<List<IdentityUser>>> RemoveRoleFromUser(string UserID)
        {
            Console.WriteLine("TO DELETE: "+UserID+" : "+"admin");
            var result = await _userService.RemoveRoleFromUser(UserID);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }
            return Ok();
        }

        //---------------------------------------------------------------------------------------------------------------//

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteUser/{UserID}")]
        public async Task DeleteUserAccount(string UserID)
        { 
            await _userService.DeleteUser(UserID);
        }
    }


}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
