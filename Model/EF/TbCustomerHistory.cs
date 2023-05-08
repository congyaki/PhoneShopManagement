using System;
using System.Collections.Generic;

namespace Model.EF
{
    public partial class TbCustomerHistory
    {
        public int CId { get; set; }
        public int OId { get; set; }
        public DateTime ChPurchaseDate { get; set; }

        public virtual TbCustomer CIdNavigation { get; set; } = null!;
        public virtual TbOrder OIdNavigation { get; set; } = null!;
    }
}
