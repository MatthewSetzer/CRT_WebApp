﻿using CRT_WebApp.Server.Data;
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
    class QuoteService : IQuoteService
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
        /// <summary>
        /// Retrieves quotes by userID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task<List<QuoteModel>> GetQuotesByUser(string userID)
        {
            return await _context.Quotes.Where(q => q.QuoteUser == userID).ToListAsync();
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Soft delete a Quote by ID. 
        /// </summary>
        /// <param name="quoteID"></param>
        /// <returns></returns>
        public async Task SoftDeleteQuote(int quoteID)
        {
            var quote = _context.Quotes.FirstOrDefault(x => x.Id == quoteID);
            quote.IsDeleted = true;
            _context.Quotes.Update(quote);
            await _context.SaveChangesAsync();
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Deletes the quote
        /// </summary>
        /// <param name="quoteID"></param>
        /// <returns></returns>
        public async Task DeleteQuote(int quoteID)
        {
            var quote = _context.Quotes.FirstOrDefault(x => x.Id == quoteID);
            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Finds the quote from quoteID
        /// </summary>
        /// <param name="quoteID"></param>
        /// <returns></returns>
        public async Task<QuoteModel> FindQuoteByID(int quoteID)
        {
            return await _context.Quotes.Where(x => x.Id == quoteID).FirstOrDefaultAsync();
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Updates quote with new QuoteModel
        /// </summary>
        /// <param name="quote"></param>
        /// <returns></returns>
        public async Task<int> UpdateQuote(QuoteModel quote)
        {
            
            _context.Update(quote);
            return await _context.SaveChangesAsync();
        }
        //---------------------------------------------------------------------------------------------------------//
        public async Task EnableQuote(QuoteModel quote)
        {
            quote.QuoteState = true;
            _context.Update(quote);
            await _context.SaveChangesAsync();
        }
        //---------------------------------------------------------------------------------------------------------//
        public async Task DisableQuote(QuoteModel quote)
        {
            quote.QuoteState = false;
            _context.Update(quote);
            await _context.SaveChangesAsync();
              
        }
        

    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//