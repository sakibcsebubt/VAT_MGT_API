using VATAPI.Model.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VATAPI.Model;
using VATAPI.Model.VATTransaction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VATAPI.Controllers.VATTransaction
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private static vmEntryTransaction1 vmTran1 = new vmEntryTransaction1();

        private readonly IConfiguration _config;
        public PurchaseController(IConfiguration config)
        {
            _config = config;
            VatServices services = new VatServices(_config);
        }
        // GET: api/<PurchaseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PurchaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PurchaseController>
        [HttpPost]
        public IActionResult Post(LocalPurchaseInfo model)
        {
            List<LocalPurchaseInfo> lpList = new List<LocalPurchaseInfo>();

            lpList.Add(new LocalPurchaseInfo()
            {
                AgrNo = model.AgrNo == null ? "" : model.AgrNo,
                Chldate = model.Chldate == null ? Convert.ToDateTime("1900-01-01") : model.Chldate,
                Ctgid = model.Ctgid,
                PId = model.PId,
                RcvChldate = model.RcvChldate == null ? Convert.ToDateTime("1900-01-01") : model.RcvChldate,
                RcvScrollno = model.RcvScrollno == null ? "" : model.RcvScrollno,
                RefChlno = model.RefChlno == null ? "" : model.RefChlno,
                Regtypeid = model.Regtypeid,
                Remarks = model.Remarks == null ? "" : model.Remarks,
                Supplierid = model.Supplierid,
                UDestination = model.UDestination == null ? "" : model.UDestination,
            });

            string locpurcInfoList = ListToXml.ToXml<List<LocalPurchaseInfo>>(lpList, "ds");
            string locpurcDetailsList = ListToXml.ToXml<List<LocalPurchaseDetails>>(model.LocalPurchaseDetails, "ds");
            var pap1 = vmTran1.SetParamUpdateVatTransc("1001", locpurcInfoList, locpurcDetailsList, "");

            if (pap1 != null)
            {
                try
                {
                    DataSet ds1 = ApiProcessAccess.GetHmsDataSet(pap1);
                    var msg = ds1.Tables[0].Rows[0]["Msg"].ToString().Trim();

                    if (ds1 != null)
                    {
                        return Created("", msg);
                    }
                    else
                    {
                        return BadRequest(msg);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);

                    throw;
                }
            }
            else
            {
                return BadRequest("something went wrong!");
            }
        }

        // PUT api/<PurchaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PurchaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
