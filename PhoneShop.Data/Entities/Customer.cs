using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.Data.Entities
{
    public class Customer
    {
        public int CusId { get; set; }
        public string CusName { get; set; }
        public string CusAddress { get; set; }
        public string CusEmail { get; set; }
        public string CusPhone { get; set; }

        public List<Order>? OrderList { get; set; }
    }
}
