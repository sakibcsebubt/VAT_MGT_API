using System;
using System.Collections.Generic;

#nullable disable

namespace VATAPI.MSModels
{
    public partial class Userinf
    {
        public string Comcod { get; set; }
        public string Hccode { get; set; }
        public string LOG_ID { get; set; }
        public string LOG_PASS { get; set; }
        public string EMP_NAME { get; set; }
        public string Userrmrk { get; set; }
        public byte[] Perdesc { get; set; }
        public long Rowid { get; set; }
        public DateTime Rowtime { get; set; }
    }
}
