using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.Data.Entities
{
    public class ProductInCategory
    {
        [DisplayName("ID Sản Phẩm")]
        public int PId { get; set; }

        public Product Product { get; set; }

        [DisplayName("ID Danh Mục")]
        public int CId { get; set; }

        public Category Category { get; set; }
    }
}
