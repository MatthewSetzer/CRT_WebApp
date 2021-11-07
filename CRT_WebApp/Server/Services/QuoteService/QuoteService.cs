using CRT_WebApp.Server.Data;
using CRT_WebApp.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRT_WebApp.Server.Services.QuoteService
{
    //---------------------------------------------------------------------------------------------------------//
    /// <summary>
    /// QuoteService implementation
    /// </summary>
    class QuoteService:IQuoteService
    {
        ApplicationDbContext _context;

        public QuoteService(ApplicationDbContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Creates a quote in DB
        /// </summary>
        /// <param name="model">The quote object to be stored in the DB</param>
        /// <returns></returns>
        public async Task CreateQuote(QuoteModel model)
        {
            _context.Quotes.Add(model);
            await _context.SaveChangesAsync();
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets a list of non 'deleted' Quotes from DB
        /// </summary>
        /// <returns>A list of type Quote.</returns>
        public async Task<List<QuoteModel>> GetQuotes()
        {
            return await _context.Quotes.Where(q => q.IsDeleted == false).ToListAsync();
        }

        //---------------------------------------------------------------------------------------------------------//
        //TODO implement GetQuotesByUser function
        public Task<List<QuoteModel>> GetQuotesByUser(string userID)
        {
            throw new NotImplementedException();
        }
        //---------------------------------------------------------------------------------------------------------//
        //TODO implement SoftDeleteQuote function
        public Task SoftDeleteQuote(int quoteID)
        {
            throw new NotImplementedException();
        }

        //---------------------------------------------------------------------------------------------------------//
        //TODO implement DeleteQuote function
        public Task DeleteQuote(int quoteID)
        {
            throw new NotImplementedException();
        }

        //---------------------------------------------------------------------------------------------------------//
        //TODO implement FindQuoteByID function
        public Task<QuoteModel> FindQuoteByID(int quoteID)
        {
            throw new NotImplementedException();
        }

        //Not async;Also its bad to try and format data's representation in the back end.
        //We dont want to make seperate calls everytime we want to retrieve data in a different format right???
        //public IEnumerable<QuoteModel> GetQuotes()
        //{
        //    return _context.Quotes.ToList().Select(x => new QuoteModel
        //    {
        //        QuoteTitle = x.QuoteTitle,
        //        QuoteUser= x.QuoteUser,
        //        QuoteDate = x.QuoteDate,
        //        QuoteState = x.QuoteState,
        //        IsDeleted = x.IsDeleted,
        //        Total = x.Total
        //    });
        //}


    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
