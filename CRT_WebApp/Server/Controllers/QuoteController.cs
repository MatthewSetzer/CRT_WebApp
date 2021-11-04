
using CRT_WebApp.Server.Data;
using CRT_WebApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CRT_WebApplication.Server.Controllers
{
    [ApiController]
    [Route("quotes")]
    
    public class QuoteController: ControllerBase
    {
        private ApplicationDbContext _ctx;

        public QuoteController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        public IActionResult CreateQuote(QuoteModel quoteModel)
        {
          return Ok(new QuoteService(_ctx).CreateQuote(quoteModel));      
        }
        
        [HttpGet]
        public IActionResult RetrieveQuotes()
        {
            return Ok(new QuoteService(_ctx).GetQuotes());
        }
    }
}
