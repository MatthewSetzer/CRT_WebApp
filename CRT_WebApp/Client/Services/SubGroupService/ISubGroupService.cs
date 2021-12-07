using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRT_WebApp.Client.Services.SubGroupService
{
    //---------------------------------------------------------------------------------------------------------//
    /// <summary>
    /// Interface for subgroup service for client
    /// </summary>
    public interface ISubGroupService
    {
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Register events to be invoked when subgroup list have been loaded/modified
        /// </summary>
        event Action OnChange;
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Current list of SubGroups items 
        /// </summary>
        List<SubGroupModel> SubGroups { get; set; }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds the Subgroup to the  list
        /// </summary>
        /// <param name="subGroup">The subgroup to be added</param>
        void AddSubGroupToList(SubGroupModel subGroup);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds the Subgroup to the  list from edit button
        /// </summary>
        /// <param name="subGroup">The subgroup to be added</param>
        void AddSubGroupToListFromEdit(SubGroupModel subGroup);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Removes a subgroup from the list
        /// </summary>
        /// <param name="subGroup">The subgroup to be removed</param>
        void RemoveSubGroupFromList(SubGroupModel subGroup);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adds a whole range of subgroups to the current list
        /// </summary>
        /// <param name="subGroups">The list of subgroups to be added</param>
        void AddRangeOfSubGroups(IEnumerable<SubGroupModel> subGroups);
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Clears the subgroup list
        /// </summary>
        void ClearSubGroupList();
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets the current list of subgroup items
        /// </summary>
        /// <returns>A list of subgroups</returns>
        List<SubGroupModel> GetSubGroupList();
        /// <summary>
        /// Gets the grand total for current list of subgroups
        /// </summary>
        /// <returns></returns>
        string GetSubGroupsTotal();
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//