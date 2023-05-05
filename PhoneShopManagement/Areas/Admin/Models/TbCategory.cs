﻿using System;
using System.Collections.Generic;

namespace PhoneShopManagement.Areas.Admin.Models
{
    public partial class TbCategory
    {
        public TbCategory()
        {
            TbProducts = new HashSet<TbProduct>();
        }

        public int CId { get; set; }
        public string CName { get; set; } = null!;

        public virtual ICollection<TbProduct> TbProducts { get; set; }
    }
}
