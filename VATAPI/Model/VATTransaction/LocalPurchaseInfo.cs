using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VATAPI.Model.VATTransaction
{
    public class LocalPurchaseInfo
    {
        public int PId { get; set; }
        public int Regtypeid { get; set; }
        public int Supplierid { get; set; }
        public int Ctgid { get; set; }
        public string RefChlno { get; set; }
        public DateTime? Chldate { get; set; }
        public DateTime? RcvChldate { get; set; }
        public string RcvScrollno { get; set; }
        public string AgrNo { get; set; }
        public string UDestination { get; set; }
        public string Remarks { get; set; }
        public DateTime Rowtime { get; set; }

        public List<LocalPurchaseDetails> LocalPurchaseDetails { get; set; }
    }
}
