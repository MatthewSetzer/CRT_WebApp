using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
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
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
