using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CRT_WebApp.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

using CRT_WebApp.Server.Services.QuoteService;

namespace CRT_WebApp.Server.Controllers
{
    //---------------------------------------------------------------------------------------------------------//
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        //---------------------------------------------------------------------------------------------------------//
        //Local variables
        private readonly IQuoteService _quoteService;
        /// <summary>
        /// CTOR with dependicies injected
        /// </summary>
        /// <param name="quoteService"></param>
        public SurveyController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Retrieve all Surveys API route
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllSurveys")]
        public async Task<ActionResult<List<QuoteModel>>> GetAllSurveys()
        {
            return Ok(await _quoteService.GetQuotesByState(false));
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Retrieve all "surveys" matching user ID API route
        /// </summary>
        /// <param name="UserID">The users ID to fetch surveys from</param>
        /// <returns>A List of "surveys" matching the condition</returns>
        [HttpGet("GetAllSurveysByUser/{UserID}")]
        public async Task<ActionResult<List<QuoteModel>>> GetAllSurveysByUserID(string UserID)
        {
           return Ok(await _quoteService.GetQuotesByStateAndUser(false,UserID));
        }

    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
