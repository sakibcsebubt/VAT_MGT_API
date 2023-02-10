using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VATAPI.Model.ViewModel
{
    public class LoggedUserModel
    {

        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string UserId { get; set; }
        public VatEntityManpower.SignInInfo SignInfos { get; set; }
        public string hcidcardno { get; set; }
        public string hcgender { get; set; }
        public string hcsupcode { get; set; }
        public string hcwrkdept { get; set; }
        public string sessionID { get; set; }
        public string hcname { get; set; }
        public string hcnamesub { get; set; }
        public string userrmrk { get; set; }
        public string LOG_ID { get; set; }
        public string hccode { get; set; }
        public string comcod { get; set; }
        public string terminalID { get; set; }
    }
}
