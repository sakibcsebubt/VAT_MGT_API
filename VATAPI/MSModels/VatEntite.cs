using System;
using System.Collections.Generic;

#nullable disable

namespace VATAPI.MSModels
{
    public partial class VatEntite
    {
        public int EntityId { get; set; }
        public string Tagid { get; set; }
        public string Tagdesc { get; set; }
        public string Tagfor { get; set; }
        public int Sortid { get; set; }
        public DateTime Rowtime { get; set; }
    }
}
