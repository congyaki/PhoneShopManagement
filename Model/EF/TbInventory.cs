using System;
using System.Collections.Generic;

namespace Model.EF
{
    public partial class TbInventory
    {
        public int PId { get; set; }
        public int? PQuantity { get; set; }

        public virtual TbProduct PIdNavigation { get; set; } = null!;
    }
}
