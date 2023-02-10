using System;
using System.Collections.Generic;

#nullable disable

namespace VATAPI.MSModels
{
    public partial class Sirinf
    {
        public int Sirid { get; set; }
        public int Regtypid { get; set; }
        public string Prtybin { get; set; }
        public string Prtyname { get; set; }
        public string Nid { get; set; }
        public string Busnssinf { get; set; }
        public string Phoneno { get; set; }
        public string Emailaddr { get; set; }
        public string Webaddr { get; set; }
        public string Ownername { get; set; }
        public string Vdsnam { get; set; }
        public string Ultmtdestnation { get; set; }
        public string Prtype { get; set; }
        public string Prtyaddress { get; set; }
        public decimal Crdtlimit { get; set; }
        public string Majorarea { get; set; }
        public string Prtycode { get; set; }
        public bool Isvdsdeducted { get; set; }
        public bool Isexciseduty { get; set; }
        public bool Isdevsurcharge { get; set; }
        public bool Isit { get; set; }
        public bool Ishlthsafety { get; set; }
        public bool Isenvsafety { get; set; }

        public virtual RegType Regtyp { get; set; }
    }
}
