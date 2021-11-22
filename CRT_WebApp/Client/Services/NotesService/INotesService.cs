using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;

namespace CRT_WebApp.Client.Services.NotesService
{
    //---------------------------------------------------------------------------------------------------------//
    public interface INotesService
    {
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Register events to be invoked when notes have been loaded/modified
        /// </summary>
        event Action OnChange;
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// List of notes
        /// </summary>
        List<NoteModel> Notes { get; set; }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Add a note to the list
        /// </summary>
        /// <param name="note">The note to be added to the list</param>
        void AddNoteToList(NoteModel note);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Remove the note from the list
        /// </summary>
        /// <param name="note">The note to be removed</param>
        void RemoveNoteFromList(NoteModel note);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets all the notes within the service
        /// </summary>
        /// <returns>A list of notes</returns>
        List<NoteModel> GetNotesFromList();
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds a range of notes to the list
        /// </summary>
        /// <param name="notesToAdd">The list of notes to be added</param>
        void AddRangeOfNotesToList(List<NoteModel> notesToAdd);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets a note from the list by its index
        /// </summary>
        /// <param name="index">The index of the note</param>
        /// <returns>The note if found</returns>
        NoteModel GetNoteFromListByIndex(int index);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets a note from the list by its name
        /// </summary>
        /// <param name="name">The name of the note</param>
        /// <returns>A note</returns>
        NoteModel GetNoteFromListByName(string name);

    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//