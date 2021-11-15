﻿using CRT_WebApp.Server.Data;
using CRT_WebApp.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRT_WebApp.Server.Services.ItemService
{
    //---------------------------------------------------------------------------------------------------------//
    /// <summary>
    /// ItemService implementation
    /// </summary>
    public class ItemService : IItemService
    {
        ApplicationDbContext _context;
        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }


        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Creates a new item
        /// </summary>
        /// <param name="itemModel">The item to be stored in the DB</param>
        public async Task AddItem(ItemModel itemModel)
        {
            _context.Items.Add(itemModel);
            await _context.SaveChangesAsync();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds multiple items to the database
        /// </summary>
        /// <param name="itemModels">The list of items to be added in the database</param>
        public async Task AddMultipleItems(List<ItemModel> itemModels)
        {
            _context.AddRange(itemModels);
            await _context.SaveChangesAsync();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets all the items from database
        /// </summary>
        /// <returns>A list of items</returns>
        public async Task<List<ItemModel>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }
        



    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
