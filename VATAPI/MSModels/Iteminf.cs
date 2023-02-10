using System;
using System.Collections.Generic;

#nullable disable

namespace VATAPI.MSModels
{
    public partial class Iteminf
    {
        public int Itemid { get; set; }
        public string ItemName { get; set; }
        public int? UnitId { get; set; }
        public string Hscode { get; set; }
        public string Skucode { get; set; }
        public bool Exempted { get; set; }
        public bool Reduced { get; set; }
        public bool Fixedvat { get; set; }
        public bool Expdatereq { get; set; }
        public bool Zerorate { get; set; }
        public bool Mrp { get; set; }
        public bool Rebatable { get; set; }
        public bool Vds { get; set; }
        public string Prtype { get; set; }
        public bool Iaabu { get; set; }
        public bool Iapd { get; set; }
        public bool Iahcs { get; set; }
        public DateTime Rowtime { get; set; }
    }
}
