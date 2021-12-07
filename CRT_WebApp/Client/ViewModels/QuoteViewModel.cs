using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRT_WebApp.Client.ViewModels
{
    public class QuoteViewModel
    {
        public int Id { get; set; }
        [Required]
        public string QuoteTitle { get; set; }
        [Required]
        public bool QuoteState { get; set; }
        [Required]
        public DateTime QuoteDate { get; set; }
        [Required]
        public string QuoteUser { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        public string GetFormattedTotal() => Total.ToString("0.00");

    }
}
