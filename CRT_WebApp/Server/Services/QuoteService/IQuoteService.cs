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
        Task DeleteQuoteByID(int quoteID);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Deletes sub group in database using its ID as reference
        /// </summary>
        /// <param name="quoteID">The quotes ID</param>
        Task DeleteSubGroupsByID(int id);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Deletes quote in database using model
        /// </summary>
        /// <param name="model">The model to remove</param>
        Task DeleteQuote(QuoteModel model);

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
        Task UpdateQuote(QuoteModel quote);
        /// <summary>
        /// Updates assembly item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task UpdateAssemblyItem(AssemblyItemModel item);
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
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets all quotes that matches the state
        /// </summary>
        /// <param name="state">The current state of the quote. False = survey; True = Quote</param>
        /// <returns>A list of quote models</returns>
        Task<List<QuoteModel>>GetQuotesByState(bool state);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets all quotes that matches the quote state and UserID
        /// </summary>
        /// <param name="state">The state of the quote. False = Survey; True = Quote</param>
        /// <param name="UserID">The users ID</param>
        /// <returns>A List of Quotes matching the condition</returns>
        Task<List<QuoteModel>> GetQuotesByStateAndUser(bool state,string UserID);
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
