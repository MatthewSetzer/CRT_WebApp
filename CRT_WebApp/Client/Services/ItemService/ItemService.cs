using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace CRT_WebApp.Client.Services.ItemService
{
    //---------------------------------------------------------------------------------------------------------//
    public class ItemService : IItemService
    {
        private readonly HttpClient _http;

        public ItemService(HttpClient http)
        {
            _http = http;
        }

       public List<ItemModel> Items { get; set; } = new List<ItemModel>();

        public event Action OnChange;
        //---------------------------------------------------------------------------------------------------------//
        public async Task AddItem(ItemModel itemModel)
        {
            await _http.PostAsJsonAsync("api/Item/AddItem",itemModel);
        }
        //---------------------------------------------------------------------------------------------------------//
        public Task<List<ItemModel>> GetItems()
        {
            throw new NotImplementedException();
        }
        //---------------------------------------------------------------------------------------------------------//
        public async Task LoadItems()
        {
            Items = await _http.GetFromJsonAsync<List<ItemModel>>("api/Item/GetAllItems");
            OnChange.Invoke();
        }

    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
