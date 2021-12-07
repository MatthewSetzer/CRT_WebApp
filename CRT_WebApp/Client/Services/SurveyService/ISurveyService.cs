using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRT_WebApp.Client.Services.SurveyService
{
    //---------------------------------------------------------------------------------------------------------//
    /// <summary>
    /// Survey Service Interface
    /// </summary>
    public interface ISurveyService
    {
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Register events to be invoked when "survey" list have been loaded/modified
        /// Survey is a quote whose quote state is set to false
        /// </summary>
        event Action OnChange;
        /// <summary>
        /// Current "Surveys"
        /// </summary>
        public List<QuoteModel> Surveys { get; set; }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Loads all the "surveys" into the list 
        /// </summary>
        Task LoadAllSurveys();
        //---------------------------------------------------------------------------------------------------------//

    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
