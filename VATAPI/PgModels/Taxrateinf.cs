using System;
using System.Collections.Generic;

#nullable disable

namespace VATAPI.PgModels
{
    public partial class Taxrateinf
    {
        public int RateId { get; set; }
        public DateTime EffectDate { get; set; }
        public int? Ttid { get; set; }
        public int Cd { get; set; }
        public int Rd { get; set; }
        public int Sd { get; set; }
        public int Vat { get; set; }
        public int At { get; set; }
        public int Ait { get; set; }
        public decimal Llimit { get; set; }
        public decimal Ulimit { get; set; }
        public decimal Vatamt { get; set; }
        public decimal Sdamt { get; set; }
        public int Itemid { get; set; }
    }
}
