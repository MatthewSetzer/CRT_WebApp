
using CRT_WebApp.Server.Data;
using CRT_WebApp.Server.Services.QuoteService;
using CRT_WebApp.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRT_WebApplication.Server.Controllers
{
    //TODO: Might need to change this route to something like "api/[controller]"
    [ApiController]
    [Route("quotes")]
    
    public class QuoteController: ControllerBase
    {

        //---------------------------------------------------------------------------------------------------------//
        //Local variables
        private readonly IQuoteService _quoteService;

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// CTOR with dependencies injected
        /// </summary>
        /// <param name="quoteService">QuoteService dependency injection</param>
        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Retrieve Quotes API route
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<QuoteModel>>> RetrieveQuotes()
        {
            return Ok(await _quoteService.GetQuotes());
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Create Quote API route, creates a quote in database using the QuoteService
        /// </summary>
        /// <param name="quoteModel">The quote to be created</param>
        [HttpPost]
        public async Task CreateQuote(QuoteModel quoteModel)
        {
            await _quoteService.CreateQuote(quoteModel);
        }
            

        //Not async. There is no point in using a service if you end up using the db context in the controller.....
        //We DONT want to create a new instance every time we want to use something that functions like a service.
        //Thats why we inject it as a dependency, so that we can use the same instance of a service(in this case scoped) 
        //for multiple things, without having to create a new one everytime. 
        //Object creation takes a lot of memory!


        //private ApplicationDbContext _ctx;

        //public QuoteController(ApplicationDbContext ctx)
        //{
        //    _ctx = ctx;
        //}

        //[HttpPost]
        //public IActionResult CreateQuote(QuoteModel quoteModel)
        //{
        //  return Ok(new QuoteService(_ctx).CreateQuote(quoteModel));      
        //}
        
        //[HttpGet]
        //public IActionResult RetrieveQuotes()
        //{
        //    return Ok(new QuoteService(_ctx).GetQuotes());
        //}
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
