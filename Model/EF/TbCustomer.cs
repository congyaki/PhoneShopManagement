using System;
using System.Collections.Generic;

namespace Model.EF
{
    public partial class TbCustomer
    {
        public TbCustomer()
        {
            TbCustomerHistories = new HashSet<TbCustomerHistory>();
            TbOrders = new HashSet<TbOrder>();
        }

        public int CId { get; set; }
        public string CName { get; set; } = null!;
        public string CAddress { get; set; } = null!;
        public string CEmail { get; set; } = null!;
        public string CPhone { get; set; } = null!;

        public virtual ICollection<TbCustomerHistory> TbCustomerHistories { get; set; }
        public virtual ICollection<TbOrder> TbOrders { get; set; }
    }
}
