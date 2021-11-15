using CRT_WebApp.Server.Services.ItemService;
using CRT_WebApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRT_WebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// API route for getting all items from database
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllItems")]
        public async Task<ActionResult<List<ItemModel>>>GetAllItems()
        {
            return Ok( await _itemService.GetItems());
        }
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
