using System;
using System.Collections.Generic;

#nullable disable

namespace VATAPI.PgModels
{
    public partial class LPurchasedtl
    {
        public int Id { get; set; }
        public int Itemid { get; set; }
        public int LPurchaseid { get; set; }
        public decimal Qty { get; set; }
        public decimal UPrice { get; set; }
        public decimal Vat { get; set; }
        public decimal Sd { get; set; }
        public decimal Ait { get; set; }
        public decimal UPriceS { get; set; }
        public decimal VatS { get; set; }
        public decimal SdS { get; set; }
        public decimal AitS { get; set; }
        public string Remarks { get; set; }
        public bool Isvds { get; set; }
        public decimal VdsAmt { get; set; }
        public bool Isexemted { get; set; }
        public bool Isrebatable { get; set; }
        public bool Iszerorate { get; set; }
        public bool Isfixedvat { get; set; }
        public bool Ismrp { get; set; }
        public bool Isreduce { get; set; }
    }
}
