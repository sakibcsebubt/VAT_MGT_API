using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VATAPI.Model.ViewModel;

namespace VATAPI.Model.General
{
    public class vmEntryTransaction1
    {
        public ASITFunParams.ProcessAccessParams SetParamUpdateVatTransc(string CompCode, string pXml01, string pXml02, string id)
        {
            ASITFunParams.ProcessAccessParams accessParams = new ASITFunParams.ProcessAccessParams();
            accessParams.comCod = CompCode;
            accessParams.ProcID = "UPDATE_VATTRANC_INFO_01";
            accessParams.ProcName = "SP_API_VAT_ENTRY_TRANS_01";
            accessParams.pXml01 = pXml01;
            accessParams.pXml02 = pXml02;
            accessParams.parm01 = id;

            return accessParams;
        }
    }
}
