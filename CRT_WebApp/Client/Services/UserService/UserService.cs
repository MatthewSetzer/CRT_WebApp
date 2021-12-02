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
        private JSRuntime jsRuntime;

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

        public async Task RegisterUser(UserDto user)
        {
            //try
            //{
            //   HttpResponseMessage responseMessage = await _http.PostAsJsonAsync("api/User/AddUser", user);
            //    //await JSRuntime.InvokeAsync<string>("Alert", responseMessage.ToString());
            //    OnChange.Invoke();
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //    //await jsRuntime.InvokeAsync<string>("Alert", e.ToString());
            //}
            await _http.PostAsJsonAsync("api/User/AddUser", user);
        }

        public async Task AddRoleToUser(string userID, string role)
        {
            
        }

        public async Task RemoveRoleFromUser(string userID, string role)
        {
            
        }
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
