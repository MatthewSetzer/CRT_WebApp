using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace CRT_WebApp.Client.Services.QuoteService
{
    public class QuoteService : IQuoteService
    {
        private readonly HttpClient _http;
        public QuoteService(HttpClient http)
        {
            _http = http;
        }

        public event Action OnChange;
        public List<QuoteModel> Quotes { get; set; } = new List<QuoteModel>();
     
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Makes API call to create a Quote
        /// </summary>
        /// <param name="quote">The Quote to be created on the DB</param>
        public async Task AddQuote(QuoteModel quote)
        {
            await _http.PostAsJsonAsync("api/Quote/CreateQuote", quote);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Makes API Call and gets Quote From DB
        /// </summary>
        /// <param name="id">The ID of the Quote that should be fetched</param>
        /// <returns>The Quote matching the ID</returns>
        public async Task<QuoteModel> GetQuoteByID(int id)
        {
            return await _http.GetFromJsonAsync<QuoteModel>($"api/Quote/QuoteByID/{id}");
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// API call that loads all Quotes associated with user ID. 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public async Task LoadQuotes(string UserID)
        {
            if(UserID != null)
            {
                Quotes = await _http.GetFromJsonAsync<List<QuoteModel>>($"api/QuotesByUser/{UserID}");
                //We can use this to call other methods as soon as this loads completely. 
                OnChange.Invoke();
            }

        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Makes API Call that gets all quotes from DB. 
        /// </summary>
        public async Task LoadAllQuotes()
        {
            Quotes = await _http.GetFromJsonAsync<List<QuoteModel>>("api/Quote/RetrieveQuotes");
            //We can use this to call other methods as soon as this loads completely. 
            OnChange.Invoke();
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// API call that gets all quotes
        /// </summary>
        /// <returns></returns>
        public async Task<List<QuoteModel>> GetAllQuotes()
        {
            return await _http.GetFromJsonAsync<List<QuoteModel>>("api/Quote/RetrieveQuotes");
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// API call that "soft" deletes a quote
        /// </summary>
        /// <param name="quoteModel"></param>
        /// <returns></returns>
        public async Task SoftDeleteQuoteByID(QuoteModel quoteModel)
        {
            await _http.PostAsJsonAsync("api/Quote/SoftDelete", quoteModel);
            OnChange.Invoke();
        }

        /// <summary>
        /// API call to delete entire quote
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteQuote(QuoteModel quote)
        {
            await _http.PostAsJsonAsync("api/Quote/DeleteQuote", quote);
        }

    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
