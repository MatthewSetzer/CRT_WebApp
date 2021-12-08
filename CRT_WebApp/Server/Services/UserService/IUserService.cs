using CRT_WebApp.Server.Models;
using CRT_WebApp.Shared.DTO;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRT_WebApp.Server.Services.UserService
{
    //---------------------------------------------------------------------------------------------------------//
    public interface IUserService
    {
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Registers a new user using the UserResgistrationDto
        /// </summary>
        /// <param name="user">The user to register</param>
        Task RegisterUser(UserModel user);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Changes the user's role
        /// </summary>
        /// <param name="userID">The user whose role should be changed</param>
        /// <param name="role">The role to be changed to</param>
        Task<IdentityResult> AddRoleToUser(string userID, string role);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Removes a user from a role
        /// </summary>
        /// <param name="userID">The id of the user to be removed from a role</param>
        /// <param name="role">The role to be removed from</param>
        Task<IdentityResult> RemoveRoleFromUser(string userID, string role);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets all registered users
        /// </summary>
        /// <returns>A list of all registered users</returns>
        Task<List<ApplicationUser>> GetAllUsers();

        /// <summary>
        /// Deletes a user account from the database using its unique user ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        Task DeleteUser(string userID);

    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//