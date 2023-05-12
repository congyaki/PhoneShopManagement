using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.Data.Entities
{
    public class ProductInCategory
    {
        public int PId { get; set; }

        public Product Product { get; set; }

        public int CId { get; set; }

        public Category Category { get; set; }
    }
}
