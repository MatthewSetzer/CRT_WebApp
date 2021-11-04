using CRT_WebApp.Server.Data;
using CRT_WebApp.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRT_WebApplication.Server
{
    class QuoteService
    {
        ApplicationDbContext _context;

        public QuoteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateQuote(QuoteModel model)
        {
            _context.Quotes.Add(model);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<QuoteModel> GetQuotes()
        {
            return _context.Quotes.ToList().Select(x => new QuoteModel
            {
                QuoteTitle = x.QuoteTitle,
                QuoteUser= x.QuoteUser,
                QuoteDate = x.QuoteDate,
                QuoteState = x.QuoteState,
                IsDeleted = x.IsDeleted,
                Total = x.Total
            });
        }
    }
}
