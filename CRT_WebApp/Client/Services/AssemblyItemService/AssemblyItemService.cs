using CRT_WebApp.Client.Services.SubGroupService;
using CRT_WebApp.Shared;
using System;
using System.Collections.Generic;

namespace CRT_WebApp.Client.Services.AssemblyItemService
{
    //---------------------------------------------------------------------------------------------------------//
    public class AssemblyItemService : IAssemblyItemService
    {
        //---------------------------------------------------------------------------------------------------------//
        ISubGroupService _subGroupService;
        public AssemblyItemService( ISubGroupService subGroupService)
        {
            _subGroupService = subGroupService;
        }
        //---------------------------------------------------------------------------------------------------------//
        public List<AssemblyItemModel> AssemblyItems { get ; set; } = new List<AssemblyItemModel>();
        //---------------------------------------------------------------------------------------------------------//
        public event Action OnChange;
        //---------------------------------------------------------------------------------------------------------//
        public void AddAssemblyItemRangeToList(List<AssemblyItemModel> list)
        {
            AssemblyItems.AddRange(list);
            OnChange.Invoke();
        }
        //---------------------------------------------------------------------------------------------------------//
        public void AddAssemblyItemToList(AssemblyItemModel item)
        {
            AssemblyItems.Add(item);
            OnChange.Invoke();
        }
        //---------------------------------------------------------------------------------------------------------//
        public void AddAssemblyListToSubGroup(string Title)
        {
            double subtotal = 0;
            foreach (AssemblyItemModel item in AssemblyItems)
            {
                subtotal += item.Total;
            }
            SubGroupModel subGroupModel = new SubGroupModel() { ListOfItems=AssemblyItems,SubGroupTitle = Title,SubTotal=subtotal };
            _subGroupService.AddSubGroupToList(subGroupModel);
        }
        //---------------------------------------------------------------------------------------------------------//
        public void ClearAssemblyItemList()
        {
            AssemblyItems = new List<AssemblyItemModel>();
            OnChange.Invoke();
        }
        //---------------------------------------------------------------------------------------------------------//
        public void RemoveAssemblyItemFromList(AssemblyItemModel item)
        {
            if(AssemblyItems.Contains(item))
            {
                AssemblyItems.Remove(item);
                OnChange.Invoke();
            }
        }
    }
}
//-------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------//
