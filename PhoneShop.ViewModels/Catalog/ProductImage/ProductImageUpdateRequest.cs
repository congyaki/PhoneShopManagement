using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.ViewModels.Catalog.ProductImage
{
    public class ProductImageUpdateRequest
    {
        public int PIId { get; set; }
        public string PICaption { get; set; }
        public bool PIIsDefault { get; set; }
        public int PISortOrder { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
