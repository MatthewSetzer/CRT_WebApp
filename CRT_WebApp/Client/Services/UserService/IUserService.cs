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
    }
}
