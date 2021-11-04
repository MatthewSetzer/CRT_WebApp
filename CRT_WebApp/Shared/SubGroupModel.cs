using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRT_WebApp.Shared
{
    public class SubGroupModel
    {
        public int Id { get; set; }
        public string SubGroupTitle { get; set; }
        public List<AssemblyItemModel> ListOfItems { get; set; }
        public double SubTotal { get; set; }
    }
}
