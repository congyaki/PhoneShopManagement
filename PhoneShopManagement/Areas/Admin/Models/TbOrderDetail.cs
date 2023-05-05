﻿using System;
using System.Collections.Generic;

namespace PhoneShopManagement.Areas.Admin.Models
{
    public partial class TbOrderDetail
    {
        public int PId { get; set; }
        public int OId { get; set; }
        public int OdQuantity { get; set; }

        public virtual TbOrder OIdNavigation { get; set; } = null!;
        public virtual TbProduct PIdNavigation { get; set; } = null!;
    }
}
