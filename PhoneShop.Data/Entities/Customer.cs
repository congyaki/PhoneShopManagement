using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.Data.Entities
{
    public class Customer
    {
        [DisplayName("Customer ID")]
        public int CusId { get; set; }
        [DisplayName("Customer Name")]
        public string CusName { get; set; }
        [DisplayName("Address")]
        public string CusAddress { get; set; }
        [DisplayName("Email")]
        public string CusEmail { get; set; }
        [DisplayName("Phone")]
        public string CusPhone { get; set; }

        public List<Order>? OrderList { get; set; }
    }
}
