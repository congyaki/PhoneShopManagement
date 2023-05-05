using System;
using System.Collections.Generic;

namespace PhoneShopManagement.Areas.Admin.Models
{
    public partial class TbEmployeePermission
    {
        public int EId { get; set; }
        public string ETableName { get; set; } = null!;
        public bool EReadPermission { get; set; }
        public bool EWritePermission { get; set; }

        public virtual TbEmployee EIdNavigation { get; set; } = null!;
    }
}
