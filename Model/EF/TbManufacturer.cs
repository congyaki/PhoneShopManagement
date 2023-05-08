using System;
using System.Collections.Generic;

namespace Model.EF
{
    public partial class TbManufacturer
    {
        public TbManufacturer()
        {
            TbProducts = new HashSet<TbProduct>();
        }

        public int MId { get; set; }
        public string MName { get; set; } = null!;
        public string MAddress { get; set; } = null!;
        public string MEmail { get; set; } = null!;
        public string MPhone { get; set; } = null!;

        public virtual ICollection<TbProduct> TbProducts { get; set; }
    }
}
