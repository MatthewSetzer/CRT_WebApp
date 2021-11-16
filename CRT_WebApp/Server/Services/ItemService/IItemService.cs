using CRT_WebApp.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRT_WebApp.Server.Services.ItemService
{
    //---------------------------------------------------------------------------------------------------------//
    /// <summary>
    /// Interface for Itemservice
    /// </summary>
    public interface IItemService
    {
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds an item of type ItemModel to the database
        /// </summary>
        /// <param name="item">The item to be added to the database</param>
        Task<bool> AddItem(ItemModel item);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds a list of items to database
        /// </summary>
        /// <param name="items">The list of items to be added</param>
        Task AddMultipleItems(List<ItemModel> items);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets all the items from database
        /// </summary>
        /// <returns>A list of all the items</returns>
        Task<List<ItemModel>> GetItems();
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Deletes item from database
        /// </summary>
        /// <param name="item">The item to be deleted</param>
        /// <returns>Returns true on successful delete operation</returns>
        Task<bool> DeleteItem(ItemModel item);
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
