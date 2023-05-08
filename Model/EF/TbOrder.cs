using System;
using System.Collections.Generic;

namespace Model.EF
{
    public partial class TbOrder
    {
        public TbOrder()
        {
            TbCustomerHistories = new HashSet<TbCustomerHistory>();
            TbOrderDetails = new HashSet<TbOrderDetail>();
        }

        public int OId { get; set; }
        public int? CId { get; set; }
        public DateTime ODate { get; set; }
        public int OStatus { get; set; }

        public virtual TbCustomer? CIdNavigation { get; set; }
        public virtual ICollection<TbCustomerHistory> TbCustomerHistories { get; set; }
        public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; }
    }
}
