using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATAPI.DataLib;
using VATAPI.FunLib;
using VATAPI.Model;
using VATAPI.Model.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VATAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VatMgtApiController : ControllerBase
    {
        private IConfiguration _config;

        public VatMgtApiController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object pap2)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(pap2.ToString());
                var file1 = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

               // string r = _config.GetConnectionString("TestDB");
                //ProcessAccessParams pap1
                var pap1 = JsonConvert.DeserializeObject<ProcessAccessParams>(file1.ToString());

                var ds1 = ProcessAccessAPI.GetDataSet(pap1: pap1);

                //var result =  ProcessAccessAPI.GetDataSetAsyncFinal(pap1: pap1);
                string JsonDs1 = JsonConvert.SerializeObject(ds1, Newtonsoft.Json.Formatting.Indented);
                //string JsonDs1 = JsonConvert.SerializeObject(ds1, Formatting.Indented);
                JsonDs1 = UtilityFuns.StrCompress(JsonDs1);
                return Created("", JsonDs1);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
