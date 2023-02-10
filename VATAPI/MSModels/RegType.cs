using System;
using System.Collections.Generic;

#nullable disable

namespace VATAPI.MSModels
{
    public partial class RegType
    {
        public RegType()
        {
            Sirinfs = new HashSet<Sirinf>();
        }

        public int RegTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Sirinf> Sirinfs { get; set; }
    }
}
