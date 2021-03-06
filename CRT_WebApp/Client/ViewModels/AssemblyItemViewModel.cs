using System;
using System.ComponentModel.DataAnnotations;

namespace CRT_WebApp.Client.ViewModels
{
    //---------------------------------------------------------------------------------------------------------//
    public class AssemblyItemViewModel
    {
        [Required]
        [StringLength(100, MinimumLength =3)]
        public string Description { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public double Quantity { get; set; }

        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public double Rate { get; set; }
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//