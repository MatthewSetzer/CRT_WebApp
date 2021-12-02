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
        private JSRuntime jsRuntime;

        //private UserRegistrationDto registrationDto = new UserRegistrationDto();
        //---------------------------------------------------------------------------------------------------------//
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //---------------------------------------------------------------------------------------------------------//
        [Authorize(Roles= "Admin")]
        [HttpPost("AddRole")]
        public async Task<ActionResult<RegistrationResponseDto>> AddRoleToUser(string userID,string role)
        {
            var result = await _userService.AddRoleToUser(userID, role);
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

        [Authorize(Roles = "Admin")]
        [HttpPost("AddUser")]
        public async Task AddUser(UserDto user)
        {
            Console.WriteLine("//---------------------------------------------------------------------------------------------------------//");
            Console.WriteLine("Gets called to add a user");
            Console.WriteLine("//---------------------------------------------------------------------------------------------------------//");
            //try
            //{
            //IdentityResult identityResult = 
            await _userService.RegisterUser(user);
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //   // await jsRuntime.InvokeAsync<string>("Alert", e.ToString());               
            //}
         
        }
    }
    //---------------------------------------------------------------------------------------------------------------//

}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
