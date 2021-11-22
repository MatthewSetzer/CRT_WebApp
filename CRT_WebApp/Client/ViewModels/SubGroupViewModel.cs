using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRT_WebApp.Client.ViewModels
{
    public class SubGroupViewModel
    {
        public int Id { get; set; }
        [Required]
        public string SubGroupTitle { get; set; }
        /*[Required]
        public List<AssemblyItemModel> ListOfItems { get; set; }*/
        [Required]
        public double SubTotal { get; set; }

        public string GetFormattedSubTotal() => SubTotal.ToString("0.00");
    }
}
