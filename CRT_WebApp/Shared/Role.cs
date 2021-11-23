using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT_WebApp.Shared
{
    public enum Role
    {
        [Description("Admin")]
        Admin,
        [Description("Employee")]
        Employee
    }
}
