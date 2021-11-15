using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRT_WebApp.Client.Services.ItemService
{
    //---------------------------------------------------------------------------------------------------------//
    public interface IItemService
    {
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Register events to be invoked when Items have been loaded/modified
        /// </summary>
        event Action OnChange;
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Current items
        /// </summary>
        public List<ItemModel> Items { get; set; }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Makes an API call to add an item to the database
        /// </summary>
        /// <param name="itemModel">The item to be added</param>
        Task AddItem(ItemModel itemModel);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Makes an API call that retrieves a List of items from the database
        /// </summary>
        /// <returns>A List of items</returns>
        Task<List<ItemModel>> GetItems();
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Makes API call to database and loads up all the items to the list.
        /// </summary>
        Task LoadItems();

    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
