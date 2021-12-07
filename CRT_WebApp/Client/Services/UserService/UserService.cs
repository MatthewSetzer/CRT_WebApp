using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Authorization;
using CRT_WebApp.Shared.DTO;
using Microsoft.JSInterop;

namespace CRT_WebApp.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        public UserService(HttpClient http)
        {
            _http = http;
        }
        public List<IdentityUser> Users { get; set; } = new List<IdentityUser>();

        public event Action OnChange;

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
        /// <summary>
        /// Loads up all users
        /// </summary>
        /// <returns>A list of users</returns>
        public async Task LoadAllUsers()
        {
            Users = await _http.GetFromJsonAsync < List<IdentityUser>>("api/User/GetUsers");
            OnChange.Invoke();
        }

        public async Task RegisterUser(UserModel user)
        {
            await _http.PostAsJsonAsync("api/User/AddUser", user);
        }

        public async Task AddRoleToUser(string userID, string roleID)
        {
            UserRole userRole = new UserRole(userID, roleID); //data being fed here correctly
            //Console.WriteLine("CLIENT ADD ROLE TO USER"+Environment.NewLine+"userID: "+userRole.UserID+Environment.NewLine+"roleID: "+userRole.RoleID);
            await _http.PostAsJsonAsync("api/User/AddRole", userRole);
        }

        public async Task RemoveRoleFromUser(string userID, string roleID)
        {
            UserRole userRole = new UserRole(userID, roleID);
            await _http.PostAsJsonAsync("api/User/RemoveRole", userRole);
        }

        public async Task DeleteUser(string userID)
        {
            //Uri address = new Uri(_http.BaseAddress, "api/User/DeleteUser");
            //await _http.DeleteAsync(address);
        }
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
