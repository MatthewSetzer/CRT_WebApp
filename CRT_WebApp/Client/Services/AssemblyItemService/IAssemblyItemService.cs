using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;

namespace CRT_WebApp.Client.Services.AssemblyItemService
{
    //---------------------------------------------------------------------------------------------------------//
    public interface IAssemblyItemService
    {
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Register events to be invoked when Assembly item list have been loaded/modified
        /// </summary>
        event Action OnChange;
        //---------------------------------------------------------------------------------------------------------//
        List<AssemblyItemModel> AssemblyItems { get; set; }

        AssemblyItemModel UpdateItem { get; set; }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds assembly item to the list
        /// </summary>
        /// <param name="item">The assembly item to be added</param>
        void AddAssemblyItemToList(AssemblyItemModel item);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Removes an assembly item from the list
        /// </summary>
        /// <param name="item">The item to be removed from the list</param>
        void RemoveAssemblyItemFromList(AssemblyItemModel item);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds a rand of assembly items to the list
        /// </summary>
        /// <param name="list">The list of assembly items to be added to the list</param>
        void AddAssemblyItemRangeToList(List<AssemblyItemModel> list);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Clears the current assembly item list
        /// </summary>
        void ClearAssemblyItemList();
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds the list of assembly items to the subgroup service.
        /// </summary>
        /// <param name="Title">The title of the Subgroup of assembly items</param>
        void AddAssemblyListToSubGroup(string Title);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds the list of assembly items to the subgroup service from edit
        /// </summary>
        /// <param name="Title">The title of the Subgroup of assembly items</param>
        void AddAssemblyListToSubGroupFromEdit(string Title);



    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
