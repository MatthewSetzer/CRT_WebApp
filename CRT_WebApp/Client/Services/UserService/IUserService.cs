using CRT_WebApp.Shared.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRT_WebApp.Client.Services.UserService
{
    public interface IUserService
    {
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Register events to be invoked when user list have been loaded/modified
        /// Survey is a quote whose quote state is set to false
        /// </summary>
        event Action OnChange;
        /// <summary>
        /// Current users
        /// </summary>
        public List<IdentityUser> Users { get; set; }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Loads all the users into the list 
        /// </summary>
        Task LoadAllUsers();
        //---------------------------------------------------------------------------------------------------------//

        Task RegisterUser(UserDto user);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Changes the user's role
        /// </summary>
        /// <param name="userID">The user whose role should be changed</param>
        /// <param name="role">The role to be changed to</param>
        Task AddRoleToUser(string userID, string role);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Removes a user from a role
        /// </summary>
        /// <param name="userID">The id of the user to be removed from a role</param>
        /// <param name="role">The role to be removed from</param>
        Task RemoveRoleFromUser(string userID, string role);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets all registered users
        /// </summary>
        /// <returns>A list of all registered users</returns>
    }
}
