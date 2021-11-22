using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRT_WebApp.Client.Services.NotesService
{
    //---------------------------------------------------------------------------------------------------------//
    public class NotesService : INotesService
    {
        //---------------------------------------------------------------------------------------------------------//
        public List<NoteModel> Notes { get; set ; } = new List<NoteModel>();
        //---------------------------------------------------------------------------------------------------------//
        public event Action OnChange;
        //---------------------------------------------------------------------------------------------------------//
        public void AddNoteToList(NoteModel note)
        {
            Notes.Add(note);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds a range of notes to the notes list
        /// </summary>
        /// <param name="notesToAdd">The list of notes to be added</param>
        public void AddRangeOfNotesToList(List<NoteModel> notesToAdd)
        {
            Notes.AddRange(notesToAdd);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets a note from the list using index
        /// </summary>
        /// <param name="index">The index of the note on the list</param>
        /// <returns>Returns the note if it has index otherwise it returns null</returns>
        public NoteModel GetNoteFromListByIndex(int index)
        {
            try { return Notes[index]; }
            catch { return null; }
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets the note whose header matches the name provided
        /// </summary>
        /// <param name="name">The header name of the note that is looked for</param>
        /// <returns>A note matching the criteria</returns>
        public NoteModel GetNoteFromListByName(string name)
        {
            return Notes.Where(n=>n.NoteHeader.Contains(name)).FirstOrDefault();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets all the current notes in the service
        /// </summary>
        /// <returns></returns>
        public List<NoteModel> GetNotesFromList()
        {
            return Notes;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Removes the note from the service
        /// </summary>
        /// <param name="note">The note to be removed</param>
        public void RemoveNoteFromList(NoteModel note)
        {
            Notes.Remove(note);
        }
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
