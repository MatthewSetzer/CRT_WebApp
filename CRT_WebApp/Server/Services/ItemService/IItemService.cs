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
        /// Adds Item to database
        /// </summary>
        /// <param name="itemModel">The item</param>
        Task AddItem(ItemModel itemModel);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds a list of items to database
        /// </summary>
        /// <param name="itemModels">The list of items to be added</param>
        Task AddMultipleItems(List<ItemModel> itemModels);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets all the items from database
        /// </summary>
        /// <returns>A list of all the items</returns>
        Task<List<ItemModel>> GetItems();

    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
