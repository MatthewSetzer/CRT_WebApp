using CRT_WebApp.Shared.DTO;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
namespace CRT_WebApp.Server.Services.UserService
{
    //---------------------------------------------------------------------------------------------------------//
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds a user to a role
        /// </summary>
        /// <param name="userID">The user id of the user to be added to a role</param>
        /// <param name="role">The role</param>
        /// <returns>the result from identity</returns>
        public async Task<IdentityResult> AddRoleToUser(string userID, string role)
        {
            var user = await _userManager.FindByIdAsync(userID);
            
            var result = await _userManager.AddToRoleAsync(user, role);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Registers a user using UserRegistrationDto, returns the result
        /// </summary>
        /// <param name="user">The user to be registered</param>
        /// <returns>The result from idenitity (success errors etc)</returns>
        public async Task<IdentityResult> RegisterUser(UserRegistrationDto user)
        {
            var newUser = new IdentityUser { UserName = user.Email, Email = user.Email };

            var result = await _userManager.CreateAsync(newUser, user.Password);
            return result;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Removes a role from the user
        /// </summary>
        /// <param name="userID">The id of the user to be removed from the role</param>
        /// <param name="role">The role to be removed from</param>
        /// <returns>Result of task</returns>
        public async Task<IdentityResult> RemoveRoleFromUser(string userID, string role)
        {
            var user = await _userManager.FindByIdAsync(userID);
            var result = await _userManager.RemoveFromRoleAsync(user,role);
            return result;
        }
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
