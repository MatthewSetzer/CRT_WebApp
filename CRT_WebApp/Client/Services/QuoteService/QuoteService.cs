using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using CRT_WebApp.Client.Services.SubGroupService;
namespace CRT_WebApp.Client.Services.QuoteService
{
    public class QuoteService : IQuoteService
    {
        private readonly HttpClient _http;
        private readonly ISubGroupService _subGroupService;
        public QuoteService(HttpClient http, ISubGroupService subGroupService)
        {
            _http = http;
            _subGroupService = subGroupService;
        }

        public event Action OnChange;
        public List<QuoteModel> Quotes { get; set; } = new List<QuoteModel>();
        //---------------------------------------------------------------------------------------------------------//
        public QuoteModel Quote { get; set; } = new QuoteModel();


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
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// API call to delete entire quote
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteQuote(int id)
        {
            await _http.PostAsJsonAsync("api/Quote/DeleteQuote", id);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// "Selects" a quote to be updated, populating the SubGroup service 
        /// </summary>
        /// <param name="quote">The quote that will be modified or changed</param>
        public void SelectQuoteToBeUpdated(QuoteModel quote)
        {
            Quote = quote;
            _subGroupService.AddRangeOfSubGroups(quote.SubGroups);
        }

        /// <summary>
        /// "Selects" a quote to be printed, populating the SubGroup service 
        /// </summary>
        /// <param name="quote"></param>
        public void SelectQuoteToBePrinted(QuoteModel quote)
        {
            Quote = quote;
            _subGroupService.AddRangeOfSubGroups(quote.SubGroups);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Sets the current quote to null
        /// </summary>
        public void ClearCurrentSelectedQuote()
        {
            Quote = null;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Makes an API call to update a quote on the database
        /// </summary>
        /// <param name="quote">The quote with the updated information</param>
        public async Task UpdateQuote(QuoteModel quote)
        {
            await _http.PostAsJsonAsync("api/Quote/UpdateQuote", quote);
        }
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
