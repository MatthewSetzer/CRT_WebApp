using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRT_WebApp.Server.Services.QuoteService
{
    //---------------------------------------------------------------------------------------------------------//
    /// <summary>
    /// Interface for quote service
    /// </summary>
    public interface IQuoteService
    {
        /// <summary>
        /// Gets Quotes from database
        /// </summary>
        /// <returns>A list of quotes</returns>
        Task<List<QuoteModel>> GetQuotes();
        /// <summary>
        /// Creates a quote in database
        /// </summary>
        /// <param name="model">The Quote to be created in the database</param>
        Task CreateQuote(QuoteModel model);

    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
