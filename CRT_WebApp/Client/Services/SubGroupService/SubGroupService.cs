﻿using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRT_WebApp.Client.Services.SubGroupService
{
    //---------------------------------------------------------------------------------------------------------//
    public class SubGroupService : ISubGroupService
    {
        public List<SubGroupModel> SubGroups { get; set; } = new List<SubGroupModel>();

        public event Action OnChange;

        //---------------------------------------------------------------------------------------------------------//
        public void AddRangeOfSubGroups(IEnumerable<SubGroupModel> subGroups)
        {
            SubGroups.AddRange(subGroups);
            OnChange.Invoke();
        }
        //---------------------------------------------------------------------------------------------------------//
        public void AddSubGroupToList(SubGroupModel subGroup)
        {
            SubGroups.Add(subGroup);
            OnChange.Invoke();
        }
        //---------------------------------------------------------------------------------------------------------//
        public void ClearSubGroupList()
        {
            SubGroups = new List<SubGroupModel>();
            OnChange.Invoke();
        }
        //---------------------------------------------------------------------------------------------------------//
        public List<SubGroupModel> GetSubGroupList()
        {
            return SubGroups;
        }

        //---------------------------------------------------------------------------------------------------------//
        public void RemoveSubGroupFromList(SubGroupModel subGroup)
        {
            if(SubGroups.Contains(subGroup))
            {
                SubGroups.Remove(subGroup);
                OnChange.Invoke();
            }
        }
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//