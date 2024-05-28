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
        [DisplayName("ID")]
        public int CusId { get; set; }
        [DisplayName("Tên")]
        public string CusName { get; set; }
        [DisplayName("Địa Chỉ")]
        public string CusAddress { get; set; }
        [DisplayName("Email")]
        public string CusEmail { get; set; }
        [DisplayName("SĐT")]
        public string CusPhone { get; set; }

        public List<Order>? OrderList { get; set; }
    }
}
