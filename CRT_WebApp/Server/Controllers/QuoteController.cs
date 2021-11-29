
using CRT_WebApp.Server.Data;
using CRT_WebApp.Server.Services.QuoteService;
using CRT_WebApp.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRT_WebApplication.Server.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]

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
        [HttpGet("RetrieveQuotes")]
        public async Task<ActionResult<List<QuoteModel>>> RetrieveQuotes()
        {
            return Ok(await _quoteService.GetQuotes());
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Create Quote API route, creates a quote in database using the QuoteService
        /// </summary>
        /// <param name="quoteModel">The quote to be created</param>
        [HttpPost("CreateQuote")]
        public async Task CreateQuote(QuoteModel quoteModel)
        {
            await _quoteService.CreateQuote(quoteModel);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Update Quote API route, updates a quote in the database using the QuoteService. 
        /// </summary>
        /// <param name="quoteModel"></param>
        [HttpPost("UpdateQuote")]
        public async Task UpdateQuote(QuoteModel quoteModel)
        {
            await _quoteService.UpdateQuote(quoteModel);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Hard delete Quote API, permanently deletes a quote using the QuoteService.
        /// </summary>
        /// <param name="quoteModel"></param>
        [HttpDelete("DeleteQuote/{id}")]
        public async Task DeleteQuote(int id)
        {
            await _quoteService.DeleteQuote(id);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Soft delete Quote API, "soft" deletion of a quote using the QuoteService.
        /// </summary>
        /// <param name="quoteModel"></param>
        [HttpPost("SoftDelete")]
        public async Task SoftDeleteQuote(QuoteModel quoteModel)
        {
            await _quoteService.SoftDeleteQuote(quoteModel.Id);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Enable quote API, Changes a survey Quote to a normal Quote
        /// </summary>
        /// <param name="quoteModel"></param>
        /// <returns></returns>
        [HttpPost("EnableQuote")]
        public async Task EnableQuote(QuoteModel quoteModel)
        {
            await _quoteService.EnableQuote(quoteModel);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Disable Quote API, changes a normal Quote to a Survey Quote again. 
        /// </summary>
        /// <param name="quoteModel"></param>
        /// <returns></returns>
        [HttpPost("DisableQuote")]
        public async Task DisableQuote(QuoteModel quoteModel)
        {
            await _quoteService.DisableQuote(quoteModel);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets Quotes associated by user ID
        /// </summary>
        /// <param name="UserID">The user ID</param>
        /// <returns>A List of Quotes</returns>
        [HttpGet("QuotesByUser/{UserID}")]
        public async Task<ActionResult<List<QuoteModel>>>GetQuotesByUser(string UserID)
        {
            return Ok(await _quoteService.GetQuotesByUser(UserID));
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Finds a Quote by its ID 
        /// </summary>
        /// <param name="Id">The Quotes ID</param>
        /// <returns>The Quote associated with the ID</returns>
        [HttpGet("QuoteByID/{Id}")]
        public async Task<ActionResult<QuoteModel>> GetQuoteById(int Id)
        {
            return Ok(await _quoteService.FindQuoteByID(Id));
        }

            
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
