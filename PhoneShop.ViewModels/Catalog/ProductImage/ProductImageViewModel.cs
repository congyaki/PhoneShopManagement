using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.ViewModels.Catalog.ProductImage
{
    public class ProductImageViewModel
    {
        public int PIId { get; set; }
        public int PId { get; set; }
        public string PIPath { get; set; }
        public string PICaption { get; set; }
        public bool PIIsDefault { get; set; }
        public int PISortOrder { get; set; }
    }
}
