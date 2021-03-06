using Blazored.Modal;
using Blazored.Toast;
using CRT_WebApp.Client.Services.AssemblyItemService;
using CRT_WebApp.Client.Services.ItemService;
using CRT_WebApp.Client.Services.NotesService;
using CRT_WebApp.Client.Services.QuoteService;
using CRT_WebApp.Client.Services.SubGroupService;
using CRT_WebApp.Client.Services.UserService;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRT_WebApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("CRT_WebApp.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CRT_WebApp.ServerAPI"));
            builder.Services.AddBlazoredModal();
            builder.Services.AddBlazoredToast();
            builder.Services.AddApiAuthorization();
            //TODO: Add your CLIENT services here
            builder.Services.AddScoped<IQuoteService, QuoteService>();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<ISubGroupService, SubGroupService>();
            builder.Services.AddScoped<INotesService, NotesService>();
            builder.Services.AddScoped<IAssemblyItemService, AssemblyItemService>();
            builder.Services.AddScoped<IUserService, UserService>();
            
            await builder.Build().RunAsync();
        }
    }
}
