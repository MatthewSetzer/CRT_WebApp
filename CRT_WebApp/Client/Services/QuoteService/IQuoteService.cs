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
        /// A selected quote to use for updates
        /// </summary>
        public QuoteModel Quote { get; set; }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Loads Quotes from DB matching the current user id
        /// </summary>
        /// <param name="UserID">The users id</param>
        /// <returns>A list of quotes</returns>
        Task LoadQuotes(string UserID);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Loads all Quotes from DB
        /// </summary>
        Task LoadAllQuotes();
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
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Deletes quote from the db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteQuote(int id);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Selects the quote to be updated and uses other services to load up the data
        /// </summary>
        /// <param name="quote">The quote that will be edited</param>
        void SelectQuoteToBeUpdated(QuoteModel quote);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Clears the current selected quote
        /// </summary>
        void ClearCurrentSelectedQuote();
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Updates quote on the database 
        /// </summary>
        /// <param name="quote"></param>
        /// <returns></returns>
        Task UpdateQuote(QuoteModel quote);


    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
