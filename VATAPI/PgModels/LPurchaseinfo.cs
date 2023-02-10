using System;
using System.Collections.Generic;

#nullable disable

namespace VATAPI.PgModels
{
    public partial class LPurchaseinfo
    {
        public int PId { get; set; }
        public int RegTypeId { get; set; }
        public int SupplierId { get; set; }
        public int Ctgid { get; set; }
        public string RefChlno { get; set; }
        public DateTime? Chldate { get; set; }
        public DateTime? RcvChldate { get; set; }
        public string RcvScrollno { get; set; }
        public string AgrNo { get; set; }
        public string UDestination { get; set; }
        public string Remarks { get; set; }
        public DateTime Rowtime { get; set; }
    }
}
