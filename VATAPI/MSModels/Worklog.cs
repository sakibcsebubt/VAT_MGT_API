using System;
using System.Collections.Generic;

#nullable disable

namespace VATAPI.MSModels
{
    public partial class Worklog
    {
        public string Comcod { get; set; }
        public long Logsl { get; set; }
        public DateTime Logtime { get; set; }
        public string Logbyid { get; set; }
        public string Logses { get; set; }
        public string Logtrm { get; set; }
        public string Trnnum { get; set; }
        public string Logref { get; set; }
        public string Logdata { get; set; }
    }
}
