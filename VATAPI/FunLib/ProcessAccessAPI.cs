using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VATAPI.DataLib;
using VATAPI.FunLib;

namespace VATAPI.FunLib
{
    public class ProcessAccessAPI
    {
        public static APIProcessAccess processAccess01 = new APIProcessAccess("SQLDBConnection", "API");
        public static DataSet GetDataSet(ProcessAccessParams pap1)
        {
            DataSet ds1 = processAccess01.GetDataSetResult(pap1: pap1);
            string JsonDs1 = JsonConvert.SerializeObject(ds1, Newtonsoft.Json.Formatting.Indented);
            // DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(JsonDs1);
            //return JsonDs1;
            return ds1;
        }

        public static Task<DataSet> GetDataSetAsyncFinal(ProcessAccessParams pap1)
        {
            DataSet ds = new DataSet();
            try
            {
                //     _SqlConnection.Open();
                return Task.Run(() =>
                {
                    DataSet ds1 = processAccess01.GetDataSetResult(pap1: pap1);
                    string JsonDs1 = JsonConvert.SerializeObject(ds1, Newtonsoft.Json.Formatting.Indented);
                    // DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(JsonDs1);
                    //return JsonDs1;
                    return ds1;
                });
            }
            catch (Exception ex)
            {
            }
    
            return null;
        }


    }
}
