using System;
using System.Collections.Generic;

namespace PhoneShopManagement.Areas.Admin.Models
{
    public partial class TbEmployee
    {
        public int EId { get; set; }
        public string EUserName { get; set; } = null!;
        public string EPassword { get; set; } = null!;
        public string EName { get; set; } = null!;
        public string EAddress { get; set; } = null!;
        public string EPhone { get; set; } = null!;

        public virtual TbEmployeePermission? TbEmployeePermission { get; set; }
    }
}
