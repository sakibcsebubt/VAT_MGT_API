using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATAPI.Model.ViewModel
{
    public class VatEntityManpower
    {

        public class SignInInfo
        {
            public SignInInfo()
            {

            }
            public byte[] hcfullsign { get; set; }
            public byte[] hcinisign { get; set; }
            public byte[] hcphoto { get; set; }
            public string hcidcardno { get; set; }
            public string hcgender { get; set; }
            public string hcsupcode { get; set; }
            public DateTime hcjoindat { get; set; }
            public string hcwrkdept { get; set; }
            public string sessionID { get; set; }
            public string hcwrkcomp { get; set; }
            public string hcdsgcod { get; set; }
            public string hcname { get; set; }
            public string hcnamesub { get; set; }
            public string userrmrk { get; set; }
            [DisplayName("Password :")]
            [Required(ErrorMessage = "Password Required!!")]
            public string LOG_PASS { get; set; }
            public string LOG_ID { get; set; }
            [DisplayName("User Name :")]
            [Required(ErrorMessage = "User Name Required!!")]
            public string hccode { get; set; }
            public string comcod { get; set; }
            public string hcappcomp { get; set; }
            public string terminalID { get; set; }
        }
    }
}
