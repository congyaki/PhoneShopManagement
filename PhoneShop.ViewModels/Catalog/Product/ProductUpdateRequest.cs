﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.ViewModels.Catalog.Product
{
    public class ProductUpdateRequest
    {
        public int PId { get; set; }

        public string PName { get; set; }

        public string PDescription { get; set; }

        public string PColor { get; set; }

        public string PStorage { get; set; }

        public string PRam { get; set; }

        public string PScreenSize { get; set; }

        public string PResolution { get; set; }

        public string POperatingSystem { get; set; }

        public string PCamera { get; set; }

        public string PBatteryCapacity { get; set; }

        public string PConnectivity { get; set; }

        public string PWeight { get; set; }

        public string PDimension { get; set; }

        public IFormFile ThumbnailImage { get; set; }


    }
}
