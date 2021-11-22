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
        public double Quantity { get; set; }

        [Required]
        public double Rate { get; set; }
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//