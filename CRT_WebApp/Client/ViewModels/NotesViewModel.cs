using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRT_WebApp.Client.ViewModels
{
    public class NotesViewModel
    {
        public int Id { get; set; }
        [Required]
        public string NoteHeader { get; set; }
       
        [Required]
        public string NoteContent { get; set; }

    }
}
