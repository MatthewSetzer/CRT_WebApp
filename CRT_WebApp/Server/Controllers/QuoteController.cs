
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

    public class QuoteController : ControllerBase
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
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Update Quote API route, updates a quote in the database using the QuoteService. 
        /// </summary>
        /// <param name="quoteModel"></param>
        [HttpPost]
        public async void UpdateQuote(QuoteModel quoteModel)
        {
            await _quoteService.UpdateQuote(quoteModel);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Hard delete Quote API, permanently deletes a quote using the QuoteService.
        /// </summary>
        /// <param name="quoteModel"></param>
        [HttpPost]
        public async void DeleteQuote(QuoteModel quoteModel)
        {
            await _quoteService.DeleteQuote(quoteModel.Id);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Soft delete Quote API, "soft" deletion of a quote using the QuoteService.
        /// </summary>
        /// <param name="quoteModel"></param>
        [HttpPost]
        public async void SoftDeleteQuote(QuoteModel quoteModel)
        {
            await _quoteService.SoftDeleteQuote(quoteModel.Id);
        }
        //---------------------------------------------------------------------------------------------------------//
        [HttpPost]
        public async void EnableQuote(QuoteModel quoteModel)
        {
            await _quoteService.EnableQuote(quoteModel);
        }
        //---------------------------------------------------------------------------------------------------------//
        [HttpPost]
        public async void DisableQuote(QuoteModel quoteModel)
        {
            await _quoteService.DisableQuote(quoteModel);
        }
            
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
