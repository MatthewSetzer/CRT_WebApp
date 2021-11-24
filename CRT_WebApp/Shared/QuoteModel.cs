using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRT_WebApp.Shared
{
    public class QuoteModel
    {
        public int Id { get; set; }
        public string QuoteTitle { get; set; }
        public bool QuoteState { get; set; }
        public DateTime QuoteDate { get; set; }
        public string QuoteUser { get; set; }
        public List<SubGroupModel> SubGroups { get; set; }
        public List<ImageModel> Images { get; set; }
        public List<NoteModel> Notes { get; set; }
        public double Total { get; set; }
        public bool IsDeleted { get; set; }

        public string GetFormattedTotalPrice() => Total.ToString("0.00");
    }
}
