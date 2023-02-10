using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VATAPI.Model.ViewModel;

namespace VATAPI.Model.General
{
    public class vmConfigSetup1
    {
        public ASITFunParams.ProcessAccessParams SetParamUpdateItemInf(string CompCode, string pXml01, string itemId)
        {
            ASITFunParams.ProcessAccessParams accessParams = new ASITFunParams.ProcessAccessParams();
            accessParams.comCod = CompCode;
            accessParams.ProcID = "UPDATE_ITEMINFO_01";
            accessParams.ProcName = "SP_API_VAT_ENTRY_TRANS_01";
            accessParams.pXml01 = pXml01;
            accessParams.parm01 = itemId;

            return accessParams;
        }
    }
}
