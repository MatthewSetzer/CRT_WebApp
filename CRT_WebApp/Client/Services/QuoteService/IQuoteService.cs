using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRT_WebApp.Client.Services.QuoteService
{
    public interface IQuoteService
    {
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Register events to be invoked when Quotes have been loaded/modified
        /// </summary>
        event Action OnChange;
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Current Quotes
        /// </summary>
        public List<QuoteModel> Quotes { get; set; }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Loads Quotes from DB
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        Task LoadQuotes(string UserID);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds a quote to DB
        /// </summary>
        /// <param name="quote"></param>
        /// <returns></returns>
        Task AddQuote(QuoteModel quote);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets a quote by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<QuoteModel> GetQuoteByID(int id);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets ALL quotes from DB
        /// </summary>
        /// <returns>A list of all Quotes</returns>
        Task<List<QuoteModel>> GetAllQuotes();
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// "soft" deletes quote from database
        /// </summary>
        /// <param name="id">The id of the Quote to be soft deleted</param>
        Task SoftDeleteQuoteByID(QuoteModel quoteModel);


    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
