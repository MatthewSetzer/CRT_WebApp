using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRT_WebApp.Server.Services.QuoteService
{
    //---------------------------------------------------------------------------------------------------------//
    /// <summary>
    /// Interface for quote service for the server
    /// </summary>
    public interface IQuoteService
    {
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets Quotes from database
        /// </summary>
        /// <returns>A list of quotes</returns>
        Task<List<QuoteModel>> GetQuotes();

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Creates a quote in database
        /// </summary>
        /// <param name="model">The Quote to be created in the database</param>
        Task CreateQuote(QuoteModel model);

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets quotes related to a specifc user
        /// </summary>
        /// <returns>A list of quotes</returns>
        Task<List<QuoteModel>> GetQuotesByUser(string userID);

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Deletes quote in database using its ID as reference
        /// </summary>
        /// <param name="quoteID">The quotes ID</param>
        Task DeleteQuote(int quoteID);

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Soft deletes quote by changing its IsDeleted field to true. 
        /// </summary>
        /// <param name="quoteID"></param>
        /// <returns></returns>
        Task SoftDeleteQuote(int quoteID);

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Find a quote from database using a QuoteID
        /// </summary>
        /// <param name="quoteID"></param>
        /// <returns>The quote if found</returns>
        Task<QuoteModel> FindQuoteByID(int quoteID);

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Update quote using QuoteModel
        /// </summary>
        /// <param name="quote"></param>
        /// <returns></returns>
        Task<int> UpdateQuote(QuoteModel quote);

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// "Enables" a Quote, which represents a survey being edited into a quote. 
        /// </summary>
        /// <param name="quote"></param>
        /// <returns></returns>
        Task EnableQuote(QuoteModel quote);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Disables a Quote, essentially reverting it back to a survey. 
        /// </summary>
        /// <param name="quote"></param>
        /// <returns></returns>
        Task DisableQuote(QuoteModel quote);
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
