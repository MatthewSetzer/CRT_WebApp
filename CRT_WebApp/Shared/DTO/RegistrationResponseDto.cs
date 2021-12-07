using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CRT_WebApp.Shared.DTO
{
    //---------------------------------------------------------------------------------------------------------//
    public class RegistrationResponseDto
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
