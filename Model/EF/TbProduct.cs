using System;
using System.Collections.Generic;

namespace Model.EF
{
    public partial class TbProduct
    {
        public TbProduct()
        {
            TbOrderDetails = new HashSet<TbOrderDetail>();
        }

        public int PId { get; set; }
        public string PName { get; set; } = null!;
        public int MId { get; set; }
        public int CId { get; set; }
        public string PDescriptions { get; set; } = null!;
        public string PColor { get; set; } = null!;
        public string PStorage { get; set; } = null!;
        public string PRam { get; set; } = null!;
        public string PScreenSize { get; set; } = null!;
        public string PResolution { get; set; } = null!;
        public string POperatingSystem { get; set; } = null!;
        public string PCamera { get; set; } = null!;
        public string PBatteryCapacity { get; set; } = null!;
        public string PConnectivity { get; set; } = null!;
        public string PWeights { get; set; } = null!;
        public string PDimensions { get; set; } = null!;
        public int PPrice { get; set; }
        public string PImages { get; set; } = null!;

        public virtual TbCategory CIdNavigation { get; set; } = null!;
        public virtual TbManufacturer MIdNavigation { get; set; } = null!;
        public virtual TbInventory? TbInventory { get; set; }
        public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; }
    }
}
